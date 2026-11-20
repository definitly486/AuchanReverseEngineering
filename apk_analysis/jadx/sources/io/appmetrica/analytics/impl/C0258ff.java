package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreapi.internal.servicecomponents.ActivationBarrierCallback;
import java.util.concurrent.TimeUnit;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.ff, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0258ff implements Pc, ActivationBarrierCallback {
    public final L9 a;
    public final Oc b;
    public final Oc c;

    public C0258ff(L9 l9, Zg zg, F4 f4, C0544qf c0544qf) {
        this.a = l9;
        Oc oc = new Oc(zg, f4, c0544qf);
        this.b = oc;
        this.c = oc;
        if (oc.b()) {
            return;
        }
        Ka.k().a().subscribe(TimeUnit.SECONDS.toMillis(AbstractC0122a8.a.longValue()), Ka.k().w().f(), this);
    }

    @Override // io.appmetrica.analytics.impl.Pc
    public final Z8 a() {
        return this.c;
    }

    @Override // io.appmetrica.analytics.coreapi.internal.servicecomponents.ActivationBarrierCallback
    public final void onWaitFinished() {
        this.b.a();
        ((A5) this.a.a()).e();
    }
}
