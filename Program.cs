using System;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace ApiTest
{
  class Program
  {
    static void Main()
    {
      var apiCallTask = ApiHelper.ApiCall(("..."));
      var result = apiCallTask.Result;
      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      List<Article> articleList = JsonConvert.DeserializeObject<List<Article>>(jsonResponse["results"].ToString());

      foreach (Article article in articleList)
      {
        Console.WriteLine($"Section: {article.Section}");
        Console.WriteLine($"Title: {article.Title}");
        Console.WriteLine($"Abstract: {article.Abstract}");
        Console.WriteLine($"Url: {article.Url}");
        Console.WriteLine($"Byline: {article.Byline}");
      }
    }
    class ApiHelper
    {
      public static async Task<string> ApiCall(string apikey)
      {
        RestClient client = new RestClient("https://api.nytimes.com/svc/topstories/v2");
        RestRequest request = new RestRequest($"home.json?api-key={...}", Method.GET);
        var response = await client.ExecuteTaskAsync(request);
        return response.Content;
      }
    }
  }