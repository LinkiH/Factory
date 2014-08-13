namespace Factory.Client
{
    using System;
    using Microsoft.Practices.Prism.Modularity;
    using Microsoft.Practices.Prism.Regions;
    using Microsoft.Practices.ServiceLocation;
    using Microsoft.Practices.Unity;

    using Factory.Common;
    using Factory.Client.Views;

    public class ClientModule : IModule
    {
        #region Private Properties
        
        private readonly IUnityContainer _container;
        private readonly IRegionManager _regionManager;

        #endregion Private Properties

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesModule"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="regionManager">The region manager.</param>
        public ClientModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        #endregion Constructor

        #region public Methods

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public void Initialize()
        {
            //Регистрируем в контейнере вьюхи для навигации

            _container.RegisterType<object, CustomerListView>(ViewNames.CustomerListView);
            _container.RegisterType<object, CustomerDetailsView>(ViewNames.CustomerDetailsView);
            _container.RegisterType<object, CustomerCardView>(ViewNames.CustomerCardView);

            //var custViewModel = _container.Resolve<CustomerListViewModel>();
            //var custView = _container.Resolve<CustomerListView>();
            //custView.DataContext = custViewModel;
            //_regionManager.AddToRegion(RegionNames.MainRegion, custView);

            //var detViewModel = _container.Resolve<CustomerDetailsViewModel>();
            //var detView = _container.Resolve<CustomerDetailsView>();
            //detView.DataContext = detViewModel;
            //_regionManager.AddToRegion(RegionNames.DetailRegion, detView);

            ////Регистрация в ServiceLocator по методу view discovery
            //_regionManager.RegisterViewWithRegion(RegionNames.MainRegion,
            //    () => ServiceLocator.Current.GetInstance<CustomerListView>());
            //_regionManager.RegisterViewWithRegion(RegionNames.DetailRegion,
            //    () => ServiceLocator.Current.GetInstance<CustomerDetailsView>());

        }

        #endregion public Methods
    }
}
