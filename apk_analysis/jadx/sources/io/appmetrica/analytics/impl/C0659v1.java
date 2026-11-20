package io.appmetrica.analytics.impl;

import android.app.Activity;
import android.app.Application;
import android.content.Context;
import android.content.Intent;
import android.location.Location;
import android.webkit.WebView;
import io.appmetrica.analytics.AdRevenue;
import io.appmetrica.analytics.AnrListener;
import io.appmetrica.analytics.AppMetricaConfig;
import io.appmetrica.analytics.DeferredDeeplinkListener;
import io.appmetrica.analytics.DeferredDeeplinkParametersListener;
import io.appmetrica.analytics.ExternalAttribution;
import io.appmetrica.analytics.ReporterConfig;
import io.appmetrica.analytics.Revenue;
import io.appmetrica.analytics.StartupParamsCallback;
import io.appmetrica.analytics.coreapi.internal.executors.IHandlerExecutor;
import io.appmetrica.analytics.coreutils.internal.WrapUtils;
import io.appmetrica.analytics.coreutils.internal.collection.CollectionUtils;
import io.appmetrica.analytics.coreutils.internal.logger.LoggerStorage;
import io.appmetrica.analytics.ecommerce.ECommerceEvent;
import io.appmetrica.analytics.internal.IdentifiersResult;
import io.appmetrica.analytics.internal.js.AppMetricaInitializerJsInterface;
import io.appmetrica.analytics.internal.js.AppMetricaJsInterface;
import io.appmetrica.analytics.logger.appmetrica.internal.PublicLogger;
import io.appmetrica.analytics.modulesapi.internal.client.adrevenue.ModuleAdRevenueProcessor;
import io.appmetrica.analytics.profile.UserProfile;
import java.util.List;
import java.util.Map;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.v1, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0659v1 {
    public final B0 a;
    public final ap b;
    public final Bi c;
    public final V7 d;
    public final Bl e;
    public final N2 f;
    public final C0707wn g;
    public final C0550ql h;

    public C0659v1(B0 b0, N2 n2, Bl bl, ap apVar, C0707wn c0707wn, Bi bi, V7 v7, C0550ql c0550ql) {
        this.a = b0;
        this.b = apVar;
        this.c = bi;
        this.d = v7;
        this.f = n2;
        this.g = c0707wn;
        this.e = bl;
        this.h = c0550ql;
    }

    public static IHandlerExecutor b() {
        return C0584s4.l().c.a();
    }

    public final void a(final Context context, final AppMetricaConfig appMetricaConfig) {
        N2 n2 = this.f;
        n2.f.a(context);
        n2.b.a(appMetricaConfig);
        C0707wn c0707wn = this.g;
        Context applicationContext = context.getApplicationContext();
        c0707wn.e.a(applicationContext);
        PublicLogger orCreatePublicLogger = LoggerStorage.getOrCreatePublicLogger(appMetricaConfig.apiKey);
        if (((Boolean) WrapUtils.getOrDefault(appMetricaConfig.sessionsAutoTrackingEnabled, Boolean.TRUE)).booleanValue()) {
            orCreatePublicLogger.info("Session auto tracking enabled", new Object[0]);
            c0707wn.d.a();
        } else {
            orCreatePublicLogger.info("Session auto tracking disabled", new Object[0]);
        }
        c0707wn.a.getClass();
        A0 a0A = A0.a(applicationContext);
        a0A.d.a(appMetricaConfig, a0A);
        IHandlerExecutor iHandlerExecutorB = b();
        ((U9) iHandlerExecutorB).b.post(new Runnable() { // from class: io.appmetrica.analytics.impl.v1$$ExternalSyntheticLambda2
            @Override // java.lang.Runnable
            public final void run() {
                this.f$0.b(context, appMetricaConfig);
            }
        });
        this.a.getClass();
        B0.b();
    }

    public final Fc c() {
        this.a.getClass();
        return A0.e.f().i();
    }

    public final void d() {
        c().a.a(this.h.a());
    }

    public final void e() {
        this.f.a.a(null);
        this.g.getClass();
        IHandlerExecutor iHandlerExecutorB = b();
        ((U9) iHandlerExecutorB).b.post(new Y0(this));
    }

    public final void b(Context context, AppMetricaConfig appMetricaConfig) {
        B0 b0 = this.a;
        Context applicationContext = context.getApplicationContext();
        b0.getClass();
        A0 a0A = A0.a(applicationContext);
        a0A.f().b(this.d.a(appMetricaConfig));
        Context context2 = a0A.a;
        ((U9) C0584s4.l().c.a()).execute(new RunnableC0737y1(context2));
    }

    public final void d(String str) {
        this.f.getClass();
        this.g.getClass();
        IHandlerExecutor iHandlerExecutorB = b();
        ((U9) iHandlerExecutorB).b.post(new V0(this, str));
    }

    public final void c(Activity activity) {
        this.f.a.a(null);
        this.g.getClass();
        IHandlerExecutor iHandlerExecutorB = b();
        ((U9) iHandlerExecutorB).b.post(new RunnableC0347j1(this, activity));
    }

    public C0659v1() {
        this(C0584s4.l().d(), new ap());
    }

    public final void d(String str, String str2) {
        N2 n2 = this.f;
        n2.a.a(null);
        if (n2.n.a(str).a) {
            this.g.getClass();
            IHandlerExecutor iHandlerExecutorB = b();
            ((U9) iHandlerExecutorB).b.post(new RunnableC0244f1(this, str, str2));
        }
    }

    public C0659v1(B0 b0, ap apVar) {
        this(b0, new N2(b0), new Bl(b0), apVar, new C0707wn(b0, apVar), Bi.a(), C0584s4.l().j(), C0584s4.l().o());
    }

    public final void c(String str, String str2) {
        N2 n2 = this.f;
        n2.a.a(null);
        n2.r.a(str);
        this.g.getClass();
        IHandlerExecutor iHandlerExecutorB = b();
        ((U9) iHandlerExecutorB).b.post(new RunnableC0530q1(this, str, str2));
    }

    public final void b(String str) {
        N2 n2 = this.f;
        n2.a.a(null);
        n2.r.a(str);
        this.g.getClass();
        IHandlerExecutor iHandlerExecutorB = b();
        ((U9) iHandlerExecutorB).b.post(new RunnableC0503p1(this, str));
    }

    public final void c(boolean z) {
        this.f.getClass();
        this.g.getClass();
        IHandlerExecutor iHandlerExecutorB = b();
        ((U9) iHandlerExecutorB).b.post(new S0(this, z));
    }

    public final void b(Activity activity) {
        N2 n2 = this.f;
        n2.a.a(null);
        n2.c.a(activity);
        this.g.getClass();
        Intent intentA = C0707wn.a(activity);
        IHandlerExecutor iHandlerExecutorB = b();
        ((U9) iHandlerExecutorB).b.post(new O0(this, intentA));
    }

    public final void c(String str) {
        if (this.e.a((Void) null).a && this.f.m.a(str).a) {
            this.g.getClass();
            IHandlerExecutor iHandlerExecutorB = b();
            ((U9) iHandlerExecutorB).b.post(new RunnableC0270g1(this, str));
        }
    }

    public final void b(boolean z) {
        this.f.getClass();
        this.g.getClass();
        IHandlerExecutor iHandlerExecutorB = b();
        ((U9) iHandlerExecutorB).b.post(new U0(this, z));
    }

    public final void a(Activity activity) {
        this.f.a.a(null);
        this.g.getClass();
        IHandlerExecutor iHandlerExecutorB = b();
        ((U9) iHandlerExecutorB).b.post(new RunnableC0477o1(this, activity));
    }

    public final void b(String str, String str2) {
        this.f.k.a(str);
        this.g.getClass();
        IHandlerExecutor iHandlerExecutorB = b();
        ((U9) iHandlerExecutorB).b.post(new RunnableC0193d1(this, str, str2));
    }

    public final void c(Context context) {
        this.f.f.a(context);
        this.g.e.a(context);
        this.a.getClass();
        A0.a(context);
    }

    public final void a(Application application) {
        this.f.e.a(application);
        this.g.c.a(application);
        IHandlerExecutor iHandlerExecutorB = b();
        ((U9) iHandlerExecutorB).b.post(new Runnable() { // from class: io.appmetrica.analytics.impl.v1$$ExternalSyntheticLambda0
            @Override // java.lang.Runnable
            public final void run() {
                this.f$0.d();
            }
        });
    }

    public final IdentifiersResult b(Context context) {
        this.f.f.a(context);
        C0707wn c0707wn = this.g;
        Context applicationContext = context.getApplicationContext();
        c0707wn.e.a(applicationContext);
        c0707wn.f.a(applicationContext);
        return C0584s4.l().a(context.getApplicationContext()).a();
    }

    public final void a(String str, Map<String, Object> map) {
        N2 n2 = this.f;
        n2.a.a(null);
        n2.r.a(str);
        this.g.getClass();
        List listFromMap = CollectionUtils.getListFromMap(map);
        IHandlerExecutor iHandlerExecutorB = b();
        ((U9) iHandlerExecutorB).b.post(new RunnableC0555r1(this, str, listFromMap));
    }

    public final void b(final Object... objArr) {
        this.f.a.a(null);
        this.g.getClass();
        IHandlerExecutor iHandlerExecutorB = b();
        ((U9) iHandlerExecutorB).b.post(new Runnable() { // from class: io.appmetrica.analytics.impl.v1$$ExternalSyntheticLambda1
            @Override // java.lang.Runnable
            public final void run() {
                C0659v1.a(objArr);
            }
        });
    }

    public final void a(String str, Throwable th) {
        N2 n2 = this.f;
        n2.a.a(null);
        n2.s.a(str);
        this.g.getClass();
        if (th == null) {
            th = new C0116a2();
            th.fillInStackTrace();
        }
        IHandlerExecutor iHandlerExecutorB = b();
        ((U9) iHandlerExecutorB).b.post(new RunnableC0581s1(this, str, th));
    }

    public final void a(String str, String str2, Throwable th) {
        N2 n2 = this.f;
        n2.a.a(null);
        n2.t.a(str);
        this.g.getClass();
        IHandlerExecutor iHandlerExecutorB = b();
        ((U9) iHandlerExecutorB).b.post(new RunnableC0607t1(this, str, str2, th));
    }

    public final void a(Throwable th) {
        N2 n2 = this.f;
        n2.a.a(null);
        n2.u.a(th);
        this.g.getClass();
        IHandlerExecutor iHandlerExecutorB = b();
        ((U9) iHandlerExecutorB).b.post(new RunnableC0633u1(this, th));
    }

    public final void a(String str) {
        N2 n2 = this.f;
        n2.a.a(null);
        n2.i.a(str);
        this.g.getClass();
        IHandlerExecutor iHandlerExecutorB = b();
        ((U9) iHandlerExecutorB).b.post(new P0(this, str));
    }

    public final void a(Intent intent) {
        N2 n2 = this.f;
        n2.a.a(null);
        n2.d.a(intent);
        this.g.getClass();
        IHandlerExecutor iHandlerExecutorB = b();
        ((U9) iHandlerExecutorB).b.post(new Q0(this, intent));
    }

    public final void a(Location location) {
        this.f.getClass();
        this.g.getClass();
        IHandlerExecutor iHandlerExecutorB = b();
        ((U9) iHandlerExecutorB).b.post(new R0(this, location));
    }

    public final void a(boolean z) {
        this.f.getClass();
        this.g.getClass();
        IHandlerExecutor iHandlerExecutorB = b();
        ((U9) iHandlerExecutorB).b.post(new T0(this, z));
    }

    public final void a(UserProfile userProfile) {
        N2 n2 = this.f;
        n2.a.a(null);
        n2.v.a(userProfile);
        this.g.getClass();
        IHandlerExecutor iHandlerExecutorB = b();
        ((U9) iHandlerExecutorB).b.post(new W0(this, userProfile));
    }

    public final void a(Revenue revenue) {
        N2 n2 = this.f;
        n2.a.a(null);
        n2.w.a(revenue);
        this.g.getClass();
        IHandlerExecutor iHandlerExecutorB = b();
        ((U9) iHandlerExecutorB).b.post(new X0(this, revenue));
    }

    public final void a(AdRevenue adRevenue) {
        N2 n2 = this.f;
        n2.a.a(null);
        n2.x.a(adRevenue);
        this.g.getClass();
        IHandlerExecutor iHandlerExecutorB = b();
        ((U9) iHandlerExecutorB).b.post(new Z0(this, adRevenue));
    }

    public final void a(ECommerceEvent eCommerceEvent) {
        N2 n2 = this.f;
        n2.a.a(null);
        n2.y.a(eCommerceEvent);
        this.g.getClass();
        IHandlerExecutor iHandlerExecutorB = b();
        ((U9) iHandlerExecutorB).b.post(new RunnableC0115a1(this, eCommerceEvent));
    }

    public final void a(DeferredDeeplinkParametersListener deferredDeeplinkParametersListener) {
        N2 n2 = this.f;
        n2.a.a(null);
        n2.g.a(deferredDeeplinkParametersListener);
        this.g.getClass();
        IHandlerExecutor iHandlerExecutorB = b();
        ((U9) iHandlerExecutorB).b.post(new RunnableC0141b1(this, deferredDeeplinkParametersListener));
    }

    public final void a(DeferredDeeplinkListener deferredDeeplinkListener) {
        N2 n2 = this.f;
        n2.a.a(null);
        n2.g.a(deferredDeeplinkListener);
        this.g.getClass();
        IHandlerExecutor iHandlerExecutorB = b();
        ((U9) iHandlerExecutorB).b.post(new RunnableC0167c1(this, deferredDeeplinkListener));
    }

    public final InterfaceC0435mb a(Context context, String str) {
        N2 n2 = this.f;
        n2.f.a(context);
        n2.j.a(str);
        C0707wn c0707wn = this.g;
        c0707wn.e.a(context.getApplicationContext());
        return this.c.a(context.getApplicationContext(), str);
    }

    public final void a(Context context, ReporterConfig reporterConfig) {
        N2 n2 = this.f;
        n2.f.a(context);
        n2.h.a(reporterConfig);
        C0707wn c0707wn = this.g;
        c0707wn.e.a(context.getApplicationContext());
        Bi bi = this.c;
        Context applicationContext = context.getApplicationContext();
        if (((C0624ti) bi.a.get(reporterConfig.apiKey)) == null) {
            synchronized (bi.a) {
                try {
                    if (((C0624ti) bi.a.get(reporterConfig.apiKey)) == null) {
                        String str = reporterConfig.apiKey;
                        IHandlerExecutor iHandlerExecutorA = C0584s4.l().c.a();
                        bi.b.getClass();
                        if (A0.e == null) {
                            ((U9) iHandlerExecutorA).b.post(new RunnableC0780zi(bi, applicationContext));
                        }
                        C0624ti c0624ti = new C0624ti(applicationContext.getApplicationContext(), str, new B0());
                        bi.a.put(str, c0624ti);
                        c0624ti.a(reporterConfig);
                    }
                } catch (Throwable th) {
                    throw th;
                }
            }
        }
    }

    public final void a(WebView webView) {
        N2 n2 = this.f;
        n2.a.a(null);
        n2.l.a(webView);
        ap apVar = this.g.b;
        apVar.getClass();
        try {
            if (webView.getSettings().getJavaScriptEnabled()) {
                webView.addJavascriptInterface(new AppMetricaJsInterface(this), "AppMetrica");
                webView.addJavascriptInterface(new AppMetricaInitializerJsInterface(this), "AppMetricaInitializer");
                Xo xo = new Xo();
                synchronized (apVar) {
                    try {
                        PublicLogger publicLogger = apVar.b;
                        if (publicLogger == null) {
                            apVar.a.add(xo);
                        } else {
                            xo.consume(publicLogger);
                        }
                    } catch (Throwable th) {
                        throw th;
                    }
                }
            } else {
                apVar.a(new Yo());
            }
        } catch (Throwable th2) {
            apVar.a(new Zo(th2));
        }
        IHandlerExecutor iHandlerExecutorB = b();
        ((U9) iHandlerExecutorB).b.post(new RunnableC0218e1(this));
    }

    public final String a(Context context) {
        this.f.f.a(context);
        C0707wn c0707wn = this.g;
        c0707wn.e.a(context.getApplicationContext());
        IdentifiersResult identifiersResult = (IdentifiersResult) C0584s4.l().d(context.getApplicationContext()).b.get(StartupParamsCallback.APPMETRICA_DEVICE_ID);
        if (identifiersResult == null) {
            return null;
        }
        return identifiersResult.id;
    }

    public final void a(String str, String str2) {
        this.f.getClass();
        this.g.getClass();
        IHandlerExecutor iHandlerExecutorB = b();
        ((U9) iHandlerExecutorB).b.post(new RunnableC0296h1(this, str, str2));
    }

    public final void a() {
        this.f.getClass();
        this.g.getClass();
        IHandlerExecutor iHandlerExecutorB = b();
        ((U9) iHandlerExecutorB).b.post(new RunnableC0322i1(this));
    }

    public final void a(Context context, StartupParamsCallback startupParamsCallback, List<String> list) {
        N2 n2 = this.f;
        n2.f.a(context);
        n2.o.a(startupParamsCallback);
        C0707wn c0707wn = this.g;
        c0707wn.e.a(context.getApplicationContext());
        IHandlerExecutor iHandlerExecutorB = b();
        ((U9) iHandlerExecutorB).b.post(new RunnableC0373k1(this, context, startupParamsCallback, list));
    }

    public final void a(AnrListener anrListener) {
        N2 n2 = this.f;
        n2.a.a(null);
        n2.p.a(anrListener);
        this.g.getClass();
        IHandlerExecutor iHandlerExecutorB = b();
        ((U9) iHandlerExecutorB).b.post(new RunnableC0399l1(this, anrListener));
    }

    public final void a(ExternalAttribution externalAttribution) {
        N2 n2 = this.f;
        n2.a.a(null);
        n2.q.a(externalAttribution);
        this.g.getClass();
        IHandlerExecutor iHandlerExecutorB = b();
        ((U9) iHandlerExecutorB).b.post(new RunnableC0425m1(this, externalAttribution));
    }

    public static /* synthetic */ void a(Object[] objArr) {
        ModuleAdRevenueProcessor moduleAdRevenueProcessorB = C0584s4.l().m().b();
        if (moduleAdRevenueProcessorB != null) {
            moduleAdRevenueProcessorB.process(objArr);
        }
    }

    public final void a(Map<Thread, StackTraceElement[]> map) {
        this.f.z.a(map);
        this.g.getClass();
        List listFromMap = CollectionUtils.getListFromMap(map);
        IHandlerExecutor iHandlerExecutorB = b();
        ((U9) iHandlerExecutorB).b.post(new RunnableC0451n1(this, listFromMap));
    }

    public static InterfaceC0306hb a(C0659v1 c0659v1) {
        return c0659v1.c().a;
    }
}
