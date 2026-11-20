package mono.com.github.chrisbanes.photoview;

import android.view.View;
import com.github.chrisbanes.photoview.OnViewTapListener;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class OnViewTapListenerImplementor implements IGCUserPeer, OnViewTapListener {
    private ArrayList refList;

    private native void n_onViewTap(View view, float f, float f2);

    public OnViewTapListenerImplementor() {
        if (getClass() == OnViewTapListenerImplementor.class) {
            TypeManager.Activate("ImageViews.Photo.IOnViewTapListenerImplementor, PhotoView", "", this, new Object[0]);
        }
    }

    @Override // com.github.chrisbanes.photoview.OnViewTapListener
    public void onViewTap(View view, float f, float f2) {
        n_onViewTap(view, f, f2);
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
