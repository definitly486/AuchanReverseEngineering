package io.appmetrica.analytics.impl;

import android.content.Context;
import io.appmetrica.analytics.AppMetricaLibraryAdapterConfig;
import io.appmetrica.analytics.coreapi.internal.executors.IHandlerExecutor;
import io.appmetrica.analytics.coreutils.internal.logger.LoggerStorage;
import java.util.concurrent.TimeUnit;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.d0, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0192d0 {
    public final B0 a;
    public final C0550ql b;
    public final C0325i4 c;
    public final long d = TimeUnit.SECONDS.toMillis(10);

    public C0192d0(B0 b0, C0550ql c0550ql, C0325i4 c0325i4) {
        this.a = b0;
        this.b = c0550ql;
        this.c = c0325i4;
    }

    public final synchronized void a(final Context context, final AppMetricaLibraryAdapterConfig appMetricaLibraryAdapterConfig) {
        this.a.getClass();
        if (B0.a()) {
            return;
        }
        LoggerStorage.getMainPublicOrAnonymousLogger().info("Session autotracking enabled", new Object[0]);
        this.b.a();
        this.a.getClass();
        A0 a0A = A0.a(context);
        a0A.d.a(null, a0A);
        IHandlerExecutor iHandlerExecutorA = this.c.a();
        ((U9) iHandlerExecutorA).b.post(new Runnable() { // from class: io.appmetrica.analytics.impl.d0$$ExternalSyntheticLambda0
            @Override // java.lang.Runnable
            public final void run() {
                C0192d0.a(this.f$0, context, appMetricaLibraryAdapterConfig);
            }
        });
        this.a.getClass();
        B0.b();
    }

    public static final void a(C0192d0 c0192d0, Context context, AppMetricaLibraryAdapterConfig appMetricaLibraryAdapterConfig) {
        c0192d0.a.getClass();
        A0 a0A = A0.a(context);
        a0A.f().a(appMetricaLibraryAdapterConfig);
        C0584s4.l().c.a().execute(new RunnableC0737y1(a0A.a));
    }
}
