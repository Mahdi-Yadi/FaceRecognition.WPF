using System.Windows;
using System.Windows.Input;
namespace FaceRecognition.WPF;
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void btn_mini_MouseDown(object sender, MouseButtonEventArgs e)
    {
        WindowState = WindowState.Minimized;
    }

    private void btn_Close_MouseDown(object sender, MouseButtonEventArgs e)
    {
        Environment.Exit(0);
    }
}