package io.appmetrica.analytics.impl;

/* JADX INFO: loaded from: classes3.dex */
public final class U0 implements Runnable {
    public final /* synthetic */ boolean a;
    public final /* synthetic */ C0659v1 b;

    public U0(C0659v1 c0659v1, boolean z) {
        this.b = c0659v1;
        this.a = z;
    }

    @Override // java.lang.Runnable
    public final void run() {
        B0 b0 = this.b.a;
        boolean z = this.a;
        b0.getClass();
        A0.c().setDataSendingEnabled(z);
    }
}
