﻿#pragma checksum "..\..\..\..\Pages\AddDoctor.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "159DB8B1E8F70CEC177AA3AD2AD6C9CC5FF394EE"
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
    /// AddDoctor
    /// </summary>
    public partial class AddDoctor : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\..\..\Pages\AddDoctor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NameText;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\Pages\AddDoctor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SpecText;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\Pages\AddDoctor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox BoxDegree;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\Pages\AddDoctor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox BoxNameMedInst;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\Pages\AddDoctor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox BoxWork;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\Pages\AddDoctor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox OperaText;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\Pages\AddDoctor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox OperaDeadText;
        
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
            System.Uri resourceLocater = new System.Uri("/CourseWork;V1.0.0.0;component/pages/adddoctor.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\AddDoctor.xaml"
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
            this.NameText = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.SpecText = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.BoxDegree = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.BoxNameMedInst = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.BoxWork = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.OperaText = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.OperaDeadText = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            
            #line 34 "..\..\..\..\Pages\AddDoctor.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Add);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

