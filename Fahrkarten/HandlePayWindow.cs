using System.Windows;
using System.Windows.Controls;

namespace Fahrkarten
{
    public class HandlePayWindow
    {
        public decimal Credit { get; set; }
        Pay pay = new Pay();
        Label _labelCredit;
        

        public void ButtonPay_Click(Label labelCredit)
        {
            _labelCredit = labelCredit;
            pay = new Pay();
            pay.Show();
            InitializeEventsForPay(pay);
        }

        private void InitializeEventsForPay(Pay pay)
        {
            pay.Button1000.Click += Button1000_Click;
            pay.Button500.Click += Button500_Click;
            pay.Button200.Click += Button200_Click;
            pay.Button100.Click += Button100_Click;
        }

        private void Button100_Click(object sender, RoutedEventArgs e)
        {
            Credit += 1.00m;
            RefreshCredit();
        }

        private void Button200_Click(object sender, RoutedEventArgs e)
        {
            Credit += 2.00m;
            RefreshCredit();
        }

        private void Button500_Click(object sender, RoutedEventArgs e)
        {
            Credit += 5.00m;
            RefreshCredit();
        }

        private void Button1000_Click(object sender, RoutedEventArgs e)
        {
            Credit += 10.00m;
            RefreshCredit();
        }

        private void RefreshCredit()
        {
            pay.Close();
            _labelCredit.Content = $"{Credit.ToString()} €";
        }
    }
}
