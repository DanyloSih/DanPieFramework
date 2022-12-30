namespace DanPie.Framework.WindowSystem
{
	public interface IWindow 
	{
		public int SortOrder { get; }
		public bool IsVisible { get; }	
		public WindowsCanvas UsingCanvas { get; }	

		public void Show(WindowsCanvas windowsCanvas);
		public void Hide();
	}
}