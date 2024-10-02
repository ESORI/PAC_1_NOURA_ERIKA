using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF_MVVM_SPA_Template.Models;
using WPF_MVVM_SPA_Template.Views;

namespace WPF_MVVM_SPA_Template.ViewModels
{
    class BankInfoFormsViewModel : INotifyPropertyChanged
    {
        private readonly MainViewModel _mainViewModel;
        private readonly Option2ViewModel _option2ViewModel;
        private readonly Option3ViewModel _option3ViewModel;

        public ObservableCollection<BancClientInfo> bancClientInfos {  get; set; } = new ObservableCollection<BancClientInfo>();

        private BancClientInfo? _newInfo;
        public BancClientInfo? NewInfo
        {
            get { return _newInfo; }
            set { _newInfo = value; OnPropertyChanged(); }
        }

        public int newId;

        public RelayCommand SaveBCInfo {  get; set; }
        public RelayCommand CancelBCInfo { get; set; }
        
        public BankInfoFormsViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
            _option2ViewModel = mainViewModel.Option2VM;
            _option3ViewModel = mainViewModel.Option3VM;
            _newInfo = new BancClientInfo();
            newId = _option3ViewModel.BancClientInfo.Count + 1;
            _newInfo.Id = newId;
            _newInfo.ClientNom = _option2ViewModel.GetNomById(newId);




            SaveBCInfo = new RelayCommand(x => Save() );
            CancelBCInfo = new RelayCommand(x => Cancel());
        }

        private void Save()
        {
            if (_newInfo != null)
            {
                if(_option3ViewModel.SelectedInfo == null)
                {
                    //MessageBox.Show(_option3ViewModel.SelectedInfo.Id.ToString());
                    
                    _option3ViewModel.BancClientInfo.Add(_newInfo);

                }
                else
                {
                    _newInfo.Id = _option3ViewModel.SelectedInfo.Id;
                    _newInfo.ClientNom = _option2ViewModel.GetNomById(_option3ViewModel.SelectedInfo.Id);
                    _option3ViewModel.BancClientInfo.Add(_newInfo);
                }
                
            }

            _mainViewModel.SelectedView = "Option3";
        }

        private void Cancel()
        {
            _mainViewModel.SelectedView = "Option3";
        }

        

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
