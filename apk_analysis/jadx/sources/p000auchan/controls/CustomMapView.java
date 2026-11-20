package p000auchan.controls;

import android.content.Context;
import android.util.AttributeSet;
import android.view.MotionEvent;
import com.yandex.mapkit.mapview.MapView;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes.dex */
public class CustomMapView extends MapView implements IGCUserPeer {
    private ArrayList refList;

    private native boolean n_onInterceptTouchEvent(MotionEvent motionEvent);

    public CustomMapView(Context context) {
        super(context);
        if (getClass() == CustomMapView.class) {
            TypeManager.Activate("Auchan.Android.Controls.CustomMapView, Auchan.Android.Net", "Android.Content.Context, Mono.Android", this, new Object[]{context});
        }
    }

    public CustomMapView(Context context, AttributeSet attributeSet) {
        super(context, attributeSet);
        if (getClass() == CustomMapView.class) {
            TypeManager.Activate("Auchan.Android.Controls.CustomMapView, Auchan.Android.Net", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new Object[]{context, attributeSet});
        }
    }

    public CustomMapView(Context context, AttributeSet attributeSet, int i) {
        super(context, attributeSet, i);
        if (getClass() == CustomMapView.class) {
            TypeManager.Activate("Auchan.Android.Controls.CustomMapView, Auchan.Android.Net", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, System.Private.CoreLib", this, new Object[]{context, attributeSet, Integer.valueOf(i)});
        }
    }

    @Override // android.view.ViewGroup
    public boolean onInterceptTouchEvent(MotionEvent motionEvent) {
        return n_onInterceptTouchEvent(motionEvent);
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
