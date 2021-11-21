namespace DesignPatterns.VisitorPattern
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// �湮�� ����
    /// ����� ��ü�� ������ ������ ó���� �и��ϴ� ����
    /// </summary>

    public interface ICart //Element
    {
        string name { get; }
        int price { get; }
        string Accept(IVisitor visitor);
    }

    public class Cart : ICart // ConcreteElement
    {

        private string _name;
        private int _price;

        public string name => _name;
        public int price => _price;

        public Cart(string name, int price)
        {
            _name = name;
            _price = price;
        }

        public string Accept(IVisitor visitor)
        {
            return visitor.Order(this);
        }
    }

    public interface IVisitor //Visitor
    {
        int TotalPrice { get; }
        int TotalNumber { get; }
        string Order(ICart cart);
    }

    public class Visitant : IVisitor //ConcreteVisitor
    {
        private ICart _cart;
        private int _totalPrice;
        private int _totalNumber;
        public int TotalPrice => _totalPrice;
        public int TotalNumber => _totalNumber;

        public string Order(ICart cart)
        {
            _cart = cart;
            _totalPrice += _cart.price;
            _totalNumber++;
            return $"{_cart.name} {_cart.price}";
        }

    }
}