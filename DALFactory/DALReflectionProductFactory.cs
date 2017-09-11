using ProductInterface;
using System.Linq;

namespace DALFactory
{
    public class DALReflectionProductFactory : BaseCreator
    {
        public override IProduct GetDALProduct()
        {
            IProduct Product = null;

            var AssemblyPath = System.Configuration.ConfigurationManager.AppSettings["Product"];
            var AssemblyObject = System.Reflection.Assembly.LoadFrom(AssemblyPath);
            var ProductType = AssemblyObject.GetTypes().Where(T => typeof(IProduct).IsAssignableFrom(T)).FirstOrDefault();

            if (ProductType != null)
            {
                Product = AssemblyObject.CreateInstance(ProductType.FullName) as IProduct;
            }

            return Product;

        }


    }
}
