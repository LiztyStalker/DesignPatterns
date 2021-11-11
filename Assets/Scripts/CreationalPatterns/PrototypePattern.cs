namespace DesignPatterns.PrototypePattern
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// ������Ÿ�� ����
    /// ��ü�� ���� �������� �ʰ� ������ �ִ� ��ü�� �����ϴ� ����
    /// </summary>
    public class Pasture
    {
        List<Animal> _list = new List<Animal>();

        private Pasture()
        {
            Animal chicken = new Chicken("��", 5);
            Animal duck = new Chicken("����", 3);

            _list.Add(chicken);
            _list.Add(duck);

            _list.Add(chicken.Clone());
            _list.Add(chicken.Clone());
            _list.Add(chicken.Clone());

            _list.Add(duck.Clone());
        }

        public static Pasture GetInstance()
        {
            return new Pasture();
        }

        public override string ToString()
        {
            var str = "";
            for(int i = 0; i < _list.Count; i++)
            {
                str += $"{_list[i].name} : {_list[i].age}\n";
            }
            return str;
        }       

    }

    public abstract class Animal //Prototype
    {
        protected string _name;
        protected int _age;

        public string name => _name;
        public int age => _age;

        public Animal(string name, int age)
        {
            _name = name;
            _age = age;
        }

        public abstract Animal Clone();
    }


    public class Chicken : Animal //ConcretePrototype
    {

        public Chicken(string name, int age) : base(name, age)
        {
            Debug.Log("�� ����");
        }

        public override Animal Clone()
        {
            return new Chicken(name, age);
        }
    }

    public class Duck : Animal //ConcretePrototype
    {
        public Duck(string name, int age) : base(name, age)
        {
            Debug.Log("���� ����");
        }
        public override Animal Clone()
        {
            return new Duck(name, age);
        }
    }




}