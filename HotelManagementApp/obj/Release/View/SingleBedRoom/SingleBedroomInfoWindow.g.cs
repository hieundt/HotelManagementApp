﻿#pragma checksum "..\..\..\..\View\SingleBedRoom\SingleBedroomInfoWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "789474E24B54BC51384F9FBFFFA9BAE165707381FD211122D2B574ABE57879F4"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using HotelManagementApp.UserControlUI;
using HotelManagementApp.View;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interactivity;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace HotelManagementApp.View {
    
    
    /// <summary>
    /// SingleBedroomInfoWindow
    /// </summary>
    public partial class SingleBedroomInfoWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\..\View\SingleBedRoom\SingleBedroomInfoWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal HotelManagementApp.View.SingleBedroomInfoWindow SingleBedRoomInfo;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\View\SingleBedRoom\SingleBedroomInfoWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TitleTxt;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\..\View\SingleBedRoom\SingleBedroomInfoWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbIdroom;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\..\View\SingleBedRoom\SingleBedroomInfoWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbCusName;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\..\View\SingleBedRoom\SingleBedroomInfoWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbCusPhone;
        
        #line default
        #line hidden
        
        
        #line 95 "..\..\..\..\View\SingleBedRoom\SingleBedroomInfoWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbCusNationality;
        
        #line default
        #line hidden
        
        
        #line 106 "..\..\..\..\View\SingleBedRoom\SingleBedroomInfoWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.TimePicker checkintime_picker;
        
        #line default
        #line hidden
        
        
        #line 119 "..\..\..\..\View\SingleBedRoom\SingleBedroomInfoWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.TimePicker checkouttime_picker;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/HotelManagementApp;component/view/singlebedroom/singlebedroominfowindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\SingleBedRoom\SingleBedroomInfoWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.SingleBedRoomInfo = ((HotelManagementApp.View.SingleBedroomInfoWindow)(target));
            return;
            case 2:
            this.TitleTxt = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.txbIdroom = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txbCusName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.txbCusPhone = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.txbCusNationality = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.checkintime_picker = ((MaterialDesignThemes.Wpf.TimePicker)(target));
            return;
            case 8:
            this.checkouttime_picker = ((MaterialDesignThemes.Wpf.TimePicker)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
