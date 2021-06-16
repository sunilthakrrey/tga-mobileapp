using ParentPortal.Contracts.Requests;
using ParentPortal.Enums;
using ParentPortal.Models;
using ParentPortal.Services.TGA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParentPortal.Storage
{
    public interface IBookMarkStorageService
    {
        Task<bool> Add(Bookmark_Like_Model model);
        Task<bool> Remove(Bookmark_Like_Model filter);
        Task<bool> IsExists(Bookmark_Like_Model filter);
    }
    public class BookMarkStorageService : SecureStorageService, IBookMarkStorageService
    {
        public async Task<bool> Add(Bookmark_Like_Model filter)
        {
            bool retVal = false;

            List<Bookmark_Like_Model> existingRecords = await this.ReadFromStorage();

            Bookmark_Like_Model foundRecord = Filter(existingRecords, filter);

            if (foundRecord == null)
            {
                existingRecords.Add(filter);
                retVal = await base.SaveAsync(SecureStorageKey.ToolBarStorage, existingRecords);
            }

            return retVal;
        }

        public async Task<bool> IsExists(Bookmark_Like_Model filter)
        {
            List<Bookmark_Like_Model> existingRecords = await this.ReadFromStorage();
            Bookmark_Like_Model found = Filter(existingRecords, filter);
            return found != null;
        }

        public async Task<bool> Remove(Bookmark_Like_Model filter)
        {
            bool retVal = false;

            List<Bookmark_Like_Model> existingRecords = await this.ReadFromStorage();

            Bookmark_Like_Model foundRecord = Filter(existingRecords, filter);

            if (foundRecord != null)
            {
                retVal = existingRecords.Remove(foundRecord);
                await base.RemoveAsync(SecureStorageKey.ToolBarStorage);
                await base.SaveAsync(SecureStorageKey.ToolBarStorage, existingRecords);
            }

            return retVal;
        }

        private async Task<List<Bookmark_Like_Model>> ReadFromStorage()
        {
            List<Bookmark_Like_Model> retVal = await base.GetAsync<List<Bookmark_Like_Model>>(SecureStorageKey.ToolBarStorage);
            return retVal == null ? new List<Bookmark_Like_Model>() : retVal;
        }

        private Bookmark_Like_Model Filter(List<Bookmark_Like_Model> existingRecords, Bookmark_Like_Model model)
        {
            Bookmark_Like_Model entity = existingRecords.FirstOrDefault(x => x.FeedId == model.FeedId && x.Module == model.Module && x.Type == model.Type);
            return entity;
        }
    }
}
