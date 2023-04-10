using System;
using System.Text;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using Spectre;
using Spectre.Console;
using System.Threading.Tasks;

namespace WebClient
{
  static class Program
  {
    private static string[] choices = { "Получить клиента по id", "Добавить клиента", "Выход" };
    private static string[] firstNames = { "Иван", "Петр", "Михаил", "Александр", "Николай", "Дмитрий" };
    private static string[] lastNames = { "Грозный", "Великий", "Тишайший", "Освободитель", "Палкин", "Донской" };
    private static HttpClient httpClient = new HttpClient();
    static Task Main(string[] args) 
    {
      try
      {
        System.Net.ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
        httpClient.BaseAddress = new Uri("https://loclhost:5000/");

        for (; ; )
        {
          var Selection = new SelectionPrompt<int>().Title("Что будем делать?").AddChoices(new[] { 1, 2, 3 });
          Selection.UseConverter<int>((x => choices[x - 1]));

          switch (AnsiConsole.Prompt(Selection))
          {
            case 1:
              {
                AnsiConsole.WriteLine("Ищем... результат:");
                GetCustomerById(AnsiConsole.Ask<string>("Введите id"));
              }  break;
            case 2:
              {
                AnsiConsole.WriteLine("Добавляем... результат:");
                SendCustomer();
              }  break;
            case 3:
              {
                httpClient.Dispose(); 
                return Task.CompletedTask;
              }
          }
          AnsiConsole.WriteLine();
        }        
      }
      catch(Exception ex) 
      {
        Console.WriteLine(ex.ToString());
        throw;
      }
    }

    private static void GetCustomerById(string id) 
    {
      
      var httpResponse = httpClient.GetAsync($"http://localhost:5000/customers/{id.Replace("\"","")}");
      if (httpResponse.Result.StatusCode == HttpStatusCode.OK)
      {
        var content = httpResponse.Result.Content.ReadAsStringAsync();
        AnsiConsole.Write(new Panel(content.Result).Header("Responce"));
      }
      else AnsiConsole.WriteLine("Ничего не нашли...");
     // AnsiConsole.Confirm("Продлжить?");
    }
    private static void SendCustomer()
    {
      
      var json = RandomCustomer().GetJson();
      var content = new StringContent(json, Encoding.UTF8, "application/json");
      string c = content.ToString();
      var httpResponse = httpClient.PostAsync("http://localhost:5000/customers/", content);
      if (httpResponse.Result.StatusCode == HttpStatusCode.OK)
      {
        var cnt = httpResponse.Result.Content.ReadAsStringAsync();
        GetCustomerById(cnt.Result);
      }
    }
    /*
      static Task Main(string[] args)
      {
          throw new NotImplementedException();
      }
  */
    private static CustomerCreateRequest RandomCustomer()
    {
      var r = new Random().Next(35);
      return new CustomerCreateRequest(firstNames[r / 6], lastNames[r % 6]);       
    }
  }
}