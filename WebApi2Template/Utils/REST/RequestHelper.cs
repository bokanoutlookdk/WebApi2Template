using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using WebApi2Template.Utils.FileLogging;

namespace WebApi2Template.Utils.REST
{
    public class RequestHelper
    {
        #region helpers
        //https://api.preprod.gratisal.dk//api/auth/login
        //https://api.gratisaltest.dk 
        public static string MakeLogin(string username, string password, string loginUrl)
        {
            string responseFromServer = null;

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(loginUrl);

            httpWebRequest.ContentType = "application/json";

            var bytes = System.Text.Encoding.UTF8.GetBytes($"{username}:{password}");
            var base64Bytes = Convert.ToBase64String(bytes);

            httpWebRequest.Method = "POST";
            httpWebRequest.Headers.Add("Authorization", $"Basic {base64Bytes}");

            // empty post body expected
            using (var streamWriter = new System.IO.StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string input = "{}";
                streamWriter.Write(input);
                streamWriter.Flush();
                streamWriter.Close();
            }

            try
            {
                var response = (HttpWebResponse)httpWebRequest.GetResponse();
                // Get the stream containing content returned by the server
                using (var responseStream = response.GetResponseStream())
                using (System.IO.StreamReader reader = new System.IO.StreamReader(responseStream))
                    responseFromServer = reader.ReadToEnd();
            }
            catch (WebException e)
            {
                LogWebExceptionError(httpWebRequest.Method, loginUrl, e, "MakeLogin:POST");

                throw;
            }

            LogSucces(httpWebRequest.Method, loginUrl, responseFromServer);

            return responseFromServer;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <param name="gratisalUrl"></param>
        /// <param name="bodyObj">either any model class or json string like { "FullName": "kristoffer andersen" } or null </param>
        /// <returns></returns>
        public static string POST(string token, string gratisalUrl, object bodyObj)
        {
            string body = "{}";

            if (bodyObj is string)
                body = bodyObj as string;
            else if (bodyObj != null)
                body = JsonConvert.SerializeObject(bodyObj);

            System.Diagnostics.Debug.WriteLine(body);

            string responseFromServer = null;

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(gratisalUrl);
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Headers.Add("Authorization", "Token " + token);

            // empty post body expected
            using (var streamWriter = new System.IO.StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string input = body;
                streamWriter.Write(input);
                streamWriter.Flush();
                streamWriter.Close();
            }

            try
            {
                var response = (HttpWebResponse)httpWebRequest.GetResponse();
                // Get the stream containing content returned by the server
                using (var responseStream = response.GetResponseStream())
                using (System.IO.StreamReader reader = new System.IO.StreamReader(responseStream))
                    responseFromServer = reader.ReadToEnd();
            }
            catch (WebException e)
            {
                LogWebExceptionError(httpWebRequest.Method, gratisalUrl, e, body);
                throw;
            }

            // log OK results 
            LogSucces(httpWebRequest.Method, gratisalUrl, responseFromServer);


            return responseFromServer;
        }

        public static string GET(string token, string gratisalUrl)
        {
            string responseFromServer = null;

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(gratisalUrl);

            httpWebRequest.ContentType = "application/json";


            httpWebRequest.Method = "GET";
            httpWebRequest.Headers.Add("Authorization", "Token " + token);


            try
            {
                var response = (HttpWebResponse)httpWebRequest.GetResponse();
                // Get the stream containing content returned by the server
                using (var responseStream = response.GetResponseStream())
                using (System.IO.StreamReader reader = new System.IO.StreamReader(responseStream))
                    responseFromServer = reader.ReadToEnd();
            }
            catch (WebException e)
            {
                LogWebExceptionError(httpWebRequest.Method, gratisalUrl, e, "METHOD:GET");

                throw;
            }

            // log OK results 
            LogSucces(httpWebRequest.Method, gratisalUrl, responseFromServer);


            return responseFromServer;
        }

        public static T GET<T>(string token, string gratisalUrl)
        {
            string toDeSerialize = GET(token, gratisalUrl);
            T res = JsonConvert.DeserializeObject<T>(toDeSerialize);
            return res;
        }

        public static string DELETE(string token, string gratisalUrl)
        {
            string responseFromServer = null;

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(gratisalUrl);

            httpWebRequest.ContentType = "application/json";


            httpWebRequest.Method = "DELETE";
            httpWebRequest.Headers.Add("Authorization", "Token " + token);


            try
            {
                var response = (HttpWebResponse)httpWebRequest.GetResponse();
                // Get the stream containing content returned by the server
                using (var responseStream = response.GetResponseStream())
                using (System.IO.StreamReader reader = new System.IO.StreamReader(responseStream))
                    responseFromServer = reader.ReadToEnd();
            }
            catch (WebException e)
            {
                LogWebExceptionError(httpWebRequest.Method, gratisalUrl, e, "Method:DELETE");

                throw;
            }

            return responseFromServer;
        }
        // When put gratisal expects all properties to be defined
        public static string PUT(string token, string gratisalUrl, object bodyObj)
        {
            string body = "{}";

            try
            {
                if (bodyObj is string)
                    body = bodyObj as string;
                else if (bodyObj != null)
                    // TODO: update values so userEmployments etc remains..
                    body = JsonConvert.SerializeObject(bodyObj);
            }
            catch (Exception ex)
            {
                string ss = ex.Message;
                throw;
            }

            System.Diagnostics.Debug.WriteLine(body);

            string responseFromServer = null;

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(gratisalUrl);
            httpWebRequest.Method = "PUT";
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Headers.Add("Authorization", "Token " + token);

            // empty post body expected
            using (var streamWriter = new System.IO.StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string input = body;
                streamWriter.Write(input);
                streamWriter.Flush();
                streamWriter.Close();
            }

            try
            {
                var response = (HttpWebResponse)httpWebRequest.GetResponse();
                // Get the stream containing content returned by the server
                using (var responseStream = response.GetResponseStream())
                using (System.IO.StreamReader reader = new System.IO.StreamReader(responseStream))
                    responseFromServer = reader.ReadToEnd();
            }
            catch (WebException e)
            {
                LogWebExceptionError(httpWebRequest.Method, gratisalUrl, e, body);

                throw;
            }

            // log OK results 
            LogSucces(httpWebRequest.Method, gratisalUrl, responseFromServer);

            return responseFromServer;
        }
        #endregion

        #region helper
        private static void LogWebExceptionError(string method, string url, WebException e, string requestBody)
        {
            int statusCode = 0;
            using (HttpWebResponse response = ((HttpWebResponse)e.Response))
            {
                if (e.Status == WebExceptionStatus.ProtocolError && response != null)
                {
                    // protocol errors find the statuscode in the Response
                    statusCode = (int)((HttpWebResponse)response).StatusCode;
                    if (statusCode == 400 || statusCode == 500)
                    {
                        string Result401 = "";
                        // check the content if needed
                        using (var requestBodyStream = response.GetResponseStream())
                        {
                            using (StreamReader readStream = new StreamReader(requestBodyStream, System.Text.Encoding.GetEncoding("utf-8")))
                            {
                                Result401 = readStream.ReadToEnd();
                                new LogWriter($"method: {method} url: {url} httpstatus:400 {e.Message}\r\n*********\r\nresponsebody: {Result401}\r\n********\r\nrequestbody: {requestBody}");
                            }
                        }
                    }
                    else
                    {
                        // non 400 errors
                        new LogWriter($"method: {method} url: {url} httpstatus:{statusCode} {e.Message}\r\n********\r\nrequestbody: {requestBody}");
                    }
                }
                else
                {
                    new LogWriter($"method: {method} url: {url} httpstatus:{statusCode} {e.Message}\r\n********\r\nrequestbody: {requestBody}");
                }
            }
        }

        private static void LogSucces(string method, string url, string responseBody)
        {
            new LogWriter($"method: {method} url: {url}\r\n*********\r\n{"200 OK"}\r\n*********\r\nResponsebody: {responseBody}");
        }
        #endregion
    }
}