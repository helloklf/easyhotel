﻿#pragma checksum "..\..\..\..\Controls\LeftMenu\C_DataMenu.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "313A77A337AFF5ED73E7264ACC8149FB"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace Project_Term2.LeftMenu {
    
    
    /// <summary>
    /// C_DataMenu
    /// </summary>
    public partial class C_DataMenu : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\..\Controls\LeftMenu\C_DataMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DockPanel MainMenu_Left;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\..\Controls\LeftMenu\C_DataMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox C;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\Controls\LeftMenu\C_DataMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel AdministratorItem;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\..\Controls\LeftMenu\C_DataMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel AdvAdminiItem;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\..\..\Controls\LeftMenu\C_DataMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel SuperAdminiItem;
        
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
            System.Uri resourceLocater = new System.Uri("/酒店管理系统-主程序;component/controls/leftmenu/c_datamenu.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Controls\LeftMenu\C_DataMenu.xaml"
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
            
            #line 6 "..\..\..\..\Controls\LeftMenu\C_DataMenu.xaml"
            ((Project_Term2.LeftMenu.C_DataMenu)(target)).Loaded += new System.Windows.RoutedEventHandler(this.UserControl_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.MainMenu_Left = ((System.Windows.Controls.DockPanel)(target));
            return;
            case 3:
            this.C = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            
            #line 13 "..\..\..\..\Controls\LeftMenu\C_DataMenu.xaml"
            ((System.Windows.Controls.Label)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.MainMenu_Clcik);
            
            #line default
            #line hidden
            return;
            case 5:
            this.AdministratorItem = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 6:
            
            #line 22 "..\..\..\..\Controls\LeftMenu\C_DataMenu.xaml"
            ((System.Windows.Controls.Label)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.ClientInRoom_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 28 "..\..\..\..\Controls\LeftMenu\C_DataMenu.xaml"
            ((System.Windows.Controls.Label)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.ClientExitRoom_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 34 "..\..\..\..\Controls\LeftMenu\C_DataMenu.xaml"
            ((System.Windows.Controls.Label)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.ClientMoney_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 40 "..\..\..\..\Controls\LeftMenu\C_DataMenu.xaml"
            ((System.Windows.Controls.Label)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.ClientBook_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 46 "..\..\..\..\Controls\LeftMenu\C_DataMenu.xaml"
            ((System.Windows.Controls.Label)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.ClientAllRoom_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 53 "..\..\..\..\Controls\LeftMenu\C_DataMenu.xaml"
            ((System.Windows.Controls.Label)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.ClientList_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.AdvAdminiItem = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 13:
            
            #line 63 "..\..\..\..\Controls\LeftMenu\C_DataMenu.xaml"
            ((System.Windows.Controls.Label)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.StaffList_Click);
            
            #line default
            #line hidden
            return;
            case 14:
            
            #line 69 "..\..\..\..\Controls\LeftMenu\C_DataMenu.xaml"
            ((System.Windows.Controls.Label)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.RoomList_Click);
            
            #line default
            #line hidden
            return;
            case 15:
            this.SuperAdminiItem = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 16:
            
            #line 79 "..\..\..\..\Controls\LeftMenu\C_DataMenu.xaml"
            ((System.Windows.Controls.Label)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.BaseDataSet_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

