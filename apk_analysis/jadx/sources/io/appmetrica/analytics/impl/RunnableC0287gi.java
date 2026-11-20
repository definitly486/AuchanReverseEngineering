package io.appmetrica.analytics.impl;

import android.content.Context;
import io.appmetrica.analytics.ReporterConfig;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.gi, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class RunnableC0287gi implements Runnable {
    public final /* synthetic */ ReporterConfig a;
    public final /* synthetic */ C0624ti b;

    public RunnableC0287gi(C0624ti c0624ti, ReporterConfig reporterConfig) {
        this.b = c0624ti;
        this.a = reporterConfig;
    }

    @Override // java.lang.Runnable
    public final void run() {
        C0624ti c0624ti = this.b;
        ReporterConfig reporterConfig = this.a;
        B0 b0 = c0624ti.a;
        Context context = c0624ti.d;
        b0.getClass();
        A0.a(context).f().a(reporterConfig);
    }
}
