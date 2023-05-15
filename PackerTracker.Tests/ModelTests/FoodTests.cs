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
      Food firstFood = new Food("scrujj", 8, 9, "snack");
      Food copyOfFirstFood = firstFood;
      copyOfFirstFood.Name = "scrujj";
      Assert.AreEqual(firstFood.Name, copyOfFirstFood.Name);
    }

    [TestMethod]
    public void Equals_ReturnsTrueIfFoodsAreTheSame_Food()
    {
      Food firstFood = new Food("prankle", 26, 2, "dinner");
      Food secondfood = new Food("prankle", 26, 2, "dinner");
      Assert.AreEqual(firstFood, secondfood);
    }

    [TestMethod]
    public void Save_SavesToDatabse_FoodList()
    {
      Food testFood = new Food("cranjjoexr", 13, 0.2F, "breunlch");
      testFood.Save();
      List<Food> result = Food.GetList();
      List<Food> testList = new List<Food>{testFood};
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void GetAll_ReturnsFoods_FoodList()
    {
      Food newFood1 = new Food("corn", 69.69F, 1.24F, "snack");
      Food newFood2 = new Food("scrorn", 3, 5, "breakfast");
      newFood1.Save();
      newFood2.Save();
      List<Food> newFoodList = new List<Food> { newFood1, newFood2 };
      List<Food> result = Food.GetList();
      CollectionAssert.AreEqual(newFoodList, result);
    }
  }
}