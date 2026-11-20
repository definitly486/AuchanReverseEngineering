package mono.com.google.android.material.navigation;

import android.view.MenuItem;
import com.google.android.material.navigation.NavigationBarView;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class NavigationBarView_OnItemSelectedListenerImplementor implements IGCUserPeer, NavigationBarView.OnItemSelectedListener {
    private ArrayList refList;

    private native boolean n_onNavigationItemSelected(MenuItem menuItem);

    public NavigationBarView_OnItemSelectedListenerImplementor() {
        if (getClass() == NavigationBarView_OnItemSelectedListenerImplementor.class) {
            TypeManager.Activate("Google.Android.Material.Navigation.NavigationBarView+IOnItemSelectedListenerImplementor, Xamarin.Google.Android.Material", "", this, new Object[0]);
        }
    }

    @Override // com.google.android.material.navigation.NavigationBarView.OnItemSelectedListener
    public boolean onNavigationItemSelected(MenuItem menuItem) {
        return n_onNavigationItemSelected(menuItem);
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
