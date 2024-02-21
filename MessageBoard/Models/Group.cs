using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MessageBoard.Models
{
  public class Group
  {
    public int GroupId { get; set; }
    public string Topic { get; set; }


    public static List<Group> GetGroups()
    {
      var apiCallTask = ApiHelper.GetAllGroups();
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Group> groupsList = JsonConvert.DeserializeObject<List<Group>>(jsonResponse.ToString());

      return groupsList;
    }

    public static Group GetDetails(int id)
    {
      var apiCallTask = ApiHelper.GetGroup(id);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Group group = JsonConvert.DeserializeObject<Group>(jsonResponse.ToString());

      return group;
    }

    public static async void PostGroup(Group group)
    {
      string jsonGroup = JsonConvert.SerializeObject(group);
      await ApiHelper.PostGroup(group);
    }

     public static void PutGroup(Group group)
    {
      // string jsonGroup = JsonConvert.SerializeObject(group);
      ApiHelper.PutGroup(group.GroupId, group);
    }

    public static void DeleteGroup(int id)
    {
      ApiHelper.DeleteGroup(id);
    }
  }
}