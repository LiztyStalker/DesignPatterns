namespace DesignPatterns.ProxyPattern
{
    using System;

    /// <summary>
    /// ���Ͻ� ����
    /// ��ü ������ �����ϱ� ���� �߰� �ܰ迡 �븮�ڸ� ��ġ��Ű�� ����
    /// </summary>

    public interface IFood
    {
        string ToString();
    }

    public class Food : IFood
    {
        private string _name;
        private DateTime _shelfLife;

        public DateTime shelfLife => _shelfLife;

        public Food(string name, DateTime shelfLife)
        {
            _name = name;
            _shelfLife = shelfLife;
        }

        public override string ToString()
        {
            return $"{_name} {_shelfLife.Year}-{_shelfLife.Month}-{_shelfLife.Day}";
        }
    }

    public class FoodWrapper : IFood
    {
        private Food _food;

        public FoodWrapper(Food food)
        {
            _food = food;
        }

        public override string ToString()
        {
            var compare = DateTime.Compare(_food.shelfLife, DateTime.Now);
            if(compare < 0)
            {
                return $"{_food.ToString()} / {DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day} ���߽��ϴ�.";
            }
            else
            {
                return $"{_food.ToString()} / {DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day} ������ �ʾҽ��ϴ�.";
            }
        }
    }


}