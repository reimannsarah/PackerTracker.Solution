using MySqlConnector;
using System;
using System.Collections.Generic;

namespace PackerTracker.Models
{
  public class Food : Gear
  {
    public DateOnly ExpirationDate;
    public string Category { get; set; }
    public int Id { get; set; }

    public enum CategoryType
    {
      Snack,
      Breakfast,
      Lunch,
      Dinner,
      Drink
    }

    public Food(string name, float weight, float price, string category)
    {
      Name = name;
      Weight = weight;
      Price = price;
      Category = category;
    }
    public Food(string name, float weight, float price, string category, int id)
    {
      Name = name;
      Weight = weight;
      Price = price;
      Category = category;
      Id = id;
    }

    public override bool Equals(System.Object otherFood)
    {
      if (!(otherFood is Food))
      {
        return false;
      }
      else
      {
        Food newFood = (Food) otherFood;
        bool nameEquality = (this.Name == newFood.Name && this.Weight == newFood.Weight && this.Price == newFood.Price && this.Category == newFood.Category);
        return nameEquality;
      }
    }

    public override int GetHashCode()
    {
      return Id.GetHashCode();
    }

    public DateOnly SetDate(int year, int month, int day)
    {
      return ExpirationDate = new DateOnly(year, month, day);
    }

    public static Food Find(int searchID)
    {
      Food placeholderFood = new Food("scurge", 8, 35, "snack");
      return placeholderFood;
    }

    public static void ClearList()
    {
      MySqlConnection conn = new MySqlConnection(DBConfiguration.ConnectionString);
      conn.Open();

      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = "DELETE FROM food;";
      cmd.ExecuteNonQuery();

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static List<Food> GetList()
    {
      List<Food> allFood = new List<Food> { };
      MySqlConnection conn = new MySqlConnection(DBConfiguration.ConnectionString);
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = "SELECT * FROM food;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while (rdr.Read())
      {
        int foodId = rdr.GetInt32(0);
        string name = rdr.GetString(1);
        int weight = rdr.GetInt32(2);
        int price = rdr.GetInt32(3);
        string category = rdr.GetString(4);
        Food newFood = new Food(name, weight, price, category, foodId);
        allFood.Add(newFood);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allFood;
    }


  }
}
