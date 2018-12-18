using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace E_WELL
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DashBoardTabbedPage : TabbedPage
    {
        public DashBoardTabbedPage ()
        {
            InitializeComponent();
            Children.Add(new DashBoard());
            Children.Add(new DashBoard());
            Children.Add(new DashBoard());
        }
    }
}