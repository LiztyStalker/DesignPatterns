namespace DesignPatterns.FactoryMethodPattern
{
    using UnityEngine;

    /// <summary>
    /// ���丮 �޼ҵ� ����
    /// 
    /// </summary>
    public abstract class FoodMaker
    {             
        protected abstract Food CreateInstance(string name);

        public Food Create(string name)
        {
            return CreateInstance(name);
        }

        // ���丮 ����
        public static FoodMaker GetInstance()
        {
            return new FoodVendingMachine();
        }
    }

    public sealed class FoodVendingMachine : FoodMaker
    {

        public FoodVendingMachine()
        {
            Debug.Log("�������Ǳ� ����");
        }

        protected override Food CreateInstance(string name)
        {
            switch (name)
            {
                case "Soup":
                    return new Soup();
                case "Bread":
                    return new Bread();
            }
            return null;
        }

        public override string ToString()
        {
            return "�������Ǳ�";
        }
    }


    public abstract class Food
    {
        public abstract override string ToString();
    }

    public class Soup : Food
    {
        public override string ToString()
        {
            return "����";
        }
    }

    public class Bread : Food
    {
        public override string ToString()
        {
            return "��";
        }
    }


}