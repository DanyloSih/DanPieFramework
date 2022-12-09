namespace DanPie.Framework.WindowSystem
{
	public interface IWindow 
	{
		public int SortOrder { get; }
		public bool IsVisible { get; }	

		public void Show(int order);
		public void Hide();
	}
}