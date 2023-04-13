using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Recetario
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuMain : TabbedPage
    {
        public MenuMain()
        {
            InitializeComponent();
        }
    }
}