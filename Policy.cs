using System.Text;
using System.Xml.Serialization;
using Apigeemig;
using Proxy.Endpoint;

namespace Proxy.Policies
{
    public class Policy
    {
        
        [XmlAttribute(AttributeName="name")]
        public string Name { get; set; }

        [XmlAttribute(AttributeName="continueOnError")]
        public bool continueOnError { get; set; }

        [XmlAttribute(AttributeName="enabled")]
        public bool Enabled { get; set; }

	    [XmlElement(ElementName="DisplayName")] 
        public string DisplayName { get; set; }

        [XmlArray(ElementName = "Properties")]
	    [XmlArrayItem(ElementName="Property")] 
        public List<Property> Properties { get; set; }

    }
     
    [XmlRoot(ElementName = "ServiceCallout")]
    public class ServiceCallout : Policy
    {
        [XmlElement(ElementName="Request")] 
        public Request Request { get; set; }

        [XmlElement(ElementName="Response")] 
        public string Response { get; set; }

        [XmlElement(ElementName="HTTPTargetConnection")] 
        public HTTPTargetConnection HTTPTargetConnection { get; set; }

        // public override string ToString()
        // {
        //     StringBuilder sb = new StringBuilder();
        //     sb.AppendLine($"Name: {Name}");
        //     sb.AppendLine($"ContinueOnError: {continueOnError}");
        //     sb.AppendLine($"Enabled: {Enabled}");
        //     sb.AppendLine($"DisplayName: {DisplayName}");
        //     sb.AppendLine($"Properties"); 
        //     if (Properties != null && Properties.Count > 0)
        //     {
        //         sb.AppendLine("Properties:");
        //         foreach (var property in Properties)
        //         {
        //             sb.AppendLine($"- {property}");
        //         }
        //     }
            
		//     if (Request != null)
		//     {
		// 	    sb.AppendLine("Request");
		// 	    sb.AppendLine($"ClearPayLoad: {Request.ClearPayload}");
        //         sb.AppendLine($"Variable : {Request.Variable}");
        //         sb.AppendLine($"IgnoreUnresolvedVariables: {Request.IgnoreUnresolvedVariables}");
        //     }
            
        //     sb.AppendLine($"Response: {Response}");
        //     sb.AppendLine($"HTTPTargetConnection");  
            
        //     if (HTTPTargetConnection != null)
		//     {
        //         // if (Properties != null && Properties.Count > 0)
        //         // {
        //            sb.AppendLine("Properties:");
        //            foreach (var property in Properties)
        //            {
        //                sb.AppendLine($"- {property}");
        //            }
        //         // }
		// 	    sb.AppendLine($"URL: {HTTPTargetConnection.URL}");
        //     }
        //     return sb.ToString();
    
    }

    
    [XmlRoot(ElementName = "SpikeArrest")]
    public class SpikeArrest : Policy
    {
        public Identifier Identifier { get; set; } 
    	public MessageWeight MessageWeight { get; set; } 
    	public string Rate { get; set; } 

        
    //     public override string ToString()
    //     {
    //         StringBuilder sb = new StringBuilder();
    //         sb.AppendLine($"Name: {Name}");
    //         sb.AppendLine($"ContinueOnError: {continueOnError}");
    //         sb.AppendLine($"Enabled: {Enabled}");
    //         sb.AppendLine($"DisplayName: {DisplayName}");
    //         sb.AppendLine($"Properties"); 
    //         if (Properties != null && Properties.Count > 0)
    //         {
    //             sb.AppendLine("Properties:");
    //             foreach (var property in Properties)
    //             {
    //                 sb.AppendLine($"- {property}");
    //             }
    //         }
    //         sb.AppendLine($"Identifier");
    //         sb.AppendLine($"ref: {Identifier.Ref}");
    //         sb.AppendLine($"MessageWeight :");
    //         sb.AppendLine($"ref : {MessageWeight.Ref}");
    //         sb.AppendLine($"Rate:{Rate}");
    //         return sb.ToString();
			
    //     }

    }
    
    [XmlRoot(ElementName = "VerifyAPIKey")]
    public class VerifyAPIKey : Policy
    {
        [XmlElement(ElementName = "APIKey")]
        public APIKey APIKey { get; set; } 

        // public override string ToString()
        // {
        //     StringBuilder sb = new StringBuilder();
        //     sb.AppendLine($"Name: {Name}");
        //     sb.AppendLine($"ContinueOnError: {continueOnError}");
        //     sb.AppendLine($"Enabled: {Enabled}");
        //     sb.AppendLine($"DisplayName: {DisplayName}");
        //     sb.AppendLine($"Properties"); 
            
        //         foreach (var property in Properties)
        //         {
        //             sb.AppendLine($"- {property}");
        //         }
        //        sb.AppendLine($"APIKey"); 
        //          sb.AppendLine($"Ref : {APIKey.Ref}");    

        //     return sb.ToString();
        // }    


    }

    [XmlRoot(ElementName = "Request")] 
    public class Request
    {
       
        [XmlElement(ElementName = "Step")]
	    public List<Step> Steps { get; set; }

        [XmlElement(ElementName="IgnoreUnresolvedVariables")] 
        public bool IgnoreUnresolvedVariables { get; set; }

        [XmlAttribute(AttributeName="clearPayload")]
        public bool ClearPayload { get; set; }

        [XmlAttribute(AttributeName="variable")]
        public string Variable { get; set; }
    }
    
    [XmlRoot(ElementName = " HTTPTargetConnection")]  
    public class HTTPTargetConnection
    {
        [XmlElement(ElementName = "Properties")]        
        public List<Property> Properties { get; set; }
        
        [XmlElement(ElementName = "URL")] 
        public string URL { get; set; }
        
        // public string BasePath { get; set; } 
        // public string VirtualHost { get; set; }
    }
    
    
    [XmlRoot(ElementName = "RouteRule")] 
    public class RouteRule 
    {
        [XmlElement(ElementName = "TargetEndpoint")]
    	public TargetEndpointName TargetEndpoint { get; set; }  

        [XmlAttribute(AttributeName = "name")]
	    public string Name { get; set; } 
    }

    
    [XmlRoot(ElementName = "Identifier")] 
    public class Identifier 
    { 
        [XmlAttribute(AttributeName="ref")]
	    public string Ref { get; set; }
    }
    
    [XmlRoot(ElementName = "MessageWeight")] 
    public class MessageWeight 
    { 
        [XmlAttribute(AttributeName="ref")]
	    public string Ref { get; set; } 
    }

    [XmlRoot(ElementName = "APIKey")] 
    public class APIKey 
    { 
        [XmlAttribute(AttributeName="ref")]
	    public string Ref { get; set; }
    }

    public class Property
    {
        
    }
}