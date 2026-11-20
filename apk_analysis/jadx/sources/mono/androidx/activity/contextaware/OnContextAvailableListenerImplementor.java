package mono.androidx.activity.contextaware;

import android.content.Context;
import androidx.activity.contextaware.OnContextAvailableListener;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class OnContextAvailableListenerImplementor implements IGCUserPeer, OnContextAvailableListener {
    private ArrayList refList;

    private native void n_onContextAvailable(Context context);

    public OnContextAvailableListenerImplementor() {
        if (getClass() == OnContextAvailableListenerImplementor.class) {
            TypeManager.Activate("AndroidX.Activity.ContextAware.IOnContextAvailableListenerImplementor, Xamarin.AndroidX.Activity", "", this, new Object[0]);
        }
    }

    @Override // androidx.activity.contextaware.OnContextAvailableListener
    public void onContextAvailable(Context context) {
        n_onContextAvailable(context);
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
