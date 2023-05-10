namespace PackerTracker.Models
{
  public abstract class Gear
  {
    public string Name { get; set; }
    public int Weight { get; set; }
    public int Price { get; set; }
    public bool PurchaseStatus { get; set; }
    public bool PackedStatus { get; set; }

  }
}