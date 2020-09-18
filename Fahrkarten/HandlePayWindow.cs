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
            pay.Button2000.Click += Button2000_Click;
            pay.Button50.Click += Button50_Click;
            pay.Button20.Click += Button20_Click;
            pay.Button10.Click += Button10_Click;
        }

        private void Button10_Click(object sender, RoutedEventArgs e)
        {
            Credit += 0.10m;
            RefreshCredit();
        }

        private void Button20_Click(object sender, RoutedEventArgs e)
        {
            Credit += 0.20m;
            RefreshCredit();
        }

        private void Button50_Click(object sender, RoutedEventArgs e)
        {
            Credit += 0.50m;
            RefreshCredit();
        }

        private void Button2000_Click(object sender, RoutedEventArgs e)
        {
            Credit += 20.00m;
            RefreshCredit();
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
