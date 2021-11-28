namespace DesignPatterns.StrategyPattern
{

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

   
    /// <summary>
    /// ���� ����
    /// ��ü ���ο��� �ذ��ؾ� �ϴ� ������ �˰��� ��ü�� �и� �����ϴ� ���
    /// </summary>

    public class Kitchen
    {
        private ICook _cook;
        public void SetStrategy(ICook cook)
        {
            _cook = cook;
        }

        public string Cook(Food food)
        {
            return _cook.Cook(food);
        }

        public Food CreateFood(string name)
        {
            return new Food(name);
        }
        
    }


    public interface ICook
    {
        string Cook(Food food);
    }

    public class BoilCook : ICook
    {
        public string Cook(Food food)
        {
            return $"{food.Name} : ������";
        }
    }

    public class FriCook : ICook
    {
        public string Cook(Food food)
        {
            return $"{food.Name} : ������";
        }
    }


    public class Food
    {
        private string _name;

        public string Name => _name;
        public Food(string name)
        {
            _name = name;
        }
    }

}