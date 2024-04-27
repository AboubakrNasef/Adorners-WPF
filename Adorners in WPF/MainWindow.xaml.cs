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

namespace Adorners_in_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private int _adornerCount = 0;

        private int clickCount;

        public MainWindow()
        {
            InitializeComponent();

            
            foreach (UIElement item in cnvs.Children)
            {
                item.MouseDown += uiElementDown;
            }            
        }


    

     

    

        private void uiElementDown(object sender, MouseButtonEventArgs e)
        {
            var uiElement = sender as UIElement;
            UIElement LastadornerUI=null;
            if (uiElement == null) { return; }
            if (e.ChangedButton == MouseButton.Right)
            {
                if (_adornerCount > 0)
                {

                     LastadornerUI = cnvs.Children.Cast<UIElement>().FirstOrDefault(ui => AdornerLayer.GetAdornerLayer(ui).GetAdorners(ui) != null);
                    var lastadorner = AdornerLayer.GetAdornerLayer(LastadornerUI).GetAdorners(LastadornerUI)?.FirstOrDefault(x => x is ResizeAdorner);
                    AdornerLayer.GetAdornerLayer(LastadornerUI).Remove(lastadorner);
                    _adornerCount--;
                }

                if (LastadornerUI == uiElement)
                {
                    return;
                }

                var adorner = AdornerLayer.GetAdornerLayer(uiElement).GetAdorners(uiElement)?.FirstOrDefault(x => x is ResizeAdorner);
              
                if (adorner != null)
                    {
                        _adornerCount--;
                        AdornerLayer.GetAdornerLayer(uiElement).Remove(adorner);
                    }
                    else
                    {

                        _adornerCount++;
                        AdornerLayer.GetAdornerLayer(uiElement).Add(new ResizeAdorner(uiElement));
                    }
                
            }
        }
    }
}
