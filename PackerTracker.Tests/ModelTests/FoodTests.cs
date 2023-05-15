using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using PackerTracker.Models;
using System;

namespace PackerTracker.Tests
{
  [TestClass]
  public class FoodTests : IDisposable
  {
    public IConfiguration Configuration { get; set; }

    public void Dispose()
    {
      Food.ClearList();
    }

    public FoodTests()
    {
      IConfigurationBuilder builder = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json");
      Configuration = builder.Build();
      DBConfiguration.ConnectionString = Configuration["ConnectionStrings:TestConnection"];
    }

    [TestMethod]
    public void GetAll_ReturnsEmptyListFromDatabase_FoodList()
    {
      List<Food> newList = new List<Food> {};
      List<Food> result = Food.GetList();
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void ReferenceTypes_ReturnsTrueBecauseBothFoodsAreSameReference_bool()
    {
      Food firstFood = new Food("scruge", 8, 9, "snack");
      Food copyOfFirstFood = firstFood;
      copyOfFirstFood.Name = "scruge";
      Assert.AreEqual(firstFood.Name, copyOfFirstFood.Name);
    }

    [TestMethod]
    public void Equals_ReturnsTrueIfFoodsAreTheSame_Food()
    {
      Food firstFood = new Food("prankle", 26, 2, "dinner");
      Food secondfood = new Food("prankle", 26, 2, "dinner");
      Assert.AreEqual(firstFood, secondfood);
    }
    // [TestMethod]
    // public void FoodConstructor_CreatesInstanceOfFood_Food()
    // {
    //   Food newFood = new Food("food", 1, 2, "snack");
    //   Assert.AreEqual(typeof(Food), newFood.GetType());
    // }

    // [TestMethod]
    // public void SetDate_AddsADateToAFood_DateOnly()
    // {
    //   Food newFood = new Food("food", 1, 2, "snack");
    //   DateOnly result = new DateOnly(1999, 9, 25);
    //   DateOnly expected = newFood.SetDate(1999, 9, 25);
    //   Assert.AreEqual(result, expected);
    // }

    // [TestMethod]
    // public void GetList_GetsListOfFoods_List()
    // {
    //   Food newFood = new Food("food", 1, 2, "snack");
    //   List<Food> result = new List<Food> {newFood};
    //   CollectionAssert.AreEqual(result, Food.GetList());
    // }
  }
}