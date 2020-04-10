using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ConfinApp.Models;
using Newtonsoft.Json;

namespace ConfinApp.Services
{
    public static class PandemicData
    {
        private const string TRANSPARENCIA_CAT = "https://analisi.transparenciacatalunya.cat/resource/";

        #region CAT DATA
        public static async Task<List<COVID19_Cat>> GetIncidenciaCatalunya()
        {
            List<COVID19_Cat> data = new List<COVID19_Cat>();

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync(TRANSPARENCIA_CAT + "623z-r97q.json"))
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    data = JsonConvert.DeserializeObject<List<COVID19_Cat>>(result);
                }
            }


            return data;
        }

        #endregion



    }
}
