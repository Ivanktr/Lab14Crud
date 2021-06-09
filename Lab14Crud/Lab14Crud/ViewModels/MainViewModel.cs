using Lab14Crud.BL;
using Lab14Crud.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Lab14Crud.ViewModels
{
    public class MainViewModel: ViewModelBase
    {
        Components components = new Components();

        private ObservableCollection<ComponentModel> listComponents;
        public ObservableCollection<ComponentModel> ListComponents
        {
            get { return listComponents; }
            set { listComponents = value; RaisePropertyChanged(); }
        }
        //Variable id
        private int idComponentP;
        public int IdComponentP
        {
            get { return idComponentP; }
            set { idComponentP = value; RaisePropertyChanged(); }
        }
        //Variable nombre
        private string nameComponentP;
        public string NameComponentP
        {
            get { return nameComponentP; }
            set { nameComponentP = value; RaisePropertyChanged();}
        }
        //Variable nacimiento
        private DateTime birthComponentP;
        public DateTime BirthComponentP
        {
            get { return birthComponentP; }
            set { birthComponentP = value; RaisePropertyChanged();}
        }
        //Variable activo
        private bool activeP;
        public bool ActiveP
        {
            get { return activeP; }
            set { activeP = value; RaisePropertyChanged(); }
        }

        public ICommand InsertRowCommand { get; set; }
        public ICommand UpdateRowCommand { get; set; }
        public ICommand DeleteRowCommand { get; set; }
        public ICommand DeleteAllRowCommand { get; set; }

        public MainViewModel()
        {
            //Eliminar una fila
            DeleteRowCommand = new Command<ComponentModel>(execute: async (componentModel) =>
            {
                await components.Delete(componentModel);
                LoadListComponents();
            });

            //Eliminar todo
            DeleteAllRowCommand = new Command(execute: async () =>
            {
                await components.DeleteAllComponents();
                LoadListComponents();
            });

            //actulaizar una fila
            UpdateRowCommand = new Command<ComponentModel>(execute: async (componentModel) =>
            {
                await components.Update(componentModel);
                LoadListComponents();
            });

            //Insertar una fila
            InsertRowCommand = new Command(execute: async () =>
            {
                await component.Insert(new ComponentModel() { IdComponentModel = IdComponentP, NameComponentModel = NameComponentP, BirthComponentModel = BirthComponentP, ActiveModel = ActiveP });
                IdComponentP = 0;
                NameComponentP = "";
                BirthComponentP = DateTime.Today;
                ActiveP = false;
                LoadListComponents();
            });

            LoadListComponents();
        }

        async void LoadListComponents()
        {
            ListComponents = new ObservableCollection<ComponentModel>(await components.GetListComponents());
        }
    }
}
