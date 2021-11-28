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

    [Test]
    public void BehaviouralPatterns_ChainPattern()
    {
        var sender = new DesignPatterns.ChainPattern.Sender();
        Debug.Log(sender.Execute("Order"));
        Debug.Log(sender.Execute("Cancel"));
    }

    [Test]
    public void BehaviouralPatterns_ObserverPattern()
    {
        DesignPatterns.ObserverPattern.ISubject market = new DesignPatterns.ObserverPattern.RetailStore();
        market.Attach(new DesignPatterns.ObserverPattern.Food("�丶��", 1000));
        market.Attach(new DesignPatterns.ObserverPattern.Food("����", 500));
        market.Attach(new DesignPatterns.ObserverPattern.Food("����", 750));

        market.Notify();

        Debug.Log(market.ToString());

    }

    [Test]
    public void BehaviouralPatterns_MediatorPattern()
    {
        DesignPatterns.MadiatorPattern.Mediator mediator = new DesignPatterns.MadiatorPattern.Server();

        DesignPatterns.MadiatorPattern.Colleague user1 = new DesignPatterns.MadiatorPattern.User("Steve");
        user1.SetMediator(mediator);
        mediator.AddColleague(user1);

        DesignPatterns.MadiatorPattern.Colleague user2 = new DesignPatterns.MadiatorPattern.User("John");
        user2.SetMediator(mediator);
        mediator.AddColleague(user2);

        DesignPatterns.MadiatorPattern.Colleague user3 = new DesignPatterns.MadiatorPattern.User("Glave");
        user3.SetMediator(mediator);
        mediator.AddColleague(user3);

        user1.Send("������1");
        user2.Send("������2");
        user3.Send("������3");
    }

    [Test]
    public void BehaviouralPatterns_StatePattern()
    {
        var context = new DesignPatterns.StatePattern.Context();

        Debug.Log(context.Process("order"));
        Debug.Log(context.Process("pay"));
        Debug.Log(context.Process("ordered"));
        Debug.Log(context.Process("finish"));
        Debug.Log(context.Process("other"));

    }


    [Test]
    public void BehaviouralPatterns_MementoPattern()
    {
        var caretaker = new DesignPatterns.MementoPattern.Caretaker();
        var origin = new DesignPatterns.MementoPattern.Originator();

        var msg = new DesignPatterns.MementoPattern.MessageData("�޸���1");

        Debug.Log(msg.Message);

        origin.SetState(msg);
        caretaker.Push(origin);

        msg.SetMessage("�޸���2");
        Debug.Log(msg.Message);
        origin.SetState(msg);
        caretaker.Push(origin);

        msg.SetMessage("�޸���3");
        Debug.Log(msg.Message);
        origin.SetState(msg);
        caretaker.Push(origin);

        msg = caretaker.Undo(origin);
        Debug.Log(msg.Message);

        msg = caretaker.Undo(origin);
        Debug.Log(msg.Message);

        msg = caretaker.Undo(origin);
        Debug.Log(msg.Message);

    }

    [Test]
    public void BehaviouralPatterns_TemplateMethodPattern()
    {
        DesignPatterns.TemplateMethodPattern.Work company = new DesignPatterns.TemplateMethodPattern.CompanyWork();
        company.Process();

        DesignPatterns.TemplateMethodPattern.Work home = new DesignPatterns.TemplateMethodPattern.HomeWork();
        home.Process();
    }

    [Test]
    public void BehaviouralPatterns_StrategyPattern()
    {
        var boil = new DesignPatterns.StrategyPattern.BoilCook();
        var fri = new DesignPatterns.StrategyPattern.FriCook();

        var kitchen = new DesignPatterns.StrategyPattern.Kitchen();
        kitchen.SetStrategy(boil);

        var food = kitchen.CreateFood("���");

        Debug.Log(kitchen.Cook(food));

        kitchen.SetStrategy(fri);

        Debug.Log(kitchen.Cook(food));

    }
}

