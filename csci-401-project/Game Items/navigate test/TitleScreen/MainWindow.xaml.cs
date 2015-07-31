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
using CharacterCreation;

namespace TitleScreen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Page
    {
        public MainWindow()
        {
            InitializeComponent();
            bgm.Play();
            
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            EnterLeaveGame();
        }

        private void ExitButton_MouseEnter(object sender, MouseEventArgs e)
        {
            ExitButton.Opacity = 1.0;
        }

        private void ExitButton_MouseLeave(object sender, MouseEventArgs e)
        {
            ExitButton.Opacity = .10;
        }

        private void XButton_Click(object sender, RoutedEventArgs e)
        {
            EnterLeaveGame();
        }

        private void TitleBarTip_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //this.DragMove();
        }

        private void TitleBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //this.DragMove();
        }

        private void TitleBarButt_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //this.DragMove();
        }

        private void LeftTitleBarPatch_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //this.DragMove();
        }

        private void RightTitleBarPatch_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //this.DragMove();
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            //WindowState = WindowState.Minimized;
        }

        private void LeaveGameOkButton_Click(object sender, RoutedEventArgs e)
        {
            // shuts down the instance of the wpf application.
            Application.Current.Shutdown();
        }

        private void LeaveGameCancelButton_Click(object sender, RoutedEventArgs e)
        {
            bgm.Volume = 0.5;
            LeaveGameGrid.Visibility = Visibility.Hidden;
            BlackOut.Visibility = Visibility.Hidden;
        }

        private void bgm_MediaEnded(object sender, RoutedEventArgs e)
        {
            bgm.Position = TimeSpan.Zero;
            bgm.Play();
        }

        private void EnterLeaveGame()
        {
            BlackOut.Visibility = Visibility.Visible;
            LeaveGameGrid.Visibility = Visibility.Visible;
            bgm.Volume = 0.2;
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            //CharacterCreation.CharacterCreationPage create = 
            //    new CharacterCreation.CharacterCreationPage((Window)this);
            //NavigationService navi = new NavigationService;
            //navi.Navigate(create);

            //CharacterCreation.MainWindow charCreateScreen = new CharacterCreation.MainWindow(this);
            //App.Current.MainWindow = charCreateScreen;
            //charCreateScreen.Show();
            //this.Close();

            this.NavigationService.Navigate(new CharacterCreation.MainWindow());
        }
    }
}
