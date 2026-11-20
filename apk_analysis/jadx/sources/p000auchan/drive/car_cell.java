package p000auchan.drive;

import android.content.Context;
import android.util.AttributeSet;
import androidx.constraintlayout.widget.ConstraintLayout;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.Runtime;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes.dex */
public class car_cell extends ConstraintLayout implements IGCUserPeer {
    public static final String __md_methods = "";
    private ArrayList refList;

    static {
        Runtime.register("Auchan.Android.Drive.UserCarCell, Auchan.Android.Net", car_cell.class, "");
    }

    public car_cell(Context context) {
        super(context);
        if (getClass() == car_cell.class) {
            TypeManager.Activate("Auchan.Android.Drive.UserCarCell, Auchan.Android.Net", "Android.Content.Context, Mono.Android", this, new Object[]{context});
        }
    }

    public car_cell(Context context, AttributeSet attributeSet) {
        super(context, attributeSet);
        if (getClass() == car_cell.class) {
            TypeManager.Activate("Auchan.Android.Drive.UserCarCell, Auchan.Android.Net", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new Object[]{context, attributeSet});
        }
    }

    public car_cell(Context context, AttributeSet attributeSet, int i) {
        super(context, attributeSet, i);
        if (getClass() == car_cell.class) {
            TypeManager.Activate("Auchan.Android.Drive.UserCarCell, Auchan.Android.Net", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, System.Private.CoreLib", this, new Object[]{context, attributeSet, Integer.valueOf(i)});
        }
    }

    public car_cell(Context context, AttributeSet attributeSet, int i, int i2) {
        super(context, attributeSet, i, i2);
        if (getClass() == car_cell.class) {
            TypeManager.Activate("Auchan.Android.Drive.UserCarCell, Auchan.Android.Net", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, System.Private.CoreLib:System.Int32, System.Private.CoreLib", this, new Object[]{context, attributeSet, Integer.valueOf(i), Integer.valueOf(i2)});
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
