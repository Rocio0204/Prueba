using AppPokeApi.Models;
using Helpers;
using PKCore.APIService;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPokeApi.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public ObservableCollection<Region> ListaRegiones { get; set; }

        public MainPageViewModel(INavigationService navigationService, IRestAPIServices restApiService)
            : base(navigationService, restApiService)
        {
            Title = "Poke Api";
        }

        public async override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            await MostrarRegiones();
            ListaRegiones = new ObservableCollection<Region>();
        }

        private async Task MostrarRegiones()
        {
            var url = $"{Constants.Region}/{ID = +1}";

            _region = await RestApiService.Get<Region>(url);
            
            if (_region != null)
            {
                ID = _region.Id;
                Nombre = _region.name;
                Url = _region.url;
            }
            //var lista = await RestApiService.Get<List<Region>>(url);

            //foreach (var item in lista)
            //{
            //    ListaRegiones.Add(item);
            //}
        }

        #region Propiedades
        private string _nombre;

        public string Nombre
        {
            get { return _nombre; }
            set { SetProperty(ref _nombre, value); }
        }
        private string _url;

        public string Url
        {
            get { return _url; }
            set { SetProperty(ref _url, value); }
        }
        private int _id;

        public int ID
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }


        public Region _region { get; set; }
        #endregion
    }
}
