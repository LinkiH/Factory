namespace Factory.Client.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Microsoft.Practices.Prism.Mvvm;
    using Microsoft.Practices.Prism.PubSubEvents;
    using Microsoft.Practices.Prism.Commands;
    using Microsoft.Practices.Unity;
    using Microsoft.Practices.Prism.Regions;
    using Microsoft.Practices.Prism.Interactivity.InteractionRequest;
    
    using Factory.Common;
    using Factory.Base.Repositories;
    using Factory.Base.Models;
    using Factory.Client.Services;
    
    public class CustomerCardViewModel : BindableBase, INavigationAware
    {
        #region Private Properties

        private IUnityContainer _container;
        private readonly IRegionManager _regionManager;
        private IEventAggregator _eventAggregator;
        private readonly IClientLayer _clientLayer;
        private Customer _currentCustomer;
        private CustomerType _currentCustomerType;
        private ObservableCollection<CustomerType> _customerTypes;
        private string _resultMessage;

        #endregion Private Properties

        #region Public Properties

        

        #endregion Public Properties

        #region Constructor
        public CustomerCardViewModel(IUnityContainer container,
                            IRegionManager regionManager,
                            IEventAggregator eventAggregator)
        {
            _container = container;
            _eventAggregator = eventAggregator;
            _regionManager = regionManager;

            this.NotificationRequest = new InteractionRequest<INotification>();

            _clientLayer = new ClientLayer();
            CurrentCustomer = new Customer();
            _customerTypes = new ObservableCollection<CustomerType>(_clientLayer.GetAllCustomerTypes());
            //CurrentCustomerType = _currentCustomer.CustomerType;
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
                    //_currentCustomer.CustomerTypeId = _currentCustomerType.Id;
                    _clientLayer.AddCustomer(_currentCustomer);
                    navigationParameters.Add("StatusCustomer", "NewCustomer");
                }
                else
                {
                    _clientLayer.UpdateCustomer(_currentCustomer);
                    navigationParameters.Add("StatusCustomer", "UpdateCustomer");
                }
                RaiseNotification();
                _regionManager.RequestNavigate(RegionNames.MainRegion, ViewNames.CustomerListView, navigationParameters);
                navigationParameters.Add("CurrentCustomer", _currentCustomer);
                _regionManager.RequestNavigate(RegionNames.DetailRegion, ViewNames.CustomerDetailsView, navigationParameters);
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
            
            NavigationParameters navigationParameters = new NavigationParameters();
            navigationParameters.Add("CurrentCustomer", _currentCustomer);
            _regionManager.RequestNavigate(RegionNames.DetailRegion, ViewNames.CustomerDetailsView, navigationParameters);
            _currentCustomer = null;
            navigationParameters.Add("StatusCustomer", "CancelCustomer");
            _regionManager.RequestNavigate(RegionNames.MainRegion, ViewNames.CustomerListView, navigationParameters);
            
            //_regionManager.RequestNavigate(RegionNames.MainRegion, new Uri(ViewNames.CustomerListView, UriKind.Relative), navigationParameters);
        }

        #endregion Отмена

        #endregion Команды

        #region Private Methods

        private void RaiseNotification()
        {
            // By invoking the Raise method we are raising the Raised event and triggering any InteractionRequestTrigger that
            // is subscribed to it.
            // As parameters we are passing a Notification, which is a default implementation of INotification provided by Prism
            // and a callback that is executed when the interaction finishes.
            this.NotificationRequest.Raise(
               new Notification { Content = "Данные сохранены!", Title = "Сохранение.." },
               n => { InteractionResultMessage = "The user was notified."; });
        }

        private void RemoveDetailsView()
        {
            List<object> views = new List<object>();

            if (_regionManager.Regions[RegionNames.DetailRegion] != null)
            {
                foreach (object view in _regionManager.Regions[RegionNames.DetailRegion].ActiveViews)
                {
                    views.Add(view);
                }

                if (views.Count > 0)
                    for (int i = 0; i < views.Count; i++)
                    {
                        _regionManager.Regions[RegionNames.DetailRegion].Remove(views[i]);
                    }
            }
        }

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
            set 
            {
                if (_currentCustomer.CustomerType != value) // && _currentCustomerType != null
                {
                    _currentCustomer.CustomerType = value;
                    _currentCustomer.CustomerTypeId = value.Id;
                }
                SetProperty(ref _currentCustomerType, value); 

            }
        }

        public ObservableCollection<CustomerType> CustomerTypes
        {
            get { return _customerTypes; }
            //set { SetProperty(ref _customerTypes, value); }
        }

        public InteractionRequest<INotification> NotificationRequest { get; private set; }

        public string InteractionResultMessage
        {
            get { return this._resultMessage; }
            set { this._resultMessage = value;this.OnPropertyChanged(() => InteractionResultMessage); }
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
                CurrentCustomerType = null;
            }
            else if (status == "EditCustomer")
            {
                CurrentCustomer = (Customer)navigationContext.Parameters["CurrentCustomer"];
                CurrentCustomerType = CurrentCustomer.CustomerType;
            }
            RemoveDetailsView();
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            navigationContext.Parameters.Add("CurrentCustomer", _currentCustomer);
        }

        #endregion Navigation

    }
}