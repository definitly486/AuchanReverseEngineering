package mono.androidx.viewpager.widget;

import androidx.viewpager.widget.PagerAdapter;
import androidx.viewpager.widget.ViewPager;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class ViewPager_OnAdapterChangeListenerImplementor implements IGCUserPeer, ViewPager.OnAdapterChangeListener {
    private ArrayList refList;

    private native void n_onAdapterChanged(ViewPager viewPager, PagerAdapter pagerAdapter, PagerAdapter pagerAdapter2);

    public ViewPager_OnAdapterChangeListenerImplementor() {
        if (getClass() == ViewPager_OnAdapterChangeListenerImplementor.class) {
            TypeManager.Activate("AndroidX.ViewPager.Widget.ViewPager+IOnAdapterChangeListenerImplementor, Xamarin.AndroidX.ViewPager", "", this, new Object[0]);
        }
    }

    @Override // androidx.viewpager.widget.ViewPager.OnAdapterChangeListener
    public void onAdapterChanged(ViewPager viewPager, PagerAdapter pagerAdapter, PagerAdapter pagerAdapter2) {
        n_onAdapterChanged(viewPager, pagerAdapter, pagerAdapter2);
    }

    @Override // mono.android.IGCUserPeer
    public void monodroidAddReference(Object obj) {
        if (this.refList == null) {
            this.refList = new ArrayList();
        }
        this.refList.add(obj);
    }

    @Override // mono.android.IGCUserPeer
    public void monodroidClearReferences() {
        ArrayList arrayList = this.refList;
        if (arrayList != null) {
            arrayList.clear();
        }
    }
}
