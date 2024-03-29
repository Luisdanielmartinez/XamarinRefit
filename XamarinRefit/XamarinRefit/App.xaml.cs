﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinRefit.ViewModels;
using XamarinRefit.Views;

namespace XamarinRefit
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainViewModel.GetInstance().Login = new LoginViewModel();
            MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
