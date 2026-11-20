package crc64f03248cb510113f2;

import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public abstract class ScrollableBottomSheet extends BaseBottomSheetDialogFragment implements IGCUserPeer {
    private ArrayList refList;

    private native View n_onCreateView(LayoutInflater layoutInflater, ViewGroup viewGroup, Bundle bundle);

    public ScrollableBottomSheet() {
        if (getClass() == ScrollableBottomSheet.class) {
            TypeManager.Activate("Auchan.Android.Base.ScrollableBottomSheet, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    public ScrollableBottomSheet(int i) {
        super(i);
        if (getClass() == ScrollableBottomSheet.class) {
            TypeManager.Activate("Auchan.Android.Base.ScrollableBottomSheet, Auchan.Android.Net", "System.Int32, System.Private.CoreLib", this, new Object[]{Integer.valueOf(i)});
        }
    }

    @Override // crc64f03248cb510113f2.BaseBottomSheetDialogFragment, androidx.fragment.app.Fragment
    public View onCreateView(LayoutInflater layoutInflater, ViewGroup viewGroup, Bundle bundle) {
        return n_onCreateView(layoutInflater, viewGroup, bundle);
    }

    @Override // crc64f03248cb510113f2.BaseBottomSheetDialogFragment, mono.android.IGCUserPeer
    public void monodroidAddReference(Object obj) {
        if (this.refList == null) {
            this.refList = new ArrayList();
        }
        this.refList.add(obj);
    }

    @Override // crc64f03248cb510113f2.BaseBottomSheetDialogFragment, mono.android.IGCUserPeer
    public void monodroidClearReferences() {
        ArrayList arrayList = this.refList;
        if (arrayList != null) {
            arrayList.clear();
        }
    }
}
