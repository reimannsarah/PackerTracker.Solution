namespace PackerTracker.Models
{
  public abstract class Gear
  {
    public string Name { get; set; }
    public float Weight { get; set; }
    public float Price { get; set; }
    public bool PurchaseStatus { get; set; }
    public bool PackedStatus { get; set; }

  }
}