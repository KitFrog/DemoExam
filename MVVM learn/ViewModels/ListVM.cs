using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MVVM_learn.Models;
using MVVM_learn.Models.Entyties;
using MVVM_learn.Models.Events;

namespace MVVM_learn.ViewModels
{
    public class ListVM : ViewModelBase
    {
        private readonly DbModel _model = new DbModel();
        //public ObservableCollection<Product> YourItems { get; set; }

        private ObservableCollection<Product> _products;
        public ObservableCollection<Product> Products
        {
            get { return _products; }
            set
            {
                _products = value;
                propertyChanged(nameof(Products));
            }
        }

        private Product _selectedItem;
        public Product SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                propertyChanged(nameof(SelectedItem));
            }
        }


        public ICommand Delete { get; set; }

        public ListVM()
        {
            Products = new ObservableCollection<Product>(_model.GetSpecificProductData());
            Delete = new RelayCommand(DeleteExecute, DeleteCanExecute);
            ListViewIsOpened();
        }

        //private void HandleMyEvent(object sender, MyEvent e)
        //{
        //    string message = e.Message;

        //    switch (message)
        //    {
        //        case "passwordIsNotAvalible":

        //            break;
        //    }
        //}

        private void ListViewIsOpened()
        {
            EventAggregator.Instance.PublishMyEvent(nameof(ListViewIsOpened));
        }

        private void DeleteExecute(object parameter)
        {
            _model.DeleteProduct(SelectedItem.ProductID);
            Products = new ObservableCollection<Product>(_model.GetSpecificProductData());
            propertyChanged(nameof(Products));
        }

        private bool DeleteCanExecute(object parameter)
        {
            return SelectedItem != null;
        }


    }
}
