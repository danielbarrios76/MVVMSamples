namespace ProductInterface
{
    public interface IProduct
    {
        Entities.Product GetProductByID(int ID);
    }
}
