using System;
using System.Collections.Generic;

namespace PackerTracker.Models
{
  public class Food : Gear
  {
    public DateOnly ExpirationDate;
    public string Category { get; set; }
    private static List<Food> _instances = new List<Food> {};

    public enum CategoryType {
      Snack,
      Breakfast,
      Lunch,
      Dinner,
      Drink
    }

    public Food(string name, int weight, int price, bool purchasedStat, bool packedStat, string category)
    {
      Name = name;
      Weight = weight;
      Price = price;
      PurchaseStatus = purchasedStat;
      PackedStatus = packedStat;
      Category = category;
      _instances.Add(this);
    }

    public DateOnly SetDate(int year, int month, int day)
    {
      return ExpirationDate = new DateOnly(year, month, day);
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