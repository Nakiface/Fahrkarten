using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Fahrkarten
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Ticket> BoughtTickets = new List<Ticket>();
        HandlePayWindow _HandlePayWindow = new HandlePayWindow();
        
        public MainWindow()
        {
            InitializeComponent();
            InitializeEvents();
            InitializeDataSource();
            
        }

        private void InitializeDataSource()
        {
            ComboBoxTicketType.ItemsSource = new TicketTypes().CreateListForComboBox();
            ComboBoxTicketType.SelectedIndex = 0;
            DataGridOrderList.ItemsSource = BoughtTickets;
        }

        private void InitializeEvents()
        {
            ButtonAdd.Click += ButtonAdd_Click;
            ButtonPay.Click += ButtonPay_Click;
            ButtonBuy.Click += ButtonBuy_Click;
        }

        private void ButtonBuy_Click(object sender, RoutedEventArgs e)
        {
            BuyForm buyForm = new BuyForm(BoughtTickets, BoughtTickets.Sum(x => x.Price), _HandlePayWindow.Credit);
            buyForm.Show();
            if (BuyFormLogic.CheckMoney(BoughtTickets.Sum(x => x.Price), _HandlePayWindow.Credit))
                buyForm.ButtonFinish.Click += ButtonFinish_CanBuyClick;
        }

        private void ButtonFinish_CanBuyClick(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void ButtonPay_Click(object sender, RoutedEventArgs e)
        {
            _HandlePayWindow.ButtonPay_Click(LabelCredit);
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            BoughtTickets.Add(new TicketTypes().FindTicketFromText(ComboBoxTicketType.SelectedItem.ToString()));
            DataGridOrderList.ItemsSource = null;
            DataGridOrderList.ItemsSource = BoughtTickets;
            LabelPrice.Content = $"{BoughtTickets.Sum(x => x.Price).ToString()} €";
        }
    }
}
