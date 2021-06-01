using Newtonsoft.Json;
using ParentPortal.Enums;
using ParentPortal.Extensions;
using System;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace ParentPortal.Services.TGA
{
    public class SecureStorageService 
    {
        public virtual async Task<T> GetAsync<T>(SecureStorageKey key, object value = null) where T : class
        {
            var retVal = default(T);

            var json = await SecureStorage.GetAsync(key.GetValueAsString());

            if (!string.IsNullOrEmpty(json))
            {
                retVal = JsonConvert.DeserializeObject<T>(json);
            }

            return retVal;
        }

        public virtual async Task<bool> RemoveAsync(SecureStorageKey key)
        {
            bool retVal = false;

            string keyAsString = key.GetValueAsString();

            var json = await SecureStorage.GetAsync(keyAsString);

            if (!string.IsNullOrEmpty(json))
            {
                retVal = SecureStorage.Remove(keyAsString);
            }

            return retVal;
        }

        public virtual async Task<bool> SaveAsync(SecureStorageKey key, object value)
        {
            var json = JsonConvert.SerializeObject(value);
            await SecureStorage.SetAsync(key.GetValueAsString(), json);
            return true;
        }

        public virtual bool RemoveAll()
        {
             SecureStorage.RemoveAll();
            return true;
        }
    }
}
