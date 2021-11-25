
namespace DesignPatterns.StatePattern
{
    using UnityEngine.Assertions;
    using System.Collections.Generic;

    /// <summary>
    /// ���� ����
    /// ��ü�� ĸ��ȭ�Ͽ� ������ �������� �����ϴ� ����
    /// </summary>
    public class Context //Context
    {
        private Dictionary<string, IState> _dic = new Dictionary<string, IState>();

        public Context()
        {
            _dic.Add("order", new StateOrder());
            _dic.Add("pay", new StatePay());
            _dic.Add("ordered", new StateOrdered());
            _dic.Add("finish", new StateFinish());
        }

        public string Process(string order)
        {
            if (_dic.ContainsKey(order))
                return _dic[order].Process();
            return "��ϵ� Ű�� �����ϴ�";
        }
    }

    public interface IState //State
    {
        string Process();
    }

    public class StateOrder : IState //ConcreteState
    {
        public string Process()
        {
            return "�ֹ�";
        }
    }

    public class StatePay : IState //ConcreteState
    {
        public string Process()
        {
            return "����";
        }
    }

    public class StateOrdered : IState //ConcreteState
    {
        public string Process()
        {
            return "�ֹ���";
        }
    }

    public class StateFinish : IState //ConcreteState
    {
        public string Process()
        {
            return "����";
        }
    }

}