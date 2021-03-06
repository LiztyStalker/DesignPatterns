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
        var root = new DesignPatterns.CompositePattern.Box("큰박스");
        var box1 = new DesignPatterns.CompositePattern.Box("박스1");
//        var box2 = new DesignPatterns.CompositePattern.Box("박스2");


        var box11 = new DesignPatterns.CompositePattern.Box("박스11");

        var box111 = new DesignPatterns.CompositePattern.Box("박스111");
        var tray1 = new DesignPatterns.CompositePattern.Box("트레이1");
        var tray11 = new DesignPatterns.CompositePattern.Box("트레이11");

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
        Assert.AreEqual(source.ToString(), "수프+조미료첨가+소스첨가");
    }

    [Test]
    public void StructuralPatterns_FasadePattern()
    {
        var kitchen = new DesignPatterns.FasadePattern.Kitchen();
        kitchen.SetOrder("수프", "빵");
        kitchen.SetOrder("빵");
        Debug.Log(kitchen.ToString());
        Assert.AreEqual(kitchen.ToString(), "1번째 식사\n수프 100\n호밀빵 50\n2번째 식사\n호밀빵 50\n");
    }

    [Test]
    public void StructuralPatterns_FlyweightPattern()
    {
        var market = new DesignPatterns.FlyweightPattern.Market();
        var tomato1 = market.GetGoodsData("토마토", 10);
        var tomato2 = market.GetGoodsData("토마토", 7);
        var tomato3 = market.GetGoodsData("토마토", 10);
        var radish = market.GetGoodsData("무우", 5);
        var springonion = market.GetGoodsData("대파", 3);


        market.PutGoodsData(tomato1, 100);
        market.PutGoodsData(tomato2, 200);
        market.PutGoodsData(tomato3, 1000);
        market.PutGoodsData(radish, 200);
        market.PutGoodsData(springonion, 200);

        Debug.Log(market.ToBill());
    }
    
    [Test]
    public void StructuralPatterns_ProxyPattern()
    {
        DesignPatterns.ProxyPattern.Food tomato  = new DesignPatterns.ProxyPattern.Food("토마토", new System.DateTime(2020, 12, 1));
        DesignPatterns.ProxyPattern.Food pemican = new DesignPatterns.ProxyPattern.Food("페미컨", new System.DateTime(2120, 12, 1));

        DesignPatterns.ProxyPattern.IFood tomatoWrapper = new DesignPatterns.ProxyPattern.FoodWrapper(tomato);
        DesignPatterns.ProxyPattern.IFood pemicanWrapper = new DesignPatterns.ProxyPattern.FoodWrapper(pemican);

        Debug.Log(tomatoWrapper.ToString());
        Debug.Log(pemicanWrapper.ToString());
    }
}
