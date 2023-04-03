using System.Net.Http;
using System.Threading.Tasks;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

class API{

    private static HttpClient client = new HttpClient();
    public static  void Main(){

        InitClient();
        //Post(GetTestData());
        Get(GetTestData());
        string input = Console.ReadLine();
        
    }

    static void InitClient(){

        client.BaseAddress = new Uri("http://192.168.2.100:1234");
    }

    static string GetTestData(){

        return "{\"user\":\"user\",\"pass\":\"1234\"}";
    }

    public static async void Post(string json){

        StringContent content = new StringContent(json, Encoding.UTF8, "application/json"); 
        HttpResponseMessage result = await client.PostAsync("push", content);
        string resultContent = await result.Content.ReadAsStringAsync();   
        Console.WriteLine(resultContent);
    }
    public static async void Get(string json){

        StringContent content = new StringContent(json, Encoding.UTF8, "application/json"); 
        HttpResponseMessage result = await client.GetAsync("pull");
        string resultContent = await result.Content.ReadAsStringAsync();   
        Console.WriteLine(resultContent);
    }  
}