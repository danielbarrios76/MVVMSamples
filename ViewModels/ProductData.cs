using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ViewModels
{
    public class ProductData : BaseModels
    {
        #region Propiedades

        private int productID;

        public int ProductID
        {
            get { return productID; }
            set
            {
                if (productID != value)
                {
                    productID = value;
                    OnPropertyChanged();
                }
                
            }
        }


        private string productName;

        public string ProductName
        {
            get { return productName; }
            set
            {
                if (productName != value)
                {
                    productName = value;
                    OnPropertyChanged();
                }
                
            }
        }


        private decimal unitPrice;

        public decimal UnitPrice
        {
            get { return unitPrice; }
            set
            {
                if (unitPrice != value)
                {
                    unitPrice = value;
                    OnPropertyChanged();
                }
            }
        }


        private int unitsInStock;

        public int UnitsInStock
        {
            get { return unitsInStock; }
            set
            {
                if (unitsInStock != value)
                {
                    unitsInStock = value;
                    OnPropertyChanged();
                }
            }
        }

        private int categoryID;

        public int CategoryID
        {
            get { return categoryID; }
            set
            {
                if (categoryID!=value)
                {
                    categoryID = value;
                    OnPropertyChanged();
                }
                
            }
        }




        #endregion

        public event Action<object, MessageEventArgs> MessageEvent; //este es el evento que va a la vista

        #region Metodos

        public void GetProductByID(int id)
        {
            var B = new BLL.Product();
            B.ErrorEvent += (s, ev) => { MessageEvent?.Invoke(this, new MessageEventArgs(ev.Message));};

            Entities.Product product = B.GetProductByID(id);

            this.ProductID = product.ProductID;
            this.ProductName = product.ProductName;
            this.UnitPrice = product.UnitPrice;
            this.UnitsInStock = product.UnitsInStock;
            this.CategoryID = product.CategoryID;

        }

        #endregion

        #region Clase Anidada
        public class MessageEventArgs : EventArgs
        {
            public string Message { get; set; }
            public MessageEventArgs(string message)
            {
                this.Message = message;
            }
        }
        #endregion

    }
}
