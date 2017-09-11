using System.Linq;
using ProductInterface;

namespace DALJson
{
    public class Product : IProduct
    {
        public Entities.Product GetProductByID(int ID)
        {
            Entities.Product Product = null;

            using (var Reader = new System.IO.StreamReader("Products.json"))
            {
                var JSON = Reader.ReadToEnd();
                var Products =
                    Newtonsoft.Json.JsonConvert.
                    DeserializeObject<Entities.Product[]>(JSON);
                Product =
                    Products.Where(x => x.ProductID == ID).FirstOrDefault();
            }
            return Product;
        }
    }


}



