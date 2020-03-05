using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Nfc;
using Android.Content;

namespace transnfc_v4.Droid
{
    [Activity(Label = "transnfc_v4", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        internal static bool _do_scanning;
        internal static NfcAdapter _nfc_adapter;
        private static PendingIntent _pending_intent;
        private static IntentFilter[] _filters;
        private static bool _nfc_avaible;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            _nfc_avaible = false;
            _do_scanning = false;
            _nfc_adapter = NfcAdapter.GetDefaultAdapter(this);

            if (_nfc_adapter != null)
            {
                _nfc_avaible = true;
                _pending_intent = PendingIntent.GetActivity(this, 0, new Intent(this, GetType()).AddFlags(ActivityFlags.SingleTop), 0);
                _filters = new IntentFilter[] { new IntentFilter(NfcAdapter.ActionTagDiscovered) };
            }

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        protected override void OnPause()
        {
            base.OnPause();
            if (_nfc_avaible)
            {
                _nfc_adapter.DisableForegroundDispatch(this);
            }
        }

        protected override void OnResume()
        {
            base.OnResume();
            if (_nfc_avaible)
            {
                _nfc_adapter.EnableForegroundDispatch(this, _pending_intent, _filters, null);
            }
        }

        protected override void OnNewIntent(Intent intent)
        {
            base.OnNewIntent(intent);
            if (_nfc_avaible && _do_scanning && intent.Action == NfcAdapter.ActionTagDiscovered)
            {
                Tag tag = intent.GetParcelableExtra(NfcAdapter.ExtraTag) as Tag;
                if (tag != null)
                {
                    IParcelable[] raw_data = intent.GetParcelableArrayExtra(NfcAdapter.ExtraNdefMessages);
                    if (raw_data != null)
                    {
                        NdefRecord record = (raw_data[0] as NdefMessage).GetRecords()[0];
                        if (record != null)
                        {
                            TagScanner._on_result(record.GetPayload());
                            _do_scanning = false;
                        }
                    }
                }
                else
                {
                    TagScanner._on_result(null);
                }
            }
        }
    }
}