package crc64f62664462a8937a9;

import android.location.Location;
import android.location.LocationListener;
import android.os.Bundle;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class SingleLocationListener implements IGCUserPeer, LocationListener {
    private ArrayList refList;

    private native void n_onFlushComplete(int i);

    private native void n_onLocationChanged(Location location);

    private native void n_onProviderDisabled(String str);

    private native void n_onProviderEnabled(String str);

    private native void n_onStatusChanged(String str, int i, Bundle bundle);

    public SingleLocationListener() {
        if (getClass() == SingleLocationListener.class) {
            TypeManager.Activate("Microsoft.Maui.Devices.Sensors.SingleLocationListener, Microsoft.Maui.Essentials", "", this, new Object[0]);
        }
    }

    @Override // android.location.LocationListener
    public void onLocationChanged(Location location) {
        n_onLocationChanged(location);
    }

    @Override // android.location.LocationListener
    public void onProviderDisabled(String str) {
        n_onProviderDisabled(str);
    }

    @Override // android.location.LocationListener
    public void onProviderEnabled(String str) {
        n_onProviderEnabled(str);
    }

    @Override // android.location.LocationListener
    public void onStatusChanged(String str, int i, Bundle bundle) {
        n_onStatusChanged(str, i, bundle);
    }

    @Override // android.location.LocationListener
    public void onFlushComplete(int i) {
        n_onFlushComplete(i);
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
