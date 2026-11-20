package com.scanflow.datacapture.barinternal.j;

import android.net.ConnectivityManager;
import android.net.Network;
import android.util.Log;
import androidx.lifecycle.MutableLiveData;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: loaded from: classes3.dex */
public final class a extends ConnectivityManager.NetworkCallback {
    public final MutableLiveData a = new MutableLiveData();

    @Override // android.net.ConnectivityManager.NetworkCallback
    public final void onAvailable(Network network) {
        Intrinsics.checkNotNullParameter(network, "network");
        super.onAvailable(network);
        this.a.postValue(d.CONNECTED);
        Log.i("InternetCallback", "Connection Available");
    }

    @Override // android.net.ConnectivityManager.NetworkCallback
    public final void onLosing(Network network, int i) {
        Intrinsics.checkNotNullParameter(network, "network");
        super.onLosing(network, i);
        this.a.postValue(d.DISCONNECTING);
        Log.i("InternetCallback", "Connection Losing");
    }

    @Override // android.net.ConnectivityManager.NetworkCallback
    public final void onLost(Network network) {
        Intrinsics.checkNotNullParameter(network, "network");
        super.onLost(network);
        this.a.postValue(d.DISCONNECTED);
        Log.i("InternetCallback", "Connection Lost");
    }
}
