namespace Core.Cache
{
    public static class ToolsCache
    {
        private static CacheHelper _SolutionsCache;

        public static CacheHelper SolutionsCache
        {
            get
            {
                if (_SolutionsCache == null)
                    _SolutionsCache = new CacheHelper();
                return _SolutionsCache;
            }
        }
    }
}