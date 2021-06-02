using RequestModels = ParentPortal.Contracts.Requests;
using ResponseModels = ParentPortal.Contracts.Responses;
using ConfigSettings = ParentPortal.Config;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ParentPortal.Contracts.Responses;
using ParentPortal.Enums;

namespace ParentPortal.Services.TGA
{
    public interface IIdentityService
    {
        Task<ResponseModels.LoginResponseModel> LoginAsync(RequestModels.LoginRequestModel model, Enums.Page page = Enums.Page.None);
        Task<ResponseModels.ForgotPasswordResponse> ForgotPassword(RequestModels.FOrgotPasswordRequestModel model, Enums.Page page = Enums.Page.None);
    }
    public class IdentityService : BaseHttpService, IIdentityService
    {
        public async Task<ForgotPasswordResponse> ForgotPassword(RequestModels.FOrgotPasswordRequestModel model, Page page = Page.None)
        {
            var json = JsonConvert.SerializeObject(model);
            ResponseModels.ForgotPasswordResponse response = await CreatHttpPOSTRequestAsync<ResponseModels.ForgotPasswordResponse>(ConfigSettings.EndPoint.Identity.FORGOT, body: json, page: page);
            return response;
        }

        public async Task<ResponseModels.LoginResponseModel> LoginAsync(RequestModels.LoginRequestModel model, Enums.Page page = Enums.Page.None)
        {
            var json = JsonConvert.SerializeObject(model);
            ResponseModels.LoginResponseModel response = await CreatHttpPOSTRequestAsync<ResponseModels.LoginResponseModel>(ConfigSettings.EndPoint.Identity.LOGIN, body: json, page: page);
            return response;
        }
    }
}
