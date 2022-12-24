using HotelManagementApp.Model;
using HotelManagementApp.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HotelManagementApp.ViewModel
{
    class SingleBedroomBillViewModel:BaseViewModel
    {
        private int _BookingID;
        public int Booking_id { get => _BookingID; set { _BookingID = value; OnPropertyChanged(); } }
        private string _CustomerName;
        public string CustomerName { get => _CustomerName; set { _CustomerName = value; OnPropertyChanged(); } }
        private string _PhoneNum;
        public string CustomerPhoneNum { get => _PhoneNum; set { _PhoneNum = value; OnPropertyChanged(); } }
        private DateTime? _StartTime = null;
        public DateTime? StartTime { get => _StartTime; set { _StartTime = value; OnPropertyChanged(); } }
        private DateTime? _DateBooking = null;
        public DateTime? DateBooking { get => _DateBooking; set { _DateBooking = value; OnPropertyChanged(); } }
        private DateTime? _EndTime = null;
        public DateTime? EndTime { get => _EndTime; set { _EndTime = value; OnPropertyChanged(); } }
        private double _TotalMoney;
        public double FieldPrice { get => _TotalMoney; set { _TotalMoney = value; OnPropertyChanged(); } }

        public ICommand PaymentCMD { get; set; }

        public SingleBedroomBillViewModel()
        {

            PaymentCMD = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {

                MessageBox.Show("Pay successfully!");

            });
        }
    }
}
