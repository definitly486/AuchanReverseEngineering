package p000auchan;

import android.animation.Animator;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes.dex */
public class ZoomableImageView_EndAnimationListener implements IGCUserPeer, Animator.AnimatorListener {
    private ArrayList refList;

    private native void n_onAnimationCancel(Animator animator);

    private native void n_onAnimationEnd(Animator animator);

    private native void n_onAnimationRepeat(Animator animator);

    private native void n_onAnimationStart(Animator animator);

    public ZoomableImageView_EndAnimationListener() {
        if (getClass() == ZoomableImageView_EndAnimationListener.class) {
            TypeManager.Activate("Auchan.Android.Catalog.ZoomableImageView+EndAnimationListener, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    @Override // android.animation.Animator.AnimatorListener
    public void onAnimationCancel(Animator animator) {
        n_onAnimationCancel(animator);
    }

    @Override // android.animation.Animator.AnimatorListener
    public void onAnimationEnd(Animator animator) {
        n_onAnimationEnd(animator);
    }

    @Override // android.animation.Animator.AnimatorListener
    public void onAnimationRepeat(Animator animator) {
        n_onAnimationRepeat(animator);
    }

    @Override // android.animation.Animator.AnimatorListener
    public void onAnimationStart(Animator animator) {
        n_onAnimationStart(animator);
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
