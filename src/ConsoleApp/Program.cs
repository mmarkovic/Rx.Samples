namespace ConsoleApp
{
    using System;
    using System.Reactive.Concurrency;
    using System.Reactive.Disposables;
    using System.Reactive.Linq;
    using System.Threading;

    class Program
    {
        static void Main(string[] args)
        {
            IObservable<long> intervalSubject = Observable.Interval(TimeSpan.FromMilliseconds(150));
            intervalSubject
                .Sample(TimeSpan.FromSeconds(1))
                .Subscribe(x => Console.WriteLine("Received: {0}", x));

            Thread.Sleep(TimeSpan.FromSeconds(4));
        }
    }

    public class SampleListener<T> : IObserver<T>
    {
        public void OnNext(T value)
        {
            Console.WriteLine("Received: {0}", value);
        }

        public void OnError(Exception error)
        {
            Console.WriteLine("Error: {0}", error);
        }

        public void OnCompleted()
        {
            Console.WriteLine("Completed!");
        }
    }

    public class SampleNumberSender : IObservable<int>
    {
        public IDisposable Subscribe(IObserver<int> observer)
        {
            observer.OnNext(1);
            observer.OnNext(2);
            observer.OnNext(3);
            observer.OnCompleted();
            return Disposable.Empty;
        }
    }

}
