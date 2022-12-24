using HotelManagementApp.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HotelManagementApp.ViewModel
{
    class SBBookingViewModel:BaseViewModel
    {
        public ICommand FastBookingCommand { get; set; }
        public SBBookingViewModel()
        {

            FastBookingCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                Window w = new SingleBedRoomFastBookingWindow();
                w.ShowDialog();

            });
        }
    }
}
