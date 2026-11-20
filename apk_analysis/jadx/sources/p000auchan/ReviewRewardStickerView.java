package p000auchan;

import android.content.Context;
import android.util.AttributeSet;
import androidx.appcompat.widget.AppCompatTextView;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.Runtime;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes.dex */
public class ReviewRewardStickerView extends AppCompatTextView implements IGCUserPeer {
    public static final String __md_methods = "";
    private ArrayList refList;

    static {
        Runtime.register("Auchan.Android.Controls.ReviewRewardStickerView, Auchan.Android.Net", ReviewRewardStickerView.class, "");
    }

    public ReviewRewardStickerView(Context context) {
        super(context);
        if (getClass() == ReviewRewardStickerView.class) {
            TypeManager.Activate("Auchan.Android.Controls.ReviewRewardStickerView, Auchan.Android.Net", "Android.Content.Context, Mono.Android", this, new Object[]{context});
        }
    }

    public ReviewRewardStickerView(Context context, AttributeSet attributeSet) {
        super(context, attributeSet);
        if (getClass() == ReviewRewardStickerView.class) {
            TypeManager.Activate("Auchan.Android.Controls.ReviewRewardStickerView, Auchan.Android.Net", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new Object[]{context, attributeSet});
        }
    }

    public ReviewRewardStickerView(Context context, AttributeSet attributeSet, int i) {
        super(context, attributeSet, i);
        if (getClass() == ReviewRewardStickerView.class) {
            TypeManager.Activate("Auchan.Android.Controls.ReviewRewardStickerView, Auchan.Android.Net", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, System.Private.CoreLib", this, new Object[]{context, attributeSet, Integer.valueOf(i)});
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
