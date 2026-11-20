package mono.androidx.appcompat.widget;

import android.view.MenuItem;
import androidx.appcompat.widget.Toolbar;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class Toolbar_OnMenuItemClickListenerImplementor implements IGCUserPeer, Toolbar.OnMenuItemClickListener {
    private ArrayList refList;

    private native boolean n_onMenuItemClick(MenuItem menuItem);

    public Toolbar_OnMenuItemClickListenerImplementor() {
        if (getClass() == Toolbar_OnMenuItemClickListenerImplementor.class) {
            TypeManager.Activate("AndroidX.AppCompat.Widget.Toolbar+IOnMenuItemClickListenerImplementor, Xamarin.AndroidX.AppCompat", "", this, new Object[0]);
        }
    }

    @Override // androidx.appcompat.widget.Toolbar.OnMenuItemClickListener
    public boolean onMenuItemClick(MenuItem menuItem) {
        return n_onMenuItemClick(menuItem);
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
