package crc64d6a2187865a565e5;

import android.content.Context;
import android.util.AttributeSet;
import android.widget.LinearLayout;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.Runtime;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class LinearLayoutWidgetBase extends LinearLayout implements IGCUserPeer {
    public static final String __md_methods = "";
    private ArrayList refList;

    static {
        Runtime.register("Auchan.Android.Base.WidgetBases.LinearLayoutWidgetBase, Auchan.Android.Net", LinearLayoutWidgetBase.class, "");
    }

    public LinearLayoutWidgetBase(Context context, AttributeSet attributeSet, int i, int i2) {
        super(context, attributeSet, i, i2);
        if (getClass() == LinearLayoutWidgetBase.class) {
            TypeManager.Activate("Auchan.Android.Base.WidgetBases.LinearLayoutWidgetBase, Auchan.Android.Net", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, System.Private.CoreLib:System.Int32, System.Private.CoreLib", this, new Object[]{context, attributeSet, Integer.valueOf(i), Integer.valueOf(i2)});
        }
    }

    public LinearLayoutWidgetBase(Context context, AttributeSet attributeSet, int i) {
        super(context, attributeSet, i);
        if (getClass() == LinearLayoutWidgetBase.class) {
            TypeManager.Activate("Auchan.Android.Base.WidgetBases.LinearLayoutWidgetBase, Auchan.Android.Net", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, System.Private.CoreLib", this, new Object[]{context, attributeSet, Integer.valueOf(i)});
        }
    }

    public LinearLayoutWidgetBase(Context context, AttributeSet attributeSet) {
        super(context, attributeSet);
        if (getClass() == LinearLayoutWidgetBase.class) {
            TypeManager.Activate("Auchan.Android.Base.WidgetBases.LinearLayoutWidgetBase, Auchan.Android.Net", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new Object[]{context, attributeSet});
        }
    }

    public LinearLayoutWidgetBase(Context context) {
        super(context);
        if (getClass() == LinearLayoutWidgetBase.class) {
            TypeManager.Activate("Auchan.Android.Base.WidgetBases.LinearLayoutWidgetBase, Auchan.Android.Net", "Android.Content.Context, Mono.Android", this, new Object[]{context});
        }
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
