package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.DeferredDeeplinkParametersListener;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.b1, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class RunnableC0141b1 implements Runnable {
    public final /* synthetic */ DeferredDeeplinkParametersListener a;
    public final /* synthetic */ C0659v1 b;

    public RunnableC0141b1(C0659v1 c0659v1, DeferredDeeplinkParametersListener deferredDeeplinkParametersListener) {
        this.b = c0659v1;
        this.a = deferredDeeplinkParametersListener;
    }

    @Override // java.lang.Runnable
    public final void run() {
        this.b.a.getClass();
        A0 a0 = A0.e;
        a0.f().a(this.a);
    }
}
