using System;
using DanPie.Framework.WindowSystem;

namespace DanPie.Framework.Pause
{
    public interface IPauseWindow : IWindow
	{
		public event Action OnContinue;
	}
}