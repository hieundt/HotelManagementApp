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
    class SingleBedroomBookingViewModel : BaseViewModel
    {
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

        public ICommand FastbookingCommand { get; set; }

        public SingleBedroomBookingViewModel()
        {
            FastbookingCommand = new RelayCommand<object>((p) =>
            {
                
                return true;
            }, (p) =>
            {
                if(CustomerName==""||CustomerPhoneNum=="")
                {
                    MessageBox.Show("Enter enough information!");
                }  
                else
                {
                    SingleBedroomBillViewModel vm = new SingleBedroomBillViewModel();
                    var booking = new RoomsReservation(); 
                    {
                        booking.CheckInTime = StartTime;
                        booking.CheckOutTime = EndTime;
                    }
                    DataProvider.Instance.DB.RoomsReservations.Add(booking);
                    DataProvider.Instance.DB.SaveChanges();
                    

                    var customer = new Customer();
                    {
                        customer.Name = CustomerName;
                        customer.PhoneNumber = CustomerPhoneNum;
                    }
                    DataProvider.Instance.DB.Customers.Add(customer);
                    DataProvider.Instance.DB.SaveChanges();

                    

                    vm.Booking_id = booking.ID;
                    vm.CustomerName = CustomerName;
                    vm.CustomerPhoneNum = CustomerPhoneNum;
                    vm.StartTime = StartTime;
                    vm.DateBooking = DateBooking;
                    vm.EndTime = EndTime;

                    var roomType = new RoomType();
                    roomType = DataProvider.Instance.DB.RoomTypes.Where(x => x.ID == roomType.ID).FirstOrDefault();

                    vm.FieldPrice = (double)roomType.Price;
                    Window w = new SingleBedroomBillWindow();
                    w.DataContext = vm;
                    w.ShowDialog();
                }    
                
            }
           );
        }
    }
}
