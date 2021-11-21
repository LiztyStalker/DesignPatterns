using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class BehaviouralPatternsTester
{
    [Test]
    public void BehaviouralPatterns_IteratorPattern()
    {
        var bucket = new DesignPatterns.IteratorPattern.Bucket("토마토", "참외", "바나나", "과자");
        var iterator = bucket.CreateIterator();

        while (iterator.HasNext())
        {
            Debug.Log(iterator.Next());
        }
    }

    [Test]
    public void BehaviouralPatterns_CommandPattern()
    {
        var invoker = new DesignPatterns.CommandPattern.Invoker();
        var human = new DesignPatterns.CommandPattern.Human();

        var getCmd = new DesignPatterns.CommandPattern.GetCommand(human);
        var dropCmd = new DesignPatterns.CommandPattern.DropCommand(human);
        var showCmd = new DesignPatterns.CommandPattern.ShowCommand(human);

        invoker.SetCommand("집기", getCmd);
        invoker.SetCommand("버리기", dropCmd);
        invoker.SetCommand("보기", showCmd);

        invoker.Execute("집기", "마늘");
        Debug.Log(invoker.Execute("보기"));
        invoker.Execute("버리기", "마늘");
        Debug.Log(invoker.Execute("보기"));
    }

    [Test]
    public void BehaviouralPatterns_VisitorPattern()
    {
        DesignPatterns.VisitorPattern.ICart cart1 = new DesignPatterns.VisitorPattern.Cart("토마토", 100);
        DesignPatterns.VisitorPattern.ICart cart2 = new DesignPatterns.VisitorPattern.Cart("감자", 200);
        DesignPatterns.VisitorPattern.ICart cart3 = new DesignPatterns.VisitorPattern.Cart("양파", 50);

        DesignPatterns.VisitorPattern.IVisitor visitant = new DesignPatterns.VisitorPattern.Visitant();

        Debug.Log(cart1.Accept(visitant));
        Debug.Log(cart2.Accept(visitant));
        Debug.Log(cart3.Accept(visitant));

        Debug.Log($"{visitant.TotalNumber} {visitant.TotalPrice}");
    }

}
