package crc64dce6dab73187a5a5;

import android.content.Context;
import android.util.AttributeSet;
import android.widget.ImageView;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.Runtime;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class FavoritesButtonView extends ImageView implements IGCUserPeer {
    public static final String __md_methods = "";
    private ArrayList refList;

    static {
        Runtime.register("Auchan.Android.Catalog.Common.FavoritesButtonView, Auchan.Android.Net", FavoritesButtonView.class, "");
    }

    public FavoritesButtonView(Context context, AttributeSet attributeSet, int i, int i2) {
        super(context, attributeSet, i, i2);
        if (getClass() == FavoritesButtonView.class) {
            TypeManager.Activate("Auchan.Android.Catalog.Common.FavoritesButtonView, Auchan.Android.Net", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, System.Private.CoreLib:System.Int32, System.Private.CoreLib", this, new Object[]{context, attributeSet, Integer.valueOf(i), Integer.valueOf(i2)});
        }
    }

    public FavoritesButtonView(Context context, AttributeSet attributeSet, int i) {
        super(context, attributeSet, i);
        if (getClass() == FavoritesButtonView.class) {
            TypeManager.Activate("Auchan.Android.Catalog.Common.FavoritesButtonView, Auchan.Android.Net", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, System.Private.CoreLib", this, new Object[]{context, attributeSet, Integer.valueOf(i)});
        }
    }

    public FavoritesButtonView(Context context, AttributeSet attributeSet) {
        super(context, attributeSet);
        if (getClass() == FavoritesButtonView.class) {
            TypeManager.Activate("Auchan.Android.Catalog.Common.FavoritesButtonView, Auchan.Android.Net", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new Object[]{context, attributeSet});
        }
    }

    public FavoritesButtonView(Context context) {
        super(context);
        if (getClass() == FavoritesButtonView.class) {
            TypeManager.Activate("Auchan.Android.Catalog.Common.FavoritesButtonView, Auchan.Android.Net", "Android.Content.Context, Mono.Android", this, new Object[]{context});
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
