﻿#pragma checksum "..\..\Database.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "316A8110F58EAEDFB22805FC1BCB67A6D1C763D18CF94A70EF809ECDC8505CE0"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using KP_WPF;
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
using Xceed.Wpf.Toolkit;


namespace KP_WPF {
    
    
    /// <summary>
    /// Database
    /// </summary>
    public partial class Database : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\Database.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_back;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\Database.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_flightNumber;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\Database.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_destination;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\Database.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_id;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\Database.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_surname;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\Database.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_luggageSpace;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\Database.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_luggageAmount;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\Database.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid main_dataGrid;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\Database.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_add;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\Database.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_delete;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\Database.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Xceed.Wpf.Toolkit.DateTimePicker dt_date;
        
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
            System.Uri resourceLocater = new System.Uri("/KP_WPF;component/database.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Database.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
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
            this.button_back = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\Database.xaml"
            this.button_back.Click += new System.Windows.RoutedEventHandler(this.Button_back_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.tb_flightNumber = ((System.Windows.Controls.TextBox)(target));
            
            #line 21 "..\..\Database.xaml"
            this.tb_flightNumber.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Tb_flightNumber_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.tb_destination = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.tb_id = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.tb_surname = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.tb_luggageSpace = ((System.Windows.Controls.TextBox)(target));
            
            #line 25 "..\..\Database.xaml"
            this.tb_luggageSpace.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Tb_luggageSpace_TextChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.tb_luggageAmount = ((System.Windows.Controls.TextBox)(target));
            
            #line 26 "..\..\Database.xaml"
            this.tb_luggageAmount.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Tb_luggageAmount_TextChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.main_dataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 9:
            this.button_add = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\Database.xaml"
            this.button_add.Click += new System.Windows.RoutedEventHandler(this.Button_add_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.button_delete = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\Database.xaml"
            this.button_delete.Click += new System.Windows.RoutedEventHandler(this.Button_delete_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.dt_date = ((Xceed.Wpf.Toolkit.DateTimePicker)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

