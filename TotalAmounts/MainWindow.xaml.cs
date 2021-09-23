// Group2: Jingfei Yao, Grace Pauly, Xiaotong Han.

using System.Windows;

/// Group 2/9 Problem – Tip, Tax and Total
/// Create an application that lets the user enter the food charge for a meal at a restaurant.
/// When a button is clicked, the application should calculate and display the amount of a 15 percent tip, 
/// 7 percent sales tax, and the total of all three amounts.
namespace TotalAmounts
{
    public partial class MainWindow : Window
    {
        // food charge
        private decimal foodCharge;

        // amount of a 15% tip
        private decimal tip;

        // 7% sales tax
        private decimal tax;

        // total amounts
        private decimal total;

        private const decimal TIP_PERCENT = (decimal)0.15;
        private const decimal TAX_PERCENT = (decimal)0.07;

        public MainWindow()
        {
            InitializeComponent();
            UpdateLabelContent();

            // Let the text box get focus to checkout quickly.
            _ = FoodChargeInput.Focus();
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string foodChargeString = FoodChargeInput.Text;
                foodCharge = decimal.Parse(foodChargeString);

                CalculateAmounts();
                UpdateLabelContent();
            }
            catch
            {
                foodCharge = (decimal)0.0;
                CalculateAmounts();
                UpdateLabelContent();

                _ = MessageBox.Show("Please enter a valid food charge!", caption: "Input Error!");
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            foodCharge = (decimal)0.0;
            FoodChargeInput.Text = "";

            CalculateAmounts();
            UpdateLabelContent();

            _ = FoodChargeInput.Focus();
        }

        private void CalculateAmounts()
        {
            tip = TIP_PERCENT * foodCharge;
            tax = TAX_PERCENT * foodCharge;
            total = foodCharge + tip + tax;
        }

        private void UpdateLabelContent()
        {
            TipLabel.Content = tip.ToString("C");
            TaxLabel.Content = tax.ToString("C");
            TotalLabel.Content = total.ToString("C");
        }
    }
}
