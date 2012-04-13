using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;
using System.Configuration;
using CaculateLibrary;
using System.ComponentModel;
using WpfApplication6;
namespace ZT.Common
{
    public class GoodsModel : ViewModelBase, IEditableObject
    {
        private string _Code;
        private string _Name;
        private int _Quantity;
        private float _LeftDay;
        private Guid _StorageId;
        private string _Desc;
        private float _Price;
        private DateTime _CreateDate;

        public GoodsModel() { }
        public GoodsModel(GoodsModule.Goods goods)
        {
            this.ID = goods.ID;
            this.Code = goods.Code;
            this.Name = goods.Name;
            this.Quantity = goods.Quantity;
            this.LeftDay = goods.LeftDay;
            this.StorageId = goods.StorageId;
            this.Desc = goods.Desc;
            this.Price = goods.Price;
            this.CreateDate = goods.CreateDate;
        }

        public Guid ID { get; set; }

        public DateTime CreateDate
        {
            get { return _CreateDate; }
            set
            {
                if (_CreateDate != value)
                {
                    _CreateDate = value;
                    RaisePropertyChanged(() => this.CreateDate);
                }
            }
        }

        public float Price
        {
            get { return _Price; }
            set
            {
                if (_Price != value)
                {
                    _Price = value;
                    RaisePropertyChanged(() => this.Price);
                }
            }
        }


        public string Desc
        {
            get
            {
                return _Desc;
            }
            set
            {
                if (_Desc != value)
                {
                    _Desc = value;
                    RaisePropertyChanged(() => this.Desc);
                }
            }
        }

        public Guid StorageId
        {
            get
            {
                return _StorageId;
            }
            set
            {
                if (_StorageId != value)
                {
                    _StorageId = value;
                    RaisePropertyChanged(() => this.StorageId);
                }
            }
        }

        public float LeftDay
        {
            get { return _LeftDay; }
            set
            {
                if (_LeftDay != value)
                {
                    _LeftDay = value;
                    RaisePropertyChanged(() => this.LeftDay);
                }
            }
        }

        public int Quantity
        {
            get { return _Quantity; }
            set
            {
                if (_Quantity != value)
                {
                    _Quantity = value;
                    RaisePropertyChanged(() => this.Quantity);
                }
            }
        }
        public string Name
        {
            get { return _Name; }
            set
            {
                if (_Name != value)
                {
                    _Name = value;
                    RaisePropertyChanged(() => this.Name);
                }
            }
        }
        public string Code
        {
            get { return _Code; }
            set
            {
                if (_Code != value)
                {
                    _Code = value;
                    RaisePropertyChanged(() => this.Code);
                }
            }
        }

        public StorageModel[] Storages
        {
            get
            {
                var data = CaculateLibrary.StorageModule.GetStorage(ConfigManager.StorageFileName);
                if (data == null) return null;
                return data.Select(m => new StorageModel(m)).ToArray();
            }
        }

        void IEditableObject.BeginEdit()
        {
           
        }

        void IEditableObject.CancelEdit()
        {
           
        }

        void IEditableObject.EndEdit()
        {
            if (this.ID == Guid.Empty)
            {
                this.ID = Guid.NewGuid();
                this.CreateDate = DateTime.Now;
                var target = new GoodsModule.Goods(this.ID, this.Code, this.Quantity, this.LeftDay, this.StorageId, this.Name, this.Desc, this.Price, this.CreateDate);
                GoodsModule.AddGoods(new GoodsModule.Goods[] { target }, ConfigManager.GoodsFileName);
            }
        }
    }
}
