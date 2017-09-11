using System;

namespace BLL
{
    public class Product
    {
        private DALFactory.BaseCreator Factory;
        
        public Product() : this(new DALFactory.DALReferenceProductFactory())
        {

        }

        public Product(DALFactory.BaseCreator factory)
        {
            this.Factory = factory;
        }

        public event Action<object, ErrorEventArgs> ErrorEvent;

        public Entities.Product GetProductByID(int ID)
        {
            Entities.Product Result;
            if(ID>0)
            {
                var D = Factory.GetDALProduct();
                Result = D.GetProductByID(ID);
                if(Result == null && ErrorEvent!= null)
                {
                    ErrorEvent(this, new ErrorEventArgs("Producto no encontrado"));
                }
                ErrorEvent?.Invoke(this, new ErrorEventArgs(Factory.GetIdentity(D)));
            }
            else
            {
                ErrorEvent?.Invoke(this, new ErrorEventArgs("El ID debe ser mayor que cero"));
                Result = null;                
            }
            return Result;
        }

        public class ErrorEventArgs:EventArgs
        {
            public string Message { get; set; }

            public ErrorEventArgs(string message)
            {
                this.Message = message;
            }
            
        }
    }
}
