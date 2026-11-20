package crc6459efab142bb48047;

import androidx.viewpager2.widget.ViewPager2;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class ViewPager2OnPageChangeCallback extends ViewPager2.OnPageChangeCallback implements IGCUserPeer {
    private ArrayList refList;

    private native void n_onPageScrollStateChanged(int i);

    private native void n_onPageScrolled(int i, float f, int i2);

    private native void n_onPageSelected(int i);

    public ViewPager2OnPageChangeCallback() {
        if (getClass() == ViewPager2OnPageChangeCallback.class) {
            TypeManager.Activate("Auchan.Android.Common.UiUtils.ViewPager2OnPageChangeCallback, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    @Override // androidx.viewpager2.widget.ViewPager2.OnPageChangeCallback
    public void onPageSelected(int i) {
        n_onPageSelected(i);
    }

    @Override // androidx.viewpager2.widget.ViewPager2.OnPageChangeCallback
    public void onPageScrolled(int i, float f, int i2) {
        n_onPageScrolled(i, f, i2);
    }

    @Override // androidx.viewpager2.widget.ViewPager2.OnPageChangeCallback
    public void onPageScrollStateChanged(int i) {
        n_onPageScrollStateChanged(i);
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
