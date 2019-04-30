using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace td3
{
    public class WSUtilisateurs
    {
        private static WSUtilisateurs _instance;
        private readonly HttpClient _httpClient;

        public static WSUtilisateurs Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new WSUtilisateurs();
                }
                return _instance;
            }
        }

        private WSUtilisateurs()
        {
            this._httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://vcouturier-001-site13.ctempurl.com/api/");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<Utilisateur> GetUtilisateurAsync(string email, string password)
        {
            Utilisateur user = null;

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync("utilisateurs?email=" + email + "&password=" + password);
                if (response.IsSuccessStatusCode)
                {
                    var contenu = await response.Content.ReadAsStringAsync();
                    user = JsonConvert.DeserializeObject<Utilisateur>(contenu);
                }
            }
            catch (Exception)
            {
                await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Erreur", "Erreur de connexion au WS !", "Ok");
            }

            return user;
        }

        public async Task<Utilisateur> PostUtilisateurAsync(Utilisateur user)
        {
            var contenu = JsonConvert.SerializeObject(user);
            var buffer = System.Text.Encoding.UTF8.GetBytes(contenu);
            var utilisateurACreer = new ByteArrayContent(buffer);
            utilisateurACreer.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            // try catch a definir plus tard

            return user;
        }
    }
}
