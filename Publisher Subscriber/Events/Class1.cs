using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    public delegate void MyEventHanlder(string message);
    public class MyEvents
    {
        event MyEventHanlder myEventHanlder;    //Define

        void onEvent()
        {
            myEventHanlder?.Invoke("Event raised");
        }

        public void EntryPoint()
        {
            myEventHanlder += delegate (string msg) {
                Console.WriteLine(msg);
            };
            onEvent();
        }
    }

    public class Publisher
    {
        public event MyEventHanlder LeftClick;  //Defining of event

        public void OnLeftClick(string msg)   //Firing the event
        {
            LeftClick?.Invoke(msg);
        }

        public event MyEventHanlder RightClick;
        public void OnRightClick(string msg)   //Firing the event
        {
            RightClick?.Invoke(msg);
        }
    }

    public class WindowsSubscriber
    {
        public void SubscribeLeftClick(Publisher p)
        {
            p.LeftClick += (msg) => Console.WriteLine(msg + "by WindowsSubscriber");
        }

        public void SubscribeRightClick(Publisher p)
        {
            p.RightClick += (msg) => Console.WriteLine(msg + "by WindowsSubscriber");
        }
    }

    public class MacSubscriber
    {
        public void SubscribeLeftClick(Publisher p) //Registering Event and Performing Action 
        {
            p.LeftClick += (msg) => Console.WriteLine(msg + "by MacSubscriber");
        }

        public void SubscribeRightClick(Publisher p)
        {
            p.RightClick += (msg) => Console.WriteLine(msg + "by MacSubscriber");
        }
    }
    public class MyEventArgs : EventArgs
    {
        public int count = 0;
    }
    public class MyArrayList : ArrayList    //Publisher
    {
        public event Action<object, MyEventArgs> Added; //Defining of event
        MyEventArgs e = new MyEventArgs();
        public override int Add(object value)   //Raising Event
        {
            e.count = Count + 1;
            Added?.Invoke(this,e);
            return base.Add(value);
        }
    }
}
