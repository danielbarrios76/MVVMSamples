
using ProductInterface;

namespace DALFactory
{
    public class DALReferenceProductFactory : BaseCreator
    {
        public override IProduct GetDALProduct()
        {
            return new DALJson.Product();
        }
    }
}
