package io.appmetrica.analytics.impl;

/* JADX INFO: loaded from: classes3.dex */
public final class P0 implements Runnable {
    public final /* synthetic */ String a;
    public final /* synthetic */ C0659v1 b;

    public P0(C0659v1 c0659v1, String str) {
        this.b = c0659v1;
        this.a = str;
    }

    @Override // java.lang.Runnable
    public final void run() {
        this.b.c().b.a(this.a, false);
    }
}
