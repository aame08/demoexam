﻿#pragma checksum "..\..\..\..\Views\ExecuteApplication.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "D47186A2C66A1C9E9F629F7F11C17DF5509CD4C8"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Demo.Views;
using DevExpress.Xpf.DXBinding;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace Demo.Views {
    
    
    /// <summary>
    /// ExecuteApplication
    /// </summary>
    public partial class ExecuteApplication : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\..\..\Views\ExecuteApplication.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bExit;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\Views\ExecuteApplication.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbID;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\Views\ExecuteApplication.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbSpareParts;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\Views\ExecuteApplication.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button toggleButton;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\..\Views\ExecuteApplication.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbSpapePartsName;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\Views\ExecuteApplication.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbSpapePartsCost;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\..\Views\ExecuteApplication.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbSpapePartsCount;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\..\Views\ExecuteApplication.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bExecute;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.4.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Demo;component/views/executeapplication.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\ExecuteApplication.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.4.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.bExit = ((System.Windows.Controls.Button)(target));
            return;
            case 2:
            this.tbID = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.cbSpareParts = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.toggleButton = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\..\..\Views\ExecuteApplication.xaml"
            this.toggleButton.Click += new System.Windows.RoutedEventHandler(this.toggleButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.tbSpapePartsName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.tbSpapePartsCost = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.tbSpapePartsCount = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.bExecute = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

