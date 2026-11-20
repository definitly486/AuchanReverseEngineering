package crc6459efab142bb48047;

import android.text.InputFilter;
import android.text.Spanned;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class SearchSpaceInputFilter implements IGCUserPeer, InputFilter {
    private ArrayList refList;

    private native CharSequence n_filter(CharSequence charSequence, int i, int i2, Spanned spanned, int i3, int i4);

    public SearchSpaceInputFilter() {
        if (getClass() == SearchSpaceInputFilter.class) {
            TypeManager.Activate("Auchan.Android.Common.UiUtils.SearchSpaceInputFilter, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    @Override // android.text.InputFilter
    public CharSequence filter(CharSequence charSequence, int i, int i2, Spanned spanned, int i3, int i4) {
        return n_filter(charSequence, i, i2, spanned, i3, i4);
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
