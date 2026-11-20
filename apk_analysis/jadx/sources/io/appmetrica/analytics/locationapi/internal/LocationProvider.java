package io.appmetrica.analytics.locationapi.internal;

import android.location.Location;

/* JADX INFO: loaded from: classes3.dex */
public interface LocationProvider {
    Location getSystemLocation();

    Location getUserLocation();
}
