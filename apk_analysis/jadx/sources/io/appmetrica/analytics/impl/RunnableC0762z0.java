package io.appmetrica.analytics.impl;

import java.util.concurrent.TimeUnit;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.z0, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class RunnableC0762z0 implements Runnable {
    public final /* synthetic */ A0 a;

    public RunnableC0762z0(A0 a0) {
        this.a = a0;
    }

    @Override // java.lang.Runnable
    public final void run() {
        C0584s4.l().c.a().executeDelayed(new RunnableC0711x1(this.a.a), TimeUnit.SECONDS.toMillis(5L));
    }
}
