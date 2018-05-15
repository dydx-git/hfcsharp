using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MileageCaluclator
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        int startingMileage;
        int endingMileage;
        double milesTraveled;
        double reimburseRate = 0.39;
        double amountOwed;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void startMileage_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (((uint)e.Key >= (uint)Windows.System.VirtualKey.Number0 &&
                (uint)e.Key <= (uint)Windows.System.VirtualKey.Number9) ||
                ((uint)e.Key >= (uint)Windows.System.VirtualKey.NumberPad0 &&
                (uint)e.Key <= (uint)Windows.System.VirtualKey.NumberPad9))
            {
                e.Handled = false;
            }
            else e.Handled = true;
        }

        private void stopMileage_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (((uint)e.Key >= (uint)Windows.System.VirtualKey.Number0 &&
                (uint)e.Key <= (uint)Windows.System.VirtualKey.Number9) ||
                ((uint)e.Key >= (uint)Windows.System.VirtualKey.NumberPad0 &&
                (uint)e.Key <= (uint)Windows.System.VirtualKey.NumberPad9))
            {
                e.Handled = false;
            }
            else e.Handled = true;
        }

        private async void Calculate_Click(object sender, RoutedEventArgs e)
        {
            startingMileage = Int32.Parse(startMileage.Text);
            endingMileage = Int32.Parse(stopMileage.Text);
            if (startingMileage < endingMileage)
            {
                milesTraveled = endingMileage -= startingMileage;
                amountOwed = milesTraveled * reimburseRate;
                amount.Text = "$" + amountOwed;
            }
            else
            {
                var dialog = new MessageDialog("The starting mileage must be less than the ending mileage.");
                await dialog.ShowAsync();
            }
        }
    }
}
