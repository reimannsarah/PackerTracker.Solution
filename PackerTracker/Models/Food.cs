using System;
using System.Collections.Generic;

namespace PackerTracker.Models
{
  public class Food : Gear
  {
    public DateOnly ExpirationDate;
    public string Category { get; set; }
    public int Id { get; }
    private static List<Food> _instances = new List<Food> { };

    public enum CategoryType
    {
      Snack,
      Breakfast,
      Lunch,
      Dinner,
      Drink
    }

    public Food(string name, float weight, float price, bool purchasedStatus, bool packedStatus, string category)
    {
      Name = name;
      Weight = weight;
      Price = price;
      PurchaseStatus = purchasedStatus;
      PackedStatus = packedStatus;
      Category = category;
      _instances.Add(this);
      Id = _instances.Count;
    }

    public DateOnly SetDate(int year, int month, int day)
    {
      return ExpirationDate = new DateOnly(year, month, day);
    }

    public static Food Find(int searchID)
    {
      return _instances[searchID - 1];
    }

    public static void ClearList()
    {
      _instances.Clear();
    }

    public static List<Food> GetList()
    {
      return _instances;
    }
  }
}