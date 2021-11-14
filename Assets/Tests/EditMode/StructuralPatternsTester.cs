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

    [Test]
    public void StructuralPatterns_CompositePattern()
    {
        var root = new DesignPatterns.CompositePattern.Box("ū�ڽ�");
        var box1 = new DesignPatterns.CompositePattern.Box("�ڽ�1");
//        var box2 = new DesignPatterns.CompositePattern.Box("�ڽ�2");


        var box11 = new DesignPatterns.CompositePattern.Box("�ڽ�11");

        var box111 = new DesignPatterns.CompositePattern.Box("�ڽ�111");
        var tray1 = new DesignPatterns.CompositePattern.Box("Ʈ����1");
        var tray11 = new DesignPatterns.CompositePattern.Box("Ʈ����11");

        box1.Add(box11);

        box11.Add(box111);
        box111.Add(tray11);
        box11.Add(tray1);

        root.Add(box1);

        Debug.Log(root.ToString());

    }

    [Test]
    public void StructuralPatterns_DecoratorPattern()
    {
        var soup = new DesignPatterns.DecoratorPattern.Soup();

        var seasoning = new DesignPatterns.DecoratorPattern.Seasoning(soup);
        var source = new DesignPatterns.DecoratorPattern.Source(seasoning);

        Debug.Log(source.ToString());
        Assert.AreEqual(source.ToString(), "����+���̷�÷��+�ҽ�÷��");
    }
}
