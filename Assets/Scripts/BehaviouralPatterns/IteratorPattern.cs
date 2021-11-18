namespace DesignPatterns.IteratorPattern
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// �ݺ��� ����
    /// ���α����� �������� �ʰ� ����ü�� ���� ���� ��ü�� ���������� ������ �� �ִ� ����� ����
    /// </summary>
    
    public interface IIterator //Iterator
    {
        bool HasNext();
        Food Next();
    }

    public class Iterator : IIterator //Iterator1
    {
        private List<Food> _list = new List<Food>();
        private int _index = 0;

        public Iterator(Food[] foods)
        {
            _index = 0;
            _list.AddRange(foods);
        }

        public bool HasNext()
        {
            return _index < _list.Count;
        }

        public Food Next()
        {
            if(_index < _list.Count)
                return _list[_index++];
            throw new System.Exception();
        }

    }

    public interface IBucket //Aggregate
    {
        IIterator CreateIterator();
    }

    public class Bucket : IBucket //Aggregate1
    {
        private Food[] foods;
        public Bucket(params string[] arr)
        {
            foods = new Food[arr.Length];
            for(int i = 0; i < arr.Length; i++)
            {
                foods[i] = new Food(arr[i]);
            }
        }

        public IIterator CreateIterator()
        {
            var iterator = new Iterator(foods);
            return iterator;
        }
    }

    public class Food
    {
        private string _name;
        public Food(string name)
        {
            _name = name;
        }

        public override string ToString()
        {
            return _name;
        }
    }
}