using System;
using Newtonsoft.Json;

namespace ConfinApp.Models
{
    public class COVID19_Cat
    {
        [JsonProperty("data")]
        public DateTime Data;
        [JsonProperty("nous_casos_diaris_confirmats")]
        public string Casos;
        [JsonProperty("defuncions_di_ries")]
        public string Defuncions;
        [JsonProperty("altes_hospital_ries_di_ries")]
        public string Altes;
        [JsonProperty("total_casos_confirmats")]
        public string Total_Casos;
        [JsonProperty("total_defuncions")]
        public string Total_Defuncions;
        [JsonProperty("total_altes_hospital_ries")]
        public string Total_Altes;


    }
}
