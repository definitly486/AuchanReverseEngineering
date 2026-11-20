package io.appmetrica.analytics.impl;

/* JADX INFO: loaded from: classes3.dex */
public final class Hi implements Runnable {
    public final /* synthetic */ Ii a;

    public Hi(Ii ii) {
        this.a = ii;
    }

    @Override // java.lang.Runnable
    public final void run() {
        this.a.c();
    }
}
