package crc64fac7521b55e1fcf3;

import android.animation.Animator;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class AnimationListener implements IGCUserPeer, Animator.AnimatorListener {
    private ArrayList refList;

    private native void n_onAnimationCancel(Animator animator);

    private native void n_onAnimationEnd(Animator animator);

    private native void n_onAnimationRepeat(Animator animator);

    private native void n_onAnimationStart(Animator animator);

    public AnimationListener() {
        if (getClass() == AnimationListener.class) {
            TypeManager.Activate("Auchan.Android.Controls.AnimationListener, Auchan.Android.Net", "", this, new Object[0]);
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
