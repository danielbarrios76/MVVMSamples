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

        private int searchProductID;

        public int SearchProductID
        {
            get { return searchProductID; }
            set
            {
                if (searchProductID != value)
                {
                    searchProductID = value;
                    OnPropertyChanged();
                }
            }
        }





        #endregion

        #region Comandos
        private RelayCommand commandSearch;
        public RelayCommand CommandSearch
        {
            get
            {
                if (commandSearch == null)
                {
                    commandSearch = new RelayCommand(p => GetProductByID(), x => searchProductID > 0);
                }
                return commandSearch;
            }
        }

        private RelayCommand commandClear;
        public RelayCommand CommandClear
        {
            get
            {
                if (commandClear == null)
                {
                    commandClear = new RelayCommand(p => Clear(), p => ProductName != "");
                }
                return commandClear;
            }
        }

        #endregion Comandos

        #region Eventos
        public event Action<object, MessageEventArgs> MessageEvent; 
        public event Action<bool> DiscontinueEvent;
        #endregion Eventos

        public ProductData()
        {
            commandClear = new RelayCommand(p => Clear());
            commandSearch = new RelayCommand(p => GetProductByID());
        }

        #region Metodos

        public void GetProductByID()
        {
            var B = new BLL.Product();
            B.ErrorEvent += (s, ev) =>  MessageEvent?.Invoke(this, new MessageEventArgs(ev.Message));
            Console.WriteLine(searchProductID);
            Entities.Product product = B.GetProductByID(searchProductID);
            if (product != null)
            { 
                this.ProductID = product.ProductID;
                this.ProductName = product.ProductName;
                this.UnitPrice = product.UnitPrice;
                this.UnitsInStock = product.UnitsInStock;
                this.CategoryID = product.CategoryID;
            }

        }

        public void Clear()
        {
            SearchProductID = 0;
            ProductID = 0;
            ProductName = string.Empty;
            UnitPrice = 0;
            UnitsInStock = 0;
            CategoryID = 0;

        }

        #endregion

        #region Clase Anidada
        public class MessageEventArgs : EventArgs
        {
            public string Message { get; set; }
            public int Result { get; set; }
            public MessageEventArgs(string message)
            {
                this.Message = message;
            }
        }
        #endregion

    }
}
