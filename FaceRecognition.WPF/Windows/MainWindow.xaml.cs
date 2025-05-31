using FaceRecognition_WPF;
using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
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

    private void btn_selecImage_Click(object sender, RoutedEventArgs e)
    {

        OpenFileDialog openFileDialog = new OpenFileDialog();

        openFileDialog.Filter = "Image files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";

        if(openFileDialog.ShowDialog() == true)
        {
            string imagePath = openFileDialog.FileName;

            img_Selected.Source = new BitmapImage(new Uri(imagePath));

            Analyze(imagePath);
        }

    }

    private void Analyze(string imagePath)
    {
        
        var imageBytes = File.ReadAllBytes(imagePath);

        var input = new MWFaceRecognition.ModelInput()
        {
            ImageSource = imageBytes
        };

        var result = MWFaceRecognition.Predict(input);

        if(result.PredictedLabel == "Man")
        {
            lbl_Result.Content = "مرد";
        }
        if (result.PredictedLabel == "Woman")
        {
            lbl_Result.Content = "زن";
        }
    }

}