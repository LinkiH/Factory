namespace Factory.Client.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Data;
    using System.ComponentModel;
    using System.Collections.ObjectModel;
    using Microsoft.Practices.Prism.Mvvm;
    using Microsoft.Practices.Prism.PubSubEvents;
    using Microsoft.Practices.Prism.Commands;
    using Microsoft.Practices.Unity;
    using Microsoft.Practices.Prism.Regions;
    
    using Factory.Common;
    using Factory.Base.Repositories;
    using Factory.Base.Models;
    using Factory.Client.Services;
    public class CustomerDetailsViewModel : BindableBase, INavigationAware
    {
        #region Private Properties

        private IUnityContainer _container;
        private IRegionManager _regionManager;
        private IEventAggregator _eventAggregator;
        private IClientLayer _clientLayer;
        private Customer _currentCustomer;
        private CustomerType _currentCustomerType;
        private ObservableCollection<CustomerType> _customerTypes;

        #endregion Public Properties

        #region Constructor
        public CustomerDetailsViewModel(IUnityContainer container,
                            IRegionManager regionManager,
                            IEventAggregator eventAggregator)
        {
            _container = container;
            _eventAggregator = eventAggregator;
            _regionManager = regionManager;
            _clientLayer = new ClientLayer();
            _currentCustomer = new Customer();
            _customerTypes = new ObservableCollection<CustomerType>(_clientLayer.GetAllCustomerTypes());
        }

        #endregion Constructor

        #region Команды

        #region Сохранить

        private readonly DelegateCommand _saveClickCommand = null;
        

        public DelegateCommand SaveClickCommand
        {
            get
            { return (_saveClickCommand ?? new DelegateCommand(this.SaveCustomerDetails)); }
        }

        private void SaveCustomerDetails()
        {
            if (_currentCustomer != null)
            {
                NavigationParameters navigationParameters = new NavigationParameters();

                if (_currentCustomer.Id == default(int))
                {
                    _currentCustomer.CustomerTypeId = 1;
                    _clientLayer.AddCustomer(_currentCustomer);
                    navigationParameters.Add("StatusCustomer", "NewCustomer");
                }
                else
                {
                    _clientLayer.UpdateCustomer(_currentCustomer);
                    navigationParameters.Add("StatusCustomer", "UpdateCustomer");
                }
                _regionManager.RequestNavigate(RegionNames.MainRegion, ViewNames.CustomerListView, navigationParameters);
                //_regionManager.RequestNavigate(RegionNames.MainRegion, new Uri(ViewNames.CustomerListView, UriKind.Relative), navigationParameters);
            }
            else
            {

               
            }
        }

        #endregion Сохранить

        #region Отмена

        private readonly DelegateCommand _canсelClickCommand = null;


        public DelegateCommand CancelClickCommand
        {
            get
            { return (_canсelClickCommand ?? new DelegateCommand(this.CancelCustomerDetails)); }
        }

        private void CancelCustomerDetails()
        {
            _currentCustomer = null;
            NavigationParameters navigationParameters = new NavigationParameters();
            navigationParameters.Add("StatusCustomer", "CancelCustomer");
            _regionManager.RequestNavigate(RegionNames.MainRegion, ViewNames.CustomerListView, navigationParameters);
            //_regionManager.RequestNavigate(RegionNames.MainRegion, new Uri(ViewNames.CustomerListView, UriKind.Relative), navigationParameters);
        }

        #endregion Отмена

        #endregion Команды

        #region Private Methods


        

        #endregion Private Methods

        #region Public Methods

        public Customer CurrentCustomer
        {
            get { return _currentCustomer; }
            set { SetProperty(ref _currentCustomer, value); }
        }

        public CustomerType CurrentCustomerType
        {
            get { return _currentCustomerType; }
            set { OnPropertyChanged(() => _currentCustomerType); }
        }

        public ObservableCollection<CustomerType> CustomerTypes 
        {
            get { return _customerTypes;}
            set { SetProperty(ref _customerTypes, value);} 
        }

        #endregion Public Methods

        #region Navigation

        public Boolean IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            string status = (string)navigationContext.Parameters["StatusCustomer"];
            if (status == "NewCustomer")
            {
                CurrentCustomer = new Customer();
            }
            else if (status == "EditCustomer")
            {
                CurrentCustomer = (Customer)navigationContext.Parameters["CurrentCustomer"];
                CurrentCustomerType = CurrentCustomer.CustomerType;
                //CustomerType. = CurrentCustomer.CustomerType;
            }
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            navigationContext.Parameters.Add("CurrentCustomer", _currentCustomer);
        }

        #endregion Navigation

    }
}