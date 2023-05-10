using Microsoft.AspNetCore.Mvc;
using PackerTracker.Models;
using System.Collections.Generic;

namespace PackerTracker.Controllers
{
  public class FoodController : Controller
  {

    [HttpGet("/food")]
    public ActionResult Index()
    {
      List<Food> allFoods = Food.GetList();
      return View(allFoods);
    }

    [HttpGet("/food/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/food")]
    public ActionResult Create(string name, float weight, float price, string category)
    {
      Food newFood = new Food(name, weight, price, category);
      return RedirectToAction("Index");
    }

    [HttpGet("/food/{id}")]
    public ActionResult Show(int id)
    {
      Gear foundFood = Gear.Find(id);
      return View(foundFood);
    }

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