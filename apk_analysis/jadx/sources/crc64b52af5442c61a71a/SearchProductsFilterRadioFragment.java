package crc64b52af5442c61a71a;

import android.app.Dialog;
import android.os.Bundle;
import android.view.View;
import crc64f03248cb510113f2.BaseDialogFragment_1;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class SearchProductsFilterRadioFragment extends BaseDialogFragment_1 implements IGCUserPeer {
    private ArrayList refList;

    private native int n_getTheme();

    private native Dialog n_onCreateDialog(Bundle bundle);

    private native void n_onViewCreated(View view, Bundle bundle);

    public SearchProductsFilterRadioFragment() {
        if (getClass() == SearchProductsFilterRadioFragment.class) {
            TypeManager.Activate("Auchan.Android.Catalog.Search.SearchProductsFilterRadioFragment, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    public SearchProductsFilterRadioFragment(int i) {
        super(i);
        if (getClass() == SearchProductsFilterRadioFragment.class) {
            TypeManager.Activate("Auchan.Android.Catalog.Search.SearchProductsFilterRadioFragment, Auchan.Android.Net", "System.Int32, System.Private.CoreLib", this, new Object[]{Integer.valueOf(i)});
        }
    }

    @Override // crc64f03248cb510113f2.BaseDialogFragment, androidx.fragment.app.DialogFragment
    public int getTheme() {
        return n_getTheme();
    }

    @Override // androidx.fragment.app.DialogFragment
    public Dialog onCreateDialog(Bundle bundle) {
        return n_onCreateDialog(bundle);
    }

    @Override // crc64f03248cb510113f2.BaseDialogFragment, androidx.fragment.app.Fragment
    public void onViewCreated(View view, Bundle bundle) {
        n_onViewCreated(view, bundle);
    }

    @Override // crc64f03248cb510113f2.BaseDialogFragment_1, crc64f03248cb510113f2.BaseDialogFragment, mono.android.IGCUserPeer
    public void monodroidAddReference(Object obj) {
        if (this.refList == null) {
            this.refList = new ArrayList();
        }
        this.refList.add(obj);
    }

    @Override // crc64f03248cb510113f2.BaseDialogFragment_1, crc64f03248cb510113f2.BaseDialogFragment, mono.android.IGCUserPeer
    public void monodroidClearReferences() {
        ArrayList arrayList = this.refList;
        if (arrayList != null) {
            arrayList.clear();
        }
    }
}
