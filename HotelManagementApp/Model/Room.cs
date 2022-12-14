//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HotelManagementApp.Model
{
    using HotelManagementApp.ViewModel;
    using System;
    using System.Collections.Generic;
    
    public partial class Room : BaseViewModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Room()
        {
            this.RoomsReservations = new HashSet<RoomsReservation>();
        }
        private int _ID { get; set; }
        private string _RoomNum { get; set; }
        private int _IDRoomType { get; set; }
        private string _Status { get; set; }
        private string _ImageData { get; set; }
        private bool _Deleted { get; set; }
        public int ID { get => _ID; set { _ID = value; OnPropertyChanged(); } }
        public string RoomNum { get => _RoomNum; set { _RoomNum = value; OnPropertyChanged(); } }
        public int IDRoomType { get => _IDRoomType; set { _IDRoomType = value; OnPropertyChanged(); } }
        public string Status { get => _Status; set { _Status = value; OnPropertyChanged(); } }
        public string ImageData { get => _ImageData; set { _ImageData = value; OnPropertyChanged(); } }
        public bool Deleted { get => _Deleted; set { _Deleted = value; OnPropertyChanged(); } }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RoomsReservation> RoomsReservations { get; set; }
        public virtual RoomType RoomType { get; set; }
    }
}
