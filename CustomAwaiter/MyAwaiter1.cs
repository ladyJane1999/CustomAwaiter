using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CustomAwaiter
{
    public class MyAwaiter
    {
        TaskCompletionSource<Action> TaskCompletionSource = new TaskCompletionSource<Action>() ;
        private int hhh;
     
        public async void SetCompleted()
         {
           
            var act = TaskCompletionSource.Task.Result;
            
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            act();
           
          
        }
 
        public MyAwaiter1 GetAwaiter()
        {
            Thread.Sleep(2000);
            return new MyAwaiter1(TaskCompletionSource);
        }

    }

    public struct MyAwaiter1 : INotifyCompletion
    {
        private TaskCompletionSource<Action> taskCompletionSource;

        public int Awaiter { get; }

        public MyAwaiter1(int awaiter) : this()
        {
            Awaiter = awaiter;
        }

        public MyAwaiter1(TaskCompletionSource<Action> taskCompletionSource) : this()
        {
            this.taskCompletionSource = taskCompletionSource;
        }

        public void OnCompleted(Action continuation)
        {
            taskCompletionSource.SetResult(continuation);   
   
        }
        public bool IsCompleted { get; private set; }
        
        public void GetResult()
        {
        }
    }
}
