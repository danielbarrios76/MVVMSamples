using ProductInterface;

namespace DALFactory
{
    public abstract class BaseCreator
    {
        public abstract IProduct GetDALProduct();

        public string GetIdentity(IProduct product)
        {
            return product.GetType().FullName;
        }
    }
}
