package p000auchan.p001Android.Feedback;

import android.content.Context;
import android.util.AttributeSet;
import crc64d6a2187865a565e5.ConstraintLayoutWidgetBase;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.Runtime;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes.dex */
public class layout_drop_down_list extends ConstraintLayoutWidgetBase implements IGCUserPeer {
    public static final String __md_methods = "";
    private ArrayList refList;

    static {
        Runtime.register("Auchan.Android.DynamicFeedback.Controls.ListSelectionField, Auchan.Android.Net", layout_drop_down_list.class, "");
    }

    public layout_drop_down_list(Context context) {
        super(context);
        if (getClass() == layout_drop_down_list.class) {
            TypeManager.Activate("Auchan.Android.DynamicFeedback.Controls.ListSelectionField, Auchan.Android.Net", "Android.Content.Context, Mono.Android", this, new Object[]{context});
        }
    }

    public layout_drop_down_list(Context context, AttributeSet attributeSet) {
        super(context, attributeSet);
        if (getClass() == layout_drop_down_list.class) {
            TypeManager.Activate("Auchan.Android.DynamicFeedback.Controls.ListSelectionField, Auchan.Android.Net", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new Object[]{context, attributeSet});
        }
    }

    public layout_drop_down_list(Context context, AttributeSet attributeSet, int i) {
        super(context, attributeSet, i);
        if (getClass() == layout_drop_down_list.class) {
            TypeManager.Activate("Auchan.Android.DynamicFeedback.Controls.ListSelectionField, Auchan.Android.Net", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, System.Private.CoreLib", this, new Object[]{context, attributeSet, Integer.valueOf(i)});
        }
    }

    public layout_drop_down_list(Context context, AttributeSet attributeSet, int i, int i2) {
        super(context, attributeSet, i, i2);
        if (getClass() == layout_drop_down_list.class) {
            TypeManager.Activate("Auchan.Android.DynamicFeedback.Controls.ListSelectionField, Auchan.Android.Net", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, System.Private.CoreLib:System.Int32, System.Private.CoreLib", this, new Object[]{context, attributeSet, Integer.valueOf(i), Integer.valueOf(i2)});
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
