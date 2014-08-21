namespace Factory.Client.ViewModels
{
    using Microsoft.Practices.Prism.Mvvm;
    using Microsoft.Practices.Prism.PubSubEvents;
    using Microsoft.Practices.Prism.Regions;

    using Factory.Base.Models;
    using Factory.Client.Services;
    using System;
    

    public class CustomerDetailsViewModel : BindableBase, INavigationAware
    {
        private Customer _currentCustomer;
        private readonly IEventAggregator _eventAggregator;
        private IClientLayer _clientLayer;

        public CustomerDetailsViewModel(IEventAggregator eventAggregator)
        {
            _clientLayer = new ClientLayer();
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<CustomerSelectedEvent>().Subscribe(this.CustomerSelected, true);
        }

        public string ViewName
        {
            get { return "Customer Details"; }
        }

        public Customer CurrentCustomer
        {
            get { return _currentCustomer; }
            set { SetProperty(ref _currentCustomer, value); }
        }

        private void CustomerSelected(int id)
        {
            CurrentCustomer = _clientLayer.GetCustomerById(id);
        }

        #region Navigation
        public Boolean IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            CurrentCustomer = (Customer)navigationContext.Parameters["CurrentCustomer"];
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            //_currentCustomer  = _customersView.CurrentItem as Customer;
            //navigationContext.Parameters.Add("CurrentCustomer", _currentCustomer);
        }

        #endregion Navigation
    }
}
