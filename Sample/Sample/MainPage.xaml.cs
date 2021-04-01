using Sample.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Sample
{
    public partial class MainPage : ContentPage
    {
        MainPageViewModel VM;

        public MainPage()
        {
            InitializeComponent();

            VM = (MainPageViewModel)this.BindingContext;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            VM.HighlighedItem = null;

            var rnd = new Random();
            var randomIndex = rnd.Next(0, VM.Items.Count - 1);

            MainCollection.ScrollTo(randomIndex, -1, ScrollToPosition.Center, false);

            await Task.Delay(250);

            VM.HighlighedItem = VM.Items[randomIndex];
        }
    }
}
