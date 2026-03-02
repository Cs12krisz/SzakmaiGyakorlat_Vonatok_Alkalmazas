using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Vonatok
{
    internal class Varakozas
    {
        public Varakozas() { }

        public Varakozas(string vonal, string allomas, string erkezoIrany, string induloIrany, int maxKeses)
        {
            Vonal = vonal;
            Allomas = allomas;
            ErkezoIrany = erkezoIrany;
            InduloIrany = induloIrany;
            VarakozasIdo = maxKeses;
        }

        public Varakozas(string sor) 
        {
            string[] tomb = sor.Split("\t");
            Vonal = tomb[0];
            Allomas = tomb[1];
            ErkezoIrany = tomb[2];
            InduloIrany = tomb[3];
            VarakozasIdo = int.Parse(tomb[4]);
        }

        [JsonPropertyName("vonal")]
        public string Vonal { get; set; }

        [JsonPropertyName("allomas")]
        public string Allomas { get; set; }

        [JsonPropertyName("erkezoirany")]
        public string ErkezoIrany { get; set; }

        [JsonPropertyName("induloirany")]
        public string InduloIrany { get; set; }

        [JsonPropertyName("keses")]
        public int VarakozasIdo { get; set; }

        public override string ToString()
        {
            return $"Vonal: {Vonal} Állomás: {Allomas} \n Érkező: {ErkezoIrany} \n Induló: {InduloIrany} \n Maximális várakozási idő: {VarakozasIdo} perc";
        }

        public bool VakozikE(string erkezesiIrany, string indulasiIrany)
        {
            bool varakozikE = false;
            string[] tomb = InduloIrany.Split(", ");
            foreach (var item in tomb)
            {
                if (erkezesiIrany == ErkezoIrany && indulasiIrany == item)
                {
                    varakozikE = true;
                }
            }


            return varakozikE;
        }
    }
}
