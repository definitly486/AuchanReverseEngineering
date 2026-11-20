package crc64f03248cb510113f2;

import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import androidx.fragment.app.DialogFragment;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public abstract class BaseDialogFragment extends DialogFragment implements IGCUserPeer {
    private ArrayList refList;

    private native int n_getTheme();

    private native boolean n_isCancelable();

    private native View n_onCreateView(LayoutInflater layoutInflater, ViewGroup viewGroup, Bundle bundle);

    private native void n_onViewCreated(View view, Bundle bundle);

    public BaseDialogFragment() {
        if (getClass() == BaseDialogFragment.class) {
            TypeManager.Activate("Auchan.Android.Base.BaseDialogFragment, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    public BaseDialogFragment(int i) {
        super(i);
        if (getClass() == BaseDialogFragment.class) {
            TypeManager.Activate("Auchan.Android.Base.BaseDialogFragment, Auchan.Android.Net", "System.Int32, System.Private.CoreLib", this, new Object[]{Integer.valueOf(i)});
        }
    }

    @Override // androidx.fragment.app.DialogFragment
    public int getTheme() {
        return n_getTheme();
    }

    @Override // androidx.fragment.app.DialogFragment
    public boolean isCancelable() {
        return n_isCancelable();
    }

    @Override // androidx.fragment.app.Fragment
    public View onCreateView(LayoutInflater layoutInflater, ViewGroup viewGroup, Bundle bundle) {
        return n_onCreateView(layoutInflater, viewGroup, bundle);
    }

    @Override // androidx.fragment.app.Fragment
    public void onViewCreated(View view, Bundle bundle) {
        n_onViewCreated(view, bundle);
    }

    public void monodroidAddReference(Object obj) {
        if (this.refList == null) {
            this.refList = new ArrayList();
        }
        this.refList.add(obj);
    }

    public void monodroidClearReferences() {
        ArrayList arrayList = this.refList;
        if (arrayList != null) {
            arrayList.clear();
        }
    }
}
