using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Caching;

namespace Core.Cache
{
    public abstract class CacheProvider<T> where T : class
    {
        public static CacheProvider<T> Instance;
        public static int CacheDuraction = 60;
        public abstract void SetData(string Key, object Value);
        public abstract List<T> GetData(string Key);
        public abstract void GetRemove(string Key);
        public abstract bool DataIsExist(string Key);
    }
    public class CacheHelper
    {
        ObjectCache _cahche;
        CacheItemPolicy _policy;
        public CacheHelper()
        {
            _cahche = MemoryCache.Default;
            _policy = new CacheItemPolicy
            {
                Priority = CacheItemPriority.NotRemovable,
                RemovedCallback = RemovedCallback,
                AbsoluteExpiration = DateTime.Now.AddHours(1)
            };
        }
        private void RemovedCallback(CacheEntryRemovedArguments val)
        {
            Trace.WriteLine("-Cache Yıkıldı-");
        }
        public bool DataIsExist(string Key)
        {
            return _cahche.Any(x => x.Key == Key);
        }
        public List<T> GetData<T>(string Key) where T : class
        {
            List<T> item;
            try
            {
                item = (List<T>)_cahche.Get(Key);
                item ??= new List<T>();
            }
            catch (Exception ex)
            {
                item = null;
                Trace.WriteLine($"Key => {Key} - Hata Oluştu - Error => {ex.Message}");
            }
            return item;
        }
        public object GetData(string Key)
        {
            object item;
            try
            {
                item = _cahche.Get(Key);

            }
            catch (Exception ex)
            {
                item = null;
                Trace.WriteLine($"Key => {Key} - Hata Oluştu - Error => {ex.Message}");
            }
            return item;
        }
        public void GetRemove(string Key)
        {
            if (DataIsExist(Key))
            {
                _cahche.Remove(Key);
            }
            else
            {
                Trace.WriteLine($"Key => {Key} - Silinecek Kayıt Bulunamadı");
            }
        }
        public void SetData(string Key, object Value)
        {
            _cahche.Set(Key, Value, _policy);
        }
    }
}