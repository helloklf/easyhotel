﻿#pragma checksum "..\..\..\Controls\SearchBox.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "E742CDC753D16E55E52E2373FD46AA7B"
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


namespace Project_Term2.Controls {
    
    
    /// <summary>
    /// SearchBox
    /// </summary>
    public partial class SearchBox : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 54 "..\..\..\Controls\SearchBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox InputContent;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\Controls\SearchBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Xaml_watermark;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\Controls\SearchBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox Xaml_DownList;
        
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
            System.Uri resourceLocater = new System.Uri("/酒店管理系统-主程序;component/controls/searchbox.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Controls\SearchBox.xaml"
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
            
            #line 50 "..\..\..\Controls\SearchBox.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.InputContent = ((System.Windows.Controls.TextBox)(target));
            
            #line 60 "..\..\..\Controls\SearchBox.xaml"
            this.InputContent.GotFocus += new System.Windows.RoutedEventHandler(this.InputContent_GotFocus);
            
            #line default
            #line hidden
            
            #line 61 "..\..\..\Controls\SearchBox.xaml"
            this.InputContent.KeyDown += new System.Windows.Input.KeyEventHandler(this.InputContent_KeyDown);
            
            #line default
            #line hidden
            
            #line 62 "..\..\..\Controls\SearchBox.xaml"
            this.InputContent.LostFocus += new System.Windows.RoutedEventHandler(this.InputContent_LostFocus);
            
            #line default
            #line hidden
            
            #line 64 "..\..\..\Controls\SearchBox.xaml"
            this.InputContent.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.InputContent_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Xaml_watermark = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.Xaml_DownList = ((System.Windows.Controls.ListBox)(target));
            
            #line 74 "..\..\..\Controls\SearchBox.xaml"
            this.Xaml_DownList.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ListBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

