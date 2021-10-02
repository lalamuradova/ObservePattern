using ObservePattern.Command;
using ObservePattern.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ObservePattern.ViewModel
{
    public class AppViewModel : BaseViewModel
    {
        private string productname;      
        
        public string ProductName
        {
            get { return productname; }
            set { productname = value; OnPropertyChanged(); }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; OnPropertyChanged(); }
        }
        public RelayCommand AddCostumerCommand { get; set; }
        public RelayCommand NotifyAllCommand { get; set; }
        public List<Customer> customers { get; set; } = new List<Customer>();
       

        public AppViewModel()
        {
            //MusicPlayer musicPlayer = new MusicPlayer();
            //musicPlayer.ChangeState(new OffState());

            //DotCommand = new RelayCommand((e) =>
            //{

            //    if (!Toggled)
            //    {
            //        musicPlayer.ChangeState(new OnState());
            //        Dot.Fill = On;
            //        Toggled = true;
            //        Dot.Margin = RightSide;
            //        click = true;
            //    }
            //    else
            //    {
            //        musicPlayer.ChangeState(new OffState());
            //        Dot.Fill = Off;
            //        Toggled = false;
            //        Dot.Margin = LeftSide;
            //        click = false;

            //    }
            //});

            //PauseCommand = new RelayCommand((e) =>
            //{
            //    if (path != null)
            //    {
            //        player.Pause();
            //    }
            //    else
            //    {
            //        MessageBox.Show("File not found");
            //    }
            //}, (p) =>
            //{

            //    return musicPlayer.GetCanPause();
            //});

            AddCostumerCommand = new RelayCommand((e) =>
            {
                if (ControlMail.Control(Email))
                {
                    Customer customer = new Customer
                    {
                        ProductName = ProductName,
                        EmailAdress = Email
                    };
                    customers.Add(customer);
                    MessageBox.Show("Email successfully added");
                    ProductName = string.Empty;
                    Email = string.Empty;
                }
                else
                {
                    MessageBox.Show("Email format not true ");
                }
                
            });

           

            NotifyAllCommand = new RelayCommand((e) =>
            {
                foreach (var customer in customers)
                {
                    SendMail.Send(customer.EmailAdress);
                }
            });



        }


    }
}
