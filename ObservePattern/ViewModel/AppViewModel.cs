using ObservePattern.Command;
using ObservePattern.Model;
using ObservePattern.Pattern;
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

        public Store store = new Store();

        public AppViewModel()
        {
            

            AddCostumerCommand = new RelayCommand((e) =>
            {
                if (ControlMail.Control(Email))
                {                    
                    store.Attach(new Customer {
                        ProductName = ProductName,
                        EmailAdress = Email
                    });                    
                    
                    MessageBox.Show("Customer successfully added");
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
                store.Notify();
                MessageBox.Show("Message sending");
            });



        }


    }
}
