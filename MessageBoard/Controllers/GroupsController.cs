using Microsoft.AspNetCore.Mvc;
using MessageBoard.Models;

namespace MessageBoard.Controllers;

public class GroupsController : Controller
{
  public IActionResult Index()
  {
    List<Group> groups = Group.GetGroups();
    return View(groups);
  }

  public IActionResult Details(int id)
  {
    Group group = Group.GetDetails(id);
    return View(group);
  }

  public ActionResult Create()
  {
    return View();
  }

  [HttpPost]
  public ActionResult Create(Group group)
  {
    Group.PostGroup(group);
    return RedirectToAction("Index");
  }

    public ActionResult Edit(int id)
  {
    Group group = Group.GetDetails(id);
    return View(group);
  }

  [HttpPost]
  public ActionResult Edit(Group group)
  {
    Group.PutGroup(group);
    return RedirectToAction("Details", new { id = group.GroupId  });
  }

   public ActionResult DeleteGroup(int id)
  {
    Group group = Group.GetDetails(id);
    return View(group);
  }

  [HttpPost, ActionName("Delete")]
  public ActionResult DeleteConfirmed(int id)
  {
    Group.DeleteGroup(id);
    return RedirectToAction("Index");
  }
}
