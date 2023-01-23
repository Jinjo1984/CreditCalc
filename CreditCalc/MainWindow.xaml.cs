using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
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
using контрольная_2;

namespace CreditCalc
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        public double SumCredit, PercentCredit, MonthQuantity, RamainsPay; //инициализирую переменные для расчета по формуле
        public class Credits //класс для подвязки ListView
        {
            public string Month { get; set; }
            public double Pays { get; set; }
            public double Ramains { get; set; }
            public double MainDebt { get; set; }
            public double PercentPay { get; set; }
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            List<Credits> pay = new List<Credits>(); //List в котором будет список экземпляров класса Credits
            
            try {
                SumCredit = Convert.ToDouble(SummCreditTextBox.Text);
                PercentCredit = Convert.ToDouble(PercentCreditTextBox.Text) / 100;
                MonthQuantity = Convert.ToDouble(MonthQuantityTextBox.Text);
                Credits cred = new Credits { Month = null,Pays = 0,Ramains = 0,MainDebt = 0,PercentPay = 0 }; //Создаю экземпляр класса Credit с обнулеными переменными
                double[] Pays = new double[Convert.ToInt32(MonthQuantity)];
                RamainsPay = SumCredit;
                double mainDebt = 0;
                double percentPay = 0;
                double percentPayCount = 0;
                mainDebt = SumCredit / MonthQuantity;
                int month = 1;
                for (int i = 0; i < MonthQuantity; i++)
                { 
                    
                    Pays[i] = Math.Round(SumCredit / MonthQuantity + RamainsPay * PercentCredit / MonthQuantity, 4); //вычисление оплаты в месяц
                    RamainsPay -= SumCredit / MonthQuantity;//остаток по оплате
                    percentPay = Pays[i] -mainDebt ;
                    percentPayCount += percentPay;//переплата по кредиту (внести в listview)
                    cred = new Credits { Month = Convert.ToString(month), Pays = Pays[i],Ramains = RamainsPay,MainDebt = mainDebt,PercentPay = percentPay};
                    month++;
                    pay.Add(cred);
                }
            }
            catch { MessageBox.Show("Неверный формат числа", "Ошибка"); }
            listView.ItemsSource = pay; 
        }
    }
}
