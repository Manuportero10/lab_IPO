﻿#pragma checksum "..\..\PaginaListadoEmpleados.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "1C156DA3321C43D48091A9B9B5B55E2F9D2125B865B2DFF5E218FAA8B41403D7"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using AplicaciónFisioterapia;
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


namespace AplicaciónFisioterapia {
    
    
    /// <summary>
    /// PaginaListadoEmpleados
    /// </summary>
    public partial class PaginaListadoEmpleados : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\PaginaListadoEmpleados.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lstEmpleados;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\PaginaListadoEmpleados.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel spEmpleados;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\PaginaListadoEmpleados.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtbNombre;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\PaginaListadoEmpleados.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtbDNI;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\PaginaListadoEmpleados.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtbSueldo;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\PaginaListadoEmpleados.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtbExpContr;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\PaginaListadoEmpleados.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbRol;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\PaginaListadoEmpleados.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnMod;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\PaginaListadoEmpleados.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnEliminar;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\PaginaListadoEmpleados.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnGuardar;
        
        #line default
        #line hidden
        
        
        #line 89 "..\..\PaginaListadoEmpleados.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDescartar;
        
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
            System.Uri resourceLocater = new System.Uri("/AplicaciónFisioterapia;component/paginalistadoempleados.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\PaginaListadoEmpleados.xaml"
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
            this.lstEmpleados = ((System.Windows.Controls.ListBox)(target));
            
            #line 17 "..\..\PaginaListadoEmpleados.xaml"
            this.lstEmpleados.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.lstEmpleados_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.spEmpleados = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 3:
            this.txtbNombre = ((System.Windows.Controls.TextBox)(target));
            
            #line 37 "..\..\PaginaListadoEmpleados.xaml"
            this.txtbNombre.KeyUp += new System.Windows.Input.KeyEventHandler(this.txtbNombre_KeyUp);
            
            #line default
            #line hidden
            return;
            case 4:
            this.txtbDNI = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.txtbSueldo = ((System.Windows.Controls.TextBox)(target));
            
            #line 51 "..\..\PaginaListadoEmpleados.xaml"
            this.txtbSueldo.KeyUp += new System.Windows.Input.KeyEventHandler(this.txtbSueldo_KeyUp);
            
            #line default
            #line hidden
            return;
            case 6:
            this.txtbExpContr = ((System.Windows.Controls.TextBox)(target));
            
            #line 58 "..\..\PaginaListadoEmpleados.xaml"
            this.txtbExpContr.KeyUp += new System.Windows.Input.KeyEventHandler(this.txtbExpContr_KeyUp);
            
            #line default
            #line hidden
            return;
            case 7:
            this.cbRol = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.btnMod = ((System.Windows.Controls.Button)(target));
            
            #line 67 "..\..\PaginaListadoEmpleados.xaml"
            this.btnMod.Click += new System.Windows.RoutedEventHandler(this.btnMod_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btnEliminar = ((System.Windows.Controls.Button)(target));
            
            #line 75 "..\..\PaginaListadoEmpleados.xaml"
            this.btnEliminar.Click += new System.Windows.RoutedEventHandler(this.btnEliminar_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.btnGuardar = ((System.Windows.Controls.Button)(target));
            
            #line 82 "..\..\PaginaListadoEmpleados.xaml"
            this.btnGuardar.Click += new System.Windows.RoutedEventHandler(this.btnGuardar_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.btnDescartar = ((System.Windows.Controls.Button)(target));
            
            #line 89 "..\..\PaginaListadoEmpleados.xaml"
            this.btnDescartar.Click += new System.Windows.RoutedEventHandler(this.btnDescartar_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

