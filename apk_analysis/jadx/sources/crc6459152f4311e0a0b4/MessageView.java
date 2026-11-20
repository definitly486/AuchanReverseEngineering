package crc6459152f4311e0a0b4;

import android.content.Context;
import android.util.AttributeSet;
import androidx.constraintlayout.widget.ConstraintLayout;
import com.bumptech.glide.load.DataSource;
import com.bumptech.glide.load.engine.GlideException;
import com.bumptech.glide.request.RequestListener;
import com.bumptech.glide.request.target.Target;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class MessageView extends ConstraintLayout implements IGCUserPeer, RequestListener {
    private ArrayList refList;

    private native boolean n_onLoadFailed(GlideException glideException, Object obj, Target target, boolean z);

    private native boolean n_onResourceReady(Object obj, Object obj2, Target target, DataSource dataSource, boolean z);

    public MessageView(Context context) {
        super(context);
        if (getClass() == MessageView.class) {
            TypeManager.Activate("Auchan.Android.SupportChat.Views.MessageView, Auchan.Android.Net", "Android.Content.Context, Mono.Android", this, new Object[]{context});
        }
    }

    public MessageView(Context context, AttributeSet attributeSet) {
        super(context, attributeSet);
        if (getClass() == MessageView.class) {
            TypeManager.Activate("Auchan.Android.SupportChat.Views.MessageView, Auchan.Android.Net", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new Object[]{context, attributeSet});
        }
    }

    public MessageView(Context context, AttributeSet attributeSet, int i) {
        super(context, attributeSet, i);
        if (getClass() == MessageView.class) {
            TypeManager.Activate("Auchan.Android.SupportChat.Views.MessageView, Auchan.Android.Net", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, System.Private.CoreLib", this, new Object[]{context, attributeSet, Integer.valueOf(i)});
        }
    }

    public MessageView(Context context, AttributeSet attributeSet, int i, int i2) {
        super(context, attributeSet, i, i2);
        if (getClass() == MessageView.class) {
            TypeManager.Activate("Auchan.Android.SupportChat.Views.MessageView, Auchan.Android.Net", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, System.Private.CoreLib:System.Int32, System.Private.CoreLib", this, new Object[]{context, attributeSet, Integer.valueOf(i), Integer.valueOf(i2)});
        }
    }

    @Override // com.bumptech.glide.request.RequestListener
    public boolean onLoadFailed(GlideException glideException, Object obj, Target target, boolean z) {
        return n_onLoadFailed(glideException, obj, target, z);
    }

    @Override // com.bumptech.glide.request.RequestListener
    public boolean onResourceReady(Object obj, Object obj2, Target target, DataSource dataSource, boolean z) {
        return n_onResourceReady(obj, obj2, target, dataSource, z);
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
