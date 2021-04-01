using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Sample.ViewModels
{
    public class SomeModel
    {
        public string Value { get; set; }
    }

    public class MainPageViewModel : BaseViewModel
    {
        public MainPageViewModel()
        {
            Items = new ObservableCollection<SomeModel>();

            for (int i = 0; i < 100; ++i)
            {
                Items.Add(new SomeModel()
                {
                    Value = $"Item {i+1}",
                });
            }
        }

        public ObservableCollection<SomeModel> Items { get; set; }

        public SomeModel HighlighedItem { get; set; }
    }
}
