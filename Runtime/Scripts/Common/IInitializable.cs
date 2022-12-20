namespace DanPie.Framework.Common
{
    public interface IInitializable
    {
        public bool IsInitialized { get; }

        public void Initialize();

        public bool TryInitialize();

        public void Deinitialize();

        public bool TryDeinitialize();
    }
}
