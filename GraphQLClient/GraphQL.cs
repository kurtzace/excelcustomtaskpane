using System;
 using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.IO;
    using System.Net;
    using System.Text;
using System.Net.Http;

namespace GraphQL
    {
        public class GraphQLClient
        {
            private class GraphQLQuery
            {
                // public string OperationName { get; set; }
                public string query { get; set; }
                public object variables { get; set; }
            }
            public class GraphQLQueryResult
            {
                private string raw;
                private JObject data;
                private Exception Exception;
                public GraphQLQueryResult(string text, Exception ex = null)
                {
                    Exception = ex;
                    raw = text;
                    data = text != null ? JObject.Parse(text) : null;
                }
                public Exception GetException()
                {
                    return Exception;
                }
                public string GetRaw()
                {
                    return raw;
                }
                public T Get<T>(string key)
                {
                    if (data == null) return default(T);
                    try
                    {
                        return JsonConvert.DeserializeObject<T>(this.data["data"][key].ToString());
                    }
                    catch
                    {
                        return default(T);
                    }
                }
                public dynamic Get(string key)
                {
                    if (data == null) return null;
                    try
                    {
                        return JsonConvert.DeserializeObject<dynamic>(this.data["data"][key].ToString());
                    }
                    catch
                    {
                        return null;
                    }
                }
                public dynamic GetData()
                {
                    if (data == null) return null;
                    try
                    {
                        return JsonConvert.DeserializeObject<dynamic>(this.data["data"].ToString());
                    }
                    catch
                    {
                        return null;
                    }
                }
            }
            private string url;
            public GraphQLClient(string url)
            {
                this.url = url;
            }
        public async System.Threading.Tasks.Task<GraphQLQueryResult> QueryAsync(string query, object variables)
        {
            //return new GraphQLQueryResult(null);
            var fullQuery = new GraphQLQuery()
            {
                query = query,
                variables = variables,
            };

            try
            {

                string jsonContent = JsonConvert.SerializeObject(fullQuery);

                Console.WriteLine(jsonContent);
                HttpClient client = new HttpClient();
                //url = "https://graphql.brandfolder.com/graphql";
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                var result = client.PostAsync(url, content).Result;
                if (result.IsSuccessStatusCode)
                {
                    var json = await result.Content.ReadAsStringAsync();
                    return new GraphQLQueryResult(json);
                } else
                {
                    var json = await result.Content.ReadAsStringAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new GraphQLQueryResult(null, e);
            }
            return new GraphQLQueryResult(null);
        }
    }

}
