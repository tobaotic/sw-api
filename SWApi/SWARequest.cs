using System;
using System.IO;
using System.Net;


namespace SWApi
{

    public class SWARequest
    {
        /// <summary>
        /// Return JSON response for given URL request
        /// </summary>
        /// <param name="jsonAPIPath">A URL string</param>
        /// <returns>JSON response as string</returns>
        public string GetJsonResponse(string jsonAPIPath)
        {
            string jsonResponse = string.Empty;

            // Create a new WebClient instance.
            using (var client = new WebClient())
            {
                client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");

                try { 
                    //Opens a readable stream for the data
                    Stream data = client.OpenRead(jsonAPIPath);
                    StreamReader reader = new StreamReader(data);
                    
                    // Read entire stream
                    jsonResponse = reader.ReadToEnd();

                    data.Close();
                    reader.Close();                
                }
                catch (WebException wex)
                {
                    throw new System.ArgumentException(wex.Message);
                }
            }

            return jsonResponse;
        }
    }
}