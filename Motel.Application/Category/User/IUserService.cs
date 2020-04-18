using Motel.ViewModel.System.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Motel.Application.Category.User
{
    public interface IUserService
    {
        Task<string> Authentication(string username, string password);

        Task<bool> register(RegisterRequest requset);
    }
}
