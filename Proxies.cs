using System.Text;
using System.Xml.Serialization;
using Proxy.Policies;
using Proxy.Target;

namespace Proxy.Endpoint;

[XmlRoot(ElementName = "ProxyEndpoint")]
public class ProxyEndpoint
{
	[XmlElement(ElementName = "Description")]
	public string Description { get; set; }

	[XmlElement(ElementName = "FaultRules")]
	public List<FaultRule> FaultRules { get; set; }

	[XmlElement(ElementName = "PreFlow")]
	public PreFlow PreFlow { get; set; }

	[XmlElement(ElementName = "PostFlow")]
	public PostFlow PostFlow { get; set; }

	[XmlElement(ElementName = "Flows")]
	public List<Flow> Flows { get; set; }

	[XmlElement(ElementName = "HTTPProxyConnection")]
	public HTTPProxyConnection HTTPProxyConnection { get; set; }

	[XmlElement(ElementName = "RouteRule")]
	public RouteRule RouteRule { get; set; }

	[XmlAttribute(AttributeName = "name")]
	public string Name { get; set; }

	// public override string ToString()
	// {
	// 	StringBuilder sb = new StringBuilder();
    //     System.Console.WriteLine("ProxyEndPoint");
	// 	sb.AppendLine($"Name: {Name}");
	// 	sb.AppendLine($"Description: {Description}");

	// 	if (FaultRules != null)
	// 	{
	// 		sb.AppendLine("FaultRules:");
	// 		foreach (var faultRule in FaultRules)
	// 		{
	// 			sb.AppendLine($"FaltRule- {faultRule}");
	// 		}
	// 	}

	// 	if (PreFlow != null)
	// 	{
	// 		sb.AppendLine("PreFlow:");
	// 		sb.AppendLine($"Name: {PreFlow.Name}");
	// 		// if (PreFlow.Request != null)
	// 		// {
	// 			sb.AppendLine("Request:");
	// 			foreach (var step in PreFlow.Request.Steps)
	// 			{
	// 				sb.AppendLine($"Step- {step.Name}");
	// 			}
	// 		// }
	// 		sb.AppendLine($"Response: {PreFlow.Response}");
	// 	}

	// 	if (PostFlow != null)
	// 	{
	// 		sb.AppendLine($"PostFlow:");
	// 		sb.AppendLine($"Name: {PostFlow.Name}");
	// 		sb.AppendLine($"Request: {PostFlow.Request}");
	// 		sb.AppendLine($"Response: {PostFlow.Response}");
	// 	}

	// 	if (Flows != null)
	// 	{
	// 		sb.AppendLine("Flows:");
	// 		foreach (var flow in Flows)
	// 		{
	// 			sb.AppendLine($"- {flow}");
	// 		}
	// 	}

	// 	if (HTTPProxyConnection != null)
	// 	{
	// 		sb.AppendLine("HTTPProxyConnection:");
	// 		sb.AppendLine($"BasePath: {HTTPProxyConnection.BasePath}");
	// 		if (HTTPProxyConnection.Properties != null)
	// 		{
	// 			sb.AppendLine("Properties:");
	// 			foreach (var property in HTTPProxyConnection.Properties)
	// 			{
	// 				sb.AppendLine($"Property -{property}");
	// 			}
	// 		}
	// 		sb.AppendLine($"VirtualHost: {HTTPProxyConnection.VirtualHost}");
	// 	}

	// 	if (RouteRule != null)
	// 	{
	// 		sb.AppendLine($"RouteRule: {RouteRule.Name}");
	// 		sb.AppendLine($"TargetEndPoint : {RouteRule.TargetEndpoint.Name}");

	// 	}

	// 	return sb.ToString();
	// }


}


[XmlRoot(ElementName = "PreFlow")]
public class PreFlow
{
	[XmlAttribute(AttributeName = "name")]
	public string Name { get; set; }

	[XmlElement(ElementName = "Request")]
	public Request Request { get; set; }

	[XmlElement(ElementName = "Response")]
	public string Response { get; set; }

}

[XmlRoot(ElementName = "Step")]
public class Step
{
	[XmlElement(ElementName = "Name")]
	public string Name { get; set; }
}

[XmlRoot(ElementName = "HTTPProxyConnection")]
public class HTTPProxyConnection
{
	[XmlElement(ElementName = "BasePath")]
	public string BasePath;

	[XmlElement(ElementName = "Properties")]
	public List<Property> Properties { get; set; }

	[XmlElement(ElementName = "VirtualHost")]
	public string VirtualHost;
}

[XmlRoot(ElementName = "Property")]
public class Property
{
   
}