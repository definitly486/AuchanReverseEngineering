package mono.com.github.chrisbanes.photoview;

import android.graphics.RectF;
import com.github.chrisbanes.photoview.OnMatrixChangedListener;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class OnMatrixChangedListenerImplementor implements IGCUserPeer, OnMatrixChangedListener {
    private ArrayList refList;

    private native void n_onMatrixChanged(RectF rectF);

    public OnMatrixChangedListenerImplementor() {
        if (getClass() == OnMatrixChangedListenerImplementor.class) {
            TypeManager.Activate("ImageViews.Photo.IOnMatrixChangedListenerImplementor, PhotoView", "", this, new Object[0]);
        }
    }

    @Override // com.github.chrisbanes.photoview.OnMatrixChangedListener
    public void onMatrixChanged(RectF rectF) {
        n_onMatrixChanged(rectF);
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
