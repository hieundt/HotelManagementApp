﻿using HotelManagementApp.Model;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace HotelManagementApp.ViewModel
{
    public class FoodViewModel : BaseViewModel
    {
        private ObservableCollection<FoodsAndService> _FoodsAndServicesList;
        public ObservableCollection<FoodsAndService> FoodsAndServicesList { get => _FoodsAndServicesList; set { _FoodsAndServicesList = value; OnPropertyChanged(); } }

        private string _Name;
        public string Name { get => _Name; set { _Name = value; OnPropertyChanged(); } }

        private string _Unit;
        public string Unit { get => _Unit; set { _Unit = value; OnPropertyChanged(); } }

        private decimal? _Price;
        public decimal? Price { get => _Price; set { _Price = value; OnPropertyChanged(); } }

        private string _Type;
        public string Type { get => _Type; set { _Type = value; OnPropertyChanged(); } }

        private string _ImageSource;
        public string ImageSource { get => _ImageSource; set { _ImageSource = value; OnPropertyChanged(); } }

        private string _SelectedImagePath;

        private BitmapImage _Image;
        public BitmapImage Image { get => _Image; set { _Image = value; OnPropertyChanged(); } }

        private FoodsAndService _SelectedItem;
        public FoodsAndService SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                if (SelectedItem != null)
                {
                    Name = SelectedItem.Name;
                    Unit = SelectedItem.Unit;
                    Price = SelectedItem.Price;
                    Type = SelectedItem.Type;
                    ImageSource = SelectedItem.ImageData;
                    if (ImageSource != null)
                    {
                        string destinationDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + ImageSource;
                        BitmapImage newBitmapImage = new BitmapImage();
                        if (File.Exists(destinationDirectory))
                        {
                            newBitmapImage.BeginInit();

                            newBitmapImage.StreamSource = new FileStream(destinationDirectory, FileMode.Open, FileAccess.Read);
                            newBitmapImage.EndInit();
                            Image = newBitmapImage;
                        }
                    }
                    else
                    {
                        Image = null;
                    }

                }
                OnPropertyChanged();
            }
        }

        public ICommand addCommand { get; set; }
        public ICommand SelectImageCommand { get; set; }
        public ICommand editCommand { get; set; }
        public FoodViewModel()
        {
            LoadFoodList();
            addCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Unit) || Price == 0 || string.IsNullOrEmpty(Type))
                {
                    return false;
                }
                var list = DataProvider.Instance.DB.FoodsAndServices.Where(x => x.Name == Name);
                if (list == null || list.Count() != 0)
                {
                    return false;
                }
                return true;
            }, (p) =>
            {
                var food = new FoodsAndService()
                {
                    Name = Name,
                    Unit = Unit,
                    Price = Price,
                    Type = Type
                };
                DataProvider.Instance.DB.FoodsAndServices.Add(food);
                DataProvider.Instance.DB.SaveChanges();
                addImage(food);
                DataProvider.Instance.DB.SaveChanges();
                LoadFoodList();
            });

            SelectImageCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                SelectImage();
            });

            editCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Unit) || Price == 0 || SelectedItem == null || string.IsNullOrEmpty(Type))
                {
                    return false;
                }
                return true;
            }, (p) =>
            {
                var food = DataProvider.Instance.DB.FoodsAndServices.Where(x => x.ID == SelectedItem.ID).SingleOrDefault();
                food.Name = Name;
                food.Unit = Unit;
                food.Price = Price;
                food.Type = Type;
                food.ImageData = _SelectedImagePath;
                addImage(food);

                DataProvider.Instance.DB.SaveChanges();

                OnPropertyChanged();
                LoadFoodList();
            });
        }
        void LoadFoodList()
        {
            FoodsAndServicesList = new ObservableCollection<FoodsAndService>();
            var foodList = DataProvider.Instance.DB.FoodsAndServices;
            foreach (var item in foodList)
            {
                FoodsAndServicesList.Add(item);
            }
        }

        void SelectImage()
        {
            OpenFileDialog OpenFile = new OpenFileDialog();
            OpenFile.Multiselect = false;
            OpenFile.Title = "Select Picture(s)";
            OpenFile.Filter = "ALL supported Graphics| *.jpeg; *.jpg;*.png;";
            if (OpenFile.ShowDialog() == true)
            {
                BitmapImage img = new BitmapImage();
                img.BeginInit();
                img.StreamSource = new FileStream(OpenFile.FileName, FileMode.Open, FileAccess.Read);
                img.EndInit();
                Image = img;
                _SelectedImagePath = OpenFile.FileName;
            }
            OnPropertyChanged();
        }
        void addImage(FoodsAndService food)
        {
            string destinationDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            if (Image != null)
            {
                food.ImageData = $"\\ImageStorage\\FoodImg\\food{food.ID}.png";
                var destination = destinationDirectory + food.ImageData;
                if (_SelectedImagePath == null)
                    return;
                File.Copy(_SelectedImagePath, destination, true);
            }
            else
            {
                ImageSource = null;
            }

            OnPropertyChanged();
        }
    }

}
