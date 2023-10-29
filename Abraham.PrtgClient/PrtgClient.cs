using Abraham.Prtg.Models;
using RestSharp;
using System.Reflection;
using System.Xml.Serialization;

namespace Abraham.Prtg;

/// <summary>
/// Connect to a PRTG server and read the sensor tree
/// 
/// Author:
/// Oliver Abraham, mail@oliver-abraham.de, https://www.oliver-abraham.de
/// 
/// Source code hosted at: 
/// https://github.com/OliverAbraham/Abraham.PrtgClient
/// 
/// Nuget Package hosted at: 
/// https://www.nuget.org/packages/Abraham.PrtgClient/
/// 
/// </summary>
/// 
public class PrtgClient
{
    #region ------------- Properties ----------------------------------------------------------
    public Models.Prtg? SensorTree { get; private set; }
    #endregion



    #region ------------- Private types -----------------------------------------------------------
    private class PropertyData
    {
        public string Name { get; set; }
        public PropertyInfo PropertyInfo { get; set; }
        public object? Obj { get; set; }

        public PropertyData(string name, PropertyInfo propertyInfo, object? obj)
        {
            Name = name;
            PropertyInfo = propertyInfo;
            Obj = obj;
        }
    }
    #endregion



    #region ------------- Fields ------------------------------------------------------------------
    private string? _url;
    private bool    _bypassSslValidation;
    private bool    _usePasshashAuthentication;
    private string? _userName;
    private string? _password;
    private bool    _useApitokenAuthentication;
    private string? _apiToken;
    private int     _timeoutInSeconds;
    private string? _authentication;
    #endregion



    #region ------------- Init ----------------------------------------------------------------
    public PrtgClient()
    {
        _bypassSslValidation = false;
        _timeoutInSeconds = 30;
    }
    #endregion



    #region ------------- Methods -------------------------------------------------------------
    /// <summary>
    /// Call this method to set a certain full path and filename, for example from command line parameters (args[0])
    /// </summary>
    public PrtgClient UseURL(string url)
    {
        _url = url;
        return this;
    }

    public PrtgClient UsePasshashAuthentication(string username, string password)
    {
        _usePasshashAuthentication = true;
        _userName = username;
        _password = password;
        return this;
    }

    public PrtgClient UseApiTokenAuthentication(string apiToken)
    {
        _useApitokenAuthentication = true;
        _apiToken = apiToken;
        return this;
    }

    public PrtgClient UseConnectionTimeout(int timeoutInSeconds)
    {
        _timeoutInSeconds = timeoutInSeconds;
        return this;
    }

    public PrtgClient UseSSLValidationBypass()
    {
        _bypassSslValidation = true;
        return this;
    }

    public async Task GetSensorTree()
    {
        var client = CreateRestClient();
        var requestUrl = $"{_url}/api/table.xml?content=sensortree";
		
        if (_usePasshashAuthentication || _useApitokenAuthentication)
        {
            if (_authentication is null)
                _authentication = await GetPassHash(client);
            if (_authentication is not null)
                requestUrl += _authentication;
        } 
        
        var request = new RestRequest(requestUrl, Method.Get);
        request.Timeout = _timeoutInSeconds * 1000;

        var response = await client.ExecuteGetAsync(request);

        if (response.StatusCode != System.Net.HttpStatusCode.OK)
            throw new Exception("could not get sensorTree from PRTG server");

        try
		{
            var serializer = new XmlSerializer(typeof(Models.Prtg));
            if (response.Content is not null)
	            using (var reader = new StringReader(response.Content))
	            {
                    var tree = (Models.Prtg?)serializer.Deserialize(reader);
                    if (tree is not null)
	                    SensorTree = tree;
	            }
		}
        catch (Exception)
		{
            throw new Exception("could not deserialize sensorTree data from PRTG server");
		}
    }

    public List<Probenode>? GetNodes(Models.Prtg? sensorTree)
    {
        var nodes = sensorTree?.Sensortree?.Nodes?.Group?.Probenodes?.ToList();
        return nodes;
    }

    public Probenode? GetNodeByName(List<Probenode>? nodes, string name)
    {
        if (nodes is null)
            return null;
        var node = nodes.Where(x => x.Name == name).FirstOrDefault();
        return node;
    }

    public List<Device>? GetDevices(Probenode node)
    {
        if (node.Group is null)
            return new List<Device>();

        var devices = node.Group.Devices;
        return devices;
    }

    public Device? GetDeviceByName(List<Device>? devices, string name)
    {
        return devices?.Where(x => x.Name == name).FirstOrDefault();
    }

    private async Task<string?> GetPassHash(RestClient client)
    {
        string requestUrl = "";
        if (_usePasshashAuthentication)
            requestUrl = $"{_url}/api/getpasshash.htm?username={_userName}&password={_password}";
        if (_useApitokenAuthentication)
            requestUrl = $"{_url}/api/getpasshash.htm?apitoken={_apiToken}";

        var request = new RestRequest(requestUrl, Method.Get);
        request.AddHeader("Content-Type", "application/json");
        request.AddHeader("Accept", "*/*");
        request.AddHeader("User-Agent", "www.nuget.org/packages/Abraham.PrtgClient");
        request.Timeout = _timeoutInSeconds * 1000;

        var response = await client.ExecuteGetAsync(request);
        var passHash = response.Content;
        if (passHash is null)
            return null;
        var authentication = $"&username={_userName}&passhash={passHash}";
        return authentication;
    }

    private RestClient CreateRestClient()
    {
        //bypass ssl validation check by using RestClient object
        var options = new RestClientOptions();
        if (_bypassSslValidation)
            options.RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;

        var client = new RestClient(options);
        return client;
    }
    #endregion
}