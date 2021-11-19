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

}
