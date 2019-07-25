

namespace XamarinRefit.ViewModels
{
    using System.Windows.Input;
    
    using GalaSoft.MvvmLight.Command;
    using Views;
    using Xamarin.Forms;
    using XamarinRefit.Models;

    public class ProductItemViewModel : Product
    {
        public ICommand SelectProductCommand => new RelayCommand(this.SelectProduct);

        private async void SelectProduct()
        {
            MainViewModel.GetInstance().EditProduct = new EditProductViewModel((Product)this);
            await Application.Current.MainPage.Navigation.PushAsync(new EditProductPage());
        }
    }

}
