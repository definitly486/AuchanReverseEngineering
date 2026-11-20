package mono.com.github.chrisbanes.photoview;

import android.view.MotionEvent;
import com.github.chrisbanes.photoview.OnSingleFlingListener;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class OnSingleFlingListenerImplementor implements IGCUserPeer, OnSingleFlingListener {
    private ArrayList refList;

    private native boolean n_onFling(MotionEvent motionEvent, MotionEvent motionEvent2, float f, float f2);

    public OnSingleFlingListenerImplementor() {
        if (getClass() == OnSingleFlingListenerImplementor.class) {
            TypeManager.Activate("ImageViews.Photo.IOnSingleFlingListenerImplementor, PhotoView", "", this, new Object[0]);
        }
    }

    @Override // com.github.chrisbanes.photoview.OnSingleFlingListener
    public boolean onFling(MotionEvent motionEvent, MotionEvent motionEvent2, float f, float f2) {
        return n_onFling(motionEvent, motionEvent2, f, f2);
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
