using DanPie.Framework.Pause;

namespace DanPie.Framework.WindowSystem
{
    public class BackgroundWindow : WindowObject, IUnhideableFromPause
    {
        public bool IsPauseWindowCanBeShown()
        {
            return true;
        }
    }
}
