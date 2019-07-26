

namespace XamarinRefit.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Plugin.Media;
    using Plugin.Media.Abstractions;
    using Refit;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Input;
    using Xamarin.Forms;
    using XamarinRefit.Interface;
    using XamarinRefit.Models;

    public class AddProductViewModel : BaseViewModel
    {
        private bool isToggled;
        private bool isRunning;
        private Product product;
        private bool isEnabled;
        private MediaFile file;
        //esto es para tomar la foto
        private ImageSource imageSource;
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public bool IsToggled
        {
            get => isToggled;
            set => SetValue(ref isToggled, value);
        }
        public bool IsRunning
        {
            get => isRunning;
            set => SetValue(ref isRunning, value);
        }
        public bool IsEnabled
        {
            get => isEnabled;
            set => SetValue(ref isEnabled, value);
        }
        public ImageSource ImageSource
        {
            get => imageSource;
            set => SetValue(ref imageSource, value);
        }
        public ICommand ConfirmarCommand => new RelayCommand(RegisterProduct);
        public ICommand ChangeImageCommand => new RelayCommand(ChangeImage);


        public AddProductViewModel()
        {
            //add the plugin his name is xaml plugin media
            isToggled = true;
            product = new Product();
            this.imageSource = "no product";
        }

        private async void RegisterProduct()
        {
            try
            {
                if (parametros())
                {
                    await Application.Current.MainPage.DisplayAlert(
                       "Error",
                       "No puede dejar ningun campo vacio",
                       "Ok");
                    return;
                }

                //isEnabled = true;
                IsRunning = true;
                product.Image = "image";
                product.Name = Name;
                product.Description = Description;
                product.IsAvalible = true;
                product.Price = Price;
                var url = Application.Current.Resources["UrlApi"].ToString();
                var apiService = RestService.For<IApiService>(url);
                var response = apiService.PostProduct(product);
                if (response.IsCompleted)
                {
                    await Application.Current.MainPage.DisplayAlert(
                         "Acetado",
                         "Se ha guardado el producto",
                         "Ok");

                    return;
                }
                else if (response.IsCanceled)
                {
                    await Application.Current.MainPage.DisplayAlert(
                        "Error",
                        "Se cancelo la respuesta de datos",
                        "Ok");
                    return;
                }
                IsRunning = false;
                // IsEnabled = false;
            }
            catch (Exception)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Error al enviar los datos",
                    "Ok");
                IsRunning = false;
                // IsEnabled = false;sasad
            }
        }
        //method for change the image
        private async void ChangeImage()
        {
            await CrossMedia.Current.Initialize();

            var source = await Application.Current.MainPage.DisplayActionSheet(
                "Where do you take the picture?",
                "Cancel",
                null,
                "From Gallery",
                "From Camera");
            //se cancela la foto
            if (source == "Cancel")
            {
                this.file = null;
                return;
            }
            //este es el metodo que dispara la camara
            if (source == "From Camera")
            {
                this.file = await CrossMedia.Current.TakePhotoAsync(
                    new StoreCameraMediaOptions
                    {
                        Directory = "Sample",
                        Name = "test.jpg",
                        PhotoSize = PhotoSize.Small,
                    }
                );
            }
            else
            {
                //aqui selecciona la foto de la galeria
                this.file = await CrossMedia.Current.PickPhotoAsync();
            }

            if (this.file != null)
            {
                this.ImageSource = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    return stream;
                });
            }
        }

        public bool parametros()
        {
            if (string.IsNullOrEmpty(Description) || string.IsNullOrEmpty(Name) || Price < 0)
            {
                return true;
            }
            return false;
        }
    }
}
