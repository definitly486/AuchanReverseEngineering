package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.locationapi.internal.LocationReceiverProvider;
import io.appmetrica.analytics.locationapi.internal.LocationReceiverProviderFactory;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.sc, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0592sc implements LocationReceiverProviderFactory {
    public final C0618tc a = new C0618tc();

    @Override // io.appmetrica.analytics.locationapi.internal.LocationReceiverProviderFactory
    public final LocationReceiverProvider getPassiveLocationReceiverProvider() {
        return this.a;
    }
}
