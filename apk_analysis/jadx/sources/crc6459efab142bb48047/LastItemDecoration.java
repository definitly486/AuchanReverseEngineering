package crc6459efab142bb48047;

import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.Runtime;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class LastItemDecoration extends GridSpacesItemDecoration3 implements IGCUserPeer {
    public static final String __md_methods = "";
    private ArrayList refList;

    static {
        Runtime.register("Auchan.Android.Common.UiUtils.LastItemDecoration, Auchan.Android.Net", LastItemDecoration.class, "");
    }

    public LastItemDecoration() {
        if (getClass() == LastItemDecoration.class) {
            TypeManager.Activate("Auchan.Android.Common.UiUtils.LastItemDecoration, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    @Override // crc6459efab142bb48047.GridSpacesItemDecoration3, mono.android.IGCUserPeer
    public void monodroidAddReference(Object obj) {
        if (this.refList == null) {
            this.refList = new ArrayList();
        }
        this.refList.add(obj);
    }

    @Override // crc6459efab142bb48047.GridSpacesItemDecoration3, mono.android.IGCUserPeer
    public void monodroidClearReferences() {
        ArrayList arrayList = this.refList;
        if (arrayList != null) {
            arrayList.clear();
        }
    }
}
