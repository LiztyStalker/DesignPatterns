namespace DesignPatterns.BuilderPattern
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;



    /// <summary>
    /// ���� ����
    /// �߻����丮 ������ Ȯ���Ͽ� ũ�� ������ ��ü�� ������ �� �ִ� ����
    /// </summary>
    /// 
    public abstract class FoodMaker //(Director)
    {
        protected Recipe _recipe;

        public void SetRecipe(Recipe recipe)
        {
            Debug.Log("������ ����");
            _recipe = recipe;
        }

        public Food GetInstance() => _recipe.GetInstance();

        public abstract FoodMaker Build();
    }

    public class Oven : FoodMaker
    {
        public Oven(Recipe recipe)
        {
            Debug.Log("�������Ǳ� ����");
            if(_recipe == null) _recipe = recipe;
        }

        public override FoodMaker Build()
        {
            _recipe.SetSeasoning(new Seasoning("�ұ�", 5, 0, 0, 0, 0, 5));
            _recipe.SetMeat(new Meat("�ҵ��", 250, 100));
            _recipe.SetVegetable(new Vegetable("����", 100, 100));
            _recipe.SetLiquid(new Liquid("��⸧", 40));
            return this;
        }
    }


    public abstract class Recipe //(Builder)
    {
        protected Food _food;
        public abstract void SetSeasoning(Seasoning seasoning);
        public abstract void SetMeat(Meat meat);
        public abstract void SetVegetable(Vegetable vegetable);
        public abstract void SetLiquid(Liquid liquid);
        public Food GetInstance() => _food;
    }

    public class BakeRecipe : Recipe //(ConcreteBuilder)
    {
        public BakeRecipe()
        {
            _food = new Food();
        }

        public override void SetLiquid(Liquid liquid)
        {
            _food.SetData(liquid);
        }

        public override void SetMeat(Meat meat)
        {
            _food.SetData(meat);
        }

        public override void SetSeasoning(Seasoning seasoning)
        {
            _food.SetData(seasoning);
        }

        public override void SetVegetable(Vegetable vegetable)
        {
            _food.SetData(vegetable);
        }
    }


    public class Food //(Product)
    {
        private List<Seasoning> _seasonings = new List<Seasoning>();
        private List<Meat> _meats = new List<Meat>();
        private List<Vegetable> _vegetables = new List<Vegetable>();
        private List<Liquid> _liquid = new List<Liquid>();


        public override string ToString()
        {
            return $"{ToString(_seasonings.ToArray())}{ToString(_meats.ToArray())}{ToString(_vegetables.ToArray())}{ToString(_liquid.ToArray())}";
        }

        public void SetData(Seasoning seasoning)
        {
            _seasonings.Add(seasoning);
        }

        public void SetData(Meat meat)
        {
            _meats.Add(meat);
        }

        public void SetData(Vegetable vegetable)
        {
            _vegetables.Add(vegetable);
        }

        public void SetData(Liquid liquid)
        {
            _liquid.Add(liquid);
        }

        private string ToString<T>(T[] list) where T : FoodMaterial
        {
            var str = "";
            for (int i = 0; i < list.Length; i++)
            {
                str += list[i].ToString() + "\n";
            }
            return str;
        }
        

    }

    public abstract class FoodMaterial
    {
        private string _name;
        private int _value;

        public string name => _name;
        public int value => _value;

        public FoodMaterial(string name, int value)
        {
            _name = name;
            _value = value;
        }

        public override string ToString()
        {
            return $"{_name} : {_value}";
        }
    }


    public class Seasoning : FoodMaterial
    {
        private int _spicyValue;
        private int _sourValue;
        private int _saltValue;
        private int _sweetValue;
        private int _bitterValue;

        public int spicyValue => _spicyValue;
        public int sourValue => _sourValue;
        public int saltValue => _saltValue;
        public int sweetValue => _sweetValue;
        public int bitterValue => _bitterValue;

        public Seasoning(string name, int value, int spicy, int sour, int sweet, int bitter, int salt) : base(name, value)
        {
            _spicyValue = spicy;
            _sourValue = sour;
            _sweetValue = sweet;
            _bitterValue = bitter;
            _saltValue = salt;
            Debug.Log("����� ����");
        }


    }

    public class Meat : FoodMaterial
    {
        private int _freshValue;
        public int freshValue => _freshValue;

        public Meat(string name, int value, int freshValue) : base(name, value)
        {
            _freshValue = freshValue;
            Debug.Log("���� ����");
        }
    }

    public class Vegetable : FoodMaterial
    {
        private int _freshValue;
        public int freshValue => _freshValue;
        public Vegetable(string name, int value, int freshValue) : base(name, value)
        {
            _freshValue = freshValue;
            Debug.Log("��ä ����");
        }
    }

    public class Liquid : FoodMaterial
    {
        public Liquid(string name, int value) : base(name, value)
        {
            Debug.Log("��ü ����");
        }
    }
}