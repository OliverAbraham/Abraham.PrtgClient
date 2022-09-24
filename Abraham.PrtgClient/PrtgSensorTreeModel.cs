using System.Xml.Serialization;

namespace Abraham.Prtg.Models;

[XmlRoot(ElementName="usertimezone")]
public class Usertimezone { 

	[XmlElement(ElementName="bias")] 
	public int Bias { get; set; } 

	[XmlElement(ElementName="standardbias")] 
	public int Standardbias { get; set; } 

	[XmlElement(ElementName="daylightbias")] 
	public int Daylightbias { get; set; } 

	[XmlElement(ElementName="standarddatemonth")] 
	public int Standarddatemonth { get; set; } 

	[XmlElement(ElementName="standarddatedayofweek")] 
	public int Standarddatedayofweek { get; set; } 

	[XmlElement(ElementName="standarddateday")] 
	public int Standarddateday { get; set; } 

	[XmlElement(ElementName="standarddatehour")] 
	public int Standarddatehour { get; set; } 

	[XmlElement(ElementName="standarddateminute")] 
	public int Standarddateminute { get; set; } 

	[XmlElement(ElementName="daylightdatemonth")] 
	public int Daylightdatemonth { get; set; } 

	[XmlElement(ElementName="daylightdatedayofweek")] 
	public int Daylightdatedayofweek { get; set; } 

	[XmlElement(ElementName="daylightdateday")] 
	public int Daylightdateday { get; set; } 

	[XmlElement(ElementName="daylightdatehour")] 
	public int Daylightdatehour { get; set; } 

	[XmlElement(ElementName="daylightdateminute")] 
	public int Daylightdateminute { get; set; } 
}

[XmlRoot(ElementName="userdatesettings")]
public class Userdatesettings { 

	[XmlElement(ElementName="shorttimeformat")] 
	public string? Shorttimeformat { get; set; } 

	[XmlElement(ElementName="longtimeformat")] 
	public string? Longtimeformat { get; set; } 

	[XmlElement(ElementName="shortdateformat")] 
	public string? Shortdateformat { get; set; } 

	[XmlElement(ElementName="longdateformat")] 
	public string? Longdateformat { get; set; } 

	[XmlElement(ElementName="dateseparator")] 
	public string? Dateseparator { get; set; } 

	[XmlElement(ElementName="timeseparator")] 
	public string? Timeseparator { get; set; } 
}

[XmlRoot(ElementName="graphs")]
public class Graphs { 

	[XmlElement(ElementName="live")] 
	public int Live { get; set; } 

	[XmlElement(ElementName="graph1")] 
	public string? Graph1 { get; set; } 

	[XmlElement(ElementName="graph2")] 
	public string? Graph2 { get; set; } 

	[XmlElement(ElementName="graph3")] 
	public string? Graph3 { get; set; } 
}

[XmlRoot(ElementName="tasks")]
public class Tasks { 

	[XmlElement(ElementName="autodisco")] 
	public int Autodisco { get; set; } 

	[XmlElement(ElementName="histcalc")] 
	public int Histcalc { get; set; } 

	[XmlElement(ElementName="correlationstatus")] 
	public int Correlationstatus { get; set; } 

	[XmlElement(ElementName="correlationrunning")] 
	public int Correlationrunning { get; set; } 

	[XmlElement(ElementName="autoupdate")] 
	public int Autoupdate { get; set; } 

	[XmlElement(ElementName="maintenance")] 
	public int Maintenance { get; set; } 

	[XmlElement(ElementName="trialdaysleft")] 
	public int Trialdaysleft { get; set; } 

	[XmlElement(ElementName="showchanneltab")] 
	public int Showchanneltab { get; set; } 

	[XmlElement(ElementName="showfollowlinks")] 
	public int Showfollowlinks { get; set; } 

	[XmlElement(ElementName="showfeedbacklinks")] 
	public int Showfeedbacklinks { get; set; } 

	[XmlElement(ElementName="probeerrors")] 
	public int Probeerrors { get; set; } 

	[XmlElement(ElementName="recommenderrunning")] 
	public int Recommenderrunning { get; set; } 
}

[XmlRoot(ElementName="options")]
public class Options { 

	[XmlElement(ElementName="usertimezone")] 
	public Usertimezone? Usertimezone { get; set; } 

	[XmlElement(ElementName="userdatesettings")] 
	public Userdatesettings? Userdatesettings { get; set; } 

	[XmlElement(ElementName="graphs")] 
	public Graphs? Graphs { get; set; } 

	[XmlElement(ElementName="sensortypes")] 
	public string? Sensortypes { get; set; } 

	[XmlElement(ElementName="usedtags")] 
	public string? Usedtags { get; set; } 

	[XmlElement(ElementName="tasks")] 
	public Tasks? Tasks { get; set; } 
}

[XmlRoot(ElementName="sensor")]
public class Sensor { 

	[XmlElement(ElementName="name")] 
	public string? Name { get; set; } 

	[XmlElement(ElementName="id")] 
	public List<int>? Ids { get; set; } 

	[XmlElement(ElementName="url")] 
	public string? Url { get; set; } 

	[XmlElement(ElementName="tags")] 
	public string? Tags { get; set; } 

	[XmlElement(ElementName="priority")] 
	public int Priority { get; set; } 

	[XmlElement(ElementName="fixed")] 
	public int Fixed { get; set; } 

	[XmlElement(ElementName="hascomment")] 
	public int Hascomment { get; set; } 

	[XmlElement(ElementName="sensortype")] 
	public string? Sensortype { get; set; } 

	[XmlElement(ElementName="sensorkind")] 
	public string? Sensorkind { get; set; } 

	[XmlElement(ElementName="interval")] 
	public int Interval { get; set; } 

	[XmlElement(ElementName="status_raw")] 
	public int StatusRaw { get; set; } 

	[XmlElement(ElementName="status")] 
	public string? Status { get; set; } 

	[XmlElement(ElementName="datamode")] 
	public int Datamode { get; set; } 

	[XmlElement(ElementName="lastvalue")] 
	public string? Lastvalue { get; set; } 

	[XmlElement(ElementName="lastvalue_raw")] 
	public string? LastvalueRaw { get; set; } 

	[XmlElement(ElementName="statusmessage")] 
	public string? Statusmessage { get; set; } 

	[XmlElement(ElementName="statussince_raw_utc")] 
	public string? StatussinceRawUtc { get; set; } 

	[XmlElement(ElementName="lasttime_raw_utc")] 
	public string? LasttimeRawUtc { get; set; } 

	[XmlElement(ElementName="lastok_raw_utc")] 
	public string? LastokRawUtc { get; set; } 

	[XmlElement(ElementName="lasterror_raw_utc")] 
	public string? LasterrorRawUtc { get; set; } 

	[XmlElement(ElementName="lastup_raw_utc")] 
	public string? LastupRawUtc { get; set; } 

	[XmlElement(ElementName="lastdown_raw_utc")] 
	public string? LastdownRawUtc { get; set; } 

	[XmlElement(ElementName="cumulateddowntime_raw")] 
	public string? CumulateddowntimeRaw { get; set; } 

	[XmlElement(ElementName="cumulateduptime_raw")] 
	public string? CumulateduptimeRaw { get; set; } 

	[XmlElement(ElementName="cumulatedsince_raw")] 
	public string? CumulatedsinceRaw { get; set; } 

	[XmlElement(ElementName="active")] 
	public bool Active { get; set; } 

	[XmlText] 
	public string? Text { get; set; } 

	public override string ToString()
	{
		return Name ?? "";
	}
}

[XmlRoot(ElementName="device")]
public class Device { 

	[XmlElement(ElementName="summary")] 
	public string? Summary { get; set; } 

	[XmlElement(ElementName="name")] 
	public string? Name { get; set; } 

	[XmlElement(ElementName="deviceicon")] 
	public string? Deviceicon { get; set; } 

	[XmlElement(ElementName="id")] 
	public List<int>? Ids { get; set; } 

	[XmlElement(ElementName="url")] 
	public string? Url { get; set; } 

	[XmlElement(ElementName="tags")] 
	public object? Tags { get; set; } 

	[XmlElement(ElementName="priority")] 
	public int Priority { get; set; } 

	[XmlElement(ElementName="fixed")] 
	public int Fixed { get; set; } 

	[XmlElement(ElementName="hascomment")] 
	public int Hascomment { get; set; } 

	[XmlElement(ElementName="host")] 
	public string? Host { get; set; } 

	[XmlElement(ElementName="status_raw")] 
	public int StatusRaw { get; set; } 

	[XmlElement(ElementName="active")] 
	public bool Active { get; set; } 

	[XmlElement(ElementName="sensor")] 
	public List<Sensor>? Sensors { get; set; } 

	[XmlText] 
	public string? Text { get; set; } 

	public override string ToString()
	{
		return Name ?? "";
	}
}

[XmlRoot(ElementName="group")]
public class Group { 

	[XmlElement(ElementName="name")] 
	public string? Name { get; set; } 

	[XmlElement(ElementName="id")] 
	public List<int>? Ids { get; set; } 

	[XmlElement(ElementName="url")] 
	public string? Url { get; set; } 

	[XmlElement(ElementName="tags")] 
	public object? Tags { get; set; } 

	[XmlElement(ElementName="priority")] 
	public int Priority { get; set; } 

	[XmlElement(ElementName="fixed")] 
	public int Fixed { get; set; } 

	[XmlElement(ElementName="hascomment")] 
	public int Hascomment { get; set; } 

	[XmlElement(ElementName="status_raw")] 
	public int StatusRaw { get; set; } 

	[XmlElement(ElementName="active")] 
	public bool Active { get; set; } 

	[XmlElement(ElementName="device")] 
	public List<Device>? Devices { get; set; } 

	[XmlText] 
	public string? Text { get; set; } 

	[XmlElement(ElementName="group")] 
	public List<Group>? Groups { get; set; } 

	[XmlElement(ElementName="probenode")] 
	public List<Probenode>? Probenodes { get; set; } 

	[XmlElement(ElementName="autodevice")] 
	public Autodevice? Autodevice { get; set; } 

	public override string ToString()
	{
		return Name ?? "";
	}
}

[XmlRoot(ElementName="probenode")]
public class Probenode { 

	[XmlElement(ElementName="name")] 
	public string? Name { get; set; } 

	[XmlElement(ElementName="id")] 
	public List<int>? Ids { get; set; } 

	[XmlElement(ElementName="url")] 
	public string? Url { get; set; } 

	[XmlElement(ElementName="tags")] 
	public object? Tags { get; set; } 

	[XmlElement(ElementName="priority")] 
	public int Priority { get; set; } 

	[XmlElement(ElementName="fixed")] 
	public int Fixed { get; set; } 

	[XmlElement(ElementName="hascomment")] 
	public int Hascomment { get; set; } 

	[XmlElement(ElementName="status_raw")] 
	public int StatusRaw { get; set; } 

	[XmlElement(ElementName="active")] 
	public bool Active { get; set; } 

	[XmlElement(ElementName="device")] 
	public Device? Device { get; set; } 

	[XmlElement(ElementName="group")] 
	public Group? Group { get; set; } 

	[XmlText] 
	public string? Text { get; set; }

	public override string ToString()
	{
		return Name ?? "";
	}
}

[XmlRoot(ElementName="autodevice")]
public class Autodevice { 

	[XmlElement(ElementName="summary")] 
	public string? Summary { get; set; } 

	[XmlElement(ElementName="name")] 
	public string? Name { get; set; } 

	[XmlElement(ElementName="deviceicon")] 
	public string? Deviceicon { get; set; } 

	[XmlElement(ElementName="id")] 
	public List<int>? Id { get; set; } 

	[XmlElement(ElementName="url")] 
	public string? Url { get; set; } 

	[XmlElement(ElementName="tags")] 
	public object? Tags { get; set; } 

	[XmlElement(ElementName="priority")] 
	public int Priority { get; set; } 

	[XmlElement(ElementName="fixed")] 
	public int Fixed { get; set; } 

	[XmlElement(ElementName="hascomment")] 
	public int Hascomment { get; set; } 

	[XmlElement(ElementName="host")] 
	public object? Host { get; set; } 

	[XmlElement(ElementName="status_raw")] 
	public int StatusRaw { get; set; } 

	[XmlElement(ElementName="active")] 
	public bool Active { get; set; } 

	[XmlElement(ElementName="sensor")] 
	public Sensor? Sensor { get; set; } 

	[XmlText] 
	public string? Text { get; set; } 

	public override string ToString()
	{
		return Name ?? "";
	}
}

[XmlRoot(ElementName="nodes")]
public class Nodes { 

	[XmlElement(ElementName="group")] 
	public Group? Group { get; set; } 
}

[XmlRoot(ElementName="sensortree")]
public class Sensortree { 

	[XmlElement(ElementName="nodes")] 
	public Nodes? Nodes { get; set; } 
}

[XmlRoot(ElementName="prtg")]
public class Prtg { 

	[XmlElement(ElementName="prtg-version")] 
	public string? Prtgversion { get; set; } 

	[XmlElement(ElementName="options")] 
	public Options? Options { get; set; } 

	[XmlElement(ElementName="sensortree")] 
	public Sensortree? Sensortree { get; set; } 
}
