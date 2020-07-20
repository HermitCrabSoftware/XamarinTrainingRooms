using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Java.Interop;
using TrainingRooms;

namespace trainingrooms.droid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private RoomRepository repo;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            repo = new RoomRepository();
            var roomList = repo.GetRooms().ToArray();
            var roomAdapter = new ArrayAdapter<TrainingRoom>(this, Resource.Layout.RoomListItem, roomList);
            
            ListView lv = FindViewById<ListView>(Resource.Id.mainListView);
            lv.Adapter = roomAdapter;
            lv.ItemClick += Lv_ItemClick;

        }

        private void Lv_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var view = e.Parent as ListView;
            var lvAdapter = view.Adapter as ArrayAdapter<TrainingRoom>;
            var room = lvAdapter.GetItem((int)e.Id);
            
            
            Intent intent = new Intent(this, typeof(TrainingRoomDetailActivity));
            intent.PutExtra("roomId", room.Id);
            StartActivity(intent);

        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}
