using Microsoft.AspNetCore.Identity;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistration);
        Task<bool> ValidateUser(UserForAuthenticationDto userForAuth);
        Task<string> CreateToken();
        Task<IdentityResult> DeleteUser(string userId);
        Task<IdentityResult> ChangePassword(string userId, string oldPassword, string newPassword);
        Task<IdentityResult> UpdateUser(string userId, UserForUpdateDto userForUpdate);
        Task<(IEnumerable<UserDto> users, MetaData metaData)> GetUsers(UserParameters userParameters);
    }
}
