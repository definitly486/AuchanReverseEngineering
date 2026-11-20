package io.appmetrica.analytics.impl;

import android.content.Context;
import android.location.Location;
import io.appmetrica.analytics.AdvIdentifiersResult;
import io.appmetrica.analytics.AppMetricaConfig;
import io.appmetrica.analytics.AppMetricaLibraryAdapterConfig;
import io.appmetrica.analytics.DeferredDeeplinkListener;
import io.appmetrica.analytics.DeferredDeeplinkParametersListener;
import io.appmetrica.analytics.ReporterConfig;
import io.appmetrica.analytics.StartupParamsCallback;
import io.appmetrica.analytics.coreapi.internal.executors.InterruptionSafeThread;
import java.util.List;
import java.util.Map;
import java.util.concurrent.Callable;
import java.util.concurrent.FutureTask;

/* JADX INFO: loaded from: classes3.dex */
public final class A0 implements InterfaceC0487ob {
    public static volatile A0 e = null;
    public static volatile boolean f = false;
    public static volatile boolean g;
    public final Context a;
    public final C0606t0 b;
    public final FutureTask c;
    public final InterfaceC0125ab d;

    public A0(Context context) {
        this.a = context;
        C0606t0 c0606t0C = C0584s4.l().c();
        this.b = c0606t0C;
        this.d = c0606t0C.a(context, C0584s4.l().g());
        this.c = new FutureTask(new Callable() { // from class: io.appmetrica.analytics.impl.A0$$ExternalSyntheticLambda1
            @Override // java.util.concurrent.Callable
            public final Object call() {
                return this.f$0.p();
            }
        });
    }

    public static A0 a(Context context) {
        A0 a0;
        A0 a1 = e;
        if (a1 != null) {
            return a1;
        }
        synchronized (A0.class) {
            try {
                a0 = e;
                if (a0 == null) {
                    a0 = new A0(context);
                    a0.j();
                    C0584s4.l().c.a().execute(new RunnableC0762z0(a0));
                    e = a0;
                }
            } catch (Throwable th) {
                throw th;
            }
        }
        return a0;
    }

    public static void b(boolean z) {
        c().a(z, true);
    }

    public static void clearAppEnvironment() {
        c().clearAppEnvironment();
    }

    public static synchronized boolean k() {
        return f;
    }

    public static boolean l() {
        return g;
    }

    public static synchronized boolean m() {
        A0 a0;
        a0 = e;
        return (a0 == null || !a0.c.isDone() || a0.f().i() == null) ? false : true;
    }

    public static synchronized void n() {
        e = null;
        f = false;
        g = false;
    }

    public static void putAppEnvironmentValue(String str, String str2) {
        c().putAppEnvironmentValue(str, str2);
    }

    public static synchronized void q() {
        f = true;
    }

    public static void r() {
        g = true;
    }

    public static A0 s() {
        return e;
    }

    public static void setDataSendingEnabled(boolean z) {
        c().setDataSendingEnabled(z);
    }

    public static void setUserProfileID(String str) {
        c().setUserProfileID(str);
    }

    public final void c(AppMetricaConfig appMetricaConfig) {
        this.d.a(appMetricaConfig, this);
    }

    public final void d(AppMetricaConfig appMetricaConfig) {
        f().b(appMetricaConfig);
        C0584s4.l().c.a().execute(new RunnableC0737y1(this.a));
    }

    public final String e() {
        return f().e();
    }

    public final InterfaceC0151bb f() {
        try {
            return (InterfaceC0151bb) this.c.get();
        } catch (Exception e2) {
            throw new RuntimeException(e2);
        }
    }

    public final Map<String, String> g() {
        return f().g();
    }

    public final AdvIdentifiersResult h() {
        return f().h();
    }

    public final Fc i() {
        return f().i();
    }

    public final void j() {
        C0325i4 c0325i4 = C0584s4.l().c;
        Runnable runnable = new Runnable() { // from class: io.appmetrica.analytics.impl.A0$$ExternalSyntheticLambda0
            @Override // java.lang.Runnable
            public final void run() {
                this.f$0.o();
            }
        };
        c0325i4.a.getClass();
        new InterruptionSafeThread(runnable, "IAA-INIT_CORE-" + Td.a.incrementAndGet()).start();
    }

    public final void o() {
        C0584s4.l().s.a(this.a);
        C0584s4.l().a(this.a).a();
        this.c.run();
    }

    public final InterfaceC0151bb p() {
        InterfaceC0151bb interfaceC0151bb;
        C0606t0 c0606t0 = this.b;
        Context context = this.a;
        InterfaceC0125ab interfaceC0125ab = this.d;
        synchronized (c0606t0) {
            try {
                if (c0606t0.d == null) {
                    if (c0606t0.a(context)) {
                        c0606t0.d = new G0();
                    } else {
                        c0606t0.d = new E0(context, interfaceC0125ab);
                    }
                }
                interfaceC0151bb = c0606t0.d;
            } catch (Throwable th) {
                throw th;
            }
        }
        return interfaceC0151bb;
    }

    public final void b(AppMetricaLibraryAdapterConfig appMetricaLibraryAdapterConfig) {
        f().a(appMetricaLibraryAdapterConfig);
        C0584s4.l().c.a().execute(new RunnableC0737y1(this.a));
    }

    public final InterfaceC0435mb c(ReporterConfig reporterConfig) {
        return f().c(reporterConfig);
    }

    public static InterfaceC0179cd c() {
        if (m()) {
            return e.f();
        }
        return C0584s4.l().b;
    }

    public final C0590sa d() {
        return f().d();
    }

    public final C0662v4 b() {
        return this.d.a();
    }

    public static void a(Location location) {
        c().a(location);
    }

    public static void a(boolean z) {
        c().a(z);
    }

    public static void a(String str, String str2) {
        c().a(str, str2);
    }

    public static void a(String str) {
        c().a(str);
    }

    public final void a(DeferredDeeplinkParametersListener deferredDeeplinkParametersListener) {
        f().a(deferredDeeplinkParametersListener);
    }

    public final void a(DeferredDeeplinkListener deferredDeeplinkListener) {
        f().a(deferredDeeplinkListener);
    }

    public final void a(ReporterConfig reporterConfig) {
        f().a(reporterConfig);
    }

    public final void a(StartupParamsCallback startupParamsCallback, List<String> list) {
        f().a(startupParamsCallback, list);
    }

    public static synchronized void a(A0 a0) {
        e = a0;
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0487ob
    public final InterfaceC0461nb a() {
        return f().a();
    }
}
