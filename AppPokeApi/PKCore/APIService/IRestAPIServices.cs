using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PKCore.APIService
{
    public interface IRestAPIServices
    {
        Task<T> Get<T>(string url);
    }
}
