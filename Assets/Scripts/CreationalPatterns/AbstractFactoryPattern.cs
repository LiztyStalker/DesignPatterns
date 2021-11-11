namespace DesignPatterns.AbstractFactoryPattern
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// �߻� ���丮 ����
    /// ���丮 �޼��� ������ Ȯ����
    /// ū �Ը��� ��ü���� �����ϴ� ����
    /// </summary>
    public abstract class FoodMaker
    {
        public abstract Dessert CreateDessert();
        public abstract Meal CreateMeal();

        public abstract override string ToString();
    }
    

    public class KoreanStyleFoodVendingMachine : FoodMaker
    {
        public KoreanStyleFoodVendingMachine()
        {
            Debug.Log("�ѽ����Ǳ� ����");
        }

        public override Dessert CreateDessert()
        {
            return new KoreanStyleDessert();
        }

        public override Meal CreateMeal()
        {
            return new KoreanStyleMeal();
        }
        public override string ToString()
        {
            return "�ѽ����Ǳ�";
        }
    }

    public class WesternStyleFoodVendingMachine : FoodMaker
    {
        public WesternStyleFoodVendingMachine()
        {
            Debug.Log("������Ǳ� ����");
        }

        public override Dessert CreateDessert()
        {
            return new WesternStyleDessert();
        }

        public override Meal CreateMeal()
        {
            return new WesternStyleMeal();
        }
        public override string ToString()
        {
            return "������Ǳ�";
        }

    }






    #region ##### Meal #####

    public abstract class Meal
    {
        public abstract override string ToString();
    }


    public class KoreanStyleMeal : Meal
    {
        public KoreanStyleMeal()
        {
            Debug.Log("�ѽ� ����");
        }
        public override string ToString()
        {
            return "����";
        }
    }

    public class WesternStyleMeal : Meal
    {
        public WesternStyleMeal()
        {
            Debug.Log("��� ����");
        }
        public override string ToString()
        {
            return "�Ľ�Ÿ";
        }
    }

    #endregion






    #region ##### Dessert #####

    public abstract class Dessert
    {
        public abstract override string ToString();

    }


    public class KoreanStyleDessert : Dessert
    {
        public KoreanStyleDessert()
        {
            Debug.Log("�ѽ� ����Ʈ ����");
        }

        public override string ToString()
        {
            return "������";
        }
    }

    public class WesternStyleDessert : Dessert
    {
        public WesternStyleDessert()
        {
            Debug.Log("��� ����Ʈ ����");
        }
        public override string ToString()
        {
            return "Ǫ��";
        }
    }

    #endregion

}