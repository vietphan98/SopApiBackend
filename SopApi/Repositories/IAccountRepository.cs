using Microsoft.AspNetCore.Identity;
using SopApi.Models;

namespace SopApi.Repositories
{
    public interface IAccountRepository
    {
        public Task<IdentityResult> SignUpAsync(SignUpModel model);
        public Task<string> LoginAsync(LoginModel model);

    }
}
