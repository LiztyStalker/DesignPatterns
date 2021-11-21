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
        var bucket = new DesignPatterns.IteratorPattern.Bucket("�丶��", "����", "�ٳ���", "����");
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

        invoker.SetCommand("����", getCmd);
        invoker.SetCommand("������", dropCmd);
        invoker.SetCommand("����", showCmd);

        invoker.Execute("����", "����");
        Debug.Log(invoker.Execute("����"));
        invoker.Execute("������", "����");
        Debug.Log(invoker.Execute("����"));
    }

    [Test]
    public void BehaviouralPatterns_VisitorPattern()
    {
        DesignPatterns.VisitorPattern.ICart cart1 = new DesignPatterns.VisitorPattern.Cart("�丶��", 100);
        DesignPatterns.VisitorPattern.ICart cart2 = new DesignPatterns.VisitorPattern.Cart("����", 200);
        DesignPatterns.VisitorPattern.ICart cart3 = new DesignPatterns.VisitorPattern.Cart("����", 50);

        DesignPatterns.VisitorPattern.IVisitor visitant = new DesignPatterns.VisitorPattern.Visitant();

        Debug.Log(cart1.Accept(visitant));
        Debug.Log(cart2.Accept(visitant));
        Debug.Log(cart3.Accept(visitant));

        Debug.Log($"{visitant.TotalNumber} {visitant.TotalPrice}");
    }

}
