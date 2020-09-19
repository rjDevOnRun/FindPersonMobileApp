using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyGameApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        static string hidingPerson = new Random().Next(1, 4).ToString();
        static int NUM_OF_TRIES = 3;

        public MainPage()
        {
            InitializeComponent();
            lblTries.Text = $"Num of tries: {NUM_OF_TRIES}";
        }

        async void Button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            if (button.Text == $"Room # {hidingPerson}")
            {
                await DisplayAlert("WINNER!", "You found the person, Hurray!", "Retry");
                NUM_OF_TRIES = 3;
            }
            else
            {
                await DisplayAlert("Please try again!", "Person is not here", "Continue");
                NUM_OF_TRIES -= 1;

                CheckIfTriesExceeded();
            }

            hidingPerson = new Random().Next(1, 4).ToString();
            lblTries.Text = $"Num of tries: {NUM_OF_TRIES}";
        }

        async void CheckIfTriesExceeded()
        {
            if (NUM_OF_TRIES == 0)
            {
                await DisplayAlert("Tries Exceeded, Better Luck next Time!", "GAME OVER", "Retry");
                NUM_OF_TRIES = 3;
                lblTries.Text = $"Num of tries: {NUM_OF_TRIES}";
            }
        }
    }
}
