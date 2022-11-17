using Core.Cache.Enums;
using Core.Results;
using Entities.Base;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Cache
{
    public static class CacheHelperRepo
    {
        public async static Task<SuccessDataResult<T>> GetCache<T>(CacheEnums enums) where T : BaseEntity<Guid>
        {
            var ModelCache = ToolsCache.SolutionsCache.GetData<T>(enums.ToString());
            if (ModelCache.Count != 0)
            {
                return await Task.FromResult(new SuccessDataResult<T>()
                {
                    ListResponseModel = ModelCache,
                    Status = true,
                    Message = "Listeleme İşlemi Başarılı.",
                    ModelCount = ModelCache.ToList().Count
                });
            }
            else
            {
                return await Task.FromResult(new SuccessDataResult<T>(){ Status = false, Message = "Cache Boş.." });
            }
        }
        public static void SetCache(string enums, object Model) => ToolsCache.SolutionsCache.SetData(enums.ToString(), Model);
    }
}