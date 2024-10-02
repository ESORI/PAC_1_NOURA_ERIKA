using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using WPF_MVVM_SPA_Template.Models;
using WPF_MVVM_SPA_Template.Views;

namespace WPF_MVVM_SPA_Template.ViewModels
{
    class Option3ViewModel : INotifyPropertyChanged
    {
        private readonly MainViewModel _mainViewModel;
        private readonly Option2ViewModel _option2ViewModel;
        private readonly BankInfoFormsViewModel _bankInfoFormsViewModel;


        public ObservableCollection<BancClientInfo> BancClientInfo { get; set; } = new ObservableCollection<BancClientInfo>();



        private BancClientInfo? _selectedInfo;
        public BancClientInfo? SelectedInfo
        {
            get { return _selectedInfo; }
            set { _selectedInfo = value; OnPropertyChanged(); }
        }

        public int IBCId;

        public RelayCommand AddBCInfoCommand { get; set; }
        public RelayCommand RemoveBCInfoCommand { get; set; }
        public RelayCommand EditBCInfoCommand { get; set; }

        

        public Option3ViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
            _option2ViewModel = mainViewModel.Option2VM;
            IBCId = 0;

            BancClientInfo.Add(new BancClientInfo { Id = 1, IBAN = "DE44 1234 1234 1234 1234 00", SavedIncome = 20000, Debt = 1654, Pin = 2323, ClientNom = _option2ViewModel.GetNomById(1) });
            BancClientInfo.Add(new BancClientInfo { Id = 2, IBAN = "GB29 NWBK 6016 1331 9268 19", SavedIncome = 5000, Debt = 0, Pin = 1111, ClientNom=_option2ViewModel.GetNomById(2) });

            AddBCInfoCommand = new RelayCommand(x => AddBCInfo());
            EditBCInfoCommand = new RelayCommand(x => EditBCInfo());
            //RemoveBCInfoCommand = new RelayCommand(x => RemBCInfo());
        }

        private void AddBCInfo()
        {
            if(SelectedInfo == null)
            {
                _mainViewModel.isEdit = false;
                _mainViewModel.SelectedView = "BIF";
                //BancClientInfo.Add(new BancClientInfo { Id = BancClientInfo.Count + 1, IBAN = "ex", SavedIncome = 0, Debt = 0, Pin = 4526, ClientNom = _option2ViewModel.GetNomById(BancClientInfo.Count + 1) });

            }
            else
            {
                
            }
            
            
        }
        
        private void EditBCInfo()
        {
            if (SelectedInfo != null)
            {
                _mainViewModel.isEdit = true;
                IBCId = SelectedInfo.Id;
                MessageBox.Show(IBCId.ToString());
                _mainViewModel.SelectedView = "BIF";
            }
        }


        private void RemBCInfo()
        {
            if (SelectedInfo != null)
                BancClientInfo.Remove(SelectedInfo);
        }

        public string GetIBANById(int id)
        {
            var info = BancClientInfo.FirstOrDefault(c => c.Id == id);
            return info != null ? info.IBAN : string.Empty;
        }



        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
