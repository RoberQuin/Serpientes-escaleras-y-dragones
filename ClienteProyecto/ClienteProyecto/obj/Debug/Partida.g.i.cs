﻿#pragma checksum "..\..\Partida.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "8EEA42014BC95C0579C285692425066E55BACDB23C61C1757F61311D3F1B6D60"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using ClienteProyecto;
using ClienteProyecto.Properties;
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


namespace ClienteProyecto {
    
    
    /// <summary>
    /// Partida
    /// </summary>
    public partial class Partida : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\Partida.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox partidasLT;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\Partida.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label partidasLB;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\Partida.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label nombreLB;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\Partida.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label crearLB;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\Partida.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox nombreTB;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\Partida.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button crearBT;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\Partida.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cancelarBT;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\Partida.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button unirseBT;
        
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
            System.Uri resourceLocater = new System.Uri("/+;component/partida.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Partida.xaml"
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
            this.partidasLT = ((System.Windows.Controls.ListBox)(target));
            return;
            case 2:
            this.partidasLB = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.nombreLB = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.crearLB = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.nombreTB = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.crearBT = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\Partida.xaml"
            this.crearBT.Click += new System.Windows.RoutedEventHandler(this.crearBT_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.cancelarBT = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\Partida.xaml"
            this.cancelarBT.Click += new System.Windows.RoutedEventHandler(this.cancelarBT_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.unirseBT = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\Partida.xaml"
            this.unirseBT.Click += new System.Windows.RoutedEventHandler(this.unirseBT_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

