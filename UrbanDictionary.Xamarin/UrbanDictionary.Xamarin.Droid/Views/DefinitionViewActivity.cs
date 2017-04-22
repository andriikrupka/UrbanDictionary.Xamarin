using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Views;
using UrbanDictionary.Xamarin.ViewModels;

namespace UrbanDictionary.Xamarin.Droid.Views
{
    [Activity]
    public class DefinitionViewActivity : MvxAppCompatActivity<DefinitionViewModel>
    {
        private MvxIncrementalListView recyclerView;
        private Toolbar toolBar;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.DefinitionViewActivity);
            
            toolBar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.definition_view_toolbar);
            toolBar.SetNavigationIcon(Resource.Drawable.ic_back_white);
            SetSupportActionBar(toolBar);
            SupportActionBar.SetHomeButtonEnabled(true);
            toolBar.Click += ToolBar_Click;
            recyclerView = FindViewById<MvxIncrementalListView>(Resource.Id.definition_recycler_view);
        }

        protected override void OnDestroy()
        {
            toolBar.Click -= ToolBar_Click;
            base.OnDestroy();
        }

        private void ToolBar_Click(object sender, System.EventArgs e)
        {
            recyclerView.SmoothScrollToPosition(0);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == global::Android.Resource.Id.Home)
            {
                Finish();
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }
    }
}