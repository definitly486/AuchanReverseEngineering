package io.appmetrica.analytics.impl;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.d1, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class RunnableC0193d1 implements Runnable {
    public final /* synthetic */ String a;
    public final /* synthetic */ String b;
    public final /* synthetic */ C0659v1 c;

    public RunnableC0193d1(C0659v1 c0659v1, String str, String str2) {
        this.c = c0659v1;
        this.a = str;
        this.b = str2;
    }

    @Override // java.lang.Runnable
    public final void run() {
        B0 b0 = this.c.a;
        String str = this.a;
        String str2 = this.b;
        b0.getClass();
        A0.c().a(str, str2);
    }
}
