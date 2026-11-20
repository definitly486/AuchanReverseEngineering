package crc64f03248cb510113f2;

import android.content.Context;
import android.util.AttributeSet;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.Runtime;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public abstract class BaseCustomView_1 extends BaseCustomView implements IGCUserPeer {
    public static final String __md_methods = "";
    private ArrayList refList;

    static {
        Runtime.register("Auchan.Android.Base.BaseCustomView`1, Auchan.Android.Net", BaseCustomView_1.class, "");
    }

    public BaseCustomView_1(Context context, AttributeSet attributeSet, int i, int i2) {
        super(context, attributeSet, i, i2);
        if (getClass() == BaseCustomView_1.class) {
            TypeManager.Activate("Auchan.Android.Base.BaseCustomView`1, Auchan.Android.Net", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, System.Private.CoreLib:System.Int32, System.Private.CoreLib", this, new Object[]{context, attributeSet, Integer.valueOf(i), Integer.valueOf(i2)});
        }
    }

    public BaseCustomView_1(Context context, AttributeSet attributeSet, int i) {
        super(context, attributeSet, i);
        if (getClass() == BaseCustomView_1.class) {
            TypeManager.Activate("Auchan.Android.Base.BaseCustomView`1, Auchan.Android.Net", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, System.Private.CoreLib", this, new Object[]{context, attributeSet, Integer.valueOf(i)});
        }
    }

    public BaseCustomView_1(Context context, AttributeSet attributeSet) {
        super(context, attributeSet);
        if (getClass() == BaseCustomView_1.class) {
            TypeManager.Activate("Auchan.Android.Base.BaseCustomView`1, Auchan.Android.Net", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new Object[]{context, attributeSet});
        }
    }

    public BaseCustomView_1(Context context) {
        super(context);
        if (getClass() == BaseCustomView_1.class) {
            TypeManager.Activate("Auchan.Android.Base.BaseCustomView`1, Auchan.Android.Net", "Android.Content.Context, Mono.Android", this, new Object[]{context});
        }
    }

    @Override // crc64f03248cb510113f2.BaseCustomView, mono.android.IGCUserPeer
    public void monodroidAddReference(Object obj) {
        if (this.refList == null) {
            this.refList = new ArrayList();
        }
        this.refList.add(obj);
    }

    @Override // crc64f03248cb510113f2.BaseCustomView, mono.android.IGCUserPeer
    public void monodroidClearReferences() {
        ArrayList arrayList = this.refList;
        if (arrayList != null) {
            arrayList.clear();
        }
    }
}
