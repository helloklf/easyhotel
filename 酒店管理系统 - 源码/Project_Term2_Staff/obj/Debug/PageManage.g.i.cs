﻿#pragma checksum "..\..\PageManage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "E4193AE504F8D271100A4103F2D75FA0"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using MyControls;
using Project_Term2_Staff;
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


namespace Project_Term2_Staff {
    
    
    /// <summary>
    /// PageManage
    /// </summary>
    public partial class PageManage : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 7 "..\..\PageManage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Project_Term2_Staff.PageManage @this;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\PageManage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox C;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\PageManage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Left_Right;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\PageManage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DockPanel LeftMenu;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\PageManage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.WrapPanel ML;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\PageManage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DockPanel RightMenu;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\PageManage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock PageTitle;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\PageManage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabControl Tab;
        
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
            System.Uri resourceLocater = new System.Uri("/Project_Term2_Staff;component/pagemanage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\PageManage.xaml"
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
            this.@this = ((Project_Term2_Staff.PageManage)(target));
            
            #line 2 "..\..\PageManage.xaml"
            this.@this.Loaded += new System.Windows.RoutedEventHandler(this.UserControl_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.C = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.Left_Right = ((System.Windows.Controls.Label)(target));
            
            #line 15 "..\..\PageManage.xaml"
            this.Left_Right.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.RightPanelSet);
            
            #line default
            #line hidden
            return;
            case 4:
            this.LeftMenu = ((System.Windows.Controls.DockPanel)(target));
            return;
            case 5:
            
            #line 21 "..\..\PageManage.xaml"
            ((MyControls.Retreat)(target)).MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.ReturnTo_MainMenu);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 22 "..\..\PageManage.xaml"
            ((System.Windows.Controls.TextBlock)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.To0);
            
            #line default
            #line hidden
            return;
            case 7:
            this.ML = ((System.Windows.Controls.WrapPanel)(target));
            return;
            case 8:
            
            #line 33 "..\..\PageManage.xaml"
            ((MyControls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.To1);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 34 "..\..\PageManage.xaml"
            ((MyControls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.To2);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 35 "..\..\PageManage.xaml"
            ((MyControls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.To3);
            
            #line default
            #line hidden
            return;
            case 11:
            this.RightMenu = ((System.Windows.Controls.DockPanel)(target));
            return;
            case 12:
            
            #line 43 "..\..\PageManage.xaml"
            ((MyControls.Retreat)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.ReturnMenu);
            
            #line default
            #line hidden
            return;
            case 13:
            this.PageTitle = ((System.Windows.Controls.TextBlock)(target));
            
            #line 44 "..\..\PageManage.xaml"
            this.PageTitle.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.To0);
            
            #line default
            #line hidden
            return;
            case 14:
            this.Tab = ((System.Windows.Controls.TabControl)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

