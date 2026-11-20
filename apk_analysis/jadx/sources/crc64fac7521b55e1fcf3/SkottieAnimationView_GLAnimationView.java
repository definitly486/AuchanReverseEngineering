package crc64fac7521b55e1fcf3;

import android.content.Context;
import android.util.AttributeSet;
import androidx.lifecycle.Lifecycle;
import androidx.lifecycle.LifecycleEventObserver;
import androidx.lifecycle.LifecycleObserver;
import androidx.lifecycle.LifecycleOwner;
import crc648e35430423bd4943.SKGLTextureView;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class SkottieAnimationView_GLAnimationView extends SKGLTextureView implements IGCUserPeer, LifecycleEventObserver, LifecycleObserver {
    private ArrayList refList;

    private native void n_onStateChanged(LifecycleOwner lifecycleOwner, Lifecycle.Event event);

    public SkottieAnimationView_GLAnimationView(Context context, AttributeSet attributeSet, int i) {
        super(context, attributeSet, i);
        if (getClass() == SkottieAnimationView_GLAnimationView.class) {
            TypeManager.Activate("Auchan.Android.Controls.SkottieAnimationView+GLAnimationView, Auchan.Android.Net", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, System.Private.CoreLib", this, new Object[]{context, attributeSet, Integer.valueOf(i)});
        }
    }

    public SkottieAnimationView_GLAnimationView(Context context, AttributeSet attributeSet) {
        super(context, attributeSet);
        if (getClass() == SkottieAnimationView_GLAnimationView.class) {
            TypeManager.Activate("Auchan.Android.Controls.SkottieAnimationView+GLAnimationView, Auchan.Android.Net", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new Object[]{context, attributeSet});
        }
    }

    public SkottieAnimationView_GLAnimationView(Context context) {
        super(context);
        if (getClass() == SkottieAnimationView_GLAnimationView.class) {
            TypeManager.Activate("Auchan.Android.Controls.SkottieAnimationView+GLAnimationView, Auchan.Android.Net", "Android.Content.Context, Mono.Android", this, new Object[]{context});
        }
    }

    @Override // androidx.lifecycle.LifecycleEventObserver
    public void onStateChanged(LifecycleOwner lifecycleOwner, Lifecycle.Event event) {
        n_onStateChanged(lifecycleOwner, event);
    }

    @Override // crc648e35430423bd4943.SKGLTextureView, crc648e35430423bd4943.GLTextureView, mono.android.IGCUserPeer
    public void monodroidAddReference(Object obj) {
        if (this.refList == null) {
            this.refList = new ArrayList();
        }
        this.refList.add(obj);
    }

    @Override // crc648e35430423bd4943.SKGLTextureView, crc648e35430423bd4943.GLTextureView, mono.android.IGCUserPeer
    public void monodroidClearReferences() {
        ArrayList arrayList = this.refList;
        if (arrayList != null) {
            arrayList.clear();
        }
    }
}
