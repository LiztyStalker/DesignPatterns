namespace DesignPatterns.DecoratorPattern
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// ���ڷ����� ����
    /// ��ü�� ���� ����� �߰��ϱ� ���� ������ �����ϴ� ����
    /// </summary>
    public interface IFood // Component
    {
        string ToString();
    }

    public class Soup : IFood
    {
        public override string ToString()
        {
            return "����";
        }
    }

    public abstract class Decorator : IFood
    {
        protected IFood _food;

        public Decorator(IFood food)
        {
            _food = food;
        }
        public abstract override string ToString();
    }

    public class Seasoning : Decorator
    {
        public Seasoning(IFood food) : base(food)
        {
        }
        public override string ToString()
        {
            return _food.ToString() + "+���̷�÷��";
        }
    }

    public class Source : Decorator
    {
        public Source(IFood food) : base(food)
        {
        }
        public override string ToString()
        {
            return _food.ToString() + "+�ҽ�÷��";
        }
    }
}