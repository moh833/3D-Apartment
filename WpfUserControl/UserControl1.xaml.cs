using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Media3D;
using HelixToolkit.Wpf;

namespace WpfUserControl
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        // private const string MODEL_PATH = "C:/Users/Baraa/Desktop/image/WpfUserControl/model.stl";
        // private const string MODEL_PATH = "D:/work/C#_test/3D-Apartment/model.stl";
        private string MODEL_PATH = System.IO.Path.GetFullPath(System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\scripts\\model\\model.stl"));

        public UserControl1()
        {
            InitializeComponent();
            ModelVisual3D device3D = new ModelVisual3D();
            device3D.Content = Display3d(MODEL_PATH);
            // Add to view port
            viewPort3d.Children.Add(device3D);
        }
        public void LoadModel(string path)
        {
            InitializeComponent();

            for(int i=0; i< viewPort3d.Children.Count(); i++)
                viewPort3d.Children.RemoveAt(i);
            // viewPort3d.Children.Clear();
            
            ModelVisual3D device3D = new ModelVisual3D();
            device3D.Content = Display3d(path);
            // Add to view port
            viewPort3d.Children.Add(device3D);
        }


        private Model3D Display3d(string model)
        {
            Model3D device = null;
            try
            {
                //Adding a gesture here
                viewPort3d.RotateGesture = new MouseGesture(MouseAction.LeftClick);

                //Import 3D model file
                ModelImporter import = new ModelImporter();

                //Load the 3D model file
                device = import.Load(model);
            }
            catch (Exception e)
            {
                // Handle exception in case can not find the 3D model file
                // MessageBox.Show("Exception Error : " + e.StackTrace);
                // MessageBox.Show(model);
            }
            return device;
        }

    }
}
