package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.ExternalAttribution;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.m1, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class RunnableC0425m1 implements Runnable {
    public final /* synthetic */ ExternalAttribution a;
    public final /* synthetic */ C0659v1 b;

    public RunnableC0425m1(C0659v1 c0659v1, ExternalAttribution externalAttribution) {
        this.b = c0659v1;
        this.a = externalAttribution;
    }

    @Override // java.lang.Runnable
    public final void run() {
        C0659v1.a(this.b).a(this.a);
    }
}
