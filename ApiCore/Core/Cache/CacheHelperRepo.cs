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
            return ModelCache.Count != 0
                ? await Task.FromResult(new SuccessDataResult<T>()
                {
                    ListResponseModel = ModelCache,
                    Status = true,
                    Message = "Listeleme İşlemi Başarılı.",
                    ModelCount = ModelCache.ToList().Count
                })
                : await Task.FromResult(new SuccessDataResult<T>(){ Status = false, Message = "Cache Boş.." });
        }
        public static void RemoveCache(CacheEnums enums) => ToolsCache.SolutionsCache.GetRemove(enums.ToString());
        public static void SetCache(string enums, object Model) => ToolsCache.SolutionsCache.SetData(enums.ToString(), Model);
    }
}