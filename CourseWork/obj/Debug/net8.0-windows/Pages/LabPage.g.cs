﻿#pragma checksum "..\..\..\..\Pages\LabPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "372706BEACCB2B2528263BA0EA64863CE7FF8C3C"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using CourseWork.Pages;
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


namespace CourseWork.Pages {
    
    
    /// <summary>
    /// LabPage
    /// </summary>
    public partial class LabPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 37 "..\..\..\..\Pages\LabPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid myDatagrid;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\..\Pages\LabPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NameText;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\..\Pages\LabPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CountProf;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\..\Pages\LabPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CountHosp;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\..\Pages\LabPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CountPoly;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\..\Pages\LabPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.WrapPanel RowCountPanel;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\..\Pages\LabPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock CountRowText;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/CourseWork;component/pages/labpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\LabPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 32 "..\..\..\..\Pages\LabPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Add);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 33 "..\..\..\..\Pages\LabPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Edit);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 34 "..\..\..\..\Pages\LabPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Del);
            
            #line default
            #line hidden
            return;
            case 4:
            this.myDatagrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 6:
            this.NameText = ((System.Windows.Controls.TextBox)(target));
            
            #line 61 "..\..\..\..\Pages\LabPage.xaml"
            this.NameText.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Filter);
            
            #line default
            #line hidden
            return;
            case 7:
            this.CountProf = ((System.Windows.Controls.TextBox)(target));
            
            #line 63 "..\..\..\..\Pages\LabPage.xaml"
            this.CountProf.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Filter);
            
            #line default
            #line hidden
            return;
            case 8:
            this.CountHosp = ((System.Windows.Controls.TextBox)(target));
            
            #line 65 "..\..\..\..\Pages\LabPage.xaml"
            this.CountHosp.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Filter);
            
            #line default
            #line hidden
            return;
            case 9:
            this.CountPoly = ((System.Windows.Controls.TextBox)(target));
            
            #line 67 "..\..\..\..\Pages\LabPage.xaml"
            this.CountPoly.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Filter);
            
            #line default
            #line hidden
            return;
            case 10:
            this.RowCountPanel = ((System.Windows.Controls.WrapPanel)(target));
            return;
            case 11:
            this.CountRowText = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            System.Windows.EventSetter eventSetter;
            switch (connectionId)
            {
            case 5:
            eventSetter = new System.Windows.EventSetter();
            eventSetter.Event = System.Windows.Controls.Control.MouseDoubleClickEvent;
            
            #line 44 "..\..\..\..\Pages\LabPage.xaml"
            eventSetter.Handler = new System.Windows.Input.MouseButtonEventHandler(this.Choise_Lab);
            
            #line default
            #line hidden
            ((System.Windows.Style)(target)).Setters.Add(eventSetter);
            break;
            }
        }
    }
}

