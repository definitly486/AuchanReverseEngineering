package crc646e7dac6304ae8ce3;

import android.content.Context;
import android.util.AttributeSet;
import crc64d6a2187865a565e5.ConstraintLayoutWidgetBase;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.Runtime;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class StreamListItem extends ConstraintLayoutWidgetBase implements IGCUserPeer {
    public static final String __md_methods = "";
    private ArrayList refList;

    static {
        Runtime.register("Auchan.Android.Streams.StreamListItem, Auchan.Android.Net", StreamListItem.class, "");
    }

    public StreamListItem(Context context) {
        super(context);
        if (getClass() == StreamListItem.class) {
            TypeManager.Activate("Auchan.Android.Streams.StreamListItem, Auchan.Android.Net", "Android.Content.Context, Mono.Android", this, new Object[]{context});
        }
    }

    public StreamListItem(Context context, AttributeSet attributeSet) {
        super(context, attributeSet);
        if (getClass() == StreamListItem.class) {
            TypeManager.Activate("Auchan.Android.Streams.StreamListItem, Auchan.Android.Net", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new Object[]{context, attributeSet});
        }
    }

    public StreamListItem(Context context, AttributeSet attributeSet, int i) {
        super(context, attributeSet, i);
        if (getClass() == StreamListItem.class) {
            TypeManager.Activate("Auchan.Android.Streams.StreamListItem, Auchan.Android.Net", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, System.Private.CoreLib", this, new Object[]{context, attributeSet, Integer.valueOf(i)});
        }
    }

    public StreamListItem(Context context, AttributeSet attributeSet, int i, int i2) {
        super(context, attributeSet, i, i2);
        if (getClass() == StreamListItem.class) {
            TypeManager.Activate("Auchan.Android.Streams.StreamListItem, Auchan.Android.Net", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, System.Private.CoreLib:System.Int32, System.Private.CoreLib", this, new Object[]{context, attributeSet, Integer.valueOf(i), Integer.valueOf(i2)});
        }
    }

    @Override // crc64d6a2187865a565e5.ConstraintLayoutWidgetBase, mono.android.IGCUserPeer
    public void monodroidAddReference(Object obj) {
        if (this.refList == null) {
            this.refList = new ArrayList();
        }
        this.refList.add(obj);
    }

    @Override // crc64d6a2187865a565e5.ConstraintLayoutWidgetBase, mono.android.IGCUserPeer
    public void monodroidClearReferences() {
        ArrayList arrayList = this.refList;
        if (arrayList != null) {
            arrayList.clear();
        }
    }
}
