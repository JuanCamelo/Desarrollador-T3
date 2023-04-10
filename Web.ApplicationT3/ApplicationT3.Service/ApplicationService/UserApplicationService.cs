using ApplicationT3.Domain;
using ApplicationT3.Domain.Models;
using ApplicationT3.Service.Contract;
using ApplicationT3.Service.DTOs.Model;
using ApplicationT3.Service.DTOs.View;
using ApplicationT3.Service.Helper;
using AutoMapper;

namespace ApplicationT3.Service.ApplicationService
{
    public class UserApplicationService : IUserApplicationService
    {
        private readonly IApplicationRepository<User> _userRepository;
        private IMapper _mapper;
        public UserApplicationService(IApplicationRepository<User> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserViewResponse>> GetUserAll()
        {
            try
            {
                var respose = await _userRepository.GetCurrentUserAsync();
                return _mapper.Map<IEnumerable<UserViewResponse>>(respose);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string> PostUserAsync(UserModel model)
        {
            try
            {  
                var user = _mapper.Map<User>(model);
                var valuesPropertys = user.QueryStringModel();

                await _userRepository.InsertAsync(new AccionTable
                {
                    Operacion = "INSERT",
                    Campos = valuesPropertys.FieldsStr,
                    Valores = valuesPropertys.ValuesStr,
                    Tabla = "[dbo].[User]"
                });
                return "Successfull!";
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string> PutUserAsync(UserModel model, string id)
        {
            try
            {
                var valuesPropertys = model.QueryStringModel();
                string queryvalues = valuesPropertys.FieldsStr.QueryStringConcatValues(valuesPropertys.ValuesStr);

                await _userRepository.UpdateAsync(new AccionTable
                {
                    Operacion = "UPDATE",
                    Tabla = "[dbo].[User]",
                    Campos = queryvalues,
                    Condicion = $"id =''{id}''"
                });
                return "Successful upgrade!";
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<string> DeleteUserAsync(string id)
        {
            try
            {
                await _userRepository.DeleteAsync(new AccionTable
                {
                    Operacion = "DELETE",
                    Tabla = "[dbo].[User]",
                    Condicion = $"id =''{id}''"
                });
                return "Successfull";
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
