using System.IO;
using System.Net;
using System.Text;
using System.Web.Helpers;

namespace GitBan.Infrastructure
{
    public static class WebClient
    {
         public static string Post(string url, string accessToken, string postData)
         {
             var data = FormatStringToBytes(postData);
             var request = (HttpWebRequest)WebRequest.Create(AppendAccessToken(url, accessToken));
             request.Method = "POST";
             request.ContentLength = data.Length;
             request.ContentType = "application/x-www-form-urlencoded";
             request.Headers.Add("Accept-Encoding", "gzip,deflate");
             var requestStream = request.GetRequestStream();
             requestStream.Write(data, 0, data.Length);
             requestStream.Close();
             var response = (HttpWebResponse)request.GetResponse();
             return GetResponseContents(response);
         }

         public static string Get(string url, string accessToken)
         {
             var request = (HttpWebRequest)WebRequest.Create(AppendAccessToken(url, accessToken));
             request.Method = "GET";
             var response = (HttpWebResponse)request.GetResponse();
             return GetResponseContents(response);
         }

        public static object GetJson(string url, string accessToken)
        {
            var result = Get(url, accessToken);
            return Json.Decode(result);
        }

         private static byte[] FormatStringToBytes(string str, params object[] formatParams)
         {
             return Encoding.ASCII.GetBytes(string.Format(str, formatParams));
         }

         private static string GetResponseContents(WebResponse response)
         {
             string contents = null;
             var respStream = response.GetResponseStream();
             if (respStream != null)
             {
                 using (var respStreamReader = new StreamReader(respStream))
                 {
                     contents = respStreamReader.ReadToEnd();
                     respStreamReader.Close();
                 }
             }
             return contents;
         }

        private static string AppendAccessToken(string url, string accessToken)
        {
            if (string.IsNullOrEmpty(accessToken))
                return url;

            var sb = new StringBuilder(url);
            sb.Append(url.Contains("?") ? "&" : "?");
            sb.Append("access_token=");
            sb.Append(accessToken);
            return sb.ToString();
        }
    }
}