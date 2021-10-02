using ObservePattern.Model;
using ObservePattern.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ObservePattern
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public AppViewModel ViewModel { get; set; } 
        public MainWindow()
        {
            InitializeComponent();
            ViewModel = new AppViewModel();
            this.DataContext = ViewModel;
        }

        public interface IObserver
        {
            void Update(ISubject subject);
        }

        public interface ISubject
        {
            void Attach(IObserver observer);
            void Detach(IObserver observer);
            void Notify();
        }



        public class Subject : ISubject
        {
            public int State { get; set; } = 0;
            private List<IObserver> _observers = new List<IObserver>();
            public void Attach(IObserver observer)
            {
                Console.WriteLine("Subject: Attached an observer.");
                this._observers.Add(observer);
            }
            public void Detach(IObserver observer)
            {
                this._observers.Remove(observer);
                Console.WriteLine("Subject: Detached an observer.");
            }
            public void Notify()
            {
                Console.WriteLine("Subject: Notifying observers...");
                foreach (var observer in _observers)
                {
                    observer.Update(this);
                }
            }



            public void SomeBusinessLogic()
            {
                Console.WriteLine("\nSubject: I'm doing something important.");
                this.State = new Random().Next(0, 10);

                Thread.Sleep(15);
                Console.WriteLine("Subject: My state has just changed to: " + this.State);
                this.Notify();
            }
        }



        class ConcreteObserverA : IObserver
        {
            public void Update(ISubject subject)
            {
                if ((subject as Subject).State <= 1)
                {
                    Console.WriteLine("ConcreteObserverA: Reacted to the event.");
                }
            }
        }





        class ConcreteObserverB : IObserver
        {
            public void Update(ISubject subject)
            {
                if ((subject as Subject).State <= 1)
                {
                    Console.WriteLine("ConcreteObserverB: Reacted to the event.");
                }
            }
        }





        //class Program
        //{
        //    static void Main(string[] args)
        //    {
        //        var subject = new Subject();
        //        var observerA = new ConcreteObserverA();
        //        subject.Attach(observerA);



        //        var observerB = new ConcreteObserverB();
        //        subject.Attach(observerB);



        //        subject.SomeBusinessLogic();
        //        subject.SomeBusinessLogic();



        //        subject.Detach(observerB);



        //        subject.SomeBusinessLogic();
        //    }
        //}


    }


}

