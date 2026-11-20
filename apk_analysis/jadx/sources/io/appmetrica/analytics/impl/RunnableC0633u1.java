package io.appmetrica.analytics.impl;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.u1, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class RunnableC0633u1 implements Runnable {
    public final /* synthetic */ Throwable a;
    public final /* synthetic */ C0659v1 b;

    public RunnableC0633u1(C0659v1 c0659v1, Throwable th) {
        this.b = c0659v1;
        this.a = th;
    }

    @Override // java.lang.Runnable
    public final void run() {
        C0659v1.a(this.b).reportUnhandledException(this.a);
    }
}
