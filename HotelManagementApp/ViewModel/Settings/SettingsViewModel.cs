using HotelManagementApp.Model;
using HotelManagementApp.View;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HotelManagementApp.ViewModel
{
    public class SettingsViewModel : BaseViewModel
    {
        private string _CurrentPassword;
        public string CurrentPassword { get => _CurrentPassword; set { _CurrentPassword = value; OnPropertyChanged(); } }
        private string _NewPassword;
        public string NewPassword { get => _NewPassword; set { _NewPassword = value; OnPropertyChanged(); } }
        private string _ConfirmPassword;
        public string ConfirmPassword { get => _ConfirmPassword; set { _ConfirmPassword = value; OnPropertyChanged(); } }

        private int _BookingID;
        public int Booking_Id { get => _BookingID; set { _BookingID = value; OnPropertyChanged(); } }
        private string _CustomerName;
        public string CustomerName { get => _CustomerName; set { _CustomerName = value; OnPropertyChanged(); } }
        private string _PhoneNum;
        public string CustomerPhoneNumber { get => _PhoneNum; set { _PhoneNum = value; OnPropertyChanged(); } }
        private DateTime? _StartTime = null;
        public DateTime? CheckInTime { get => _StartTime; set { _StartTime = value; OnPropertyChanged(); } }
        private DateTime? _DateBooking = null;
        public DateTime? DateBooking { get => _DateBooking; set { _DateBooking = value; OnPropertyChanged(); } }
        private DateTime? _EndTime = null;
        public DateTime? CheckOutTime { get => _EndTime; set { _EndTime = value; OnPropertyChanged(); } }
        private double _GoodTotal;
        public double Good_total { get => _GoodTotal; set { _GoodTotal = value; OnPropertyChanged(); } }
        private double _RoomPrice;
        public double Room_price { get => _RoomPrice; set { _RoomPrice = value; OnPropertyChanged(); } }
        private double _TotalPayMent;
        public double Total_Payment { get => _TotalPayMent; set { _TotalPayMent = value; OnPropertyChanged(); } }

        public ICommand LogoutCommand { get; set; }
        public ICommand ChangePasswordCommand { get; set; }
        public ICommand OpenBillReportWindow { get; set; }


        public SettingsViewModel()
        {
            LogoutCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
                Application.Current.Shutdown();
            }
            );

            ChangePasswordCommand = new RelayCommand<object>((p) => 
            {
                var hashedPassword = MD5Hash(Base64Encode(CurrentPassword));
                if(ConfirmPassword != NewPassword)
                {
                    return false;
                }
                if (hashedPassword != Const.ActiveAccount.PasswordHash)
                {
                    return false;
                }

                return true;
            }, (p) =>
            {
                var account = DataProvider.Instance.DB.Accounts.Where(x => x.IDStaff == Const.ActiveAccount.IDStaff).FirstOrDefault();
                var hashedPassword = MD5Hash(Base64Encode(NewPassword));
                account.PasswordHash = hashedPassword;
                DataProvider.Instance.DB.SaveChanges();
                CurrentPassword = NewPassword = ConfirmPassword = null;
            }
            );
            OpenBillReportWindow = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                var room = new RoomsReservation();
                room = DataProvider.Instance.DB.RoomsReservations.Where(x => x.ID == room.ID).FirstOrDefault();
                Booking_Id = room.ID;
                CheckInTime = room.CheckInTime;
                CheckOutTime = room.CheckOutTime;

                var customer = new Customer();
                customer = DataProvider.Instance.DB.Customers.Where(x => x.ID == customer.ID).FirstOrDefault();
                CustomerName = customer.Name;
                CustomerPhoneNumber = customer.PhoneNumber;

                var roomType = new RoomType();
                roomType = DataProvider.Instance.DB.RoomTypes.Where(x => x.ID == roomType.ID).FirstOrDefault();
                Room_price = (double)roomType.Price;

                var order = new Order();
                order = DataProvider.Instance.DB.Orders.Where(x => x.ID == order.ID).FirstOrDefault();
                Good_total = (double)order.TotalPrice;

                var bill = new BillDetail();
                bill = DataProvider.Instance.DB.BillDetails.Where(x => x.ID == bill.ID).FirstOrDefault();
                Total_Payment = (double)bill.TotalMoney;

                BillReportViewModel vm = new BillReportViewModel();
                vm.Booking_Id = Booking_Id;
                vm.DateBooking = DateBooking;
                vm.CheckInTime = CheckInTime;
                vm.CheckOutTime = CheckOutTime;
                vm.CustomerName = CustomerName;
                vm.CustomerPhoneNumber = CustomerPhoneNumber;
                vm.Good_total = Good_total;
                vm.Room_price = Room_price;
                vm.Total_Payment = Total_Payment;

                Window paymentWindow = new PaymentWindow();
                paymentWindow.DataContext = vm;
                paymentWindow.Show();
            }
           );

        }

        private string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }

        private string Base64Encode(string input)
        {
            var textBytes = Encoding.UTF8.GetBytes(input);
            var base64String = Convert.ToBase64String(textBytes);
            return base64String;
        }
    }
}
