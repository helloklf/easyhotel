﻿#pragma checksum "..\..\..\Controls\ToolBar.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "EC63C7CCC1A913A1621AFF37A9A97A9D"
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


namespace Project_Term2.Top {
    
    
    /// <summary>
    /// ToolBar
    /// </summary>
    public partial class ToolBar : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 3 "..\..\..\Controls\ToolBar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Project_Term2.Top.ToolBar This;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\Controls\ToolBar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox C;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\Controls\ToolBar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock MCount;
        
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
            System.Uri resourceLocater = new System.Uri("/酒店管理系统-主程序;component/controls/toolbar.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Controls\ToolBar.xaml"
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
            this.This = ((Project_Term2.Top.ToolBar)(target));
            
            #line 1 "..\..\..\Controls\ToolBar.xaml"
            this.This.Loaded += new System.Windows.RoutedEventHandler(this.UserControl_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.C = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            
            #line 36 "..\..\..\Controls\ToolBar.xaml"
            ((System.Windows.Controls.Border)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.MainPage_ToHome);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 39 "..\..\..\Controls\ToolBar.xaml"
            ((System.Windows.Controls.Border)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.MainPage_Up);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 42 "..\..\..\Controls\ToolBar.xaml"
            ((System.Windows.Controls.Border)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.MainPage_Down);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 45 "..\..\..\Controls\ToolBar.xaml"
            ((System.Windows.Controls.Border)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.ResetOrLoad);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 48 "..\..\..\Controls\ToolBar.xaml"
            ((System.Windows.Controls.Border)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.UserWindowState);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 51 "..\..\..\Controls\ToolBar.xaml"
            ((System.Windows.Controls.Border)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.UserWindowState_Message);
            
            #line default
            #line hidden
            return;
            case 9:
            this.MCount = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 10:
            
            #line 57 "..\..\..\Controls\ToolBar.xaml"
            ((System.Windows.Controls.Border)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.ShowColorSelectPanl);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 60 "..\..\..\Controls\ToolBar.xaml"
            ((System.Windows.Controls.Border)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.LockAppliction_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 63 "..\..\..\Controls\ToolBar.xaml"
            ((System.Windows.Controls.Border)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.WindowMini);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 66 "..\..\..\Controls\ToolBar.xaml"
            ((System.Windows.Controls.Border)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.WinodwMax);
            
            #line default
            #line hidden
            return;
            case 14:
            
            #line 69 "..\..\..\Controls\ToolBar.xaml"
            ((System.Windows.Controls.Border)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.CloseWindow);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

