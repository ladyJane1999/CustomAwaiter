using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CustomAwaiter
{
    public class MyObject
    {
        public MyAwaiter1 GetAwaiter()
        {
            return new MyAwaiter1();
        }

        public int SetCompleted()
        {
            return Thread.CurrentThread.ManagedThreadId;
        }
    }

    public struct MyAwaiter1 : INotifyCompletion
    {
        public void OnCompleted(Action continuation)
        {
            continuation();
        }
        public bool IsCompleted { get; private set; }

        public void GetResult()
        {
            Thread.Sleep(2000);
        }
    }
}
