using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

using Factory.Base.Models;
using Factory.Common;
using Factory.Client.Views;
using Factory.Client.ViewModels;

namespace Factory.Client.Services
{
    public class MainRegionController
    {
        private readonly IUnityContainer container;
        private readonly IRegionManager regionManager;
        private readonly IEventAggregator eventAggregator;
        private readonly ICustomerRepository dataService;

        public MainRegionController(IUnityContainer container,
                                    IRegionManager regionManager,
                                    IEventAggregator eventAggregator,
                                    ICustomerRepository dataService)
        {
            if (container == null) throw new ArgumentNullException("container");
            if (regionManager == null) throw new ArgumentNullException("regionManager");
            if (eventAggregator == null) throw new ArgumentNullException("eventAggregator");
            if (dataService == null) throw new ArgumentNullException("dataService");

            this.container = container;
            this.regionManager = regionManager;
            this.eventAggregator = eventAggregator;
            this.dataService = dataService;

            // Подписываемся на событие
            this.eventAggregator.GetEvent<CustomerSelectedEvent>().Subscribe(this.CustomerSelected, true);
        }

        private void CustomerSelected(string id)
        {
            if (string.IsNullOrEmpty(id)) return;

            Customer selectedCustomer = this.dataService.GetCustomers().FirstOrDefault(item => item.Id == id);
            
            IRegion mainRegion = this.regionManager.Regions[RegionNames.MainRegion];
            if (mainRegion == null) return;

            CustomerDetailsView view = mainRegion.GetView("CustomerDetailsView") as CustomerDetailsView;
            if (view == null)
            {
                view = this.container.Resolve<CustomerDetailsView>();
                mainRegion.Add(view, "CustomerDetailsView");
            }
            else
            {
                mainRegion.Activate(view);
            }

            // Set the current employee property on the view model.
            CustomerDetailsViewModel viewModel = view.DataContext as CustomerDetailsViewModel;
            if (viewModel != null)
            {
                viewModel.CurrentCustomer = selectedCustomer;
            }
        }

    }
}
