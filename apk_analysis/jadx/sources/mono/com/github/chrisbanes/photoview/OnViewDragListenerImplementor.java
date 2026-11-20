package mono.com.github.chrisbanes.photoview;

import com.github.chrisbanes.photoview.OnViewDragListener;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class OnViewDragListenerImplementor implements IGCUserPeer, OnViewDragListener {
    private ArrayList refList;

    private native void n_onDrag(float f, float f2);

    public OnViewDragListenerImplementor() {
        if (getClass() == OnViewDragListenerImplementor.class) {
            TypeManager.Activate("ImageViews.Photo.IOnViewDragListenerImplementor, PhotoView", "", this, new Object[0]);
        }
    }

    @Override // com.github.chrisbanes.photoview.OnViewDragListener
    public void onDrag(float f, float f2) {
        n_onDrag(f, f2);
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
