using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Huawei.Hms.Common;
using Huawei.Hms.Maps;
using Huawei.Hms.Maps.Model;
using static Android.Views.View;
using Android.Views;
using Android.Widget;

namespace Maps_and_Markets.Droid
{
    [Activity(Label = "Maps_and_Markets", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity, IOnMapReadyCallback, IOnClickListener
    {
        private HuaweiMap hMap;
        private int Index = 0;
        private LatLng[] coors = new LatLng[] { 
            new LatLng(20.0331364,-88.8711063),
            new LatLng(19.4266932, -99.1739945),
            new LatLng(22.4021434, -101.4854814)
        };

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
            this.initMaps(savedInstanceState);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        
        private void initMaps(Bundle savedInstanceState)
        {
            MapsInitializer.SetApiKey("DAEDANX22nxDXpZOJCswNiHYIvmulvoTvkrI9LuE73bbQLbDgRiZ8BVDAWJNda0ZZm0Q0h5O/f06euJV7K5hK+5vCI77qrW8JSUHAQ==");
            MapsInitializer.Initialize(this);
            MapView mMapView;
            mMapView = new MapView(this.BaseContext);
            Bundle mapViewBundle = null; 
            
            if (savedInstanceState != null) { 
                mapViewBundle = savedInstanceState.GetBundle("MapViewBundleKey"); 
            }

            mMapView.OnCreate(mapViewBundle); 
            mMapView.GetMapAsync(this);
            
            var button = new Button(this.BaseContext);

            var height = ViewGroup.LayoutParams.WrapContent;
            var width = ViewGroup.LayoutParams.MatchParent;

            var layoutParameters = new LinearLayout.LayoutParams(width, height);
            button.LayoutParameters = layoutParameters;
            button.Text = "Next";
            button.SetOnClickListener(this);

            mMapView.AddView(button);

            this.SetContentView(mMapView);
        }

        public void OnMapReady(HuaweiMap huaweiMap)
        {
            this.hMap = huaweiMap;
            Marker marker1;
            MarkerOptions marker1Options = new MarkerOptions()
                            .InvokePosition(coors[0])
                            .InvokeTitle("Monumento a la Madre")
                            .InvokeSnippet("Monumento");
            Marker marker2;
            MarkerOptions marker1Options2 = new MarkerOptions()
                            .InvokePosition(coors[1])
                            .InvokeTitle("A la Paz")
                            .InvokeSnippet("Monumento");
            Marker marker3;
            MarkerOptions marker1Options3 = new MarkerOptions()
                            .InvokePosition(coors[2])
                            .InvokeTitle("Honor a Damián Carmona")
                            .InvokeSnippet("Monumento");


            marker1 = hMap.AddMarker(marker1Options);
            marker2 = hMap.AddMarker(marker1Options2);
            marker3 = hMap.AddMarker(marker1Options3);

            OnClick(null);
        }

        public void OnClick(View v)
        {
            if (Index == 2) Index = 0;
            else Index++;

            float zoom0 = 13.0f;
            CameraUpdate cameraUpdate7 = CameraUpdateFactory.NewLatLngZoom(coors[Index], zoom0);

            hMap.AnimateCamera(cameraUpdate7);
        }
    }
}