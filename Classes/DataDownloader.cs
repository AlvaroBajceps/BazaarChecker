using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;

namespace BazaarChecker.Classes
{
    static class DataDownloader
    {
        public static HttpClient httpClient { set; get; }

        static DataDownloader()
        {
            httpClient = new HttpClient();
        }

        public static Bazaar GetBazaarData()
        {
            var responde = httpClient.GetAsync("https://api.hypixel.net/skyblock/bazaar");
            return JsonSerializer.Deserialize<Bazaar>(responde.Result.Content.ReadAsStringAsync().Result);
        }

        public static ActiveAuctions GetWholeAh()
        {
            var completeActiveAuctions = new ActiveAuctions();
            List<Task<ActiveAuctions>> downloadTasks = new List<Task<ActiveAuctions>>();

            //pobieranie pierszej strony aby poznac ilosc stron do pobrania
            var responde = httpClient.GetAsync($"https://api.hypixel.net/skyblock/auctions").Result;
            completeActiveAuctions = JsonSerializer.Deserialize<ActiveAuctions>(responde.Content.ReadAsStringAsync().Result);
            
            for(UInt16 i = 1; i < completeActiveAuctions.totalPages; i++)
            {
                downloadTasks.Add(GetAHPage(i));
            }

            Task.WaitAll(downloadTasks.ToArray());

            foreach (var item in downloadTasks)
            {
                if(item.Result.success == false)
                {
                    throw new Exception("NotAllAHDownloadWasSuccesfull");
                }
                completeActiveAuctions.auctions.AddRange(item.Result.auctions);
            }
            responde.Dispose();
            return completeActiveAuctions;
        }

        private static async Task<ActiveAuctions> GetAHPage(UInt16 page)
        {
            var responde = await httpClient.GetAsync($"https://api.hypixel.net/skyblock/auctions?page={page}");
            if (!responde.IsSuccessStatusCode) throw new Exception("BazaarDownloadWasNotSuccefull");
            return JsonSerializer.Deserialize<ActiveAuctions>(await responde.Content.ReadAsStringAsync());
        }
    }

    
}