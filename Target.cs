using System.Text;
using System.Xml.Serialization;
using Proxy.Endpoint;
using Proxy.Policies;

namespace Proxy.Target;

[XmlRoot(ElementName="TargetEndpoint")]
public class TargetEndpoint
{
	[XmlElement(ElementName="Description")] 
	public string Description { get; set; }

	[XmlElement(ElementName="FaultRules")] 
	public List<FaultRule> FaultRules { get; set; } 

	[XmlElement(ElementName="PreFlow")] 
	public PreFlow PreFlow { get; set; } 

	[XmlElement(ElementName="PostFlow")] 
	public PostFlow PostFlow { get; set; }

	[XmlElement(ElementName="Flows")] 
	public List<Flow> Flows { get; set; }
	
	[XmlElement(ElementName="HTTPTargetConnection")] 
	public HTTPTargetConnection HTTPTargetConnection { get; set; } 

	[XmlAttribute(AttributeName="name")] 
	public string Name { get; set; }


	// public override string ToString()
	// {
	// 	StringBuilder sb = new StringBuilder();

    //     System.Console.WriteLine("TargetEndpoint");
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
	// 		// sb.AppendLine("PreFlow:");
	// 		sb.AppendLine($"Name: {PreFlow.Name}");
	// 		sb.AppendLine("Request:");
	// 		sb.AppendLine($"Response: {PreFlow.Response}");
	// 	}

	// 	if (PostFlow != null)
	// 	{
	// 		// sb.AppendLine($"PostFlow:");
	// 		sb.AppendLine($"Name: {PostFlow.Name}");
	// 		sb.AppendLine($"Request: {PostFlow.Request}");
	// 		sb.AppendLine($"Response: {PostFlow.Response}");
	// 	}

	// 	if (Flows != null)
	// 	{
	// 		sb.AppendLine("Flows:");
	// 		foreach (var flow in Flows)
	// 		{
	// 			// sb.AppendLine($"Flow- {flow}");
	// 		}
	// 	}

	// 	if (HTTPTargetConnection != null)
	// 	{
	// 		sb.AppendLine("HTTPTargetConnection:");
	// 		// if (HTTPTargetConnection.Properties != null)
	// 		// {
	// 			sb.AppendLine("Properties:");
	// 			foreach (var property in HTTPTargetConnection.Properties)
	// 			{
	// 				// sb.AppendLine($"Property -{property}");
	// 			}
	// 		// }
	// 		sb.AppendLine($"URL: {HTTPTargetConnection.URL}");
	// 	}

	// 	return sb.ToString();
	// }


}

[XmlRoot(ElementName="FaultRule")]
public class FaultRule
{
	
}

// [XmlRoot(ElementName="PreFlow")]
// public class PreFlow { 

// 	[XmlElement(ElementName="Request")] 
// 	public Request Request { get; set; } 

// 	[XmlElement(ElementName="Response")] 
// 	public string Response { get; set; } 
	
// 	[XmlAttribute(AttributeName="name")] 
// 	public string Name { get; set; } 
// }


[XmlRoot(ElementName="PostFlow")]
public class PostFlow { 

	[XmlElement(ElementName="Request")] 
	public Request Request { get; set; } 

	[XmlElement(ElementName="Response")] 
	public string Response { get; set; } 

	[XmlAttribute(AttributeName="name")] 
	public string Name { get; set; }
}

[XmlRoot(ElementName="Flow")]
public class Flow
{
	
}