using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using DesignPatterns;

public class CreationalPatternsTester
{


    [Test]
    public void CreationalPatterns_FactoryPattern()
    {
        var soup = DesignPatterns.FactoryPattern.FoodMaker.GetInstance("Soup");
        var bread = DesignPatterns.FactoryPattern.FoodMaker.GetInstance("Bread");

        Debug.Log(soup.ToString());
        Debug.Log(bread.ToString());

        Assert.AreEqual(soup.ToString(), "����");
        Assert.AreEqual(bread.ToString(), "��");

        var soupGen = DesignPatterns.FactoryPattern.FoodMaker.GetInstance<DesignPatterns.FactoryPattern.Soup>();
        var breadGen = DesignPatterns.FactoryPattern.FoodMaker.GetInstance<DesignPatterns.FactoryPattern.Bread>();

        Debug.Log(soupGen.ToString());
        Debug.Log(breadGen.ToString());

        Assert.AreEqual(soupGen.ToString(), "����");
        Assert.AreEqual(breadGen.ToString(), "��");
       
    }

    [Test]
    public void CreationalPatterns_SingletonPattern()
    {
        var market = FoodMarket.current;
        Debug.Log(market.ToString());
        Assert.AreEqual(market.ToString(), "���Ļ���");
    }

    [Test]
    public void CreationalPatterns_FactoryMethodPattern()
    {
        var vendingMachine = DesignPatterns.FactoryMethodPattern.FoodMaker.GetInstance();

        var soup = vendingMachine.Create("Soup");
        var bread = vendingMachine.Create("Bread");

        Debug.Log(vendingMachine.ToString());
        Debug.Log(soup.ToString());
        Debug.Log(bread.ToString());

        Assert.AreEqual(vendingMachine.ToString(), "�������Ǳ�");
        Assert.AreEqual(soup.ToString(), "����");
        Assert.AreEqual(bread.ToString(), "��");
    }

    [Test]
    public void CreationalPatterns_AbstractFactoryPattern()
    {
        DesignPatterns.AbstractFactoryPattern.FoodMaker koreanStyleVendingMachine = new DesignPatterns.AbstractFactoryPattern.KoreanStyleFoodVendingMachine();
        DesignPatterns.AbstractFactoryPattern.FoodMaker westernStyleVendingMachine = new DesignPatterns.AbstractFactoryPattern.WesternStyleFoodVendingMachine();

        Debug.Log(koreanStyleVendingMachine.ToString());
        Debug.Log(westernStyleVendingMachine.ToString());

        Assert.AreEqual(koreanStyleVendingMachine.ToString(), "�ѽ����Ǳ�");
        Assert.AreEqual(westernStyleVendingMachine.ToString(), "������Ǳ�");

        var koMeal = koreanStyleVendingMachine.CreateMeal();
        var koDessert = koreanStyleVendingMachine.CreateDessert();
        var weMeal = westernStyleVendingMachine.CreateMeal();
        var weDessert = westernStyleVendingMachine.CreateDessert();

        Debug.Log(koMeal.ToString());
        Debug.Log(koDessert.ToString());
        Debug.Log(weMeal.ToString());
        Debug.Log(weDessert.ToString());

        Assert.AreEqual(koMeal.ToString(), "����");
        Assert.AreEqual(koDessert.ToString(), "������");
        Assert.AreEqual(weMeal.ToString(), "�Ľ�Ÿ");
        Assert.AreEqual(weDessert.ToString(), "Ǫ��");

    }

    [Test]
    public void CreationalPatterns_BuilderPattern()
    {
        var recipe = new DesignPatterns.BuilderPattern.BakeRecipe();
        var builder = new DesignPatterns.BuilderPattern.Oven(recipe);
        var food = builder.Build().GetInstance();
        Debug.Log(food.ToString());
        Assert.AreEqual(food.ToString(), "�ұ� : 5\n�ҵ�� : 250\n���� : 100\n��⸧ : 40\n");
    }

    [Test]
    public void CreationalPatterns_PrototypePattern()
    {
        var pasture = DesignPatterns.PrototypePattern.Pasture.GetInstance();
        Debug.Log(pasture.ToString());
        Assert.AreEqual(pasture.ToString(), "�� : 5\n���� : 3\n�� : 5\n�� : 5\n�� : 5\n���� : 3\n");
    }
}
