package crc6459efab142bb48047;

import android.content.Context;
import android.view.View;
import android.view.ViewGroup;
import com.google.android.material.snackbar.BaseTransientBottomBar;
import com.google.android.material.snackbar.ContentViewCallback;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class AuchanSnackbar extends BaseTransientBottomBar implements IGCUserPeer {
    private ArrayList refList;

    private native BaseTransientBottomBar n_setDuration(int i);

    public AuchanSnackbar(Context context, ViewGroup viewGroup, View view, ContentViewCallback contentViewCallback) {
        super(context, viewGroup, view, contentViewCallback);
        if (getClass() == AuchanSnackbar.class) {
            TypeManager.Activate("Auchan.Android.Common.UiUtils.AuchanSnackbar, Auchan.Android.Net", "Android.Content.Context, Mono.Android:Android.Views.ViewGroup, Mono.Android:Android.Views.View, Mono.Android:Google.Android.Material.Snackbar.IContentViewCallback, Xamarin.Google.Android.Material", this, new Object[]{context, viewGroup, view, contentViewCallback});
        }
    }

    public AuchanSnackbar(ViewGroup viewGroup, View view, ContentViewCallback contentViewCallback) {
        super(viewGroup, view, contentViewCallback);
        if (getClass() == AuchanSnackbar.class) {
            TypeManager.Activate("Auchan.Android.Common.UiUtils.AuchanSnackbar, Auchan.Android.Net", "Android.Views.ViewGroup, Mono.Android:Android.Views.View, Mono.Android:Google.Android.Material.Snackbar.IContentViewCallback, Xamarin.Google.Android.Material", this, new Object[]{viewGroup, view, contentViewCallback});
        }
    }

    @Override // com.google.android.material.snackbar.BaseTransientBottomBar
    public BaseTransientBottomBar setDuration(int i) {
        return n_setDuration(i);
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
