package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.AnrListener;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.l1, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class RunnableC0399l1 implements Runnable {
    public final /* synthetic */ AnrListener a;
    public final /* synthetic */ C0659v1 b;

    public RunnableC0399l1(C0659v1 c0659v1, AnrListener anrListener) {
        this.b = c0659v1;
        this.a = anrListener;
    }

    @Override // java.lang.Runnable
    public final void run() {
        C0659v1.a(this.b).a(this.a);
    }
}
