package mono.android.widget;

import android.widget.RatingBar;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class RatingBar_OnRatingBarChangeListenerImplementor implements IGCUserPeer, RatingBar.OnRatingBarChangeListener {
    private ArrayList refList;

    private native void n_onRatingChanged(RatingBar ratingBar, float f, boolean z);

    public RatingBar_OnRatingBarChangeListenerImplementor() {
        if (getClass() == RatingBar_OnRatingBarChangeListenerImplementor.class) {
            TypeManager.Activate("Android.Widget.RatingBar+IOnRatingBarChangeListenerImplementor, Mono.Android", "", this, new Object[0]);
        }
    }

    @Override // android.widget.RatingBar.OnRatingBarChangeListener
    public void onRatingChanged(RatingBar ratingBar, float f, boolean z) {
        n_onRatingChanged(ratingBar, f, z);
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
