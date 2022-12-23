﻿using HotelManagementApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;

namespace HotelManagementApp.ViewModel
{
    public class CustomersViewModel : BaseViewModel
    {
        private ObservableCollection<Customer> _CustomersList;
        public ObservableCollection<Customer> CustomersList { get => _CustomersList; set { _CustomersList = value; OnPropertyChanged(); } }

        private ObservableCollection<Customer> _FilteredList;
        public ObservableCollection<Customer> FilteredList { get => _FilteredList; set { _FilteredList = value; OnPropertyChanged(); } }


        private string _Filter;
        public string Filter { get => _Filter; set { _Filter = value; LoadFilteredList(); OnPropertyChanged(); } }
        private string _SearchString;
        public string SearchString { get => _SearchString; set { _SearchString = value; LoadFilteredList(); OnPropertyChanged(); } }

        private string _Name;
        public string Name { get => _Name; set { _Name = value; OnPropertyChanged(); } }
        private string _Sex;
        public string Sex { get => _Sex; set { _Sex = value; OnPropertyChanged(); } }

        private string _CCCD;
        public string CCCD { get => _CCCD; set { _CCCD = value; OnPropertyChanged(); } }

        private string _PhoneNum;
        public string PhoneNum { get => _PhoneNum; set { _PhoneNum = value; OnPropertyChanged(); } }

        private string _Email;
        public string Email { get => _Email; set { _Email = value; OnPropertyChanged(); } }
        private string _Nationality;
        public string Nationality { get => _Nationality; set { _Nationality = value; OnPropertyChanged(); } }

        private int? _BillsNum;
        public int? BillsNum { get => _BillsNum; set { _BillsNum = value; OnPropertyChanged(); } }
        private decimal? _TotalSpending;
        public decimal? TotalSpending { get => _TotalSpending; set { _TotalSpending = value; OnPropertyChanged(); } }

        private Customer _SelectedItem;
        public Customer SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                TotalSpending = 0;
                BillsNum = 0;
                if (SelectedItem != null)
                {
                    Name = SelectedItem.Name;
                    Sex = SelectedItem.Sex;
                    CCCD = SelectedItem.CCCD;
                    PhoneNum = SelectedItem.PhoneNumber;
                    Email = SelectedItem.Email;
                    Nationality = SelectedItem.Nationality;
                    BillsNum = SelectedItem.BillDetails.Count();
                    foreach (var item in SelectedItem.BillDetails)
                    {
                        TotalSpending += item.TotalMoney;
                    }
                }
                OnPropertyChanged();
            }
        }

        public ICommand addCommand { get; set; }
        public ICommand SelectImageCommand { get; set; }
        public ICommand editCommand { get; set; }
        public ICommand deleteCommand { get; set; }

        public CustomersViewModel()
        {
            LoadCustomersList();
            LoadFilteredList();
            addCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Sex) || string.IsNullOrEmpty(CCCD) || string.IsNullOrEmpty(PhoneNum) || string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Nationality))
                {
                    return false;
                }
                var list = DataProvider.Instance.DB.Customers.Where(x => x.CCCD == CCCD && x.Deleted == false);
                if (list == null || list.Count() != 0)
                {
                    return false;
                }
                return true;
            }, (p) =>
            {
                var customer = new Customer()
                {
                    Name = Name,
                    CCCD = CCCD,
                    Sex = Sex,
                    PhoneNumber = PhoneNum,
                    Email = Email,
                    Nationality = Nationality,
                };
                DataProvider.Instance.DB.Customers.Add(customer);
                DataProvider.Instance.DB.SaveChanges();
                LoadCustomersList();
                ClearFields();
                SelectedItem = null;
            });

            editCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Sex) || string.IsNullOrEmpty(CCCD) || string.IsNullOrEmpty(PhoneNum) || string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Nationality) || SelectedItem == null)
                {
                    return false;
                }
                var list = DataProvider.Instance.DB.Customers.Where(x => x.CCCD == CCCD && x.Deleted == false && x.ID != SelectedItem.ID);
                if (list == null || list.Count() != 0)
                {
                    return false;
                }
                return true;
            }, (p) =>
            {
                var customer = DataProvider.Instance.DB.Customers.Where(x => x.ID == SelectedItem.ID).FirstOrDefault();
                customer.Name = Name;
                customer.Sex = Sex;
                customer.CCCD = CCCD;
                customer.Email = Email;
                customer.Nationality = Nationality;

                DataProvider.Instance.DB.SaveChanges();

                OnPropertyChanged();
                LoadCustomersList();
                ClearFields();
                SelectedItem = null;
            });
            deleteCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null)
                {
                    return false;
                }
                return true;
            }, (p) =>
            {
                var customer = DataProvider.Instance.DB.Staffs.Where(x => x.ID == SelectedItem.ID).FirstOrDefault();
                customer.Deleted = true;

                DataProvider.Instance.DB.SaveChanges();

                OnPropertyChanged();
                LoadCustomersList();
                ClearFields();
                SelectedItem = null;
            });
        }

        void LoadCustomersList()
        {
            CustomersList = new ObservableCollection<Customer>();
            var customersList = DataProvider.Instance.DB.Customers.Where(x => x.Deleted == false);
            foreach (var item in customersList)
            {
                CustomersList.Add(item);
            }
            LoadFilteredList();
        }

        private void LoadFilteredList()
        {

        } 

        private void ClearFields()
        {
            Name = Sex = CCCD = PhoneNum = Email = Nationality = null;
            BillsNum = null;
            TotalSpending = null;
        }
        
    }
}
