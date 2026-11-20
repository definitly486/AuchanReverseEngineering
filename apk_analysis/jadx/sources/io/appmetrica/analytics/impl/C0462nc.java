package io.appmetrica.analytics.impl;

import com.scanflow.datacapture.barinternal.kotlin.Unit;
import io.appmetrica.analytics.locationapi.internal.LocationControllerObserver;
import kotlin.jvm.functions.Function1;
import kotlin.jvm.internal.Lambda;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.nc, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0462nc extends Lambda implements Function1 {
    public static final C0462nc a = new C0462nc();

    public C0462nc() {
        super(1);
    }

    @Override // kotlin.jvm.functions.Function1
    public final Object invoke(Object obj) {
        ((LocationControllerObserver) obj).stopLocationTracking();
        return Unit.INSTANCE;
    }
}
