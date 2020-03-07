using Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PKCore.APIService
{
    public class RestApiService : IRestAPIServices
    {
        HttpClient _httpClient;

        #region Constructor

        public RestApiService()
        {
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri(Constants.BaseUrl)
            };
        }
        #endregion

        public async Task<T> Get<T>(string url)
        {
            //funcion que permite llamar la ruta de la web api
            var respuesta = await _httpClient.GetAsync(url);
            if (respuesta.IsSuccessStatusCode)
            {
                var obj = await respuesta.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(obj);
            }
            return default(T);
        }
    }
}
