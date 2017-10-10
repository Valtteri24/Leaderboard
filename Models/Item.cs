using System;

namespace gameapi.Models
{
  public class Item
  {
    public Guid Id { get; set; }
    public int Level { get; set; }
    public int Price { get; set; }
  }

  public class NewItem
  {
    public int Level { get; set; }
  }

  public class ModifiedItem
  {
    public int Price { get; set; }
  }
}