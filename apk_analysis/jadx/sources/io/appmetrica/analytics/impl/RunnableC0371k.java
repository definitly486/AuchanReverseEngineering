package io.appmetrica.analytics.impl;

import android.app.Activity;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.k, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class RunnableC0371k implements Runnable {
    public final /* synthetic */ Activity a;
    public final /* synthetic */ C0423m b;

    public RunnableC0371k(C0423m c0423m, Activity activity) {
        this.b = c0423m;
        this.a = activity;
    }

    @Override // java.lang.Runnable
    public final void run() {
        this.b.a(this.a);
    }
}
