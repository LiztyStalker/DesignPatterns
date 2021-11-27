namespace DesignPatterns.TemplateMethodPattern
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// ���ø� �޼��� ����
    /// �޼��带 �̿��� �� �ܰ踦 ���ø� ����ȭ�ϰ� �ൿ�� ����
    /// </summary>
    public abstract class Work //AbstractClass
    {
        public void Process()
        {
            Move();
            Check();
            Working();
            Return();
        }

        protected abstract void Move();
        protected abstract void Check();
        protected abstract void Working();
        protected abstract void Return();
    }


    public class CompanyWork : Work //SubClass
    {
        protected override void Check()
        {
            Debug.Log("ȸ�� �⼮");
        }

        protected override void Move()
        {
            Debug.Log("ȸ��� �̵�");
        }

        protected override void Return()
        {
            Debug.Log("������ ���");
        }

        protected override void Working()
        {
            Debug.Log("���ϱ�");
        }
    }

    public class HomeWork : Work //SubClass
    {
        protected override void Check()
        {
            Debug.Log("������ �⼮");
        }

        protected override void Move()
        {
            Debug.Log("��ǻ�� ����");
        }

        protected override void Return()
        {
            Debug.Log("��ǻ�� ����");
        }

        protected override void Working()
        {
            Debug.Log("������ ���ϱ�");
        }
    }
}