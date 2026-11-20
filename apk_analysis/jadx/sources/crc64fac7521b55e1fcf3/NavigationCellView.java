package crc64fac7521b55e1fcf3;

import android.content.Context;
import android.util.AttributeSet;
import android.widget.LinearLayout;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class NavigationCellView extends LinearLayout implements IGCUserPeer {
    private ArrayList refList;

    private native void n_onFinishInflate();

    public NavigationCellView(Context context, AttributeSet attributeSet, int i, int i2) {
        super(context, attributeSet, i, i2);
        if (getClass() == NavigationCellView.class) {
            TypeManager.Activate("Auchan.Android.Controls.NavigationCellView, Auchan.Android.Net", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, System.Private.CoreLib:System.Int32, System.Private.CoreLib", this, new Object[]{context, attributeSet, Integer.valueOf(i), Integer.valueOf(i2)});
        }
    }

    public NavigationCellView(Context context, AttributeSet attributeSet, int i) {
        super(context, attributeSet, i);
        if (getClass() == NavigationCellView.class) {
            TypeManager.Activate("Auchan.Android.Controls.NavigationCellView, Auchan.Android.Net", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, System.Private.CoreLib", this, new Object[]{context, attributeSet, Integer.valueOf(i)});
        }
    }

    public NavigationCellView(Context context, AttributeSet attributeSet) {
        super(context, attributeSet);
        if (getClass() == NavigationCellView.class) {
            TypeManager.Activate("Auchan.Android.Controls.NavigationCellView, Auchan.Android.Net", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new Object[]{context, attributeSet});
        }
    }

    public NavigationCellView(Context context) {
        super(context);
        if (getClass() == NavigationCellView.class) {
            TypeManager.Activate("Auchan.Android.Controls.NavigationCellView, Auchan.Android.Net", "Android.Content.Context, Mono.Android", this, new Object[]{context});
        }
    }

    @Override // android.view.View
    public void onFinishInflate() {
        n_onFinishInflate();
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
