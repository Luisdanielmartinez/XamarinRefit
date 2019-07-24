
namespace XamarinRefit.Infratructure
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using XamarinRefit.ViewModels;

    public class InstanceLocator
    {
        public MainViewModel Main { get; set; }

        public InstanceLocator()
        {
            Main = MainViewModel.GetInstace();
        }
    }
}
