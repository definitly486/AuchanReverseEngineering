package mono.android.animation;

import android.animation.ValueAnimator;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class ValueAnimator_AnimatorUpdateListenerImplementor implements IGCUserPeer, ValueAnimator.AnimatorUpdateListener {
    private ArrayList refList;

    private native void n_onAnimationUpdate(ValueAnimator valueAnimator);

    public ValueAnimator_AnimatorUpdateListenerImplementor() {
        if (getClass() == ValueAnimator_AnimatorUpdateListenerImplementor.class) {
            TypeManager.Activate("Android.Animation.ValueAnimator+IAnimatorUpdateListenerImplementor, Mono.Android", "", this, new Object[0]);
        }
    }

    @Override // android.animation.ValueAnimator.AnimatorUpdateListener
    public void onAnimationUpdate(ValueAnimator valueAnimator) {
        n_onAnimationUpdate(valueAnimator);
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
