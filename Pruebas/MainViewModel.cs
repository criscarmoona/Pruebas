using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Pruebas
{
    public class MainViewModel : ViewModelBase
    {

        public ObservableCollection<DatosGraficas> DatosGPastel { get; set; }

        public MainViewModel()
        {
            DatosGPastel = new ObservableCollection<DatosGraficas>(ObtenerDatosGPastel());
        }

        public ObservableCollection<DatosGraficas> ObtenerDatosGPastel()
        {
            return new ObservableCollection<DatosGraficas>
            {
                new DatosGraficas { Etiqueta = "Altos",     Valor = 10 },
                new DatosGraficas { Etiqueta = "Bajos",     Valor = 10 },
                new DatosGraficas { Etiqueta = "Ok",     Valor = 10 }
            };
        }

    }

    public class DatosGraficas 
    {
        public string Etiqueta { get; set; }

        public float Valor { get; set; }
    }

}

