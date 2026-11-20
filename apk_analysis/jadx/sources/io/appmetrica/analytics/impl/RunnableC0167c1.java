package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.DeferredDeeplinkListener;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.c1, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class RunnableC0167c1 implements Runnable {
    public final /* synthetic */ DeferredDeeplinkListener a;
    public final /* synthetic */ C0659v1 b;

    public RunnableC0167c1(C0659v1 c0659v1, DeferredDeeplinkListener deferredDeeplinkListener) {
        this.b = c0659v1;
        this.a = deferredDeeplinkListener;
    }

    @Override // java.lang.Runnable
    public final void run() {
        this.b.a.getClass();
        A0 a0 = A0.e;
        a0.f().a(this.a);
    }
}
