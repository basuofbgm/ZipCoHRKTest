using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Zip.Backend.Models;

namespace Zip.Backend.APIService
{
  public class DogimageFetchService
  {
    public async static Task<IEnumerable<RandomDogEntryModel>> FetchDogRandownimages()
    {
      var _dogs = new List<RandomDogEntryModel>();
      string _URI = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("CustomAPPConfigs")["RandomDogUrl"].ToString();  //"https://random.dog/woof.json";  
      for (int i = 0; i < 8; i++)
      {
        using HttpClient client = new HttpClient();
        using HttpResponseMessage response = await client.GetAsync(_URI);
        var result = await response.Content.ReadAsAsync<RandomDogEntryModel>();   
       _dogs.Add(result);
      }
      return _dogs;
    }
  }
}
