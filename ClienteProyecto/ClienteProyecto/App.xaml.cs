using System.Globalization;
using System.Threading;
using System.Windows;

namespace ClienteProyecto {

    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
    public partial class App : Application {

        private App() {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("es-MX");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-MX");
        }
    }
}