using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TareasDS.Cells
{
    public class TareasCell : ViewCell
    {
        //Personalizar List view
        public TareasCell()
        {
            var ID_TareaLabel = new Label
            {
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            ID_TareaLabel.SetBinding(Label.TextProperty, new Binding("ID_Tarea"));

            var Titulo_de_TareaLabel = new Label
            {
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            Titulo_de_TareaLabel.SetBinding(Label.TextProperty, new Binding("Titulo_de_Tarea"));

            //Vista de la lista
            View = new StackLayout
            {
                Children =
                {
                    ID_TareaLabel, Titulo_de_TareaLabel
                },
                Orientation = StackOrientation.Horizontal
            };

        }


    }
}
