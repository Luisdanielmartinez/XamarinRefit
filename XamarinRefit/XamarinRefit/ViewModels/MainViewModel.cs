

namespace XamarinRefit.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;
   public class MainViewModel
    {
        private static MainViewModel mainViewModel;
        public PostViewModel Posts { get; set; }
        public MainViewModel()
        {
            mainViewModel = this;
        }

        public static MainViewModel GetInstace()
        {
            if (mainViewModel==null) {
                mainViewModel = new MainViewModel();
            }
            return mainViewModel;
        }
    }
}
