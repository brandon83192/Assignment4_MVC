using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Assignment4.Models;
using Newtonsoft.Json;

namespace Assignment4.Infrastructure.GHIListHandler
{
    public class GHIHandler
    {
        static string BASE_URL = "https://data.medicare.gov/resource/xubh-q36u.json"; //This is the base URL, method specific URL is appended to this.
        HttpClient httpClient;

        public GHIHandler()
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }



        public List<Hospital> GetFloridadata()
        {
            string GHIHospital_API_PATH = BASE_URL + "?$where=state='FL'";
            string hospitalList = "";

            List<Hospital> hospitals = null;

            httpClient.BaseAddress = new Uri(GHIHospital_API_PATH);
            HttpResponseMessage response = httpClient.GetAsync(GHIHospital_API_PATH).GetAwaiter().GetResult();
            if (response.IsSuccessStatusCode)
            {
                hospitalList = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            }

            if (!hospitalList.Equals(""))
            {
                hospitals = JsonConvert.DeserializeObject<List<Hospital>>(hospitalList);
                hospitals = hospitals.GetRange(0, 50);
            }
            return hospitals;
        }

        //public List<Hospital> GetChart(string symbol)
        //{
        //    //Using the format method.
        //    //string IEXTrading_API_PATH = BASE_URL + "stock/{0}/batch?types=chart&range=1y";
        //    //IEXTrading_API_PATH = string.Format(IEXTrading_API_PATH, symbol);

        //    string GHIHospital_API_PATH = BASE_URL + "?$where=state='FL'";
        //    string hospitalList = "";

        //    string charts = "";
        //    List<Hospital> HospitalInfo = new List<Hospital>();
        //    httpClient.BaseAddress = new Uri(GHIHospital_API_PATH);
        //    HttpResponseMessage response = httpClient.GetAsync(GHIHospital_API_PATH).GetAwaiter().GetResult();
        //    if (response.IsSuccessStatusCode)
        //    {
        //        charts = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        //    }
        //    if (!charts.Equals(""))
        //    {
        //        ChartRoot root = JsonConvert.DeserializeObject<ChartRoot>(charts, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        //        HospitalInfo = root.chart.ToList();
        //    }
        //    //make sure to add the symbol the chart
        //    foreach (Hospital Hospital in HospitalInfo)
        //    {
        //        Hospital.hospital_name = symbol;
        //    }

        //    return HospitalInfo;
        //}
    }
}
