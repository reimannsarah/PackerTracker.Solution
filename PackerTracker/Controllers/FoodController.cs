using Microsoft.AspNetCore.Mvc;
using PackerTracker.Models;
using System.Collections.Generic;

namespace PackerTracker.Controllers
{
  public class FoodController : Controller
  {

    [HttpGet("/food/new")]
    public ActionResult New()
    {
      return View();
    }

    // [HttpGet("/food/new")]
    // public ActionResult New()
    // {
    //   return View();
    // }

    // [HttpPost("/food")]
    // public ActionResult Create(string description)
    // {
    //   Item myItem = new Item(description);
    //   return RedirectToAction("Index");
    // }

    // [HttpPost("/food/delete")]
    // public ActionResult DeleteAll()
    // {
    //   Item.ClearAll();
    //   return View();
    // }

    // [HttpGet("/food/{id}")]
    // public ActionResult Show(int id)
    // {
    //   Item foundItem = Item.Find(id);
    //   return View(foundItem);
    // }
  }
}