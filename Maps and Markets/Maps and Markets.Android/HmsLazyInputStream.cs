// Android
using Android.Content;
using Android.Util;
// System
using System;
using System.IO;
// Huawei 
using Huawei.Agconnect.Config;

namespace Maps_and_Markets.Droid
{
    internal class HmsLazyInputStream : LazyInputStream
    {
        public HmsLazyInputStream(Context context) : base(context)
        {
        }

        public override Stream Get(Context context)
        {
            try
            {
                return context.Assets.Open("agconnect-services.json");
            }
            catch (Exception e)
            {
                Log.Error(e.ToString(), "Can't open agconnect file");

                return null;
            }
        }
    }
}