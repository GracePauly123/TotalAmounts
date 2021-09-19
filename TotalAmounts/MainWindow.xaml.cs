// Group2: Jingfei Yao, Grace Pauly, Xiaotong Han.

using System.Windows;
using System.Globalization;
using System.Windows.Input;

namespace TotalAmounts
{
    /// Group 2/9 Problem – Tip, Tax and Total
    /// Create an application that lets the user enter the food charge for a meal at a restaurant.
    /// When a button is clicked, the application should calculate and display the amount of a 15 percent tip, 
    /// 7 percent sales tax, and the total of all three amounts.
    public partial class MainWindow : Window
    {
        // food charge
        private float foodCharge;

        // amount of a 15% tip
        private float tip;

        // 7% sales tax
        private float tax;

        // total amounts
        private float total;

        private static readonly float TIP_PERCENT = 0.15F;
        private static readonly float TAX_PERCENT = 0.07F;

        private readonly CultureInfo culture = new("en-us");

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
                foodCharge = float.Parse(foodChargeString, culture);

                CalculateAmounts();
                UpdateLabelContent();
            }
            catch
            {
                _ = MessageBox.Show("Please enter a valid food charge!", caption: "Input Error!");
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            foodCharge = 0F;
            FoodChargeInput.Text = "";

            CalculateAmounts();
            UpdateLabelContent();

            _ = FoodChargeInput.Focus();
        }

        private void FoodChargeInput_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                Calculate.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Primitives.ButtonBase.ClickEvent));
            }
            else if (e.Key == Key.Escape)
            {
                Clear.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Primitives.ButtonBase.ClickEvent));
            }
        }

        private void CalculateAmounts()
        {
            tip = TIP_PERCENT * foodCharge;
            tax = TAX_PERCENT * foodCharge;
            total = foodCharge + tip + tax;
        }

        private void UpdateLabelContent()
        {
            TipLabel.Content = tip.ToString("C", culture);
            TaxLabel.Content = tax.ToString("C", culture);
            TotalLabel.Content = total.ToString("C", culture);
        }
    }
}
