using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MessageBoard.Models
{
  public class Message
  {
    public int MessageId { get; set; }
    
    // public string UserId { get; set; }
    // public int GroupId { get; set; }
    // [Required(ErrorMessage = "Text is required.")]
    public string Text { get; set; }
    public DateTime Date { get; set; }

    // public ApplicationUser User { get; set; }
    // public Group Group { get; set; }

    public static List<Message> GetMessages()
    {
      var apiCallTask = ApiHelper.GetAllMessages();
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Message> messagesList = JsonConvert.DeserializeObject<List<Message>>(jsonResponse.ToString());

      return messagesList;
    }

    public static Message GetMessageDetails(int id)
    {
      var apiCallTask = ApiHelper.GetMessage(id);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Message message = JsonConvert.DeserializeObject<Message>(jsonResponse.ToString());

      return message;
    }

    public static void PostMessage(Message message)
    {
      string jsonMessage = JsonConvert.SerializeObject(message);
      ApiHelper.PostMessage(jsonMessage);
    }

     public static void PutMessage(Message message)
    {
      string jsonMessage = JsonConvert.SerializeObject(message);
      ApiHelper.PutMessage(message.MessageId, jsonMessage);
    }

    public static void DeleteMessage(int id)
    {
      ApiHelper.DeleteMessage(id);
    }
  }
}