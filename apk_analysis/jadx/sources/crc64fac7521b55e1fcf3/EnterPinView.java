package crc64fac7521b55e1fcf3;

import android.content.Context;
import android.util.AttributeSet;
import androidx.gridlayout.widget.GridLayout;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.Runtime;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class EnterPinView extends GridLayout implements IGCUserPeer {
    public static final String __md_methods = "";
    private ArrayList refList;

    static {
        Runtime.register("Auchan.Android.Controls.EnterPinView, Auchan.Android.Net", EnterPinView.class, "");
    }

    public EnterPinView(Context context) {
        super(context);
        if (getClass() == EnterPinView.class) {
            TypeManager.Activate("Auchan.Android.Controls.EnterPinView, Auchan.Android.Net", "Android.Content.Context, Mono.Android", this, new Object[]{context});
        }
    }

    public EnterPinView(Context context, AttributeSet attributeSet) {
        super(context, attributeSet);
        if (getClass() == EnterPinView.class) {
            TypeManager.Activate("Auchan.Android.Controls.EnterPinView, Auchan.Android.Net", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new Object[]{context, attributeSet});
        }
    }

    public EnterPinView(Context context, AttributeSet attributeSet, int i) {
        super(context, attributeSet, i);
        if (getClass() == EnterPinView.class) {
            TypeManager.Activate("Auchan.Android.Controls.EnterPinView, Auchan.Android.Net", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, System.Private.CoreLib", this, new Object[]{context, attributeSet, Integer.valueOf(i)});
        }
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
