using MvvmCross.Droid.Support.V4;
using System;
using Android.Support.V4.App;
using MvvmCross.Core.ViewModels;
using Android.Content;
using System.Collections.Generic;
using Android.Support.Design.Widget;
using System.Linq;

namespace UrbanDictionary.Xamarin.Droid
{
    public class ViewPagerAdapter : FragmentStatePagerAdapter
    {
        public class FragmentInfo
        {
            public string Title { get; set; }
            public int IconDrawable { get; set; }
            public Type FragmentType { get; set; }
            public IMvxViewModel ViewModel { get; set; }
        }

        private readonly Context _context;
        private TabLayout _tabLayout;

        public ViewPagerAdapter(Context context, FragmentManager fm, IReadOnlyCollection<FragmentInfo> fragments, TabLayout tabLayout)
            : base(fm)
        {
            Fragments = fragments;
            _context = context;
            _tabLayout = tabLayout;
        }

        public override int Count => Fragments?.Count ?? 0;

        public IReadOnlyCollection<FragmentInfo> Fragments { get; private set; }

        public override Fragment GetItem(int position)
        {
            var frag = Fragments.ElementAt(position);
            var fragment = Fragment.Instantiate(this._context,
                                                Java.Lang.Class.FromType(frag.FragmentType).Name);

            ((MvxFragment)fragment).DataContext = frag.ViewModel;
            return fragment;
        }

        public void SetupIcons()
        {
            for (var i = 0; i < _tabLayout.TabCount; i++)
            {
                var tab = _tabLayout.GetTabAt(i);
                tab.SetText(string.Empty);
                tab.SetIcon(Fragments.ElementAt(i).IconDrawable);
            }
        }
    }
}