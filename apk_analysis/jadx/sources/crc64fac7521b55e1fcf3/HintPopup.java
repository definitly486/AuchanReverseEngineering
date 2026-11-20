package crc64fac7521b55e1fcf3;

import android.content.Context;
import android.util.AttributeSet;
import android.view.View;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.Runtime;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class HintPopup extends HintPopupBase implements IGCUserPeer {
    public static final String __md_methods = "";
    private ArrayList refList;

    static {
        Runtime.register("Auchan.Android.Controls.HintPopup, Auchan.Android.Net", HintPopup.class, "");
    }

    public HintPopup(Context context, AttributeSet attributeSet, int i) {
        super(context, attributeSet, i);
        if (getClass() == HintPopup.class) {
            TypeManager.Activate("Auchan.Android.Controls.HintPopup, Auchan.Android.Net", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, System.Private.CoreLib", this, new Object[]{context, attributeSet, Integer.valueOf(i)});
        }
    }

    public HintPopup(Context context, AttributeSet attributeSet) {
        super(context, attributeSet);
        if (getClass() == HintPopup.class) {
            TypeManager.Activate("Auchan.Android.Controls.HintPopup, Auchan.Android.Net", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new Object[]{context, attributeSet});
        }
    }

    public HintPopup(View view, int i, int i2) {
        super(view, i, i2);
        if (getClass() == HintPopup.class) {
            TypeManager.Activate("Auchan.Android.Controls.HintPopup, Auchan.Android.Net", "Android.Views.View, Mono.Android:System.Int32, System.Private.CoreLib:System.Int32, System.Private.CoreLib", this, new Object[]{view, Integer.valueOf(i), Integer.valueOf(i2)});
        }
    }

    public HintPopup(int i, int i2) {
        super(i, i2);
        if (getClass() == HintPopup.class) {
            TypeManager.Activate("Auchan.Android.Controls.HintPopup, Auchan.Android.Net", "System.Int32, System.Private.CoreLib:System.Int32, System.Private.CoreLib", this, new Object[]{Integer.valueOf(i), Integer.valueOf(i2)});
        }
    }

    @Override // crc64fac7521b55e1fcf3.HintPopupBase, mono.android.IGCUserPeer
    public void monodroidAddReference(Object obj) {
        if (this.refList == null) {
            this.refList = new ArrayList();
        }
        this.refList.add(obj);
    }

    @Override // crc64fac7521b55e1fcf3.HintPopupBase, mono.android.IGCUserPeer
    public void monodroidClearReferences() {
        ArrayList arrayList = this.refList;
        if (arrayList != null) {
            arrayList.clear();
        }
    }
}
