using System;


namespace RecipeDatabase
{
    public class Dish
    {
        private string _id;
        private string _name;
        private double _price;

        public void GetDishes()
        {
            _id = "01";
            _name = "烤八目鳗";
            _price = 30.0;
            Console.WriteLine($"{_name} 的价格是 {_price}元");
        }
    }
}
