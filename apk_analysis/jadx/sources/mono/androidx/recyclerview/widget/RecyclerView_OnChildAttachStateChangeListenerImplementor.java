package mono.androidx.recyclerview.widget;

import android.view.View;
import androidx.recyclerview.widget.RecyclerView;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class RecyclerView_OnChildAttachStateChangeListenerImplementor implements IGCUserPeer, RecyclerView.OnChildAttachStateChangeListener {
    private ArrayList refList;

    private native void n_onChildViewAttachedToWindow(View view);

    private native void n_onChildViewDetachedFromWindow(View view);

    public RecyclerView_OnChildAttachStateChangeListenerImplementor() {
        if (getClass() == RecyclerView_OnChildAttachStateChangeListenerImplementor.class) {
            TypeManager.Activate("AndroidX.RecyclerView.Widget.RecyclerView+IOnChildAttachStateChangeListenerImplementor, Xamarin.AndroidX.RecyclerView", "", this, new Object[0]);
        }
    }

    @Override // androidx.recyclerview.widget.RecyclerView.OnChildAttachStateChangeListener
    public void onChildViewAttachedToWindow(View view) {
        n_onChildViewAttachedToWindow(view);
    }

    @Override // androidx.recyclerview.widget.RecyclerView.OnChildAttachStateChangeListener
    public void onChildViewDetachedFromWindow(View view) {
        n_onChildViewDetachedFromWindow(view);
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
