using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using DesignPatterns;

public class StructuralPatternsTester
{
    [Test]
    public void StructuralPatterns_AdapterPattern()
    {
        var mixer = DesignPatterns.AdapterPattern.Kitchen.GetInstance();
        mixer.Mix(10f);
        mixer.Mix(20f);
        mixer.Mix(30f);
        Debug.Log(mixer.Value);
        Assert.AreEqual(mixer.Value, 60f);
    }

    [Test]
    public void StructuralPatterns_BridgePattern()
    {
        var mortar = DesignPatterns.BridgePattern.Kitchen.GetInstance("Mortar");
        var foodProcesser = DesignPatterns.BridgePattern.Kitchen.GetInstance("FoodProcesser");

        mortar.Cook(5);
        mortar.Cook(10);

        foodProcesser.Cook(20f);
        foodProcesser.Cook(10f);

        Debug.Log(mortar.GetValue());
        Debug.Log(foodProcesser.GetValue());
        Assert.AreEqual(mortar.GetValue(), 15f);
        Assert.AreEqual(foodProcesser.GetValue(), 30f);


    }
}
