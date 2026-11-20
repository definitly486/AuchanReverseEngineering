package crc641036e980d349e100;

import android.view.View;
import androidx.core.view.OnApplyWindowInsetsListener;
import androidx.core.view.WindowInsetsCompat;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class AddressMapFragment_InsetListener implements IGCUserPeer, OnApplyWindowInsetsListener {
    private ArrayList refList;

    private native WindowInsetsCompat n_onApplyWindowInsets(View view, WindowInsetsCompat windowInsetsCompat);

    public AddressMapFragment_InsetListener() {
        if (getClass() == AddressMapFragment_InsetListener.class) {
            TypeManager.Activate("Auchan.Android.Ecom.AddressStoreSelection.AddressMapFragment+InsetListener, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    public AddressMapFragment_InsetListener(AddressMapFragment addressMapFragment) {
        if (getClass() == AddressMapFragment_InsetListener.class) {
            TypeManager.Activate("Auchan.Android.Ecom.AddressStoreSelection.AddressMapFragment+InsetListener, Auchan.Android.Net", "Auchan.Android.Ecom.AddressStoreSelection.AddressMapFragment, Auchan.Android.Net", this, new Object[]{addressMapFragment});
        }
    }

    @Override // androidx.core.view.OnApplyWindowInsetsListener
    public WindowInsetsCompat onApplyWindowInsets(View view, WindowInsetsCompat windowInsetsCompat) {
        return n_onApplyWindowInsets(view, windowInsetsCompat);
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
