using Abraham.Prtg;

namespace Abraham.PrtgClientDemo
{
    /// <summary>
    /// Demo of the Nuget package.
    /// Demonstrates how to read all sensors.
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
    internal class Program
    {
        // by default, you PRTG server is reachable on port 8443
        // The sensortree can be found at 
        // If in doubt, you could try accessing https:// YOUR PRTG SERVER:8443/api/table.xml?content=sensortree with postman

        private static string _serverURL = "https:// YOUR PRTG SERVER:8443";
        private static string _username  = "YOUR USERNAME";
        private static string _password  = "YOUR PASSWORD";
        private static PrtgClient _client;

        static void Main()
        {
            Console.WriteLine("Demo for the Nuget package 'Abraham.PrtgClient'");

            #if DEBUG
            _serverURL = File.ReadAllText(@"C:\Credentials\prtgserver_url.txt");
            _username  = File.ReadAllText(@"C:\Credentials\prtgserver_username.txt");
            _password  = File.ReadAllText(@"C:\Credentials\prtgserver_password.txt");
            #endif

            _client = new PrtgClient()
                .UseURL(_serverURL)
                .UsePasshashAuthentication(_username, _password)
                .UseSSLValidationBypass() // remove this later!
                .UseConnectionTimeout(60);

            // read the complete sensor tree (once).
            // you can control with your own code how often you query for updates.
            // you could use my "Abraham.Scheduler" nuget package to read on a regular basis.

            _client.GetSensorTree().GetAwaiter().GetResult();



            Console.WriteLine($"\nPRTG's sensor tree:");
            
            // The PRTG sensor tree is complex and filled with lots of fields.
            // you'll have to find out the structure based on your infrastructure.

            var nodes = _client.GetNodes(_client.SensorTree);
            foreach(var node in nodes)
            {
                if (node.Group is not null)
                { 
                    Console.WriteLine($"Group {node.Group.Name,-20}");

                    foreach (var probeNode in node.Group?.Probenodes)
                        Console.WriteLine($"        ProbeNode {probeNode.Name,-20}");

                    foreach (var group in node.Group.Groups)
                        Console.WriteLine($"        Subgroup {group.Name,-20}");
                }
                Console.WriteLine($"\nNode {node.Name}:\n------------------------------------------");
                if (node.Device is not null)
                {
                    Console.WriteLine($"    Device {node.Device?.Name,-20}:   active: {node.Device?.Active,-5}   status: {node.Device?.StatusRaw}");
                    foreach (var sensor in node.Device.Sensors)
                        Console.WriteLine($"        Sensor {sensor.Name,-20} {sensor.Sensortype,-20} {sensor.Status,-20} {sensor.Statusmessage} {sensor.Lastvalue}");
                }

                Console.WriteLine();
            }
        }
    }
}
