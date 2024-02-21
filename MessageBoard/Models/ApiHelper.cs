using System.Threading.Tasks;
using RestSharp;

namespace MessageBoard.Models
{
  public class ApiHelper
  {
    private static RestClient client = new RestClient("http://localhost:5000/");

    public static async Task<string> GetAllMessages()
    {
      RestClient client = new RestClient("http://localhost:5000/");
      RestRequest request = new RestRequest($"api/messages", Method.Get);
      RestResponse response = await client.GetAsync(request);
      return response.Content;
    }

    public static async Task<string> GetMessage(int id)
    {
      RestClient client = new RestClient("http://localhost:5000/");
      RestRequest request = new RestRequest($"api/messages/{id}", Method.Get);
      RestResponse response = await client.GetAsync(request);
      return response.Content;
    }

    public static async void PostMessage(string newMessage)
    {
      RestClient client = new RestClient("http://localhost:5000/");
      RestRequest request = new RestRequest($"api/messages", Method.Post);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newMessage);
      await client.PostAsync(request);
    }

    public static async void PutMessage(int id, string newMessage)
    {
      RestClient client = new RestClient("http://localhost:5000/");
      RestRequest request = new RestRequest($"api/messages/{id}", Method.Put);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newMessage);
      await client.PutAsync(request);
    }

    public static async void DeleteMessage(int id)
    {
      RestClient client = new RestClient("http://localhost:5000/");
      RestRequest request = new RestRequest($"api/messages/{id}", Method.Delete);
      request.AddHeader("Content-Type", "application/json");
      await client.DeleteAsync(request);
    }

    public static async Task<string> SignInUser(string _userId)
    {
      RestClient client = new RestClient("http://localhost:5000/");
      RestRequest request = new RestRequest($"api/accounts/SignIn/{_userId}", Method.Get);
      RestResponse response = await client.GetAsync(request);
      return response.Content;
    }

    public static async Task<string> RegisterUser(string user)
    {
      RestClient client = new RestClient("http://localhost:5000/");
      RestRequest request = new RestRequest($"api/accounts/Register", Method.Post);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(user);
      RestResponse response = await client.PostAsync(request);
      return response.Content;
    }

    public static async Task<string> GetAllGroups()
        {
            RestRequest request = new RestRequest($"api/groups", Method.Get);
            RestResponse response = await client.GetAsync(request);
            return response.Content;
        }

        public static async Task<string> GetGroup(int id)
        {
            RestRequest request = new RestRequest($"api/groups/{id}", Method.Get);
            RestResponse response = await client.GetAsync(request);
            return response.Content;
        }

        public static async Task PostGroup(Group group)
        {
            RestRequest request = new RestRequest($"api/groups", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(group); // Assuming group can be serialized directly
            await client.PostAsync(request);
        }

        public static async Task PutGroup(int id, Group group)
        {
            RestRequest request = new RestRequest($"api/groups/{id}", Method.Put);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(group); // Assuming group can be serialized directly
            await client.PutAsync(request);
        }

        public static async Task DeleteGroup(int id)
        {
            RestRequest request = new RestRequest($"api/groups/{id}", Method.Delete);
            request.AddHeader("Content-Type", "application/json");
            await client.DeleteAsync(request);
        }
  }
}
