package crc64f3dd990328beca9c;

import android.content.Context;
import android.view.View;
import android.view.ViewGroup;
import androidx.viewpager.widget.PagerAdapter;
import java.util.ArrayList;
import me.relex.circleindicator.CircleIndicator;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class LoyaltyPagerAdapter extends PagerAdapter implements IGCUserPeer {
    private ArrayList refList;

    private native void n_destroyItem(ViewGroup viewGroup, int i, Object obj);

    private native int n_getCount();

    private native Object n_instantiateItem(ViewGroup viewGroup, int i);

    private native boolean n_isViewFromObject(View view, Object obj);

    public LoyaltyPagerAdapter() {
        if (getClass() == LoyaltyPagerAdapter.class) {
            TypeManager.Activate("Auchan.Android.LoyaltyProgram.LoyaltyPagerAdapter, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    public LoyaltyPagerAdapter(Context context, CircleIndicator circleIndicator) {
        if (getClass() == LoyaltyPagerAdapter.class) {
            TypeManager.Activate("Auchan.Android.LoyaltyProgram.LoyaltyPagerAdapter, Auchan.Android.Net", "Android.Content.Context, Mono.Android:Me.Relex.CircleIndicatorLib.CircleIndicator, Ongakuer.CircleIndicator", this, new Object[]{context, circleIndicator});
        }
    }

    @Override // androidx.viewpager.widget.PagerAdapter
    public int getCount() {
        return n_getCount();
    }

    @Override // androidx.viewpager.widget.PagerAdapter
    public boolean isViewFromObject(View view, Object obj) {
        return n_isViewFromObject(view, obj);
    }

    @Override // androidx.viewpager.widget.PagerAdapter
    public Object instantiateItem(ViewGroup viewGroup, int i) {
        return n_instantiateItem(viewGroup, i);
    }

    @Override // androidx.viewpager.widget.PagerAdapter
    public void destroyItem(ViewGroup viewGroup, int i, Object obj) {
        n_destroyItem(viewGroup, i, obj);
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
