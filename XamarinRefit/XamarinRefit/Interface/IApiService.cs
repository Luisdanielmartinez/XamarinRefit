

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

        Task<List<Post>> Get();
    }
}
