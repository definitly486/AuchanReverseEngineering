package crc6459efab142bb48047;

import com.bumptech.glide.load.DataSource;
import com.bumptech.glide.load.engine.GlideException;
import com.bumptech.glide.request.RequestListener;
import com.bumptech.glide.request.target.Target;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class GlideLoadingListener implements IGCUserPeer, RequestListener {
    private ArrayList refList;

    private native boolean n_onLoadFailed(GlideException glideException, Object obj, Target target, boolean z);

    private native boolean n_onResourceReady(Object obj, Object obj2, Target target, DataSource dataSource, boolean z);

    public GlideLoadingListener() {
        if (getClass() == GlideLoadingListener.class) {
            TypeManager.Activate("Auchan.Android.Common.UiUtils.GlideLoadingListener, Auchan.Android.Net", "", this, new Object[0]);
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
