using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using DesignPatterns;
using DesignPatterns.FactoryPattern;

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

        var soupGen = DesignPatterns.FactoryPattern.FoodMaker.GetInstance<Soup>();
        var breadGen = DesignPatterns.FactoryPattern.FoodMaker.GetInstance<Bread>();

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
}
