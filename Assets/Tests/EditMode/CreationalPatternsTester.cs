using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using DesignPatterns;

public class CreationalPatternsTester
{


    [Test]
    public void CreationalPatterns_FactoryPatterns()
    {
        var soup = FoodMaker.GetInstance("Soup");
        var bread = FoodMaker.GetInstance("Bread");

        Debug.Log(soup.ToString());
        Debug.Log(bread.ToString());

        Assert.AreEqual(soup.ToString(), "¼öÇÁ");
        Assert.AreEqual(bread.ToString(), "»§");

        var soupGen = FoodMaker.GetInstance<Soup>();
        var breadGen = FoodMaker.GetInstance<Bread>();

        Debug.Log(soupGen.ToString());
        Debug.Log(breadGen.ToString());

        Assert.AreEqual(soupGen.ToString(), "¼öÇÁ");
        Assert.AreEqual(breadGen.ToString(), "»§");
       
    }
}
