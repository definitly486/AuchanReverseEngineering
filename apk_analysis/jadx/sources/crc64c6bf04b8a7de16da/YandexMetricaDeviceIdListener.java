package crc64c6bf04b8a7de16da;

import io.appmetrica.analytics.StartupParamsCallback;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class YandexMetricaDeviceIdListener implements IGCUserPeer, StartupParamsCallback {
    private ArrayList refList;

    private native void n_onReceive(StartupParamsCallback.Result result);

    private native void n_onRequestError(StartupParamsCallback.Reason reason, StartupParamsCallback.Result result);

    public YandexMetricaDeviceIdListener() {
        if (getClass() == YandexMetricaDeviceIdListener.class) {
            TypeManager.Activate("Auchan.Android.AppAnalytics.YandexMetrica.YandexMetricaDeviceIdListener, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    @Override // io.appmetrica.analytics.StartupParamsCallback
    public void onReceive(StartupParamsCallback.Result result) {
        n_onReceive(result);
    }

    @Override // io.appmetrica.analytics.StartupParamsCallback
    public void onRequestError(StartupParamsCallback.Reason reason, StartupParamsCallback.Result result) {
        n_onRequestError(reason, result);
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
