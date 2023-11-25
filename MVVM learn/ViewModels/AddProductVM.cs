using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using MVVM_learn.Models;

namespace MVVM_learn.ViewModels
{
    public class AddProductVM : ViewModelBase
    {
        private BitmapImage _selectedImage;
        public BitmapImage SelectedImage
        {
            get { return _selectedImage; }
            set
            {
                _selectedImage = value;
                propertyChanged(nameof(SelectedImage));
            }
        }

        private string _statusMessage;
        public string StatusMessage
        {
            get { return _statusMessage; }
            set
            {
                _statusMessage = value;
                propertyChanged(nameof(StatusMessage));
            }
        }

        private string _iD;
        public string ID
        {
            get { return _iD; }
            set
            {
                _iD = value;
                propertyChanged(nameof(ID));
            }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                propertyChanged(nameof(Name));
            }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                propertyChanged(nameof(Description));
            }
        }

        private string _category;
        public string Category
        {
            get { return _category; }
            set
            {
                _category = value;
                propertyChanged(nameof(Category));
            }
        }

        private string _manufature;
        public string Manufature
        {
            get { return _manufature; }
            set
            {
                _manufature = value;
                propertyChanged(nameof(Manufature));
            }
        }

        private int _cost;
        public int Cost
        {
            get { return _cost; }
            set
            {
                _cost = value;
                propertyChanged(nameof(Cost));
            }
        }

        private int _disount;
        public int Disount
        {
            get { return _disount; }
            set
            {
                _disount = value;
                propertyChanged(nameof(Disount));
            }
        }

        private int _quantityInStock;
        public int QuantityInStock
        {
            get { return _quantityInStock; }
            set
            {
                _quantityInStock = value;
                propertyChanged(nameof(QuantityInStock));
            }
        }

        private string _status;
        public string Status
        {
            get { return _status; }
            set
            {
                _status = value;
                propertyChanged(nameof(Status));
            }
        }

        private bool _trueRadioButton;
        public bool TrueRadioButton
        {
            get { return _trueRadioButton; }
            set
            {
                if(_trueRadioButton != value)
                {
                    _trueRadioButton = value;
                    propertyChanged(nameof(TrueRadioButton));
                    if (_trueRadioButton)
                    {
                        FalseRadioButton = false;
                    }
                }
            }
        }

        private bool _falseRadioButton;
        public bool FalseRadioButton
        {
            get { return _falseRadioButton; }
            set
            {
                if (_falseRadioButton != value)
                {
                    _falseRadioButton = value;
                    propertyChanged(nameof(FalseRadioButton));
                    if (_falseRadioButton)
                    {
                        TrueRadioButton = false;
                    }
                }
            }
        }

        public ICommand LoadImageCommand { get;}
        public ICommand SaveProduct { get; set; }

        public AddProductVM()
        {
            LoadImageCommand = new RelayCommand(LoadImage);
        }

        private void SaveProductExecute(object parameter)
        {

        }

        private void LoadImage(object parameter)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image files (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg|All files (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    BitmapImage bitmap = new BitmapImage(new Uri(openFileDialog.FileName));
                    SelectedImage = bitmap;

                    string projectDiretory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..");

                    string destinationPath = Path.Combine(projectDiretory, "Resources", Path.GetFileName(openFileDialog.FileName));

                    //File.Copy(openFileDialog.FileName, destinationPath, true);

                    StatusMessage = $"Файл '{Path.GetFileName(openFileDialog.FileName)}' выбран.";
                }
                catch(Exception ex)
                {
                    StatusMessage = $"Ошибка загрузки изображения: {ex.Message}";
                }
            }
        }
    }
}
