using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Diagnostics;
using ModernHttpClient;
using System.IO;
using System.Collections.ObjectModel;

namespace BounMeals
{
    public class MealsApi
    {
        string apiUrl = "https://bounmeals.firebaseio.com/bounmeals.json";
        HttpClient client;

        public MealsApi()
        {
            client = new HttpClient(new NativeMessageHandler());
            client.MaxResponseContentBufferSize = 256000;
        }

        public async Task<List<DailyMealViewModel>> GetAllMeals()
        {
            List<DailyMealViewModel> meals = new List<DailyMealViewModel>();

            var serializer = new JsonSerializer
            {
                DateFormatString = "yyyyMMdd"
            };

            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response != null)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    JsonTextReader rdr = new JsonTextReader(new StringReader(result));

                    meals = serializer.Deserialize<List<DailyMealViewModel>>(rdr);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            return meals;            
        }
    }
}
