using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Esri.ArcGISRuntime.Data;
using Esri.ArcGISRuntime.Mapping;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        async private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            map1.Map = new Map();

            string folder = Windows.ApplicationModel.Package.Current.InstalledLocation.Path;
            string filename = @"Assets\NOA\bnd-political-boundary-a.shp";
            string filepath = Path.Combine(folder, filename);

            ShapefileFeatureTable shapefile = await ShapefileFeatureTable.OpenAsync(filepath);

            FeatureLayer featurelayer = new FeatureLayer(shapefile);

            map1.Map.OperationalLayers.Add(featurelayer);

            await map1.SetViewpointGeometryAsync(featurelayer.FullExtent);
        }
    }
}
