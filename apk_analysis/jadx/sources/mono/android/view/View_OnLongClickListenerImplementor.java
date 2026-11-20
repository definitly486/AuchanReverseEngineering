package mono.android.view;

import android.view.View;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class View_OnLongClickListenerImplementor implements IGCUserPeer, View.OnLongClickListener {
    private ArrayList refList;

    private native boolean n_onLongClick(View view);

    private native boolean n_onLongClickUseDefaultHapticFeedback(View view);

    public View_OnLongClickListenerImplementor() {
        if (getClass() == View_OnLongClickListenerImplementor.class) {
            TypeManager.Activate("Android.Views.View+IOnLongClickListenerImplementor, Mono.Android", "", this, new Object[0]);
        }
    }

    @Override // android.view.View.OnLongClickListener
    public boolean onLongClick(View view) {
        return n_onLongClick(view);
    }

    @Override // android.view.View.OnLongClickListener
    public boolean onLongClickUseDefaultHapticFeedback(View view) {
        return n_onLongClickUseDefaultHapticFeedback(view);
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
