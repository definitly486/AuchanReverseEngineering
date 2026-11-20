package crc64e53d2f592022988e;

import android.net.ConnectivityManager;
import android.net.LinkProperties;
import android.net.Network;
import android.net.NetworkCapabilities;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class ConnectivityImplementation_EssentialsNetworkCallback extends ConnectivityManager.NetworkCallback implements IGCUserPeer {
    private ArrayList refList;

    private native void n_onAvailable(Network network);

    private native void n_onCapabilitiesChanged(Network network, NetworkCapabilities networkCapabilities);

    private native void n_onLinkPropertiesChanged(Network network, LinkProperties linkProperties);

    private native void n_onLosing(Network network, int i);

    private native void n_onLost(Network network);

    private native void n_onUnavailable();

    public ConnectivityImplementation_EssentialsNetworkCallback() {
        if (getClass() == ConnectivityImplementation_EssentialsNetworkCallback.class) {
            TypeManager.Activate("Microsoft.Maui.Networking.ConnectivityImplementation+EssentialsNetworkCallback, Microsoft.Maui.Essentials", "", this, new Object[0]);
        }
    }

    @Override // android.net.ConnectivityManager.NetworkCallback
    public void onAvailable(Network network) {
        n_onAvailable(network);
    }

    @Override // android.net.ConnectivityManager.NetworkCallback
    public void onLost(Network network) {
        n_onLost(network);
    }

    @Override // android.net.ConnectivityManager.NetworkCallback
    public void onCapabilitiesChanged(Network network, NetworkCapabilities networkCapabilities) {
        n_onCapabilitiesChanged(network, networkCapabilities);
    }

    @Override // android.net.ConnectivityManager.NetworkCallback
    public void onUnavailable() {
        n_onUnavailable();
    }

    @Override // android.net.ConnectivityManager.NetworkCallback
    public void onLinkPropertiesChanged(Network network, LinkProperties linkProperties) {
        n_onLinkPropertiesChanged(network, linkProperties);
    }

    @Override // android.net.ConnectivityManager.NetworkCallback
    public void onLosing(Network network, int i) {
        n_onLosing(network, i);
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
