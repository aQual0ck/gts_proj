﻿#pragma checksum "..\..\..\Pages\PageList.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "A4C7A3CAE41D95591C94916B9E255ED2394EEF619F4C565212238D8DBB47EC50"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using GTS.AuxClasses;
using GTS.Pages;
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


namespace GTS.Pages {
    
    
    /// <summary>
    /// PageList
    /// </summary>
    public partial class PageList : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 21 "..\..\..\Pages\PageList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem menuAdd;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\Pages\PageList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem menuPhone;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\Pages\PageList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem menuGeneral;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\Pages\PageList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem menuBack;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\Pages\PageList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem menuExit;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\Pages\PageList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbSearch;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\Pages\PageList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbFilterCat;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\Pages\PageList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox cbDebt;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\Pages\PageList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox cbIntercity;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\Pages\PageList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox cbDI;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\Pages\PageList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnReport;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\Pages\PageList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgrCustomer;
        
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
            System.Uri resourceLocater = new System.Uri("/GTS;component/pages/pagelist.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\PageList.xaml"
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
            this.menuAdd = ((System.Windows.Controls.MenuItem)(target));
            
            #line 21 "..\..\..\Pages\PageList.xaml"
            this.menuAdd.Click += new System.Windows.RoutedEventHandler(this.menuAdd_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.menuPhone = ((System.Windows.Controls.MenuItem)(target));
            
            #line 23 "..\..\..\Pages\PageList.xaml"
            this.menuPhone.Click += new System.Windows.RoutedEventHandler(this.menuPhone_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.menuGeneral = ((System.Windows.Controls.MenuItem)(target));
            
            #line 24 "..\..\..\Pages\PageList.xaml"
            this.menuGeneral.Click += new System.Windows.RoutedEventHandler(this.menuGeneral_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.menuBack = ((System.Windows.Controls.MenuItem)(target));
            
            #line 26 "..\..\..\Pages\PageList.xaml"
            this.menuBack.Click += new System.Windows.RoutedEventHandler(this.menuBack_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.menuExit = ((System.Windows.Controls.MenuItem)(target));
            
            #line 27 "..\..\..\Pages\PageList.xaml"
            this.menuExit.Click += new System.Windows.RoutedEventHandler(this.menuExit_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.txbSearch = ((System.Windows.Controls.TextBox)(target));
            
            #line 31 "..\..\..\Pages\PageList.xaml"
            this.txbSearch.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txbSearch_TextChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.cmbFilterCat = ((System.Windows.Controls.ComboBox)(target));
            
            #line 33 "..\..\..\Pages\PageList.xaml"
            this.cmbFilterCat.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cmbFilterCat_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.cbDebt = ((System.Windows.Controls.CheckBox)(target));
            
            #line 36 "..\..\..\Pages\PageList.xaml"
            this.cbDebt.Checked += new System.Windows.RoutedEventHandler(this.cbDebt_Checked);
            
            #line default
            #line hidden
            
            #line 37 "..\..\..\Pages\PageList.xaml"
            this.cbDebt.Unchecked += new System.Windows.RoutedEventHandler(this.cbDebt_Unchecked);
            
            #line default
            #line hidden
            return;
            case 9:
            this.cbIntercity = ((System.Windows.Controls.CheckBox)(target));
            
            #line 39 "..\..\..\Pages\PageList.xaml"
            this.cbIntercity.Checked += new System.Windows.RoutedEventHandler(this.cbIntercity_Checked);
            
            #line default
            #line hidden
            
            #line 40 "..\..\..\Pages\PageList.xaml"
            this.cbIntercity.Unchecked += new System.Windows.RoutedEventHandler(this.cbIntercity_Unchecked);
            
            #line default
            #line hidden
            return;
            case 10:
            this.cbDI = ((System.Windows.Controls.CheckBox)(target));
            
            #line 43 "..\..\..\Pages\PageList.xaml"
            this.cbDI.Checked += new System.Windows.RoutedEventHandler(this.cbDI_Checked);
            
            #line default
            #line hidden
            
            #line 43 "..\..\..\Pages\PageList.xaml"
            this.cbDI.Unchecked += new System.Windows.RoutedEventHandler(this.cbDI_Unchecked);
            
            #line default
            #line hidden
            return;
            case 11:
            this.btnReport = ((System.Windows.Controls.Button)(target));
            
            #line 46 "..\..\..\Pages\PageList.xaml"
            this.btnReport.Click += new System.Windows.RoutedEventHandler(this.btnReport_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.dgrCustomer = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 13:
            
            #line 77 "..\..\..\Pages\PageList.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnEdit_Click);
            
            #line default
            #line hidden
            break;
            case 14:
            
            #line 80 "..\..\..\Pages\PageList.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnDelete_Click);
            
            #line default
            #line hidden
            break;
            case 15:
            
            #line 83 "..\..\..\Pages\PageList.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnViewNumbers_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

