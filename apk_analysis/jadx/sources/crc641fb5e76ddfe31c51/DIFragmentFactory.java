package crc641fb5e76ddfe31c51;

import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentFactory;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class DIFragmentFactory extends FragmentFactory implements IGCUserPeer {
    private ArrayList refList;

    private native Fragment n_instantiate(ClassLoader classLoader, String str);

    public DIFragmentFactory() {
        if (getClass() == DIFragmentFactory.class) {
            TypeManager.Activate("Auchan.Android.DependencyInjection.DIFragmentFactory, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    @Override // androidx.fragment.app.FragmentFactory
    public Fragment instantiate(ClassLoader classLoader, String str) {
        return n_instantiate(classLoader, str);
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
