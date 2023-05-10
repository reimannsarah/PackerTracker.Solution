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
    public ActionResult Create(string name, float weight, float price, bool purchasedStatus, bool packedStatus, string category)
    {
      Food newFood = new Food(name, weight, price, purchasedStatus, packedStatus, category);
      return RedirectToAction("Index");
    }

    [HttpGet("/food/{id}")]
    public ActionResult Show(int id)
    {
      Food foundFood = Food.Find(id);
      return View("Index", foundFood);
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