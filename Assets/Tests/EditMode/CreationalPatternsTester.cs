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

        Assert.AreEqual(soup.ToString(), "수프");
        Assert.AreEqual(bread.ToString(), "빵");

        var soupGen = DesignPatterns.FactoryPattern.FoodMaker.GetInstance<DesignPatterns.FactoryPattern.Soup>();
        var breadGen = DesignPatterns.FactoryPattern.FoodMaker.GetInstance<DesignPatterns.FactoryPattern.Bread>();

        Debug.Log(soupGen.ToString());
        Debug.Log(breadGen.ToString());

        Assert.AreEqual(soupGen.ToString(), "수프");
        Assert.AreEqual(breadGen.ToString(), "빵");
       
    }

    [Test]
    public void CreationalPatterns_SingletonPattern()
    {
        var market = FoodMarket.current;
        Debug.Log(market.ToString());
        Assert.AreEqual(market.ToString(), "음식상점");
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

        Assert.AreEqual(vendingMachine.ToString(), "음식자판기");
        Assert.AreEqual(soup.ToString(), "수프");
        Assert.AreEqual(bread.ToString(), "빵");
    }

    [Test]
    public void CreationalPatterns_AbstractFactoryPattern()
    {
        DesignPatterns.AbstractFactoryPattern.FoodMaker koreanStyleVendingMachine = new DesignPatterns.AbstractFactoryPattern.KoreanStyleFoodVendingMachine();
        DesignPatterns.AbstractFactoryPattern.FoodMaker westernStyleVendingMachine = new DesignPatterns.AbstractFactoryPattern.WesternStyleFoodVendingMachine();

        Debug.Log(koreanStyleVendingMachine.ToString());
        Debug.Log(westernStyleVendingMachine.ToString());

        Assert.AreEqual(koreanStyleVendingMachine.ToString(), "한식자판기");
        Assert.AreEqual(westernStyleVendingMachine.ToString(), "양식자판기");

        var koMeal = koreanStyleVendingMachine.CreateMeal();
        var koDessert = koreanStyleVendingMachine.CreateDessert();
        var weMeal = westernStyleVendingMachine.CreateMeal();
        var weDessert = westernStyleVendingMachine.CreateDessert();

        Debug.Log(koMeal.ToString());
        Debug.Log(koDessert.ToString());
        Debug.Log(weMeal.ToString());
        Debug.Log(weDessert.ToString());

        Assert.AreEqual(koMeal.ToString(), "국밥");
        Assert.AreEqual(koDessert.ToString(), "수정과");
        Assert.AreEqual(weMeal.ToString(), "파스타");
        Assert.AreEqual(weDessert.ToString(), "푸딩");

    }

    [Test]
    public void CreationalPatterns_BuilderPattern()
    {
        var recipe = new DesignPatterns.BuilderPattern.BakeRecipe();
        var builder = new DesignPatterns.BuilderPattern.Oven(recipe);
        var food = builder.Build().GetInstance();
        Debug.Log(food.ToString());
        Assert.AreEqual(food.ToString(), "소금 : 5\n소등심 : 250\n양파 : 100\n콩기름 : 40\n");
    }

    [Test]
    public void CreationalPatterns_PrototypePattern()
    {
        var pasture = DesignPatterns.PrototypePattern.Pasture.GetInstance();
        Debug.Log(pasture.ToString());
        Assert.AreEqual(pasture.ToString(), "닭 : 5\n오리 : 3\n닭 : 5\n닭 : 5\n닭 : 5\n오리 : 3\n");
    }
}
