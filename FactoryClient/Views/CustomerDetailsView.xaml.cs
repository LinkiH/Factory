using System.Windows.Controls;
using Microsoft.Practices.Prism.Regions;
using Factory.Base.Models;
using Factory.Client.ViewModels;

namespace Factory.Client.Views
{
    /// <summary>
    /// Логика взаимодействия для CustomerDetailsView.xaml
    /// </summary>
    public partial class CustomerDetailsView : UserControl
    {
        public CustomerDetailsView(CustomerDetailsViewModel vm)
        {
            InitializeComponent();
            this.DataContext = vm;
            //RegionContext.GetObservableContext(this).PropertyChanged += (s, e)
            //                                                            =>
            //                                                            DataContext.CurrentCustomer =
            //                                                            RegionContext.GetObservableContext(this).Value
            //                                                            as Customer;
        }
    }
}
