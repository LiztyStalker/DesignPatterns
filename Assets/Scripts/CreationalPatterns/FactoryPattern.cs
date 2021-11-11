namespace DesignPatterns.FactoryPattern
{
    using System;
    using UnityEngine;

    /// <summary>
    /// ���丮 ����
    /// ��ü ������ �����մϴ�
    /// </summary>
    public class FoodMaker
    {
        public static T GetInstance<T>() where T : Food
        {
            return Activator.CreateInstance<T>();
        }

        public static Food GetInstance(string name)
        {
            switch (name)
            {
                case "Soup":
                    return new Soup();
                case "Bread":
                    return new Bread();
            }
            Debug.LogWarning($"{name}�� �����ϴ� Ŭ���� �̸��� �����ϴ�");
            return null;
        }
    }



    public abstract class Food
    {
        public override abstract string ToString();
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