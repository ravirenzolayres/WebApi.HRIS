using HrisApi.Model;
using HrisApi.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HrisApi.Function.JWTManager
{
    public interface IJwtManager
    {
        Task<bool> AuthenticateUser(UserCredential userCredential);
        Task<string> Authenticate(UserCredential userCredential);
    }
}
