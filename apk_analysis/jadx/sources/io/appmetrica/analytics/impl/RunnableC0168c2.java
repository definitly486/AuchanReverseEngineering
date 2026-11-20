package io.appmetrica.analytics.impl;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.c2, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class RunnableC0168c2 implements Runnable {
    public final /* synthetic */ InterfaceC0672ve a;
    public final /* synthetic */ Q7 b;

    public RunnableC0168c2(C0219e2 c0219e2, Q7 q7) {
        this.a = c0219e2;
        this.b = q7;
    }

    @Override // java.lang.Runnable
    public final void run() {
        this.a.consume(this.b);
    }
}
