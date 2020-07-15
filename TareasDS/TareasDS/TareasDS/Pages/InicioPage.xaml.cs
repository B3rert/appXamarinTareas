using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TareasDS.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InicioPage : TabbedPage
    {
        public InicioPage()
        {
            InitializeComponent();

            //Pestañas de la TabbedPage
            //Children.Add(new HomePage());
            Children.Add(new ListaTareasPage());
            Children.Add(new NuevaTareaPage());

        }
    }
}