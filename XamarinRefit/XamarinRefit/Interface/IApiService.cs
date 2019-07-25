

namespace XamarinRefit.Interface
{
    using Refit;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using XamarinRefit.Models;

    public  interface IApiService
    {
        [Get("/posts")]
        Task<List<Post>> GET();
        [Get("/Product")]
        Task<List<Product>> GetProduct();
        [Post("/Product")]
        Task PostProduct([Body] Product product);
    }
}
