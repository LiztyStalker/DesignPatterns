namespace DesignPatterns.FasadePattern
{
    using System.Collections.Generic;
    using UnityEngine;
    using FoodPackage;


    public class Kitchen
    {
        private List<Meal> _meals = new List<Meal>();

        public void SetOrder(params string[] orders)
        {
            if (orders.Length > 0)
            {
                var meal = new Meal($"{(_meals.Count + 1)}��° �Ļ�");
                for (int i = 0; i < orders.Length; i++)
                {
                    switch (orders[i])
                    {
                        case "����":
                            AddFood(meal, new Soup("����", 100));
                            break;
                        case "��":
                            AddFood(meal, new Bread("ȣ�л�", 50));
                            break;
                        default:
                            Debug.LogError("�ش� �ֹ� ������ �����ϴ�.");
                            break;

                    }
                }
                _meals.Add(meal);
            }
            else
            {
                Debug.LogError("�ֹ��� ������ϴ�");
            }

        }

        private void AddFood(Meal meal, Food food)
        {
            meal.AddFood(food);
        }

        public override string ToString()
        {
            var str = "";
            for (int i = 0; i < _meals.Count; i++)
            {
                str += _meals[i].ToString();
            }
            return str;
        }
    }

    #region ##### FoodPackage #####

    namespace FoodPackage
    {

        internal class Meal
        {

            private string _order;
            private List<Food> _food = new List<Food>();

            internal Meal(string order)
            {
                _order = order;
            }

            internal void AddFood(Food food)
            {
                _food.Add(food);
            }

            public override string ToString()
            {
                var str = _order + "\n";
                for (int i = 0; i < _food.Count; i++)
                {
                    str += _food[i].ToString();
                }
                return str;
            }
        }

        internal abstract class Food
        {
            private string _name;
            private int _value;
            internal Food(string name, int value)
            {
                _name = name;
                _value = value;
            }

            public override string ToString()
            {
                return $"{_name} {_value}\n";
            }
        }

        internal class Soup : Food
        {
            internal Soup(string name, int value) : base(name, value)
            {

            }
        }

        internal class Bread : Food
        {
            internal Bread(string name, int value) : base(name, value)
            {

            }
        }
    }

    #endregion
}