package mono.com.github.chrisbanes.photoview;

import android.widget.ImageView;
import com.github.chrisbanes.photoview.OnPhotoTapListener;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class OnPhotoTapListenerImplementor implements IGCUserPeer, OnPhotoTapListener {
    private ArrayList refList;

    private native void n_onPhotoTap(ImageView imageView, float f, float f2);

    public OnPhotoTapListenerImplementor() {
        if (getClass() == OnPhotoTapListenerImplementor.class) {
            TypeManager.Activate("ImageViews.Photo.IOnPhotoTapListenerImplementor, PhotoView", "", this, new Object[0]);
        }
    }

    @Override // com.github.chrisbanes.photoview.OnPhotoTapListener
    public void onPhotoTap(ImageView imageView, float f, float f2) {
        n_onPhotoTap(imageView, f, f2);
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
