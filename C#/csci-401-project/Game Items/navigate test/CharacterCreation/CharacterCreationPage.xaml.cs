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

namespace CharacterCreation
{
    /// <summary>
    /// Interaction logic for CharacterCreationPage.xaml
    /// </summary>
    public partial class CharacterCreationPage : Page
    {
        Window main;

        public CharacterCreationPage(Window title)
        {
            main = title;
            InitializeComponent();
        }

        private void EnterLeaveGame()
        {
            BlackOut.Visibility = Visibility.Visible;
            LeaveGameGrid.Visibility = Visibility.Visible;
            //bgm.Volume = 0.2;
        }

        private void CustomAppear()
        {
            BlackOut.Visibility = Visibility.Visible;
            CustomizeWindowGrid.Visibility = Visibility.Visible;
        }

        private void TitleBarTip_MouseDown(object sender, MouseButtonEventArgs e)
        {
            main.DragMove();
        }

        private void TitleBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            main.DragMove();
        }

        private void TitleBarButt_MouseDown(object sender, MouseButtonEventArgs e)
        {
            main.DragMove();
        }

        private void LeftTitleBarPatch_MouseDown(object sender, MouseButtonEventArgs e)
        {
            main.DragMove();
        }

        private void RightTitleBarPatch_MouseDown(object sender, MouseButtonEventArgs e)
        {
            main.DragMove();
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            main.WindowState = WindowState.Minimized;
        }

        private void XButton_Click(object sender, RoutedEventArgs e)
        {
            EnterLeaveGame();
        }

        private void LeaveGameOkButton_Click(object sender, RoutedEventArgs e)
        {
            // shuts down the instance of the wpf application.
            Application.Current.Shutdown();
        }

        private void LeaveGameCancelButton_Click(object sender, RoutedEventArgs e)
        {
            //bgm.Volume = 0.5;
            LeaveGameGrid.Visibility = Visibility.Hidden;
            BlackOut.Visibility = Visibility.Hidden;
        }

        private void HeroOneHighlight_MouseEnter(object sender, MouseEventArgs e)
        {
            HeroOneHighlight.Opacity = .15;
        }

        private void HeroOneHighlight_MouseLeave(object sender, MouseEventArgs e)
        {
            HeroOneHighlight.Opacity = 1;
        }

        private void HeroOneAura_MouseEnter(object sender, MouseEventArgs e)
        {
            HeroOneHighlight.Opacity = .15;
        }

        private void HeroOneAura_MouseLeave(object sender, MouseEventArgs e)
        {
            HeroOneHighlight.Opacity = 1;
        }

        private void HeroOneFrame_MouseEnter(object sender, MouseEventArgs e)
        {
            HeroOneHighlight.Opacity = .15;
        }

        private void HeroOneFrame_MouseLeave(object sender, MouseEventArgs e)
        {
            HeroOneHighlight.Opacity = 1;
        }

        private void HeroOneSlot_MouseEnter(object sender, MouseEventArgs e)
        {
            HeroOneHighlight.Opacity = .15;
        }

        private void HeroOneSlot_MouseLeave(object sender, MouseEventArgs e)
        {
            HeroOneHighlight.Opacity = 1;
        }

        private void HeroTwoAura_MouseEnter(object sender, MouseEventArgs e)
        {
            HeroTwoHighlight.Opacity = .15;
        }

        private void HeroTwoAura_MouseLeave(object sender, MouseEventArgs e)
        {
            HeroTwoHighlight.Opacity = 1;
        }

        private void HeroTwoFrame_MouseEnter(object sender, MouseEventArgs e)
        {
            HeroTwoHighlight.Opacity = .15;
        }

        private void HeroTwoFrame_MouseLeave(object sender, MouseEventArgs e)
        {
            HeroTwoHighlight.Opacity = 1;
        }

        private void HeroTwoSlot_MouseEnter(object sender, MouseEventArgs e)
        {
            HeroTwoHighlight.Opacity = .15;
        }

        private void HeroTwoSlot_MouseLeave(object sender, MouseEventArgs e)
        {
            HeroTwoHighlight.Opacity = 1;
        }

        private void HeroThreeHighlight_MouseEnter(object sender, MouseEventArgs e)
        {
            HeroThreeHighlight.Opacity = .15;
        }

        private void HeroThreeHighlight_MouseLeave(object sender, MouseEventArgs e)
        {
            HeroThreeHighlight.Opacity = 1;
        }

        private void HeroThreeAura_MouseEnter(object sender, MouseEventArgs e)
        {
            HeroThreeHighlight.Opacity = .15;
        }

        private void HeroThreeAura_MouseLeave(object sender, MouseEventArgs e)
        {
            HeroThreeHighlight.Opacity = 1;
        }

        private void HeroThreeFrame_MouseEnter(object sender, MouseEventArgs e)
        {
            HeroThreeHighlight.Opacity = .15;
        }

        private void HeroThreeFrame_MouseLeave(object sender, MouseEventArgs e)
        {
            HeroThreeHighlight.Opacity = 1;
        }

        private void HeroThreeSlot_MouseEnter(object sender, MouseEventArgs e)
        {
            HeroThreeHighlight.Opacity = .15;
        }

        private void HeroThreeSlot_MouseLeave(object sender, MouseEventArgs e)
        {
            HeroThreeHighlight.Opacity = 1;
        }

        private void HeroFourHighlight_MouseEnter(object sender, MouseEventArgs e)
        {
            HeroFourHighlight.Opacity = .15;
        }

        private void HeroFourHighlight_MouseLeave(object sender, MouseEventArgs e)
        {
            HeroFourHighlight.Opacity = 1;
        }

        private void HeroFourAura_MouseEnter(object sender, MouseEventArgs e)
        {
            HeroFourHighlight.Opacity = .15;
        }

        private void HeroFourAura_MouseLeave(object sender, MouseEventArgs e)
        {
            HeroFourHighlight.Opacity = 1;
        }

        private void HeroFourFrame_MouseEnter(object sender, MouseEventArgs e)
        {
            HeroFourHighlight.Opacity = .15;
        }

        private void HeroFourFrame_MouseLeave(object sender, MouseEventArgs e)
        {
            HeroFourHighlight.Opacity = 1;
        }

        private void HeroFourSlot_MouseEnter(object sender, MouseEventArgs e)
        {
            HeroFourHighlight.Opacity = .15;
        }

        private void HeroFourSlot_MouseLeave(object sender, MouseEventArgs e)
        {
            HeroFourHighlight.Opacity = 1;
        }

        private void HeroFiveHighlight_MouseEnter(object sender, MouseEventArgs e)
        {
            HeroFiveHighlight.Opacity = .15;
        }

        private void HeroFiveHighlight_MouseLeave(object sender, MouseEventArgs e)
        {
            HeroFiveHighlight.Opacity = 1;
        }

        private void HeroFiveAura_MouseEnter(object sender, MouseEventArgs e)
        {
            HeroFiveHighlight.Opacity = .15;
        }

        private void HeroFiveAura_MouseLeave(object sender, MouseEventArgs e)
        {
            HeroFiveHighlight.Opacity = 1;
        }

        private void HeroFiveFrame_MouseEnter(object sender, MouseEventArgs e)
        {
            HeroFiveHighlight.Opacity = .15;
        }

        private void HeroFiveFrame_MouseLeave(object sender, MouseEventArgs e)
        {
            HeroFiveHighlight.Opacity = 1;
        }

        private void HeroFiveSlot_MouseEnter(object sender, MouseEventArgs e)
        {
            HeroFiveHighlight.Opacity = .15;
        }

        private void HeroFiveSlot_MouseLeave(object sender, MouseEventArgs e)
        {
            HeroFiveHighlight.Opacity = 1;
        }

        private void HeroTwoHighlight_MouseEnter(object sender, MouseEventArgs e)
        {
            HeroTwoHighlight.Opacity = .15;
        }

        private void HeroTwoHighlight_MouseLeave(object sender, MouseEventArgs e)
        {
            HeroTwoHighlight.Opacity = 1;
        }

        private void SoftwareEngineerButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CustomizeXButton_Click(object sender, RoutedEventArgs e)
        {
            CustomizeWindowGrid.Visibility = Visibility.Hidden;
            BlackOut.Visibility = Visibility.Hidden;
        }

        private void HeroOneSlot_Click(object sender, RoutedEventArgs e)
        {
            CustomAppear();
        }

        private void HeroOneFrame_Click(object sender, RoutedEventArgs e)
        {
            CustomAppear();
        }

        private void HeroOneAura_Click(object sender, RoutedEventArgs e)
        {
            CustomAppear();
        }

        private void HeroOneHighlight_Click(object sender, RoutedEventArgs e)
        {
            CustomAppear();
        }

        private void HeroTwoHighlight_Click(object sender, RoutedEventArgs e)
        {
            CustomAppear();
        }

        private void HeroTwoAura_Click(object sender, RoutedEventArgs e)
        {
            CustomAppear();
        }

        private void HeroTwoFrame_Click(object sender, RoutedEventArgs e)
        {
            CustomAppear();
        }

        private void HeroTwoSlot_Click(object sender, RoutedEventArgs e)
        {
            CustomAppear();
        }

        private void HeroThreeHighlight_Click(object sender, RoutedEventArgs e)
        {
            CustomAppear();
        }

        private void HeroThreeAura_Click(object sender, RoutedEventArgs e)
        {
            CustomAppear();
        }

        private void HeroThreeFrame_Click(object sender, RoutedEventArgs e)
        {
            CustomAppear();
        }

        private void HeroThreeSlot_Click(object sender, RoutedEventArgs e)
        {
            CustomAppear();
        }

        private void HeroFourHighlight_Click(object sender, RoutedEventArgs e)
        {
            CustomAppear();
        }

        private void HeroFourAura_Click(object sender, RoutedEventArgs e)
        {
            CustomAppear();
        }

        private void HeroFourFrame_Click(object sender, RoutedEventArgs e)
        {
            CustomAppear();
        }

        private void HeroFourSlot_Click(object sender, RoutedEventArgs e)
        {
            CustomAppear();
        }

        private void HeroFiveHighlight_Click(object sender, RoutedEventArgs e)
        {
            CustomAppear();
        }

        private void HeroFiveAura_Click(object sender, RoutedEventArgs e)
        {
            CustomAppear();
        }

        private void HeroFiveFrame_Click(object sender, RoutedEventArgs e)
        {
            CustomAppear();
        }

        private void HeroFiveSlot_Click(object sender, RoutedEventArgs e)
        {
            CustomAppear();
        }
    }
}
