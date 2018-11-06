using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public static class RequestCurrency
    {

        public async static Task<decimal?> GetValue()
        {

            string result = await GetRequest("http://free.currencyconverterapi.com/api/v5/convert?q=USD_EUR&compact=y");

            JsonObject output = JsonConvert.DeserializeObject<JsonObject>(result);
            decimal value2;
            bool success = decimal.TryParse(output.USD_EUR.val.ToString(), out value2);
            if (success)
            {
                return value2;
            }
            return null;
        }

        public async static Task<string> GetRequest(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                Console.WriteLine("client created");
                using (HttpResponseMessage response = await client.GetAsync(url))
                {
                    Console.WriteLine("response created");
                    using (HttpContent content = response.Content)
                    {
                        string mycontent = await content.ReadAsStringAsync();
                        //Console.WriteLine(mycontent);
                        return mycontent;
                    }
                }
            }
        }
    }







    //public static float GetCurrency()
    //{
    //    string result = null;

    //    try {
    //        var task = GetRequest("http://free.currencyconverterapi.com/api/v5/convert?q=USD_EUR&compact=y");
    //        result = task.Result;
    //    }
    //    catch (Exception ex)
    //    {
    //        Console.WriteLine(ex.Message);
    //    }

    //    JsonObject output = JsonConvert.DeserializeObject<JsonObject>(result);

    //    return output.USD_EUR.val;
    //}

    //async static Task<string> GetRequest(string url)
    //{
    //    using (HttpClient client = new HttpClient())
    //    {
    //        return await client.GetStringAsync(url);
    //        //Console.WriteLine("client created");
    //        //using (HttpResponseMessage response = await client.GetAsync(url))
    //        //{
    //        //    Console.WriteLine("response created");
    //        //    using (HttpContent content = response.Content)
    //        //    {
    //        //        string mycontent = await content.ReadAsStringAsync();
    //        //        //Console.WriteLine(mycontent);
    //        //        return mycontent;
    //        //    }
    //        //}
    //    }
    //}
}



