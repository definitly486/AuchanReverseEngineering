package mono.androidx.core.view;

import androidx.core.view.ActionProvider;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class ActionProvider_SubUiVisibilityListenerImplementor implements IGCUserPeer, ActionProvider.SubUiVisibilityListener {
    private ArrayList refList;

    private native void n_onSubUiVisibilityChanged(boolean z);

    public ActionProvider_SubUiVisibilityListenerImplementor() {
        if (getClass() == ActionProvider_SubUiVisibilityListenerImplementor.class) {
            TypeManager.Activate("AndroidX.Core.View.ActionProvider+ISubUiVisibilityListenerImplementor, Xamarin.AndroidX.Core", "", this, new Object[0]);
        }
    }

    @Override // androidx.core.view.ActionProvider.SubUiVisibilityListener
    public void onSubUiVisibilityChanged(boolean z) {
        n_onSubUiVisibilityChanged(z);
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
