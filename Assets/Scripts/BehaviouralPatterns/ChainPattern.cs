namespace DesignPatterns.ChainPattern
{

    /// <summary>
    /// ü�� ����
    /// ��ü �޽����� �۽Ű� ������ �и��ؼ� ó��
    /// </summary>
    public class Sender
    { 
        public string Execute(string msg)
        {
            var handler = new Order();
            handler.SetNext(new Cancel());
            return handler.Request(msg);
        }
    }

    public abstract class Handler
    {
        protected Handler _handler;

        public void SetNext(Handler handler)
        {
            _handler = handler;
        }

        public abstract string Request(string msg);
    }

    public class Order : Handler
    {
        public override string Request(string msg)
        {
            if (msg == "Order")
                return "�ֹ� �Ǿ���";
            return _handler.Request(msg);
        }

    }


    public class Cancel : Handler
    {
        public override string Request(string msg)
        {
            if (msg == "Cancel")
                return "��� �Ǿ���";
            return _handler.Request(msg);
        }
    }
}