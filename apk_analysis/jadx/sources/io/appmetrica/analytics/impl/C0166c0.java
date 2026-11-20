package io.appmetrica.analytics.impl;

import android.content.Context;
import io.appmetrica.analytics.AppMetricaLibraryAdapterConfig;
import io.appmetrica.analytics.coreutils.internal.executors.SafeRunnable;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.c0, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0166c0 extends SafeRunnable {
    public final /* synthetic */ C0192d0 a;
    public final /* synthetic */ Context b;

    public C0166c0(C0192d0 c0192d0, Context context) {
        this.a = c0192d0;
        this.b = context;
    }

    @Override // io.appmetrica.analytics.coreutils.internal.executors.SafeRunnable
    public final void runSafety() {
        C0192d0 c0192d0 = this.a;
        Context context = this.b;
        c0192d0.getClass();
        c0192d0.a(context, AppMetricaLibraryAdapterConfig.newConfigBuilder().build());
    }
}
