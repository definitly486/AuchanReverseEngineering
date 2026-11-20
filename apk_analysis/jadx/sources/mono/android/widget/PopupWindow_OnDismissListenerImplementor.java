package mono.android.widget;

import android.widget.PopupWindow;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class PopupWindow_OnDismissListenerImplementor implements IGCUserPeer, PopupWindow.OnDismissListener {
    private ArrayList refList;

    private native void n_onDismiss();

    public PopupWindow_OnDismissListenerImplementor() {
        if (getClass() == PopupWindow_OnDismissListenerImplementor.class) {
            TypeManager.Activate("Android.Widget.PopupWindow+IOnDismissListenerImplementor, Mono.Android", "", this, new Object[0]);
        }
    }

    @Override // android.widget.PopupWindow.OnDismissListener
    public void onDismiss() {
        n_onDismiss();
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
