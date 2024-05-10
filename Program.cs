using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Apigeemig;
using Proxy.Endpoint;
using Proxy.Policies;
using Proxy.Target;
using CsvHelper;
using System.Globalization;
using System.Text;
using System.Reflection;
class Program
{
    public static Dictionary<string, object> DeserializedObjectList = new Dictionary<string, object>();
    static void Main(string[] args)
    {
        string rootDirectory = @"C:\Users\RRai\Downloads\apigeemig_rev2_2024_03_12\apiproxy";

        var apigeeType = new List<Type> { typeof(ApiProxy) };
        var policyTypes = new List<Type> { typeof(ServiceCallout), typeof(SpikeArrest), typeof(VerifyAPIKey) };
        var targetTypes = new List<Type> { typeof(TargetEndpoint) };
        var proxyTypes = new List<Type> { typeof(ProxyEndpoint) };

        DeserializePolicies(rootDirectory, policyTypes);
        DeserializeTargetEndpoints(rootDirectory, targetTypes);
        DeserializeProxyEndpoints(rootDirectory, proxyTypes);

        var apigee = BuildApigee(rootDirectory, apigeeType);
        // System.Console.WriteLine(apigee.GetType() is object);
        // System.Console.WriteLine( apigee.ToString());
        // string csvString = WriteObjectsToCsv(apigee);

        WriteObjectsToCsv(apigee);

    }

    public static void WriteObjectsToCsv(object Obj)
    {
        // T obj = Deserialize<T>(xmlpath);

        // System.Console.WriteLine(Obj.GetType() == typeof(object));

        var properties = Obj.GetType().GetProperties();

        StringBuilder csvContent = new StringBuilder();

        //Append header
        csvContent.AppendLine(GetCsvHeader(properties));

        // Get values of properties
        var values = GetPropertyValues(properties, Obj);

        // Append values to CSV content
        csvContent.AppendLine(string.Join(",", values));

        System.Console.WriteLine(csvContent);

        // Write content to file
        // File.WriteAllText(outputfilePath, csvContent.ToString());
    }

    private static string GetCsvHeader(PropertyInfo[] properties)
    {
        List<string> header = new List<string>();
        foreach (var property in properties)
        {
            if (property.PropertyType.IsPrimitive || property.PropertyType == typeof(string) || property.PropertyType == typeof(object))
            {
                header.Add(property.Name);
            }
            else
            {
                var subObjectProperties = property.PropertyType.GetProperties();
                header.AddRange(subObjectProperties.Select(subProperty => $"{property.Name}.{subProperty.Name}"));
            }
        }
        return string.Join(",", header);
    }

    private static IEnumerable<object> GetPropertyValues(PropertyInfo[] properties, object obj)
    {
        List<object> values = new List<object>();
        foreach (var property in properties)
        {
            var value = property.GetValue(obj);


            if (value != null)
            {
                if (property.PropertyType.IsPrimitive || property.PropertyType == typeof(string) || property.PropertyType == typeof(object))
                {
                    values.Add(value);
                }
                else
                {
                    var subObjectProperties = property.PropertyType.GetProperties();
                    values.AddRange(GetPropertyValues(subObjectProperties, value));
                }
            }
            else
            {
                values.Add(""); // If the property is null, add an empty string to maintain CSV structure
            }
        }

        return values;
    }

    private static ApiProxy BuildApigee(string FilePath, List<Type> Types)
    {
        var apigee = DeserializeApigee(FilePath, Types);

        foreach (var policyInfo in apigee.Policies)
        {
            policyInfo.PolicyObject = DeserializedObjectList[policyInfo.Name];
        }

        foreach (var targetEndpointInfo in apigee.TargetEndpoints)
        {
            targetEndpointInfo.TargetEndpointObject = DeserializedObjectList[targetEndpointInfo.Name];
        }

        foreach (var proxyEndpointInfo in apigee.ProxyEndpoints)
        {
            proxyEndpointInfo.ProxyEndPointObject = DeserializedObjectList[proxyEndpointInfo.Name];
        }

        return apigee;

    }

    private static ApiProxy DeserializeApigee(string filePath, List<Type> apigeeType)
    {
        try
        {
            string[] apigeeFiles = Directory.GetFiles(filePath, "*.xml");

            foreach (string File in apigeeFiles)
            {
                object apigee = TryDeserialize(File, apigeeType);

                if (apigee != null)
                {

                    return (ApiProxy)apigee;

                }
            }

            return null;
        }
        catch (Exception ex)
        {
            // Console.WriteLine($"Error deserializing apigee: {ex.Message}");
            return null;
        }
    }

    private static void DeserializeProxyEndpoints(string rootDirectory, List<Type> proxyTypes)
    {

        try
        {
            // Search for XML files in the policies directory
            string proxyDirectory = Path.Combine(rootDirectory, "proxies");
            string[] targetFiles = Directory.GetFiles(proxyDirectory, "*.xml");

            // Deserialize each policy file and add it to the list
            foreach (var filePath in targetFiles)
            {
                // Attempt to deserialize the file into each policy type
                object proxy = TryDeserialize(filePath, proxyTypes);


                // If deserialization is successful, add the policy to the list
                if (proxy != null)
                {

                    // policies.Add(policy);

                    var name = GetProxyName((ProxyEndpoint)proxy);

                    DeserializedObjectList[name] = proxy;

                }
            }
        }
        catch (Exception ex)
        {
            // Console.WriteLine($"Error deserializing policies: {ex.Message}");
            throw;
        }

    }

    private static string GetProxyName(ProxyEndpoint proxy)
    {
        return proxy.Name;
    }

    private static void DeserializeTargetEndpoints(string rootDirectory, List<Type> targetTypes)
    {
        try
        {
            // Search for XML files in the policies directory
            string targetDirectory = Path.Combine(rootDirectory, "targets");
            string[] targetFiles = Directory.GetFiles(targetDirectory, "*.xml");

            // Deserialize each policy file and add it to the list
            foreach (var filePath in targetFiles)
            {
                // Attempt to deserialize the file into each policy type
                object target = TryDeserialize(filePath, targetTypes);


                // If deserialization is successful, add the policy to the list
                if (target != null)
                {

                    // policies.Add(policy);

                    var name = GetTargetName((TargetEndpoint)target);

                    DeserializedObjectList[name] = target;

                }
            }
        }
        catch (Exception ex)
        {
            // Console.WriteLine($"Error deserializing policies: {ex.Message}");
            throw;
        }
    }

    private static string GetTargetName(TargetEndpoint target)
    {
        return target.Name;
    }

    public static void DeserializePolicies(string rootDirectory, List<Type> policyTypes)
    {

        try
        {
            // Search for XML files in the policies directory
            string policiesDirectory = Path.Combine(rootDirectory, "policies");
            string[] policyFiles = Directory.GetFiles(policiesDirectory, "*.xml");

            foreach (var filePath in policyFiles)
            {
                // Attempt to deserialize the file into each policy type
                object policy = TryDeserialize(filePath, policyTypes);


                // If deserialization is successful, add the policy to the list
                if (policy != null)
                {

                    // policies.Add(policy);

                    var name = GetPolicyName((Policy)policy);

                    DeserializedObjectList[name] = policy;

                }
            }
        }
        catch (Exception ex)
        {
            // Console.WriteLine($"Error deserializing policies: {ex.Message}");
            throw;
        }

    }

    public static object TryDeserialize(string filePath, List<Type> types)
    {
        object des_obj = null;

        foreach (var type in types)
        {
            try
            {
                // Attempt to deserialize the file into the current policy type
                des_obj = DeserializeXmlFile(filePath, type);

                // If deserialization succeeds, return the policy
                return des_obj;
            }
            catch (Exception ex)
            {
                // Log the error (optional)
                // Console.WriteLine($"Error deserializing '{filePath}' as '{type.Name}': {ex.Message}");
            }
        }

        // If all attempts fail, return null
        return des_obj;
    }


    public static object DeserializeXmlFile(string filePath, Type objectType)
    {
        object result;

        try
        {
            // Create XML serializer for the specified object type
            XmlSerializer serializer = new XmlSerializer(objectType);

            // Deserialize the XML file
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
            {
                result = serializer.Deserialize(fileStream);
            }
            return result;
        }
        catch (Exception ex)
        {
            // If an error occurs during deserialization, throw an exception
            throw new Exception($"Error deserializing '{filePath}' as '{objectType.Name}': {ex.Message}");
        }


    }

    public static string ObjectToString<T>(T obj)
    {
        return obj.ToString();
    }

    public static string GetPolicyName(Policy policy)
    {
        // Assuming the property you want to use as the key is "Name"
        return policy.Name;
    }

}
