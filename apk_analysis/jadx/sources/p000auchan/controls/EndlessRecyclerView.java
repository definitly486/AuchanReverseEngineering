package p000auchan.controls;

import android.content.Context;
import android.util.AttributeSet;
import androidx.recyclerview.widget.RecyclerView;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.Runtime;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes.dex */
public class EndlessRecyclerView extends RecyclerView implements IGCUserPeer {
    public static final String __md_methods = "";
    private ArrayList refList;

    static {
        Runtime.register("Auchan.Android.Controls.EndlessRecyclerView, Auchan.Android.Net", EndlessRecyclerView.class, "");
    }

    public EndlessRecyclerView(Context context) {
        super(context);
        if (getClass() == EndlessRecyclerView.class) {
            TypeManager.Activate("Auchan.Android.Controls.EndlessRecyclerView, Auchan.Android.Net", "Android.Content.Context, Mono.Android", this, new Object[]{context});
        }
    }

    public EndlessRecyclerView(Context context, AttributeSet attributeSet) {
        super(context, attributeSet);
        if (getClass() == EndlessRecyclerView.class) {
            TypeManager.Activate("Auchan.Android.Controls.EndlessRecyclerView, Auchan.Android.Net", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new Object[]{context, attributeSet});
        }
    }

    public EndlessRecyclerView(Context context, AttributeSet attributeSet, int i) {
        super(context, attributeSet, i);
        if (getClass() == EndlessRecyclerView.class) {
            TypeManager.Activate("Auchan.Android.Controls.EndlessRecyclerView, Auchan.Android.Net", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, System.Private.CoreLib", this, new Object[]{context, attributeSet, Integer.valueOf(i)});
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
