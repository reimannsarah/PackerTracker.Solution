using System;

namespace PackerTracker.Models
{
  public class Food : Gear
  {
    public DateOnly ExpirationDate;
    public string Category { get; set; }

    public Food(string name, int weight, int price, bool purchasedStat, bool packedStat, string category)
    {
      Name = name;
      Weight = weight;
      Price = price;
      PurchaseStatus = purchasedStat;
      PackedStatus = packedStat;
      Category = category;
    }

    public DateOnly SetDate(int year, int month, int day)
    {
      return ExpirationDate = new DateOnly(year, month, day);
    }
  }
}