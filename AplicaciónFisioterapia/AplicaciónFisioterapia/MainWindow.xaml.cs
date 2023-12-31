using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;



namespace AplicaciónFisioterapia
{

    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        private MenuPrincipal menu_principal;
        private BitmapImage imagCheck = new BitmapImage(new Uri("img/check_verde.png", UriKind.Relative));
        private BitmapImage imagCross = new BitmapImage(new Uri("img/cross.png", UriKind.Relative));
        private BitmapImage imgFazul = new BitmapImage(new Uri("img/Fazul.png", UriKind.Relative));
        private BitmapImage imgFnormal = new BitmapImage(new Uri("img/Fnormal.png", UriKind.Relative));
        private String usuario = "Martinez";
        private String password = "1234";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult resultado = MessageBox.Show("¿Estás seguro de que quieres cerrar la aplicación?", "Cierre de aplicación", MessageBoxButton.YesNo, MessageBoxImage.Information);
            if (resultado == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            menu_principal = new MenuPrincipal();
            menu_principal.Show();
            this.Visibility = Visibility.Hidden;
        }

        private void txtUsuario_keyDown(object sender, KeyEventArgs e)
        {
            // se hará la comprobación al pulsar el "Enter"
            if (e.Key == Key.Return)
            {
                if (ComprobarEntrada(txtUsuario.Text, usuario,
                txtUsuario, imgCheckUsuario))
                {
                    // habilitar entrada de contraseña y pasarle el foco
                    passContrasena.IsEnabled = true;
                    passContrasena.Focus();
                    // deshabilitar entrada de login
                    txtUsuario.IsEnabled = false;
                }
                else
                {
                    MessageBox.Show("Usuario introducido incorrecto", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                    
                }
            }
        }

        private Boolean ComprobarEntrada(string valorIntroducido, string valorValido,
                Control componenteEntrada, Image imagenFeedBack)
        {
            Boolean valido = false;
            if (valorIntroducido.Equals(valorValido))
            {
                // borde y background en verde
                componenteEntrada.BorderBrush = Brushes.Green;
                componenteEntrada.Background = Brushes.LightGreen;
                // imagen al lado de la entrada de usuario --> check
                imagenFeedBack.Source = imagCheck;
                valido = true;
            }
            else
            {
                // marcamos borde en rojo
                componenteEntrada.BorderBrush = Brushes.Red;
                componenteEntrada.Background = Brushes.LightCoral;
                // imagen al lado de la entrada de usuario --> cross
                imagenFeedBack.Source = imagCross;
                valido = false;
            }
            return valido;
        }

        private void passContrasena_KeyUp(object sender, KeyEventArgs e)
        {
            if (ComprobarEntrada(passContrasena.Password, password,
                        passContrasena, imgCheckContrasena))
            {
                btnLogin.Focus();
                imgLogin.Source = imgFazul;
                btnLogin.IsEnabled = true;
            }
            else
            {
                imgLogin.Source = imgFnormal;
            }

        }

    }
}
