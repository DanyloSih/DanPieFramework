namespace DanPie.Framework.Common
{
    public interface IActivable
    {
        bool IsActive { get; }

        void Activate();
        void Deactivate();
    }
}