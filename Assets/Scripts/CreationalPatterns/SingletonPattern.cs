namespace DesignPatterns
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    //��ü ���� ������ 1���� �����ϴ� ����
    public class FoodMarket{
        private static FoodMarket _current;

        public static FoodMarket current
        {
            get
            {
                if (_current == null)
                {
                    _current = new FoodMarket();
                }
                return _current;
            }
        }

        private FoodMarket()
        {
            Debug.Log("���Ļ��� ����");
        }

        public override string ToString()
        {
            return "���Ļ���";
        }
    }
}