

namespace XamarinRefit.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    
    using Refit;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Windows.Input;
    using XamarinRefit.Interface;
    using XamarinRefit.Models;

    public class ProductViewModel : BaseViewModel
    {
        private List<Product> myProduct;
        private ObservableCollection<ProductItemViewModel> listProdut;
        private bool isRefresh;
        public bool IsRefreshing
        {
            get => isRefresh;
            set => SetValue(ref isRefresh, value);
        }
        public ObservableCollection<ProductItemViewModel> ListProduct
        {
            get => listProdut;
            set => SetValue(ref listProdut, value);
        }
        public ProductViewModel()
        {
            LoadProduct();
        }
        public ICommand RefreshCommand => new RelayCommand(Refresh);


        private async void LoadProduct()
        {
            try
            {
                IsRefreshing = true;
                var apiService = RestService.For<IApiService>("http://192.168.2.2:8001/api");
               this.myProduct = await apiService.GetProduct();
                this.RefresProductsList();
                IsRefreshing = false;
            }
            catch (Exception ex)
            {

            }
        }
        public void AddProductToList(Product product)
        {
            this.myProduct.Add(product);
            this.RefresProductsList();
        }

        public void UpdateProductInList(Product product)
        {
            var previousProduct = this.myProduct.Where(p => p.Id == product.Id).FirstOrDefault();
            if (previousProduct != null)
            {
                this.myProduct.Remove(previousProduct);
            }

            this.myProduct.Add(product);
            this.RefresProductsList();
        }

        public void DeleteProductInList(int productId)
        {
            var previousProduct = this.myProduct.Where(p => p.Id == productId).FirstOrDefault();
            if (previousProduct != null)
            {
                this.myProduct.Remove(previousProduct);
            }

            this.RefresProductsList();
        }

        private void RefresProductsList()
        {
            this.listProdut = new ObservableCollection<ProductItemViewModel>(myProduct.Select(p => new ProductItemViewModel
            {
                Id=p.Id,
                Name=p.Name,
                Description=p.Description,
                Price=p.Price,
                IsAvalible=p.IsAvalible,
                Image=p.Image
            })
            .OrderBy(p => p.Name)
            .ToList());
        }


        private void Refresh()
        {
            IsRefreshing = true;
            LoadProduct();
            IsRefreshing = false;
        }

    }
}
