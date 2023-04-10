using ApplicationT3.Service.DTOs.Model;
using ApplicationT3.Service.DTOs.View;

namespace ApplicationT3.Service.Contract
{
    public interface IUserApplicationService
    {
        Task<IEnumerable<UserViewResponse>> GetUserAll();
        Task<string> PostUserAsync(UserModel model);
        Task<string> PutUserAsync(UserModel model, string id);
        Task<string> DeleteUserAsync(string id);
    }
}
