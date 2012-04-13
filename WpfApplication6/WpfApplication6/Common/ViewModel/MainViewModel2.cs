using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfApplication6.Common.ViewModel
{
    public partial class MainViewModel
    {
        private string _Area = string.Empty;
        private string _AccountName = string.Empty;
        private string _UserName = string.Empty;
        private string _Code = string.Empty;
        private int _FreeSpace = -1;


        private string _GoodsCode = string.Empty;
        private float _GoodsLeftDay = -1;
        private string _GoodsArea = string.Empty;
        private Guid _GoodsStorage;

        public Guid GoodsStorage
        {
            get
            {
                return this._GoodsStorage;
            }
            set
            {
                if (this._GoodsStorage != value)
                {
                    this._GoodsStorage = value;
                    RaisePropertyChanged(() => this.GoodsStorage);
                }
            }
        }

        public string GoodsArea
        {
            get
            {
                return this._GoodsArea;
            }
            set
            {
                if (this._GoodsArea != value)
                {
                    this._GoodsArea = value;
                    RaisePropertyChanged(() => this.GoodsArea);
                }
            }
        }

        public float GoodsLeftDay
        {
            get
            {
                return this._GoodsLeftDay;
            }
            set
            {
                if (this._GoodsLeftDay != value)
                {
                    this._GoodsLeftDay = value;
                    RaisePropertyChanged(() => this.GoodsLeftDay);
                }
            }
        }

        public string GoodsCode
        {
            get
            {
                return this._GoodsCode;
            }
            set
            {
                if (this._GoodsCode != value)
                {
                    this._GoodsCode = value;
                    RaisePropertyChanged(() => this.GoodsCode);
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

        public string AccountName
        {
            get { return _AccountName; }
            set
            {
                if (_AccountName != value)
                {
                    _AccountName = value;
                    RaisePropertyChanged(() => this.AccountName);
                }
            }
        }

        public string UserName
        {
            get { return _UserName; }
            set
            {
                if (_UserName != value)
                {
                    _UserName = value;
                    RaisePropertyChanged(() => this.UserName);
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

        public int FreeSpace
        {
            get { return _FreeSpace; }
            set
            {
                if (_FreeSpace != value)
                {
                    _FreeSpace = value;
                    RaisePropertyChanged(() => this.FreeSpace);
                }
            }
        }

        public IEnumerable<string> Areas
        {
            get
            {
                return CaculateLibrary.StorageModule.GetAllAreas(ConfigManager.StorageFileName);
            }
        }


    }
}
