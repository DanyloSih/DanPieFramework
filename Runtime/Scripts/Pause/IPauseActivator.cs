using DanPie.Framework.WindowSystem;

namespace DanPie.Framework.Pause
{
    public interface IPauseActivator
    {
        public bool Enabled { get; set; }

        public void Initialize(
            WindowsCanvas pauseWindowCanvas,
            IPauseWindow pauseWindowInstance,
            IPauseController pauseController);
    }
}