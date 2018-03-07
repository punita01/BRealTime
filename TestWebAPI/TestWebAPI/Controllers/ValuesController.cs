using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using TestWebAPI.Filters;

namespace TestWebAPI.Controllers
{
    public class ValuesController : ApiController
    {
        [DataCheck]
        // GET api/values
        public HttpResponseMessage Get()
        {
            HttpContent requestContent = Request.Content;
            string jsonContent = requestContent.ReadAsStringAsync().Result;
            HttpResponseMessage resp = new HttpResponseMessage(HttpStatusCode.OK);
            string result = "OK";
            var queryStringParamsDict = Request.GetQueryNameValuePairs()
                          .ToDictionary(kv => kv.Key, kv => kv.Value, StringComparer.OrdinalIgnoreCase);

            using (StreamWriter sw = File.AppendText("C:\\ApiLogs\\ApiLog.txt"))
            {                
                sw.WriteLine("//New Request");
                sw.WriteLine(Request.Method);
                sw.WriteLine(Request.RequestUri);
                sw.WriteLine(Request.Headers);
                sw.WriteLine(Request.Content);                
                sw.WriteLine();
                sw.WriteLine();
            }

            if (queryStringParamsDict["q"] == "Name")
            {
                result = "Punita Repe";
            }
            else if (queryStringParamsDict["q"].Contains("Email"))
            {
                result = "pdr8@njit.edu";
            }
            else if (queryStringParamsDict["q"] == "Phone")
            {
                result = "9732777701";
            }
            else if (queryStringParamsDict["q"] == "Position")
            {
                result = "Software Developer";
            }
            else if (queryStringParamsDict["q"] == "Years")
            {
                result = "2";
            }
            else if (queryStringParamsDict["q"] == "Referrer")
            {
                result = "Heena Otia";
            }
            else if (queryStringParamsDict["q"] == "Degree")
            {
                result = "MS in Computer Science";
            }
            else if (queryStringParamsDict["q"] == "Resume")
            {
                result = "https://www.linkedin.com/in/punita-repe-69711a67/detail/treasury/summary/?entityUrn=urn%3Ali%3Afs_treasuryMedia%3A(ACoAAA4T1FMB0PutuOamLYx4pS9WDzLCpGM_QKI%2C1510695511678)";
            }
            else if (queryStringParamsDict["q"] == "Puzzle")
            {
                result = " ABCD\n" +
                        "A=>>>\n" +
                        "B<=<<\n" +
                        "C<>=>\n" +
                        "D<><= ";
            }
            else if (queryStringParamsDict["q"] == "Status")
            {
                result = "Yes";
            }
            else if (queryStringParamsDict["q"] == "Source")
            {
                result = "Yes";
            }
            else
            {
                result = "OK";
                
            }

            resp = new HttpResponseMessage(HttpStatusCode.OK);
            resp.Content = new StringContent(result, System.Text.Encoding.UTF8, "text/plain");
            return resp;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
