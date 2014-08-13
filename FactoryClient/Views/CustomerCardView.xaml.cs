using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Factory.Client.ViewModels;


namespace Factory.Client.Views
{
	public partial class CustomerCardView : UserControl
	{
        public CustomerCardView(CustomerDetailsViewModel vw)
		{
			this.InitializeComponent();
            this.DataContext = vw;
		}
	}
}