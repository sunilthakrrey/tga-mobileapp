using ParentPortal.Contracts.Requests;
using ParentPortal.Enums;
using ParentPortal.Services.TGA;
using System.Threading.Tasks;

namespace ParentPortal.Storage
{
   public class AccountCredentialsStorage
    {


        public interface IAccountCredentialStorage
        {
            Task<bool> SaveCredential(string username, string password, bool isRememberMe);

            Task<LoginRequestModel> GetCredentials();
        }

        public class AccountCredentialStorage : SecureStorageService, IAccountCredentialStorage
        {


            public async Task<bool> SaveCredential(string email, string password, bool isRememberMe)
            {
                bool isSaveCredential = false;

                LoginRequestModel userCredentialInfo = await base.GetAsync<LoginRequestModel>(SecureStorageKey.AccountCredential);
                if (userCredentialInfo != null && userCredentialInfo.Email == email && userCredentialInfo.Password == password && userCredentialInfo.RememberMe == isRememberMe)
                {
                    isSaveCredential = true;
                }
                else
                {
                    isSaveCredential = await base.SaveAsync(SecureStorageKey.AccountCredential, new LoginRequestModel
                    {
                        Email = email,
                        Password = password,
                        RememberMe = isRememberMe,
                    });
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
}
