

namespace XamarinRefit.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Input;
    using Xamarin.Forms;
    using XamarinRefit.Views;

    public class MainViewModel
    {
        public static MainViewModel mainViewModel { get; set; }
        public LoginViewModel Login { get; set; }
        public AddProductViewModel AddProduct { get; set; }
        public PostViewModel Post { get; set; }
        public ProductViewModel Products { get; set; }
        public ICommand AddProductCommand => new RelayCommand(GoToProduct);
        public EditProductViewModel EditProduct { get; set; }
        public MainViewModel()
        {
            mainViewModel = this;
        }

        public static MainViewModel GetInstance()
        {
            if (mainViewModel == null)
            {
                mainViewModel = new MainViewModel();
            }
            return mainViewModel;
        }
        public void GoToProduct()
        {
            this.AddProduct = new AddProductViewModel();
            Application.Current.MainPage.Navigation.PushAsync(new AddProductPage());

        }
    }
}
