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
using System.Windows.Resources;
using System.Windows.Shapes;

namespace DrugiProjektni
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private int redniBrojIgraca = 0;
        private bool igraTraje = true;
        private int rezX = 0;
        private int rezO = 0;
        private int brojac= 0;
        
        public MainWindow()
        {
        }

        private void Image_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            Image slika = (Image)sender;
            String putanjaSlike = "Resources/";
            String putanja = slika.Source.ToString();
            if (igraTraje && putanja.EndsWith("bijela.png"))
            {
                brojac++;
                if (redniBrojIgraca == 1)
                {
                    putanjaSlike += "OKS.png";
                    redniBrojIgraca = 2;
                    TrenutnoIgra.Content = "Trenutno igra: X";
                }
                else
                {
                    putanjaSlike += "IKS.png";
                    redniBrojIgraca = 1;
                    TrenutnoIgra.Content = "Trenutno igra: O";
                }
                slika.Source = new BitmapImage(new Uri(putanjaSlike, UriKind.Relative));
                if (provjeraPobjede("IKS.png"))
                {
                    MessageBox.Show("Pobijedio je igrač: X\nČestitamo!", "Igrica IKS-OKS");
                    rezX++;
                    RezultatX.Content = rezX;
                    TrenutnoIgra.Visibility = Visibility.Hidden;
                    igraTraje = false;
                }
                else if (provjeraPobjede("OKS.png"))
                {
                    MessageBox.Show("Pobijedio je igrač: O\nČestitamo!", "Igrica IKS-OKS");
                    rezO++;
                    RezultatO.Content = rezO;
                    TrenutnoIgra.Visibility = Visibility.Hidden;
                    igraTraje = false;
                }
                else if (brojac == 9)
                {
                    MessageBox.Show("Neriješeno!", "Igrica IKS-OKS");
                    TrenutnoIgra.Visibility = Visibility.Visible;
                }
              
            }
        }

        public Boolean provjeraPobjede(String imeSlike)
        {
            for(int i = 0; i < 9; i += 3)
            {
                if (
                    ((Image)kanvas.Children[i]).Source.ToString().EndsWith(imeSlike)
                    && ((Image)kanvas.Children[i + 1]).Source.ToString().EndsWith(imeSlike)
                    && ((Image)kanvas.Children[i + 2]).Source.ToString().EndsWith(imeSlike)
                    )
                {
                    if (i == 0)
                    {
                        pobjeda_3.Visibility = Visibility.Visible;
                    }
                    else if (i == 3)
                    {
                        pobjeda_4.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        pobjeda_5.Visibility = Visibility.Visible;
                    }
                    return true;
                }
            }
            for(int i = 0; i < 3; i++)
            {
                if (
                    ((Image)kanvas.Children[i]).Source.ToString().EndsWith(imeSlike)
                    && ((Image)kanvas.Children[i + 3]).Source.ToString().EndsWith(imeSlike)
                    && ((Image)kanvas.Children[i + 6]).Source.ToString().EndsWith(imeSlike)
                    )
                {
                    if (i == 0)
                    {
                        pobjeda_6.Visibility = Visibility.Visible;
                    }
                    else if (i == 1)
                    {
                        pobjeda_7.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        pobjeda_8.Visibility = Visibility.Visible;
                    }
                    return true;
                } 
            }
            if (
                    ((Image)kanvas.Children[0]).Source.ToString().EndsWith(imeSlike)
                    && ((Image)kanvas.Children[4]).Source.ToString().EndsWith(imeSlike)
                    && ((Image)kanvas.Children[8]).Source.ToString().EndsWith(imeSlike)
                    )
            {
                pobjeda_1.Visibility = Visibility.Visible;
                return true;
            } 
            if (
                    ((Image)kanvas.Children[2]).Source.ToString().EndsWith(imeSlike)
                    && ((Image)kanvas.Children[4]).Source.ToString().EndsWith(imeSlike)
                    && ((Image)kanvas.Children[6]).Source.ToString().EndsWith(imeSlike)
                    )
            {
                pobjeda_2.Visibility = Visibility.Visible;
                return true;
            } 
            return false;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void Button_Click_2_Click(object sender, RoutedEventArgs e)
        {
            rezX = 0;
            rezO = 0;
            brojac = 0;
            RezultatX.Content = rezX;
            RezultatO.Content = rezO;
            spremiZaNovuIgru();
            ocistiLinije();
        }
       
        private void spremiZaNovuIgru()
        {
            for (int i = 0; i < 9; i++)
            {
                ((Image)kanvas.Children[i]).Source = new BitmapImage(new Uri("Resources/bijela.png", UriKind.Relative));
            }

        }

        private void ocistiLinije()
        {
            pobjeda_1.Visibility = Visibility.Hidden;
            pobjeda_2.Visibility = Visibility.Hidden;
            pobjeda_3.Visibility = Visibility.Hidden;
            pobjeda_4.Visibility = Visibility.Hidden;
            pobjeda_5.Visibility = Visibility.Hidden;
            pobjeda_6.Visibility = Visibility.Hidden;
            pobjeda_7.Visibility = Visibility.Hidden;
            pobjeda_8.Visibility = Visibility.Hidden;
        }

        private void Button_NovaIgra(object sender, RoutedEventArgs e)
        {
            spremiZaNovuIgru();
            igraTraje = true;
            TrenutnoIgra.Visibility = Visibility.Visible;
            brojac = 0;
            ocistiLinije();
        }
    }

       

}
