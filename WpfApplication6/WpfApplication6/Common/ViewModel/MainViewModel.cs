using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Configuration;
using ZT.Common;
using GalaSoft.MvvmLight.Command;
using CaculateLibrary;
namespace WpfApplication6.Common.ViewModel
{
    public partial class MainViewModel : ViewModelBase
    {
        #region fields
        private ObservableCollection<StorageModel> _StorageCol = new ObservableCollection<StorageModel>();
        private ObservableCollection<string> _AreaCol = new ObservableCollection<string>();
        public ObservableCollection<StorageModule.Storage> _StoragePerAreaCol = new ObservableCollection<StorageModule.Storage>();
        public ObservableCollection<GoodsModel> _GoodsCol = new ObservableCollection<GoodsModel>();
        private float _FirstAdd1;
        private float _SecondAdd1;
        private float _LValue1;
        private float _DValue1;
        private float _LTotalValue;
        private float _DTotalValue;

        private float _FirstAdd2;
        private float _SecondAdd2;
        private float _LValue2;
        private float _DValue2;

        private float _FirstAdd3;
        private float _SecondAdd3;
        private float _LValue3;
        private float _DValue3;


        private float _FirstAdd4;
        private float _SecondAdd4;
        private float _LValue4;
        private float _DValue4;

        private float _FirstAdd5;
        private float _SecondAdd5;
        private float _LValue5;
        private float _DValue5;



        private float _FirstAdd6;
        private float _SecondAdd6;
        private float _LValue6;
        private float _DValue6;


        private float _FirstAdd7;
        private float _SecondAdd7;
        private float _LValue7;
        private float _DValue7;


        private float _FirstAdd8;
        private float _SecondAdd8;
        private float _LValue8;
        private float _DValue8;

        private float _FirstAdd9;
        private float _SecondAdd9;
        private float _LValue9;
        private float _DValue9;

        private float _FirstAdd10;
        private float _SecondAdd10;
        private float _LValue10;
        private float _DValue10;


        #endregion

        public MainViewModel()
        {
            this.StorageView = CollectionViewSource.GetDefaultView(this._StorageCol);
            this.AreaView = CollectionViewSource.GetDefaultView(this._AreaCol);
            this.StoragePerAreaView = CollectionViewSource.GetDefaultView(this._StoragePerAreaCol);
            this.GoodsView = CollectionViewSource.GetDefaultView(this._GoodsCol);
            this.AreaView.CurrentChanged += new EventHandler(AreaView_CurrentChanged);
            LoadData();
            RegisterCommand();
        }

        void AreaView_CurrentChanged(object sender, EventArgs e)
        {
            if (this.AreaView.CurrentItem == null) return;
            {
                if (this._StoragePerAreaCol.Count == 0) this._StoragePerAreaCol.Add(new StorageModule.Storage(Guid.Empty, "请选择", 0, string.Empty, string.Empty, 42, string.Empty));
                var toBeUserd = this._StoragePerAreaCol.Where(m => m.ID != Guid.Empty).ToArray();
                foreach (var item in toBeUserd)
                {
                    this._StoragePerAreaCol.Remove(item);
                }
                var data = StorageModule.GetStorageByArea(ConfigManager.StorageFileName, this.AreaView.CurrentItem.ToString());
                if (data == null) return;
                foreach (var item in data) this._StoragePerAreaCol.Add(item);
            }
        }


        #region Properties
        public ICollectionView StorageView { get; set; }
        public ICollectionView AreaView { get; set; }
        public ICollectionView StoragePerAreaView { get; set; }
        public ICollectionView GoodsView { get; set; }
        public float FirstAdd1
        {
            get
            {
                return _FirstAdd1;
            }
            set
            {
                if (_FirstAdd1 != value)
                {
                    _FirstAdd1 = value;
                    LValue1 = value * SecondAdd1;
                    DValue1 = CaculateLibrary.YZModule.lTod(LValue1);
                    RaisePropertyChanged(() => this.FirstAdd1);
                }
            }
        }
        public float SecondAdd1
        {
            get { return _SecondAdd1; }
            set
            {
                if (_SecondAdd1 != value)
                {
                    _SecondAdd1 = value;
                    LValue1 = value * FirstAdd1;
                    DValue1 = CaculateLibrary.YZModule.lTod(LValue1);
                    RaisePropertyChanged(() => this.SecondAdd1);
                }
            }
        }
        public float LValue1
        {
            get
            {
                return _LValue1;
            }
            set
            {
                if (_LValue1 != value)
                {
                    _LValue1 = value;
                    LTotalValue = value + LValue2 + LValue3 + LValue4 + LValue5 + LValue6 + LValue7 + LValue8 + LValue9 + LValue10;
                    DTotalValue = CaculateLibrary.YZModule.lTod(LTotalValue);
                    RaisePropertyChanged(() => this.LValue1);
                }
            }
        }
        public float DValue1
        {
            get
            {
                return _DValue1;
            }
            set
            {
                if (_DValue1 != value)
                {
                    _DValue1 = value;
                    RaisePropertyChanged(() => this.DValue1);
                }
            }
        }






        public float FirstAdd2
        {
            get
            {
                return _FirstAdd2;
            }
            set
            {
                if (_FirstAdd2 != value)
                {
                    _FirstAdd2 = value;
                    LValue2 = value * SecondAdd2;
                    DValue2 = CaculateLibrary.YZModule.lTod(LValue2);
                    RaisePropertyChanged(() => this.FirstAdd2);
                }
            }
        }
        public float SecondAdd2
        {
            get { return _SecondAdd2; }
            set
            {
                if (_SecondAdd2 != value)
                {
                    _SecondAdd2 = value;
                    LValue2 = value * FirstAdd2;
                    DValue2 = CaculateLibrary.YZModule.lTod(LValue2);
                    RaisePropertyChanged(() => this.SecondAdd2);
                }
            }
        }
        public float LValue2
        {
            get
            {
                return _LValue2;
            }
            set
            {
                if (_LValue2 != value)
                {
                    _LValue2 = value;
                    LTotalValue = value + LValue1 + LValue3 + LValue4 + LValue5 + LValue6 + LValue7 + LValue8 + LValue9 + LValue10;
                    DTotalValue = CaculateLibrary.YZModule.lTod(LTotalValue);
                    RaisePropertyChanged(() => this.LValue2);
                }
            }
        }
        public float DValue2
        {
            get
            {
                return _DValue2;
            }
            set
            {
                if (_DValue2 != value)
                {
                    _DValue2 = value;
                    RaisePropertyChanged(() => this.DValue2);
                }
            }
        }





        public float FirstAdd3
        {
            get
            {
                return _FirstAdd3;
            }
            set
            {
                if (_FirstAdd3 != value)
                {
                    _FirstAdd3 = value;
                    LValue3 = value * SecondAdd3;
                    DValue3 = CaculateLibrary.YZModule.lTod(LValue3);
                    RaisePropertyChanged(() => this.FirstAdd3);
                }
            }
        }
        public float SecondAdd3
        {
            get { return _SecondAdd3; }
            set
            {
                if (_SecondAdd3 != value)
                {
                    _SecondAdd3 = value;
                    LValue3 = value * FirstAdd3;
                    DValue3 = CaculateLibrary.YZModule.lTod(LValue3);
                    RaisePropertyChanged(() => this.SecondAdd3);
                }
            }
        }
        public float LValue3
        {
            get
            {
                return _LValue3;
            }
            set
            {
                if (_LValue3 != value)
                {
                    _LValue3 = value;
                    LTotalValue = value + LValue1 + LValue2 + LValue4 + LValue5 + LValue6 + LValue7 + LValue8 + LValue9 + LValue10;
                    DTotalValue = CaculateLibrary.YZModule.lTod(LTotalValue);

                    RaisePropertyChanged(() => this.LValue3);
                }
            }
        }
        public float DValue3
        {
            get
            {
                return _DValue3;
            }
            set
            {
                if (_DValue3 != value)
                {
                    _DValue3 = value;
                    RaisePropertyChanged(() => this.DValue3);
                }
            }
        }





        public float FirstAdd4
        {
            get
            {
                return _FirstAdd4;
            }
            set
            {
                if (_FirstAdd4 != value)
                {
                    _FirstAdd4 = value;
                    LValue4 = value * SecondAdd4;
                    DValue4 = CaculateLibrary.YZModule.lTod(LValue4);
                    RaisePropertyChanged(() => this.FirstAdd4);
                }
            }
        }
        public float SecondAdd4
        {
            get { return _SecondAdd4; }
            set
            {
                if (_SecondAdd4 != value)
                {
                    _SecondAdd4 = value;
                    LValue4 = value * FirstAdd4;
                    DValue4 = CaculateLibrary.YZModule.lTod(LValue4);
                    RaisePropertyChanged(() => this.SecondAdd4);
                }
            }
        }
        public float LValue4
        {
            get
            {
                return _LValue4;
            }
            set
            {
                if (_LValue4 != value)
                {
                    _LValue4 = value;
                    LTotalValue = value + LValue1 + LValue2 + LValue3 + LValue5 + LValue6 + LValue7 + LValue8 + LValue9 + LValue10;
                    DTotalValue = CaculateLibrary.YZModule.lTod(LTotalValue);
                    RaisePropertyChanged(() => this.LValue4);
                }
            }
        }
        public float DValue4
        {
            get
            {
                return _DValue4;
            }
            set
            {
                if (_DValue4 != value)
                {
                    _DValue4 = value;
                    RaisePropertyChanged(() => this.DValue4);
                }
            }
        }



        public float FirstAdd5
        {
            get
            {
                return _FirstAdd5;
            }
            set
            {
                if (_FirstAdd5 != value)
                {
                    _FirstAdd5 = value;
                    LValue5 = value * SecondAdd5;
                    DValue5 = CaculateLibrary.YZModule.lTod(LValue5);
                    RaisePropertyChanged(() => this.FirstAdd5);
                }
            }
        }
        public float SecondAdd5
        {
            get { return _SecondAdd5; }
            set
            {
                if (_SecondAdd5 != value)
                {
                    _SecondAdd5 = value;
                    LValue5 = value * FirstAdd5;
                    DValue5 = CaculateLibrary.YZModule.lTod(LValue5);
                    RaisePropertyChanged(() => this.SecondAdd5);
                }
            }
        }
        public float LValue5
        {
            get
            {
                return _LValue5;
            }
            set
            {
                if (_LValue5 != value)
                {
                    _LValue5 = value;
                    LTotalValue = value + LValue1 + LValue2 + LValue4 + LValue3 + LValue6 + LValue7 + LValue8 + LValue9 + LValue10;
                    DTotalValue = CaculateLibrary.YZModule.lTod(LTotalValue);
                    RaisePropertyChanged(() => this.LValue5);
                }
            }
        }
        public float DValue5
        {
            get
            {
                return _DValue5;
            }
            set
            {
                if (_DValue5 != value)
                {
                    _DValue5 = value;
                    RaisePropertyChanged(() => this.DValue5);
                }
            }
        }



        public float FirstAdd6
        {
            get
            {
                return _FirstAdd6;
            }
            set
            {
                if (_FirstAdd6 != value)
                {
                    _FirstAdd6 = value;
                    LValue6 = value * SecondAdd6;
                    DValue6 = CaculateLibrary.YZModule.lTod(LValue6);
                    RaisePropertyChanged(() => this.FirstAdd6);
                }
            }
        }
        public float SecondAdd6
        {
            get { return _SecondAdd6; }
            set
            {
                if (_SecondAdd6 != value)
                {
                    _SecondAdd6 = value;
                    LValue6 = value * FirstAdd6;
                    DValue6 = CaculateLibrary.YZModule.lTod(LValue6);
                    RaisePropertyChanged(() => this.SecondAdd6);
                }
            }
        }
        public float LValue6
        {
            get
            {
                return _LValue6;
            }
            set
            {
                if (_LValue6 != value)
                {
                    _LValue6 = value;
                    LTotalValue = value + LValue1 + LValue3 + LValue4 + LValue5 + LValue2 + LValue7 + LValue8 + LValue9 + LValue10;
                    DTotalValue = CaculateLibrary.YZModule.lTod(LTotalValue);
                    RaisePropertyChanged(() => this.LValue6);
                }
            }
        }
        public float DValue6
        {
            get
            {
                return _DValue6;
            }
            set
            {
                if (_DValue6 != value)
                {
                    _DValue6 = value;
                    RaisePropertyChanged(() => this.DValue6);
                }
            }
        }




        public float FirstAdd7
        {
            get
            {
                return _FirstAdd7;
            }
            set
            {
                if (_FirstAdd7 != value)
                {
                    _FirstAdd7 = value;
                    LValue7 = value * SecondAdd7;
                    DValue7 = CaculateLibrary.YZModule.lTod(LValue7);
                    RaisePropertyChanged(() => this.FirstAdd7);
                }
            }
        }
        public float SecondAdd7
        {
            get { return _SecondAdd7; }
            set
            {
                if (_SecondAdd7 != value)
                {
                    _SecondAdd7 = value;
                    LValue7 = value * FirstAdd7;
                    DValue7 = CaculateLibrary.YZModule.lTod(LValue7);
                    RaisePropertyChanged(() => this.SecondAdd7);
                }
            }
        }
        public float LValue7
        {
            get
            {
                return _LValue7;
            }
            set
            {
                if (_LValue7 != value)
                {
                    _LValue7 = value;
                    LTotalValue = value + LValue1 + LValue3 + LValue4 + LValue5 + LValue6 + LValue2 + LValue8 + LValue9 + LValue10;
                    DTotalValue = CaculateLibrary.YZModule.lTod(LTotalValue);
                    RaisePropertyChanged(() => this.LValue7);
                }
            }
        }
        public float DValue7
        {
            get
            {
                return _DValue7;
            }
            set
            {
                if (_DValue7 != value)
                {
                    _DValue7 = value;
                    RaisePropertyChanged(() => this.DValue7);
                }
            }
        }




        public float FirstAdd10
        {
            get
            {
                return _FirstAdd10;
            }
            set
            {
                if (_FirstAdd10 != value)
                {
                    _FirstAdd10 = value;
                    LValue10 = value * SecondAdd10;
                    DValue10 = CaculateLibrary.YZModule.lTod(LValue10);
                    RaisePropertyChanged(() => this.FirstAdd10);
                }
            }
        }
        public float SecondAdd10
        {
            get { return _SecondAdd10; }
            set
            {
                if (_SecondAdd10 != value)
                {
                    _SecondAdd10 = value;
                    LValue10 = value * FirstAdd10;
                    DValue10 = CaculateLibrary.YZModule.lTod(LValue10);
                    RaisePropertyChanged(() => this.SecondAdd10);
                }
            }
        }
        public float LValue10
        {
            get
            {
                return _LValue10;
            }
            set
            {
                if (_LValue10 != value)
                {
                    _LValue10 = value;
                    LTotalValue = value + LValue1 + LValue3 + LValue4 + LValue5 + LValue6 + LValue7 + LValue8 + LValue9 + LValue2;
                    DTotalValue = CaculateLibrary.YZModule.lTod(LTotalValue);
                    RaisePropertyChanged(() => this.LValue10);
                }
            }
        }
        public float DValue10
        {
            get
            {
                return _DValue10;
            }
            set
            {
                if (_DValue10 != value)
                {
                    _DValue10 = value;
                    RaisePropertyChanged(() => this.DValue10);
                }
            }
        }





        public float FirstAdd8
        {
            get
            {
                return _FirstAdd8;
            }
            set
            {
                if (_FirstAdd8 != value)
                {
                    _FirstAdd8 = value;
                    LValue8 = value * SecondAdd8;
                    DValue8 = CaculateLibrary.YZModule.lTod(LValue8);
                    RaisePropertyChanged(() => this.FirstAdd8);
                }
            }
        }
        public float SecondAdd8
        {
            get { return _SecondAdd8; }
            set
            {
                if (_SecondAdd8 != value)
                {
                    _SecondAdd8 = value;
                    LValue8 = value * FirstAdd8;
                    DValue8 = CaculateLibrary.YZModule.lTod(LValue8);
                    RaisePropertyChanged(() => this.SecondAdd8);

                }
            }
        }
        public float LValue8
        {
            get
            {
                return _LValue8;
            }
            set
            {
                if (_LValue8 != value)
                {
                    _LValue8 = value;
                    LTotalValue = value + LValue1 + LValue3 + LValue4 + LValue5 + LValue6 + LValue7 + LValue2 + LValue9 + LValue10;
                    DTotalValue = CaculateLibrary.YZModule.lTod(LTotalValue);
                    RaisePropertyChanged(() => this.LValue8);
                }
            }
        }
        public float DValue8
        {
            get
            {
                return _DValue8;
            }
            set
            {
                if (_DValue8 != value)
                {
                    _DValue8 = value;
                    RaisePropertyChanged(() => this.DValue8);
                }
            }
        }



        public float FirstAdd9
        {
            get
            {
                return _FirstAdd9;
            }
            set
            {
                if (_FirstAdd9 != value)
                {
                    _FirstAdd9 = value;
                    LValue9 = value * SecondAdd9;
                    DValue9 = CaculateLibrary.YZModule.lTod(LValue9);
                    RaisePropertyChanged(() => this.FirstAdd9);
                }
            }
        }
        public float SecondAdd9
        {
            get { return _SecondAdd9; }
            set
            {
                if (_SecondAdd9 != value)
                {
                    _SecondAdd9 = value;
                    LValue9 = value * FirstAdd9;
                    DValue9 = CaculateLibrary.YZModule.lTod(LValue9);
                    RaisePropertyChanged(() => this.SecondAdd9);
                }
            }
        }
        public float LValue9
        {
            get
            {
                return _LValue9;
            }
            set
            {
                if (_LValue9 != value)
                {
                    _LValue9 = value;
                    LTotalValue = value + LValue1 + LValue3 + LValue4 + LValue5 + LValue6 + LValue7 + LValue8 + LValue2 + LValue10;
                    DTotalValue = CaculateLibrary.YZModule.lTod(LTotalValue);
                    RaisePropertyChanged(() => this.LValue9);
                }
            }
        }
        public float DValue9
        {
            get
            {
                return _DValue9;
            }
            set
            {
                if (_DValue9 != value)
                {
                    _DValue9 = value;
                    RaisePropertyChanged(() => this.DValue9);
                }
            }
        }


        public float LTotalValue
        {
            get
            {
                return _LTotalValue;
            }
            set
            {
                if (_LTotalValue != value)
                {
                    _LTotalValue = value;
                    RaisePropertyChanged(() => this.LTotalValue);
                }
            }
        }
        public float DTotalValue
        {
            get
            {
                return _DTotalValue;
            }
            set
            {
                if (_DTotalValue != value)
                {
                    _DTotalValue = value;
                    RaisePropertyChanged(() => this.DTotalValue);
                }
            }
        }


        #endregion

        #region Command
        public RelayCommand StorageQueryCmd { get; set; }
        public RelayCommand GoodsQueryCmd { get; set; }
        public RelayCommand DelStorageCmd { get; set; }
        public RelayCommand DelGoodsCmd { get; set; }
        #endregion

        private void RegisterCommand()
        {

            this.StorageQueryCmd = new RelayCommand(() =>
            {
                this._StorageCol.Clear();
                var data = CaculateLibrary.StorageModule.GetStorageByCondition(ConfigManager.StorageFileName, this.Area.Trim(), this.Code.Trim(), this.UserName.Trim(), this.AccountName.Trim(), this.FreeSpace);
                if (data == null) return;
                foreach (var item in data) this._StorageCol.Add(new StorageModel(item));
            });

            this.GoodsQueryCmd = new RelayCommand(() =>
            {
                this._GoodsCol.Clear();
                var data = GoodsModule.GetGoodsByCondition(ConfigManager.GoodsFileName, ConfigManager.StorageFileName, this.GoodsCode, this.GoodsLeftDay, this.GoodsStorage, this.GoodsStorage==Guid.Empty?this.GoodsArea:string.Empty);
                if (data == null) return;
                foreach (var item in data) this._GoodsCol.Add(new GoodsModel(item));
            });

            this.DelStorageCmd = new RelayCommand(() =>
            {
                if (this.StorageView.CurrentItem == null) return;
                StorageModel model = this.StorageView.CurrentItem as StorageModel;
                StorageModule.DelStorage(ConfigManager.StorageFileName,ConfigManager.GoodsFileName, model.ID.ToString());
                this._StorageCol.Remove(model);
                var target = this._GoodsCol.Where(m => m.StorageId == model.ID).ToArray();
                foreach (var item in target)
                {
                    this._GoodsCol.Remove(item);
                }
            });

            this.DelGoodsCmd = new RelayCommand(() =>
            {
                if (this.GoodsView.CurrentItem == null) return;
                GoodsModel model = this.GoodsView.CurrentItem as GoodsModel;
                GoodsModule.DelGoods(ConfigManager.GoodsFileName, model.ID.ToString());
                this._GoodsCol.Remove(model);
            });
        }

        private void LoadData()
        {
            LoadStorageData();
            LoadAreaData();
            LoadGoodsData();
        }

        public void LoadGoodsData()
        {
            var data = GoodsModule.GetGoods(ConfigManager.GoodsFileName);
            if (data == null) return;
            foreach (var item in data) this._GoodsCol.Add(new GoodsModel(item));
        }

        private void LoadAreaData()
        {
            var data = StorageModule.GetAllAreas(ConfigManager.StorageFileName);
            if (data == null) return;
            foreach (var item in data) this._AreaCol.Add(item);
        }

        private void LoadStorageData()
        {
            var data = CaculateLibrary.StorageModule.GetStorage(ConfigManager.StorageFileName);
            if (data != null)
            {
                foreach (var item in data)
                {
                    this._StorageCol.Add(new StorageModel(item));
                }
            }
        }
    }
}
