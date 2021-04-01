using Sample.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sample.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestTemplate : ContentView
    {
        public static readonly BindableProperty HighlightedModelProperty =
               BindableProperty.Create(nameof(HighlightedModel), typeof(SomeModel), typeof(TestTemplate), null,
                   propertyChanged: OnHighlightedBarcodeChanged);

        public SomeModel HighlightedModel
        {
            get { return (SomeModel)GetValue(HighlightedModelProperty); }
            set { SetValue(HighlightedModelProperty, value); }
        }

        static async void OnHighlightedBarcodeChanged(BindableObject bindable, object oldValue, object newValue)
        {
            TestTemplate i = (TestTemplate)bindable;

            if ((SomeModel)newValue == i.BindingContext)
            {
                _ = i.Highlight();
            }
        }

        public TestTemplate()
        {
            InitializeComponent();
        }

        public async Task Highlight()
        {
            await HighlightContainer.FadeTo(0.5, 250, Easing.CubicOut);

            await Task.Delay(2000);

            await HighlightContainer.FadeTo(0, 500, Easing.Linear);
        }
    }
}