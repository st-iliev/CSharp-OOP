using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Core
{
    public class Controller : IController
    {
        private ICollection<IBakedFood> bakedFoods;
        private ICollection<IDrink> drinks;
        private ICollection<ITable> tables;
        private decimal totalIncome;
        public Controller()
        {
            this.bakedFoods = new List<IBakedFood>();
            this.drinks = new List<IDrink>();
            this.tables = new List<ITable>();
        }
        public string AddDrink(string type, string name, int portion, string brand)
        {
            IDrink drink = null;
            if (type == nameof(Tea))
            {
                drink = new Tea(name,portion,brand);
            }
            else if (type == nameof(Water))
            {
                drink = new Water(name, portion, brand);
            }
            if (drink != null)
            {
                drinks.Add(drink);
                return $"Added {name} ({drink.GetType().Name}) to the drink menu";
            }
            return null;
        }

        public string AddFood(string type, string name, decimal price)
        {
            IBakedFood food = null;
           if (type == nameof(Bread))
            {
                 food = new Bread(name, price);
            }
           else if (type == nameof(Cake))
            {
                 food = new Cake(name, price);
            }
           if (food != null)
            {
                bakedFoods.Add(food);
                return $"Added {name} ({food.GetType().Name}) to the menu";
            }
            return null;
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table = null;
            if (type == nameof(InsideTable))
            {
                table = new InsideTable(tableNumber, capacity);
            }
            else if (type == nameof(OutsideTable))
            {
                table = new OutsideTable(tableNumber, capacity);
            }
            if (table != null)
            {
                tables.Add(table);
                return $"Added table number {tableNumber} in the bakery";
            }
            return null;
        }

        public string GetFreeTablesInfo()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var table in tables.Where(s=>!s.IsReserved))
            {
                sb.AppendLine(table.GetFreeTableInfo());
            }
            return sb.ToString().TrimEnd();
        }

        public string GetTotalIncome()
        {
           
            return $"Total income: {totalIncome:f2}lv";
        }

        public string LeaveTable(int tableNumber)
        {
            ITable table = tables.FirstOrDefault(s => s.TableNumber == tableNumber);
           decimal tableBill = table.GetBill();
            totalIncome += tableBill;
            table.Clear();
            return $"Table: {tableNumber}\r\nBill: {tableBill:f2}";

        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            ITable table = tables.FirstOrDefault(s => s.TableNumber == tableNumber);
            if (table == null)
            {
                return $"Could not find table {tableNumber}";
            }
            IDrink drink = drinks.FirstOrDefault(s => s.Name == drinkName && s.Brand == drinkBrand);
            if (drink == null)
            {
                return $"There is no {drinkName} {drinkBrand} available";
            }
            table.OrderDrink(drink);
            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            ITable table = tables.FirstOrDefault(s => s.TableNumber == tableNumber);
            if (table == null)
            {
                return $"Could not find table {tableNumber}";
            }
            IBakedFood food = bakedFoods.FirstOrDefault(s => s.Name == foodName);
            if (food == null)
            {
                return $"No {foodName} in the menu";
            }
            table.OrderFood(food);
            return $"Table {tableNumber} ordered {foodName}";
        }

        public string ReserveTable(int numberOfPeople)
        {
            ITable table = tables.FirstOrDefault(s =>!s.IsReserved  && s.Capacity >= numberOfPeople);
            if (table != null)
            {
                table.Reserve(numberOfPeople);
              return $"Table {table.TableNumber} has been reserved for {numberOfPeople} people";
            }
            return $"No available table for {numberOfPeople} people";
        }
    }
}
