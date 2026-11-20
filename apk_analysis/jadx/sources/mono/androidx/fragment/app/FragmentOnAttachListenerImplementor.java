package mono.androidx.fragment.app;

import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentManager;
import androidx.fragment.app.FragmentOnAttachListener;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class FragmentOnAttachListenerImplementor implements IGCUserPeer, FragmentOnAttachListener {
    private ArrayList refList;

    private native void n_onAttachFragment(FragmentManager fragmentManager, Fragment fragment);

    public FragmentOnAttachListenerImplementor() {
        if (getClass() == FragmentOnAttachListenerImplementor.class) {
            TypeManager.Activate("AndroidX.Fragment.App.IFragmentOnAttachListenerImplementor, Xamarin.AndroidX.Fragment", "", this, new Object[0]);
        }
    }

    @Override // androidx.fragment.app.FragmentOnAttachListener
    public void onAttachFragment(FragmentManager fragmentManager, Fragment fragment) {
        n_onAttachFragment(fragmentManager, fragment);
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
