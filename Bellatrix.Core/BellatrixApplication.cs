namespace Bellatrix.Core
{
    public sealed class BellatrixApplication
    {
        #region Singleton

        private static volatile BellatrixApplication instance;
        private static object syncRoot = new object();

        public static BellatrixApplication Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new BellatrixApplication();
                        }
                    }
                }
                return instance;
            }
        }

        private BellatrixApplication()
        {
        }

        #endregion

        private IResolver resolver;

        public IResolver Resolver
        {
            get { return resolver; }
            set { resolver = value; }
        }
    }
}