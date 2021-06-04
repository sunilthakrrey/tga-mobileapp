using Newtonsoft.Json;
using ParentPortal.Enums;
using ParentPortal.Services.TGA;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Xamarin.Essentials;
using Xamarin.Forms;
using static ParentPortal.Config.SecureStorage;
using ConfigSettings = ParentPortal.Config;
using NetworkAccess = Xamarin.Essentials.NetworkAccess;

namespace ParentPortal.Services
{

    public class Token
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public string expires_in { get; set; }
        public string scope { get; set; }


        public string token
        {
            get
            {
                return string.Concat(token_type, " ", access_token);
            }
        }
    }

    public class BaseHttpService
    {
        public BaseHttpService()
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }


        protected async Task<T> CreateHttpGETRequestAsync<T>(string url, WebHeaderCollection headers = null, Enums.Page page = Enums.Page.None)
        {
            IsCheckInternetConnectivity();

            MessagingCenter.Send<MainPage, Enums.Page>(new MainPage(), MessageCenterAuthenticator.RequestStarted.ToString(), page);


            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            HttpWebRequest request = CreateRequest(url);
            request.Method = ConfigSettings.Constant.RequestMethod.Get;

            if (headers != null)
            {
                request.Headers = headers;
            }
            //AuthorizedToken authorizedToken = await GetTokenAsync();
            //if (authorizedToken != null)
            //{
            //    request.Headers.Add(ConfigSettings.Constant.HeaderKey.Authorization, string.Format("Bearer {0}", authorizedToken.Token));
            //}
            try
            {
                var httpResponse = (HttpWebResponse)await request.GetResponseAsync();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    obj = JsonConvert.DeserializeObject<T>(result);
                }
            }
            catch (WebException ex)
            {
                HandleBadResponse(ex);
            }
            finally
            {
                MessagingCenter.Send<MainPage, Enums.Page>(new MainPage(), MessageCenterAuthenticator.RequestCompleted.ToString(), page);
            }

            return obj;
        }

        protected async Task<T> CreatHttpPOSTRequestAsync<T>(string url, Dictionary<string, string> headers = null, string body = null, Enums.Page page = Enums.Page.None)
        {
            IsCheckInternetConnectivity();

            MessagingCenter.Send<MainPage, Enums.Page>(new MainPage(), MessageCenterAuthenticator.RequestStarted.ToString(), page);

            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();
            try
            {
                HttpWebRequest request = CreateRequest(url);
                request.Method = ConfigSettings.Constant.RequestMethod.Post;
                request.ContentType = ConfigSettings.Constant.ContentType.Json;

                if (headers != null)
                {
                    foreach (var item in headers)
                    {
                        request.Headers.Add(item.Key, item.Value);
                    }
                }

                //AuthorizedToken authorizedToken = await GetTokenAsync();
                //if (authorizedToken != null)
                //{
                //    request.Headers.Add(ConfigSettings.Constant.HeaderKey.Authorization, string.Format("Bearer {0}", authorizedToken.Token));
                //}

                using (StreamWriter w = new StreamWriter(request.GetRequestStream()))
                {
                    if (body != null)
                    {
                        w.Write(body);
                    }
                    w.Flush();
                }

                var httpResponse = (HttpWebResponse)await request.GetResponseAsync();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    obj = JsonConvert.DeserializeObject<T>(result);
                }
            }
            catch (WebException ex)
            {
                HandleBadResponse(ex);
            }
            finally
            {
                MessagingCenter.Send<MainPage, Enums.Page>(new MainPage(), MessageCenterAuthenticator.RequestCompleted.ToString(), page);
            }

            return obj;
        }

        protected async Task<T> CreatHttpPOSTFormDataRequestAsync<T>(string url, MultipartFormDataContent form = null, Enums.Page page = Enums.Page.None)
        {
            IsCheckInternetConnectivity();

            MessagingCenter.Send<MainPage, Enums.Page>(new MainPage(), MessageCenterAuthenticator.RequestStarted.ToString(), page);

            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();
            try
            {
                HttpWebRequest request = CreateRequest(url);
                request.Method = ConfigSettings.Constant.RequestMethod.Post;
                request.ContentType = ConfigSettings.Constant.ContentType.Json;

                //AuthorizedToken authorizedToken = await GetTokenAsync();
                //if (authorizedToken != null)
                //{
                //    request.Headers.Add(ConfigSettings.Constant.HeaderKey.Authorization, string.Format("Bearer {0}", authorizedToken.Token));
                //}
              
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add(ConfigSettings.Constant.HeaderKey.Authorization, string.Format("Bearer {0}"));
                HttpResponseMessage httpResponse = client.PostAsync(url, form).Result;
                if (httpResponse.IsSuccessStatusCode)
                {
                    var result = httpResponse.Content.ReadAsStringAsync().Result;
                    obj = JsonConvert.DeserializeObject<T>(result);
                }
                //using (var streamReader = new StreamReader(httpResponse.Content.ReadAsStringAsync().Result))
                //{
                //    var result = streamReader.ReadToEnd();
                //    obj = JsonConvert.DeserializeObject<T>(result);
                //}
            }
            catch (WebException ex)
            {
                HandleBadResponse(ex);
            }
            finally
            {
                MessagingCenter.Send<MainPage, Enums.Page>(new MainPage(), MessageCenterAuthenticator.RequestCompleted.ToString(), page);
            }

            return obj;
        }
      

        private HttpWebRequest CreateRequest(string uri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 6.0; en-US; rv:1.9.1.13) Gecko/20100914 Firefox/3.5.13 (.NET CLR 3.5.30729)";
            return request;
        }

        

        private static bool IsCheckInternetConnectivity()
        {
            var isInternetConnection = Connectivity.NetworkAccess == NetworkAccess.Internet;

            if (!isInternetConnection)
                App.HandleError(new Exception("You have no access to Internet.Please check your connection"));
            return isInternetConnection;
        }

        private static void  HandleBadResponse(WebException ex)
        {
           

            string result = string.Empty;

            using (WebResponse response = ex.Response)
            {
                HttpWebResponse httpResponse = (HttpWebResponse)response;
                if (httpResponse.StatusCode == HttpStatusCode.ServiceUnavailable || httpResponse.StatusCode == HttpStatusCode.Forbidden)
                {
                    App.HandleError(new Exception("There has been an error, we have been alerted, please try again later."));
                }
                else
                {

                    using (Stream data = response.GetResponseStream())
                    {
                        using (var reader = new StreamReader(data))
                        {

                            result = reader.ReadToEnd();
                           Contracts.Responses.ErrorResult errorMessage = JsonConvert.DeserializeObject<Contracts.Responses.ErrorResult>(result);
                            result = errorMessage.Message;
                        }
                    }

                    App.HandleError(new Exception(result));

                }

               

            }
        }



        private string GetPayloadString(NameValueCollection parameters)
        {
            if (parameters == null)
            {
                return String.Empty;
            }

            StringBuilder buff = new StringBuilder();
            buff.Length = 0;
            foreach (string key in parameters.Keys)
            {
                string[] values = parameters.GetValues(key);
                if (values != null)
                {
                    foreach (string val in values)
                    {
                        if (buff.Length > 0)
                        {
                            buff.Append("&");
                        }
                        buff.Append(HttpUtility.UrlEncode(key));
                        buff.Append("=");
                        buff.Append(HttpUtility.UrlEncode(val));
                    }
                }
            }
            return buff.ToString();
        }


        private async Task<AuthorizedToken> GetTokenAsync()
        {
            SecureStorageService secureStorageService = new SecureStorageService();
            AuthorizedToken response = await secureStorageService.GetAsync<AuthorizedToken>(Enums.SecureStorageKey.AuthorizedToken);
            return response;
        }

    }
}
