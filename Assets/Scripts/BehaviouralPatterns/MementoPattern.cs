namespace DesignPatterns.MementoPattern
{
    using System.Collections.Generic;

    /// <summary>
    /// �޸��� ����
    /// ��ü�� ���¸� �����Ͽ� ���� ���·� �����ϴ� ����
    /// </summary>
    public class Caretaker ///Caretaker
    {
        private Stack<Memento> _stack = new Stack<Memento>();

        public void Push(Originator origin)
        {
            var memento = origin.CreateMemento();
            _stack.Push(memento);
        }

        public MessageData Undo(Originator origin)
        {
            var memento = _stack.Pop();
            origin.Restore(memento);
            return origin.GetState();
        }
    }


    public class Originator //Originator
    {
        private MessageData _data;

        public Memento CreateMemento()
        {
            return new Memento(_data);
        }

        public void Restore(Memento memento)
        {
            _data = memento.GetObject();
        }

        public MessageData GetState()
        {
            return _data;
        }

        public void SetState(MessageData data)
        {
            _data = data;
        }
    }

    public class Memento //Memento
    {
        private MessageData _data;

        public Memento(MessageData data)
        {
            _data = data.Clone();
        }

        public MessageData GetObject()
        {
            return _data;
        }
    }


    public class MessageData
    {
        private string _msg;
        public MessageData(string msg)
        {
            _msg = msg;
        }

        public void SetMessage(string msg)
        {
            _msg = msg;
        }

        public MessageData Clone()
        {
            return new MessageData(_msg);
        }

        public string Message => _msg;
    }    
}