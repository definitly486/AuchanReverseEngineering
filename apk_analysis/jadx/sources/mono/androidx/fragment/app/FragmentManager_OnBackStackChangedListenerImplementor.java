package mono.androidx.fragment.app;

import androidx.activity.BackEventCompat;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentManager;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class FragmentManager_OnBackStackChangedListenerImplementor implements IGCUserPeer, FragmentManager.OnBackStackChangedListener {
    private ArrayList refList;

    private native void n_onBackStackChangeCancelled();

    private native void n_onBackStackChangeCommitted(Fragment fragment, boolean z);

    private native void n_onBackStackChangeProgressed(BackEventCompat backEventCompat);

    private native void n_onBackStackChangeStarted(Fragment fragment, boolean z);

    private native void n_onBackStackChanged();

    public FragmentManager_OnBackStackChangedListenerImplementor() {
        if (getClass() == FragmentManager_OnBackStackChangedListenerImplementor.class) {
            TypeManager.Activate("AndroidX.Fragment.App.FragmentManager+IOnBackStackChangedListenerImplementor, Xamarin.AndroidX.Fragment", "", this, new Object[0]);
        }
    }

    @Override // androidx.fragment.app.FragmentManager.OnBackStackChangedListener
    public void onBackStackChanged() {
        n_onBackStackChanged();
    }

    @Override // androidx.fragment.app.FragmentManager.OnBackStackChangedListener
    public void onBackStackChangeCancelled() {
        n_onBackStackChangeCancelled();
    }

    @Override // androidx.fragment.app.FragmentManager.OnBackStackChangedListener
    public void onBackStackChangeCommitted(Fragment fragment, boolean z) {
        n_onBackStackChangeCommitted(fragment, z);
    }

    @Override // androidx.fragment.app.FragmentManager.OnBackStackChangedListener
    public void onBackStackChangeProgressed(BackEventCompat backEventCompat) {
        n_onBackStackChangeProgressed(backEventCompat);
    }

    @Override // androidx.fragment.app.FragmentManager.OnBackStackChangedListener
    public void onBackStackChangeStarted(Fragment fragment, boolean z) {
        n_onBackStackChangeStarted(fragment, z);
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
