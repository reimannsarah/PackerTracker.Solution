using System.Collections.Generic;

namespace PackerTracker.Models
{
  public abstract class Gear
  {
    public string Name { get; set; }
    public float Weight { get; set; }
    public float Price { get; set; }
    // public int Id { get; set; }
    // public bool PurchaseStatus { get; set; }
    // public bool PackedStatus { get; set; }
    protected static List<Gear> _allGear = new List<Gear> { };

    public static List<Gear> GetGear()
    {
      return _allGear;
    }

    // public static Gear Find(int searchID)
    // {
    //   return _allGear[searchID - 1];
    // }
  }
}