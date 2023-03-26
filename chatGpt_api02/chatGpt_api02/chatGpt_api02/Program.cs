using Newtonsoft.Json;
using System.Text;

namespace chatGpt_api02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting a question ...");

            Task<string> answer_task = Get_answer();
            string answer = answer_task.Result;

            int t = 0;

        }


        public static async Task<string> Get_answer()
        {
            string bearerToken = "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";

            //string url_request_base = "https://gif-apim.pwcinternal.com/pwclabs-catalogue-us-sandbox/api/v2/workspaces";
            //string workspace_id = workspaceId.ToString();

            //string url_request = $"{url_request_base}/{workspace_id}/assets?subscription-key={subscription_key}";
            string url_request = "https://api.openai.com/v1/chat/completions";


            string body_register_temp = @"
            {
                ""model"" : ""gpt-3.5-turbo"",
                ""messages"" : [{""role"": ""user"", ""content"": ""what is your name?""}]
            }
            ";


            var req_register = new HttpRequestMessage(HttpMethod.Post, url_request);
            req_register.Headers.Add("Authorization", "Bearer " + bearerToken); // bearer authentication

            //req_register.Headers.Add("Content-Type", "application/json");
            req_register.Headers.Add("Accept", "*/*");
            req_register.Headers.Add("Accept-Encoding", "gzip, deflate, br");

            string body_register = body_register_temp;
            req_register.Content = new StringContent(body_register,
                                    Encoding.UTF8,
                                    "application/json");//CONTENT-TYPE header

            var httpClient_register = new HttpClient();

            HttpResponseMessage response = await httpClient_register.SendAsync(req_register);

            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            //AssetResponse.Rootobject rootobject = JsonConvert.DeserializeObject<AssetResponse.Rootobject>(responseBody);

            //string asset_id = rootobject.id;

            return responseBody;
        }

    }
}