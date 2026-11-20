package io.appmetrica.analytics.impl;

import android.content.Context;
import android.os.Handler;
import io.appmetrica.analytics.AppMetrica;
import io.appmetrica.analytics.AppMetricaConfig;
import io.appmetrica.analytics.coreapi.internal.executors.ICommonExecutor;
import io.appmetrica.analytics.coreapi.internal.executors.IHandlerExecutor;
import io.appmetrica.analytics.coreutils.internal.StringUtils;
import io.appmetrica.analytics.logger.appmetrica.internal.ImportantLogger;
import io.appmetrica.analytics.logger.common.BaseReleaseLogger;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.s0, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0580s0 implements InterfaceC0125ab {
    public final Context a;
    public final IHandlerExecutor b;
    public final C0662v4 c = new C0662v4();
    public final Handler d = f().getHandler();
    public final C0245f2 e = new C0245f2();
    public final Gb f = new Gb();

    public C0580s0(Context context, C0325i4 c0325i4) {
        this.a = context;
        this.b = c0325i4.a();
        BaseReleaseLogger.init(context);
        f().execute(new Runnable() { // from class: io.appmetrica.analytics.impl.s0$$ExternalSyntheticLambda0
            @Override // java.lang.Runnable
            public final void run() {
                C0580s0.e();
            }
        });
        a().a();
        W3.a().onCreate();
    }

    public static final void e() {
        ImportantLogger.INSTANCE.info("AppMetrica", "Initializing of AppMetrica, " + StringUtils.capitalize("release") + " type, Version 8.1.0, API Level " + AppMetrica.getLibraryApiLevel() + ", Dated 13.04.2026.", new Object[0]);
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0125ab
    public final C0662v4 a() {
        return this.c;
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0125ab
    public final Handler b() {
        return this.d;
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0125ab
    public final C0245f2 c() {
        return this.e;
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0125ab
    public final Gb d() {
        return this.f;
    }

    public final IHandlerExecutor f() {
        return this.b;
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0125ab
    public final ICommonExecutor getDefaultExecutor() {
        return this.b;
    }

    /* JADX WARN: Code duplicated, block: B:17:0x0029 A[Catch: all -> 0x000e, TryCatch #0 {all -> 0x000e, blocks: (B:3:0x0001, B:6:0x0007, B:8:0x000b, B:11:0x0010, B:14:0x0017, B:19:0x0032, B:21:0x0036, B:22:0x0038, B:25:0x003f, B:28:0x004c, B:26:0x0045, B:15:0x001d, B:17:0x0029), top: B:33:0x0001 }] */
    @Override // io.appmetrica.analytics.impl.InterfaceC0125ab
    public final synchronized void a(AppMetricaConfig appMetricaConfig, InterfaceC0487ob interfaceC0487ob) {
        try {
            if (!A0.g) {
                if (appMetricaConfig == null) {
                    this.f.c();
                    this.f.b();
                    if (appMetricaConfig != null) {
                        this.f.a(this.a, appMetricaConfig, interfaceC0487ob);
                    }
                } else {
                    Boolean bool = appMetricaConfig.crashReporting;
                    if (bool == null) {
                        bool = Boolean.TRUE;
                    }
                    if (bool.booleanValue()) {
                        this.f.c();
                        this.f.b();
                        if (appMetricaConfig != null) {
                            this.f.a(this.a, appMetricaConfig, interfaceC0487ob);
                        }
                    } else {
                        this.f.a();
                    }
                }
                if (appMetricaConfig == null) {
                    this.e.b();
                } else {
                    Boolean bool2 = appMetricaConfig.appOpenTrackingEnabled;
                    if (bool2 == null) {
                        bool2 = Boolean.TRUE;
                    }
                    if (bool2.booleanValue()) {
                        this.e.b();
                    } else {
                        this.e.c();
                    }
                }
                if (appMetricaConfig != null) {
                    A0.g = true;
                }
            }
        } catch (Throwable th) {
            throw th;
        }
    }
}
