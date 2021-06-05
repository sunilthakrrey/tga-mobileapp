using ParentPortal.Contracts.Requests;
using ParentPortal.Enums;
using ParentPortal.Services.TGA;
using System.Threading.Tasks;

namespace ParentPortal.Storage
{
    public interface IAccountCredentialStorage
    {
        Task<bool> SaveCredential(LoginRequestModel loginRequestModel);

        Task<LoginRequestModel> GetCredentials();
    }
        public class AccountCredentialStorage : SecureStorageService, IAccountCredentialStorage
        {


            public async Task<bool> SaveCredential(LoginRequestModel loginRequestModel)
            {
                bool isSaveCredential = false;

                LoginRequestModel userCredentialInfo = await base.GetAsync<LoginRequestModel>(SecureStorageKey.AccountCredential);
                if (userCredentialInfo != null && userCredentialInfo.Email == loginRequestModel.Email && userCredentialInfo.Password == loginRequestModel.Password && userCredentialInfo.RememberMe == loginRequestModel.RememberMe)
                {
                    isSaveCredential = true;
                }
                else
                {
                    isSaveCredential = await base.SaveAsync(SecureStorageKey.AccountCredential, loginRequestModel);
                }

                return isSaveCredential;
            }

            public async Task<LoginRequestModel> GetCredentials()
            {
                LoginRequestModel userCredentialsInfo = await base.GetAsync<LoginRequestModel>(SecureStorageKey.AccountCredential);
                return userCredentialsInfo;
            }
        }
 
}
