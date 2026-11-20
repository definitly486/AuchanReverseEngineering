package crc64e02c8cbb4566d722;

import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class NotificationIntentReceiver extends BroadcastReceiver implements IGCUserPeer {
    private ArrayList refList;

    private native void n_onReceive(Context context, Intent intent);

    public NotificationIntentReceiver() {
        if (getClass() == NotificationIntentReceiver.class) {
            TypeManager.Activate("Auchan.Android.PushNotifications.NotificationIntentReceiver, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    @Override // android.content.BroadcastReceiver
    public void onReceive(Context context, Intent intent) {
        n_onReceive(context, intent);
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
