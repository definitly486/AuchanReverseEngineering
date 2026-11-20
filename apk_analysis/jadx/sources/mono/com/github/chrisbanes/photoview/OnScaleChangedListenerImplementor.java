package mono.com.github.chrisbanes.photoview;

import com.github.chrisbanes.photoview.OnScaleChangedListener;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class OnScaleChangedListenerImplementor implements IGCUserPeer, OnScaleChangedListener {
    private ArrayList refList;

    private native void n_onScaleChange(float f, float f2, float f3);

    public OnScaleChangedListenerImplementor() {
        if (getClass() == OnScaleChangedListenerImplementor.class) {
            TypeManager.Activate("ImageViews.Photo.IOnScaleChangedListenerImplementor, PhotoView", "", this, new Object[0]);
        }
    }

    @Override // com.github.chrisbanes.photoview.OnScaleChangedListener
    public void onScaleChange(float f, float f2, float f3) {
        n_onScaleChange(f, f2, f3);
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
