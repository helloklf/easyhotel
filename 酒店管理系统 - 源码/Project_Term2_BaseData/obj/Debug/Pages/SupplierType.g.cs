﻿#pragma checksum "..\..\..\Pages\SupplierType.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "2FB60B678D8D1375DEA1BD2E2AAE162C"
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


namespace Project_Term2_BaseData.Pages {
    
    
    /// <summary>
    /// SupplierType
    /// </summary>
    public partial class SupplierType : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\Pages\SupplierType.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox C;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\Pages\SupplierType.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MyControls.DataListMenu IsCheck;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\Pages\SupplierType.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabControl Tab;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\Pages\SupplierType.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox InText;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\Pages\SupplierType.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox InRemark;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\Pages\SupplierType.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox UpText;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\Pages\SupplierType.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox UpRemark;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\Pages\SupplierType.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MyControls.DataListBox LB;
        
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
            System.Uri resourceLocater = new System.Uri("/Project_Term2_BaseData;component/pages/suppliertype.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\SupplierType.xaml"
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
            
            #line 6 "..\..\..\Pages\SupplierType.xaml"
            ((Project_Term2_BaseData.Pages.SupplierType)(target)).Loaded += new System.Windows.RoutedEventHandler(this.UserControl_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.C = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.IsCheck = ((MyControls.DataListMenu)(target));
            
            #line 13 "..\..\..\Pages\SupplierType.xaml"
            this.IsCheck.OnAddItem += new System.Windows.Input.MouseButtonEventHandler(this.AddItem);
            
            #line default
            #line hidden
            
            #line 13 "..\..\..\Pages\SupplierType.xaml"
            this.IsCheck.OnEditItem += new System.Windows.Input.MouseButtonEventHandler(this.EditItem);
            
            #line default
            #line hidden
            
            #line 13 "..\..\..\Pages\SupplierType.xaml"
            this.IsCheck.OnSelectedItemEnabled += new System.Windows.Input.MouseButtonEventHandler(this.SelectedItemEnabled);
            
            #line default
            #line hidden
            
            #line 13 "..\..\..\Pages\SupplierType.xaml"
            this.IsCheck.OnSelectedItemEnabledNo += new System.Windows.Input.MouseButtonEventHandler(this.SelectedItemEnabledNo);
            
            #line default
            #line hidden
            
            #line 13 "..\..\..\Pages\SupplierType.xaml"
            this.IsCheck.OnCheckBox_Click += new System.Windows.RoutedEventHandler(this.CheckBox_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 18 "..\..\..\Pages\SupplierType.xaml"
            ((System.Windows.Controls.Label)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.RightPanelSet);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Tab = ((System.Windows.Controls.TabControl)(target));
            return;
            case 6:
            this.InText = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.InRemark = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            
            #line 32 "..\..\..\Pages\SupplierType.xaml"
            ((MyControls.OK)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Label_MouseDown);
            
            #line default
            #line hidden
            return;
            case 9:
            this.UpText = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.UpRemark = ((System.Windows.Controls.TextBox)(target));
            return;
            case 11:
            
            #line 47 "..\..\..\Pages\SupplierType.xaml"
            ((MyControls.No)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.ReturnList);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 48 "..\..\..\Pages\SupplierType.xaml"
            ((MyControls.OK)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Label_MouseDown_1);
            
            #line default
            #line hidden
            return;
            case 13:
            this.LB = ((MyControls.DataListBox)(target));
            
            #line 57 "..\..\..\Pages\SupplierType.xaml"
            this.LB.OnAddItem += new System.Windows.Input.MouseButtonEventHandler(this.AddItem);
            
            #line default
            #line hidden
            
            #line 57 "..\..\..\Pages\SupplierType.xaml"
            this.LB.OnEditItem += new System.Windows.Input.MouseButtonEventHandler(this.EditItem);
            
            #line default
            #line hidden
            
            #line 57 "..\..\..\Pages\SupplierType.xaml"
            this.LB.OnSelectedItemEnabled += new System.Windows.Input.MouseButtonEventHandler(this.SelectedItemEnabled);
            
            #line default
            #line hidden
            
            #line 57 "..\..\..\Pages\SupplierType.xaml"
            this.LB.OnLBContextMenuOpening += new System.Windows.Controls.ContextMenuEventHandler(this.LB_ContextMenuOpening);
            
            #line default
            #line hidden
            
            #line 57 "..\..\..\Pages\SupplierType.xaml"
            this.LB.OnSelectedItemEnabledNo += new System.Windows.Input.MouseButtonEventHandler(this.SelectedItemEnabledNo);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

