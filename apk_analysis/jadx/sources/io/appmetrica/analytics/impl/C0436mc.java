package io.appmetrica.analytics.impl;

import com.scanflow.datacapture.barinternal.kotlin.Unit;
import io.appmetrica.analytics.locationapi.internal.LocationControllerObserver;
import kotlin.jvm.functions.Function1;
import kotlin.jvm.internal.Lambda;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.mc, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0436mc extends Lambda implements Function1 {
    public static final C0436mc a = new C0436mc();

    public C0436mc() {
        super(1);
    }

    @Override // kotlin.jvm.functions.Function1
    public final Object invoke(Object obj) {
        ((LocationControllerObserver) obj).startLocationTracking();
        return Unit.INSTANCE;
    }
}
