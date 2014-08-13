namespace Factory.Client.ViewModels
{
    using Microsoft.Practices.Prism;
    using Microsoft.Practices.Prism.Commands;
    using Microsoft.Practices.Prism.Regions;
    using Microsoft.Practices.ServiceLocation;
    using Microsoft.Practices.Prism.Mvvm;
    using Microsoft.Practices.Prism.Interactivity.InteractionRequest;
    using Microsoft.Practices.Prism.PubSubEvents;
    using Microsoft.Practices.Unity;
    using System;
    using System.Collections.ObjectModel;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Windows.Data;
    using System.Windows.Input;
    using System.Windows;
    using System.Windows.Threading;
    

    using Factory.Common;
    using Factory.Client.Services;
    using Factory.Base.Models;
    //using Factory.Client.Views;
    
    public class CustomerListViewModel : BindableBase , INavigationAware
    {
        #region Private Properties

        private readonly ObservableCollection<Customer> _customers;
        private readonly ICollectionView customersView;
        private Customer _currentCustomer;
        private IUnityContainer _container;
        private IRegionManager _regionManager;
        private IEventAggregator _eventAggregator;
        private IClientLayer _clientLayer;

        #endregion

        #region Команды

        #region Создание

        private readonly DelegateCommand<Customer> _сreateCustomerCommand;
        public ICommand CreateCustomerCommand
        {
            get { return _сreateCustomerCommand; }
        }

        private void CreateCustomer(Customer customer)
        {
            ShowCustomersDetails(true);
        }

        #endregion Создание

        #region Редактирование и проверка

        private readonly DelegateCommand<bool?> _editCustomerDetailsCommand;
        private bool _enableEditCustomerDetails;

        public bool EnableEditCustomerDetails
        {
            get { return _enableEditCustomerDetails; }
            set { this.SetProperty(ref _enableEditCustomerDetails, value); }
        }

        public ICommand EditCustomerDetailsCommand
        {
            get { return _editCustomerDetailsCommand; }
        }

        private void ExecuteEditCustomerDetails(bool? show)
        {
            if (show != null)
            {
                this.EnableEditCustomerDetails = show.Value;
                this.EditCustomerDetails();
            }
        }

        private bool CanExecuteEditCustomerDetails(bool? show)
        {
            return this.customersView.CurrentItem != null;
        }

        private void EditCustomerDetails()
        {
            _currentCustomer = customersView.CurrentItem as Customer;
            if (_currentCustomer != null)
            {
                ShowCustomersDetails(false);
            }
        }
                
        #endregion Редактирование и проверка

        

        #endregion Команды

        #region Public Properties

        public ICollectionView Customers 
        {
            get { return customersView; }
        }

        #endregion Public Properties

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductViewModel"/> class.
        /// </summary>
        public CustomerListViewModel(IUnityContainer container,
                            IRegionManager regionManager,
                            IEventAggregator eventAggregator)
        {
            _container = container;
            _eventAggregator = eventAggregator;
            _regionManager = regionManager;

            _clientLayer = new ClientLayer();


            _customers = new ObservableCollection<Customer>();
            customersView = new ListCollectionView(_customers);

            _editCustomerDetailsCommand = new DelegateCommand<bool?>(this.ExecuteEditCustomerDetails, this.CanExecuteEditCustomerDetails);
            _сreateCustomerCommand = new DelegateCommand<Customer>(this.CreateCustomer);

            customersView.CurrentChanged += (s, e) => _editCustomerDetailsCommand.RaiseCanExecuteChanged();

            IEnumerable<Customer> newCustomers = _clientLayer.GetAllCustomers();
            foreach (var item in newCustomers)
            {
                _customers.Add(item);    
            }
        }

        #endregion Constructor

        #region Public Methods

        #region Navigation
        public Boolean IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            _currentCustomer = (Customer)navigationContext.Parameters["CurrentCustomer"];
            string status = (string)navigationContext.Parameters["StatusCustomer"];
            if (_currentCustomer != null && status != "CancelCustomer")
            {
                if (status == "NewCustomer") _customers.Add(_currentCustomer);
                Customers.MoveCurrentTo(_currentCustomer);
                Customers.Refresh();
            }
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            //_currentCustomer  = _customersView.CurrentItem as Customer;
            //navigationContext.Parameters.Add("CurrentCustomer", _currentCustomer);
        }

        #endregion Navigation

        #endregion Public Methods

        #region Private Methods

        private void ShowCustomersDetails(bool isNew)
        {
            NavigationParameters navigationParameters = new NavigationParameters();
            if (isNew == true)
                navigationParameters.Add("StatusCustomer", "NewCustomer");
            else 
            {
                if (_currentCustomer != null) navigationParameters.Add("CurrentCustomer", _currentCustomer);
                navigationParameters.Add("StatusCustomer", "EditCustomer");
            }
            //_regionManager.RequestNavigate(RegionNames.MainRegion, ViewNames.CustomerDetailsView, navigationParameters);
            _regionManager.RequestNavigate(RegionNames.MainRegion, ViewNames.CustomerCardView, navigationParameters);
            //_regionManager.RequestNavigate(RegionNames.MainRegion,new Uri(ViewNames.CustomerDetailsView, UriKind.Relative), navigationParameters);
        }

        private void SelectedCustomerChanged(object sender, EventArgs e)
        {
            //для динамического просмотра
        }

        #endregion Private Methods

    }
}