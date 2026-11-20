package crc6459efab142bb48047;

import android.view.MotionEvent;
import android.view.View;
import androidx.viewpager2.widget.ViewPager2;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class ViewPager2AutoScroller implements IGCUserPeer, View.OnTouchListener {
    private ArrayList refList;

    private native boolean n_onTouch(View view, MotionEvent motionEvent);

    public ViewPager2AutoScroller() {
        if (getClass() == ViewPager2AutoScroller.class) {
            TypeManager.Activate("Auchan.Android.Common.UiUtils.ViewPager2AutoScroller, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    public ViewPager2AutoScroller(ViewPager2 viewPager2) {
        if (getClass() == ViewPager2AutoScroller.class) {
            TypeManager.Activate("Auchan.Android.Common.UiUtils.ViewPager2AutoScroller, Auchan.Android.Net", "AndroidX.ViewPager2.Widget.ViewPager2, Xamarin.AndroidX.ViewPager2", this, new Object[]{viewPager2});
        }
    }

    @Override // android.view.View.OnTouchListener
    public boolean onTouch(View view, MotionEvent motionEvent) {
        return n_onTouch(view, motionEvent);
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
