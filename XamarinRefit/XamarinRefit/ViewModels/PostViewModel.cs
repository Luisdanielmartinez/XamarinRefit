

namespace XamarinRefit.ViewModels
{
    using Refit;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Text;
    using XamarinRefit.Interface;
    using XamarinRefit.Models;

    public class PostViewModel:BaseViewModel
    {
        private ObservableCollection<Post> listPost;

        public ObservableCollection<Post> ListPost
        {
            get => this.listPost;
            set => this.SetValue(ref listPost,value);
        }
        public PostViewModel()
        {
            LoadPost();
        }
        //cambio
        private async void LoadPost()
        {
            try {
                var apiService =  RestService.For<IApiService>("https://jsonplaceholder.typicode.com");
                var result = await apiService.GET();
                ListPost = new ObservableCollection<Post>(result);
            }
            catch(Exception ex){

            }
        }
    }
}
