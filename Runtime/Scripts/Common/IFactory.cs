namespace DanPie.Framework.Common
{
    public interface IFactory<TProducingType>
    {
        TProducingType Create();
    }
}
