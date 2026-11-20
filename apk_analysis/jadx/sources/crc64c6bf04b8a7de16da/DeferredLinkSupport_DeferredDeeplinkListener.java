package crc64c6bf04b8a7de16da;

import io.appmetrica.analytics.DeferredDeeplinkListener;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class DeferredLinkSupport_DeferredDeeplinkListener implements IGCUserPeer, DeferredDeeplinkListener {
    private ArrayList refList;

    private native void n_onDeeplinkLoaded(String str);

    private native void n_onError(DeferredDeeplinkListener.Error error, String str);

    public DeferredLinkSupport_DeferredDeeplinkListener() {
        if (getClass() == DeferredLinkSupport_DeferredDeeplinkListener.class) {
            TypeManager.Activate("Auchan.Android.AppAnalytics.YandexMetrica.DeferredLinkSupport+DeferredDeeplinkListener, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    @Override // io.appmetrica.analytics.DeferredDeeplinkListener
    public void onDeeplinkLoaded(String str) {
        n_onDeeplinkLoaded(str);
    }

    @Override // io.appmetrica.analytics.DeferredDeeplinkListener
    public void onError(DeferredDeeplinkListener.Error error, String str) {
        n_onError(error, str);
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
