using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using PackerTracker.Models;
using System;

namespace PackerTracker.Tests
{
  [TestClass]
  public class FoodTests : IDisposable
  {
    public void Dispose()
    {
      Food.ClearList();
    }

    [TestMethod]
    public void FoodConstructor_CreatesInstanceOfFood_Food()
    {
      Food newFood = new Food("food", 1, 2, "snack");
      Assert.AreEqual(typeof(Food), newFood.GetType());
    }

    [TestMethod]
    public void SetDate_AddsADateToAFood_DateOnly()
    {
      Food newFood = new Food("food", 1, 2, "snack");
      DateOnly result = new DateOnly(1999, 9, 25);
      DateOnly expected = newFood.SetDate(1999, 9, 25);
      Assert.AreEqual(result, expected);
    }

    [TestMethod]
    public void GetList_GetsListOfFoods_List()
    {
      Food newFood = new Food("food", 1, 2, "snack");
      List<Food> result = new List<Food> {newFood};
      CollectionAssert.AreEqual(result, Food.GetList());
    }
  }
}