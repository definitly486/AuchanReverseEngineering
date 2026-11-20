package mono.androidx.appcompat.widget;

import androidx.appcompat.widget.SearchView;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class SearchView_OnQueryTextListenerImplementor implements IGCUserPeer, SearchView.OnQueryTextListener {
    private ArrayList refList;

    private native boolean n_onQueryTextChange(String str);

    private native boolean n_onQueryTextSubmit(String str);

    public SearchView_OnQueryTextListenerImplementor() {
        if (getClass() == SearchView_OnQueryTextListenerImplementor.class) {
            TypeManager.Activate("AndroidX.AppCompat.Widget.SearchView+IOnQueryTextListenerImplementor, Xamarin.AndroidX.AppCompat", "", this, new Object[0]);
        }
    }

    @Override // androidx.appcompat.widget.SearchView.OnQueryTextListener
    public boolean onQueryTextChange(String str) {
        return n_onQueryTextChange(str);
    }

    @Override // androidx.appcompat.widget.SearchView.OnQueryTextListener
    public boolean onQueryTextSubmit(String str) {
        return n_onQueryTextSubmit(str);
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
