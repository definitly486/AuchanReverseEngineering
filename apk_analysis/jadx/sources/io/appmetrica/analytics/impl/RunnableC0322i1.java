package io.appmetrica.analytics.impl;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.i1, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class RunnableC0322i1 implements Runnable {
    public final /* synthetic */ C0659v1 a;

    public RunnableC0322i1(C0659v1 c0659v1) {
        this.a = c0659v1;
    }

    @Override // java.lang.Runnable
    public final void run() {
        this.a.a.getClass();
        A0.c().clearAppEnvironment();
    }
}
