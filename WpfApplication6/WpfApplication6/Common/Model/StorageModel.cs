using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;
using System.ComponentModel;
using System.Configuration;
using WpfApplication6;

namespace ZT.Common
{
    public class StorageModel : ViewModelBase, IEditableObject
    {
        public StorageModel() { }
        public StorageModel(CaculateLibrary.StorageModule.Storage model)
        {
            this.ID =model.ID;
            this.Code = model.Code;
            this.Area =model.Area;
            this.UserAccount = model.UserAccount;
            this.UserName = model.UserName;
            this.Capacity = model.Capacity;
            this.FreeSpace = model.FreeSpace;
        }
        private string _Code;
        private string _Area;
        private string _UserAccount;
        private string _UserName;
        private int _Capacity;
        private int _FreeSpace;
        public Guid ID { get; set; }
        public string Code
        {
            get
            {
                return _Code;
            }
            set
            {
                if (_Code != value)
                {
                    _Code = value;
                    RaisePropertyChanged(() => this.Code);
                }
            }
        }

        public string Area
        {
            get
            {
                return _Area;
            }
            set
            {
                if (_Area != value)
                {
                    _Area = value;
                    RaisePropertyChanged(() => this.Area);
                }
            }
        }

        public string UserAccount
        {
            get
            {
                return _UserAccount;
            }
            set
            {
                if (_UserAccount != value)
                {
                    _UserAccount = value;
                    RaisePropertyChanged(() => this.UserAccount);
                }
            }
        }

        public string UserName
        {
            get
            {
                return _UserName;
            }
            set
            {
                if (_UserName != value)
                {
                    _UserName = value;
                    RaisePropertyChanged(() => this.UserName);
                }
            }
        }

        public int Capacity
        {
            get
            {
                return _Capacity;
            }
            set
            {
                if (_Capacity != value)
                {
                    _Capacity = value;
                    RaisePropertyChanged(() => this.Capacity);
                }
            }
        }

        public int FreeSpace
        {
            get
            {
                return _FreeSpace;
            }
            set
            {
                if (_FreeSpace != value)
                {
                    _FreeSpace = value;
                    RaisePropertyChanged(() => this.FreeSpace);
                }
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
            if (this.ID ==Guid.Empty)
            {
                this.ID=Guid.NewGuid();
                this.Capacity = 42;
                CaculateLibrary.StorageModule.Storage target = new CaculateLibrary.StorageModule.Storage(this.ID, this.Code, this.FreeSpace, this.UserName, this.UserAccount, this.Capacity, this.Area);
                CaculateLibrary.StorageModule.AddStorage(new CaculateLibrary.StorageModule.Storage[] { target }, ConfigManager.StorageFileName);
            }
        }
    }
}
