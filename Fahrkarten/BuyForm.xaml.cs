using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Fahrkarten
{
    /// <summary>
    /// Interaktionslogik für BuyForm.xaml
    /// </summary>
    public partial class BuyForm : Window
    {
        public BuyForm(List<Ticket> ticketList, decimal price, decimal credit)
        {
            InitializeComponent();
            if (BuyFormLogic.CheckMoney(price, credit))
                CanPay(ticketList, price, credit);
            else
                CantPay(ticketList, price, credit);
        }

        private void CanPay(List<Ticket> ticketList, decimal price, decimal credit)
        {
            ButtonFinish.Content = "Beenden";
            DataGridTickets.ItemsSource = ticketList;
            LabelText.Content = BuyFormLogic.CreateTextCanPay(price, credit);
        }

        

        private void CantPay(List<Ticket> ticketList, decimal price, decimal credit)
        {
            ButtonFinish.Content = "OK";
            ButtonFinish.Click += ButtonFinish_Click;
            DataGridTickets.ItemsSource = ticketList;
            LabelText.Content = BuyFormLogic.CreateTextCantPay(price, credit);
        }

        private void ButtonFinish_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        

        
    }

    public static class BuyFormLogic
    {
        public static bool CheckMoney(decimal price, decimal credit)
        {
            if (price > credit)
                return false;
            else
                return true;
        }

        public static string CreateTextCanPay(decimal price, decimal credit)
        {
            var dif = credit - price;
            return $"Ihre Tickets Kosten {price} €. \nDa Sie ein Guthaben von {credit} € haben,\nbekommen Sie {dif} € zurück";
        }

        public static string CreateTextCantPay(decimal price, decimal credit)
        {
            var dif = credit - price;
            return $"Ihre Tickets Kosten {price} €. \nDa Sie ein Guthaben von {credit} € haben,\nmüssen Sie {dif} € noch zusätzlich Aufladen";
        }
    }
}
