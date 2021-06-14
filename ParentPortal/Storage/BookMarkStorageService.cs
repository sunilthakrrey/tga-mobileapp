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
        Task AddRecord(ToolStorageModel toolStorageModel);
        Task<bool> RemoveRecord(ToolStorageModel toolStorageModel);
        Task<bool> IsRecordExists(ToolStorageModel toolStorageModel);
    }
    public class BookMarkStorageService : SecureStorageService, IBookMarkStorageService
    {
        public async Task AddRecord(ToolStorageModel newtoolStorageModel)
        {
            if (!await IsRecordExists(newtoolStorageModel))
            {
                List<ToolStorageModel> toolStorage = new List<ToolStorageModel>();
                toolStorage = await base.GetAsync<List<ToolStorageModel>>(SecureStorageKey.ToolBarStorage) ;
                toolStorage.Add(newtoolStorageModel);
                await base.SaveAsync(SecureStorageKey.ToolBarStorage, toolStorage);
            }
        }

        public async Task<bool> IsRecordExists(ToolStorageModel toolStorageModel)
        {
            bool isSaveCredential = false;
            List<ToolStorageModel> toolBarStorage = await base.GetAsync<List<ToolStorageModel>>(SecureStorageKey.AccountCredential);
            isSaveCredential = toolBarStorage != null && toolBarStorage.Any(x => x.id == toolStorageModel.id && x.Module == toolStorageModel.Module && x.Type == toolStorageModel.Type);
            return isSaveCredential;
        }

        public async Task<bool> RemoveRecord(ToolStorageModel toolStorageModel)
        {
            if (await IsRecordExists(toolStorageModel))
            {
                List<ToolStorageModel> toolStorage = await base.GetAsync<List<ToolStorageModel>>(SecureStorageKey.ToolBarStorage);
                ToolStorageModel existedRecord=   toolStorage.Where(x => x.id == toolStorageModel.id && x.Module == toolStorageModel.Module && x.Type == toolStorageModel.Type).FirstOrDefault();
                toolStorage.Remove(existedRecord);
                await base.RemoveAsync(SecureStorageKey.ToolBarStorage);
                await base.SaveAsync(SecureStorageKey.ToolBarStorage, toolStorage);
            }
            return true;
        }
    }
}
