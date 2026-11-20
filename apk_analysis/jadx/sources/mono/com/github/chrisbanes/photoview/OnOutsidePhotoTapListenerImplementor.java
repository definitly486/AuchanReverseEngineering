package mono.com.github.chrisbanes.photoview;

import android.widget.ImageView;
import com.github.chrisbanes.photoview.OnOutsidePhotoTapListener;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class OnOutsidePhotoTapListenerImplementor implements IGCUserPeer, OnOutsidePhotoTapListener {
    private ArrayList refList;

    private native void n_onOutsidePhotoTap(ImageView imageView);

    public OnOutsidePhotoTapListenerImplementor() {
        if (getClass() == OnOutsidePhotoTapListenerImplementor.class) {
            TypeManager.Activate("ImageViews.Photo.IOnOutsidePhotoTapListenerImplementor, PhotoView", "", this, new Object[0]);
        }
    }

    @Override // com.github.chrisbanes.photoview.OnOutsidePhotoTapListener
    public void onOutsidePhotoTap(ImageView imageView) {
        n_onOutsidePhotoTap(imageView);
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
