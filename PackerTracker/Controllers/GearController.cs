using Microsoft.AspNetCore.Mvc;
using PackerTracker.Models;
using System.Collections.Generic;

namespace PackerTracker.Controllers
{
  public class GearController : Controller
  {

    [HttpGet("/gear")]
    public ActionResult Index()
    {
      List<Gear> allGear = Gear.GetGear();
      return View(allGear);
    }

    // [HttpGet("/gear/new")]
    // public ActionResult New()
    // {
    //   return View();
    // }

    // [HttpPost("/gear")]
    // public ActionResult Create(string description)
    // {
    //   Item myItem = new Item(description);
    //   return RedirectToAction("Index");
    // }

    // [HttpPost("/gear/delete")]
    // public ActionResult DeleteAll()
    // {
    //   Item.ClearAll();
    //   return View();
    // }

    [HttpGet("/gear/{id}")]
    public ActionResult Show(int id)
    {
      Gear foundGear = Gear.Find(id);
      return View(foundGear);
    }
  }
}