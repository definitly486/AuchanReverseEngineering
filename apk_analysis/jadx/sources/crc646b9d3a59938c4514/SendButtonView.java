package crc646b9d3a59938c4514;

import android.content.Context;
import android.util.AttributeSet;
import crc64d6a2187865a565e5.LinearLayoutWidgetBase;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.Runtime;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class SendButtonView extends LinearLayoutWidgetBase implements IGCUserPeer {
    public static final String __md_methods = "";
    private ArrayList refList;

    static {
        Runtime.register("Auchan.Android.DynamicFeedback.Controls.SendButtonView, Auchan.Android.Net", SendButtonView.class, "");
    }

    public SendButtonView(Context context, AttributeSet attributeSet, int i, int i2) {
        super(context, attributeSet, i, i2);
        if (getClass() == SendButtonView.class) {
            TypeManager.Activate("Auchan.Android.DynamicFeedback.Controls.SendButtonView, Auchan.Android.Net", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, System.Private.CoreLib:System.Int32, System.Private.CoreLib", this, new Object[]{context, attributeSet, Integer.valueOf(i), Integer.valueOf(i2)});
        }
    }

    public SendButtonView(Context context, AttributeSet attributeSet, int i) {
        super(context, attributeSet, i);
        if (getClass() == SendButtonView.class) {
            TypeManager.Activate("Auchan.Android.DynamicFeedback.Controls.SendButtonView, Auchan.Android.Net", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, System.Private.CoreLib", this, new Object[]{context, attributeSet, Integer.valueOf(i)});
        }
    }

    public SendButtonView(Context context, AttributeSet attributeSet) {
        super(context, attributeSet);
        if (getClass() == SendButtonView.class) {
            TypeManager.Activate("Auchan.Android.DynamicFeedback.Controls.SendButtonView, Auchan.Android.Net", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new Object[]{context, attributeSet});
        }
    }

    public SendButtonView(Context context) {
        super(context);
        if (getClass() == SendButtonView.class) {
            TypeManager.Activate("Auchan.Android.DynamicFeedback.Controls.SendButtonView, Auchan.Android.Net", "Android.Content.Context, Mono.Android", this, new Object[]{context});
        }
    }

    @Override // crc64d6a2187865a565e5.LinearLayoutWidgetBase, mono.android.IGCUserPeer
    public void monodroidAddReference(Object obj) {
        if (this.refList == null) {
            this.refList = new ArrayList();
        }
        this.refList.add(obj);
    }

    @Override // crc64d6a2187865a565e5.LinearLayoutWidgetBase, mono.android.IGCUserPeer
    public void monodroidClearReferences() {
        ArrayList arrayList = this.refList;
        if (arrayList != null) {
            arrayList.clear();
        }
    }
}
