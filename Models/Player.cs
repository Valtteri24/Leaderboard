using System;
using System.ComponentModel.DataAnnotations;

namespace gameapi.Models
{
  public class Player
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Level { get; set; }
    public Item[] Items { get; set; }
  }

  public class NewPlayer
  {
    [Required]
    public string Name { get; set; }
  }

  public class ModifiedPlayer
  {
    [Required]
    public int Level{get;set;}
  }
}