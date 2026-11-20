package io.appmetrica.analytics.impl;

import android.content.Context;
import android.location.Location;
import android.os.Bundle;
import io.appmetrica.analytics.AdvIdentifiersResult;
import io.appmetrica.analytics.AppMetricaConfig;
import io.appmetrica.analytics.AppMetricaLibraryAdapterConfig;
import io.appmetrica.analytics.DeferredDeeplinkListener;
import io.appmetrica.analytics.DeferredDeeplinkParametersListener;
import io.appmetrica.analytics.ReporterConfig;
import io.appmetrica.analytics.StartupParamsCallback;
import io.appmetrica.analytics.coreapi.internal.lifecycle.ActivityEvent;
import io.appmetrica.analytics.coreutils.internal.ApiKeyUtils;
import io.appmetrica.analytics.coreutils.internal.WrapUtils;
import io.appmetrica.analytics.coreutils.internal.logger.LoggerStorage;
import io.appmetrica.analytics.logger.appmetrica.internal.ImportantLogger;
import io.appmetrica.analytics.logger.appmetrica.internal.PublicLogger;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: loaded from: classes3.dex */
public final class E0 implements InterfaceC0151bb {
    public final Context a;
    public final InterfaceC0125ab b;
    public final C0517pf c;
    public final C0265fm d;
    public final C0622tg e;
    public final Wf f;
    public final C0702wi g;
    public final Ji h;
    public final V7 i;
    public final C0550ql j;
    public volatile Fc k;
    public final C0476o0 l;
    public boolean m;

    public E0(Context context, InterfaceC0125ab interfaceC0125ab) {
        this.a = context;
        this.b = interfaceC0125ab;
        C0517pf c0517pfB = C0584s4.l().b(context);
        this.c = c0517pfB;
        ArrayList arrayListA = Md.a();
        C0584s4 c0584s4L = C0584s4.l();
        c0584s4L.m().a(new C0144b4(context));
        F0.a(context).a(arrayListA);
        Wf wfA = F0.a(context, F0.a(interfaceC0125ab.b(), this));
        this.f = wfA;
        V7 v7J = c0584s4L.j();
        this.i = v7J;
        Ji jiA = F0.a(wfA, context, interfaceC0125ab.getDefaultExecutor());
        this.h = jiA;
        v7J.a(jiA);
        C0265fm c0265fmA = F0.a(context, jiA, interfaceC0125ab.b());
        this.d = c0265fmA;
        jiA.a(c0265fmA);
        this.e = F0.a(jiA, c0517pfB, interfaceC0125ab.b());
        this.g = F0.a(context, wfA, jiA, interfaceC0125ab.b(), c0265fmA);
        this.j = c0584s4L.o();
        this.l = new C0476o0(c0517pfB);
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0151bb
    public final InterfaceC0435mb c(ReporterConfig reporterConfig) {
        return this.g.b(reporterConfig);
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0151bb, io.appmetrica.analytics.impl.InterfaceC0179cd
    public final void clearAppEnvironment() {
        j().clearAppEnvironment();
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0151bb
    public final C0590sa d() {
        return this.d.e();
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0151bb
    public final String e() {
        return this.d.d();
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0151bb
    public final Map<String, String> g() {
        return this.d.b();
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0151bb
    public final AdvIdentifiersResult h() {
        return this.d.a();
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0151bb
    public final Fc i() {
        return this.k;
    }

    public final InterfaceC0306hb j() {
        Fc fc = this.k;
        Intrinsics.checkNotNull(fc);
        return fc.a;
    }

    public final C0702wi k() {
        return this.g;
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0151bb, io.appmetrica.analytics.impl.InterfaceC0179cd
    public final void putAppEnvironmentValue(String str, String str2) {
        j().putAppEnvironmentValue(str, str2);
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0151bb, io.appmetrica.analytics.impl.InterfaceC0179cd
    public final void setDataSendingEnabled(boolean z) {
        j().setDataSendingEnabled(z);
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0151bb, io.appmetrica.analytics.impl.InterfaceC0179cd
    public final void setUserProfileID(String str) {
        j().setUserProfileID(str);
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0151bb
    public final void a(AppMetricaLibraryAdapterConfig appMetricaLibraryAdapterConfig) {
        Boolean bool;
        C0476o0 c0476o0 = this.l;
        C0736y0 c0736y0 = c0476o0.b;
        c0736y0.getClass();
        AppMetricaConfig.Builder builderNewConfigBuilder = AppMetricaConfig.newConfigBuilder("629a824d-c717-4ba5-bc0f-3f3968554d01");
        if (c0736y0.a.b() && Intrinsics.areEqual(c0736y0.b.a, Boolean.TRUE)) {
            builderNewConfigBuilder.handleFirstActivationAsUpdate(true);
        }
        Boolean bool2 = appMetricaLibraryAdapterConfig.advIdentifiersTracking;
        if (bool2 == null) {
            bool2 = Boolean.FALSE;
        }
        builderNewConfigBuilder.withAdvIdentifiersTracking(bool2.booleanValue());
        AppMetricaConfig appMetricaConfigBuild = builderNewConfigBuilder.build();
        AppMetricaConfig.Builder builderF = c0476o0.a.f();
        if (builderF != null) {
            if (builderF.build().advIdentifiersTracking == null && (bool = appMetricaConfigBuild.advIdentifiersTracking) != null) {
                builderF.withAdvIdentifiersTracking(bool.booleanValue());
            }
            appMetricaConfigBuild = builderF.build();
        }
        PublicLogger mainPublicOrAnonymousLogger = LoggerStorage.getMainPublicOrAnonymousLogger();
        if (a(mainPublicOrAnonymousLogger, appMetricaConfigBuild, new D0(this, appMetricaConfigBuild, mainPublicOrAnonymousLogger), false)) {
            ImportantLogger.INSTANCE.info("AppMetrica", "Activate AppMetrica in anonymous mode", new Object[0]);
        }
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0151bb
    public final void b(AppMetricaConfig appMetricaConfig) {
        boolean z;
        PublicLogger orCreateMainPublicLogger = LoggerStorage.getOrCreateMainPublicLogger(appMetricaConfig.apiKey);
        boolean zA = a(orCreateMainPublicLogger, appMetricaConfig, new C0(this, appMetricaConfig, orCreateMainPublicLogger), true);
        if (zA || this.m) {
            z = false;
        } else {
            a(orCreateMainPublicLogger, appMetricaConfig, true);
            z = true;
        }
        if (zA || z) {
            this.c.a(appMetricaConfig);
        } else {
            orCreateMainPublicLogger.warning("AppMetrica SDK already has been activated", new Object[0]);
        }
        if (zA) {
            ImportantLogger.INSTANCE.info("AppMetrica", "Activate AppMetrica with APIKey " + ApiKeyUtils.createPartialApiKey(appMetricaConfig.apiKey), new Object[0]);
        }
        if (z) {
            ImportantLogger.INSTANCE.info("AppMetrica", "Upgrade AppMetrica anonymous mode to normal with APIKey " + ApiKeyUtils.createPartialApiKey(appMetricaConfig.apiKey), new Object[0]);
        }
        this.m = true;
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0151bb, io.appmetrica.analytics.impl.S6
    public final void a(int i, Bundle bundle) {
        this.d.b(bundle, null);
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0151bb
    public final void a(DeferredDeeplinkParametersListener deferredDeeplinkParametersListener) {
        this.e.a(deferredDeeplinkParametersListener);
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0151bb
    public final void a(DeferredDeeplinkListener deferredDeeplinkListener) {
        this.e.a(deferredDeeplinkListener);
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0151bb
    public final void a(ReporterConfig reporterConfig) {
        this.g.a(reporterConfig);
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0151bb
    public final void a(StartupParamsCallback startupParamsCallback, List<String> list) {
        this.d.a(startupParamsCallback, list, Cb.c(this.f.a.getAsString("PROCESS_CFG_CLIDS")));
    }

    public final boolean a(PublicLogger publicLogger, AppMetricaConfig appMetricaConfig, Rc rc, boolean z) {
        int i = 0;
        if (this.k == null) {
            a(publicLogger, appMetricaConfig, z);
            this.e.a();
            Dc dcA = rc.a();
            Q7 q7 = new Q7(dcA);
            Fc fc = new Fc(dcA, q7);
            this.b.c().a(q7);
            this.k = fc;
            C5 c5 = this.j.b;
            synchronized (c5) {
                try {
                    c5.a = dcA;
                    ArrayList arrayList = c5.b;
                    int size = arrayList.size();
                    while (i < size) {
                        Object obj = arrayList.get(i);
                        i++;
                        ((InterfaceC0672ve) obj).consume(dcA);
                    }
                    c5.b.clear();
                } catch (Throwable th) {
                    throw th;
                }
            }
            return true;
        }
        rc.a();
        return false;
    }

    public final void a(PublicLogger publicLogger, AppMetricaConfig appMetricaConfig, boolean z) {
        Boolean bool = appMetricaConfig.logs;
        Boolean bool2 = Boolean.TRUE;
        if (bool2.equals(bool)) {
            publicLogger.setEnabled(true);
            PublicLogger.Companion.getAnonymousInstance().setEnabled(true);
        } else {
            publicLogger.setEnabled(false);
            PublicLogger.Companion.getAnonymousInstance().setEnabled(false);
        }
        if (((Boolean) WrapUtils.getOrDefault(appMetricaConfig.crashReporting, bool2)).booleanValue()) {
            this.b.d().a(this.a, appMetricaConfig, this);
            this.b.d().b();
            publicLogger.info("Register application crash handler", new Object[0]);
        } else {
            this.b.d().a();
            publicLogger.info("Disable all crash handlers", new Object[0]);
        }
        if (((Boolean) WrapUtils.getOrDefault(appMetricaConfig.sessionsAutoTrackingEnabled, bool2)).booleanValue()) {
            this.j.a();
        } else {
            C0550ql c0550ql = this.j;
            synchronized (c0550ql) {
                if (c0550ql.g) {
                    c0550ql.a.unregisterListener(c0550ql.c, ActivityEvent.RESUMED);
                    c0550ql.a.unregisterListener(c0550ql.d, ActivityEvent.PAUSED);
                    c0550ql.g = false;
                }
            }
        }
        this.f.d(appMetricaConfig);
        C0265fm c0265fm = this.d;
        c0265fm.e = publicLogger;
        c0265fm.b(appMetricaConfig.customHosts);
        C0265fm c0265fm2 = this.d;
        Object obj = appMetricaConfig.additionalConfig.get("YMM_clids");
        c0265fm2.a(obj instanceof Map ? (Map) obj : null);
        String str = (String) appMetricaConfig.additionalConfig.get("YMM_distributionReferrer");
        this.d.a(str);
        if (str != null) {
            this.d.b("api");
        }
        this.h.a(appMetricaConfig.locationTracking, appMetricaConfig.dataSendingEnabled, appMetricaConfig.advIdentifiersTracking, Boolean.valueOf(z));
        this.d.i();
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0151bb, io.appmetrica.analytics.impl.InterfaceC0179cd
    public final void a(Location location) {
        j().a(location);
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0151bb, io.appmetrica.analytics.impl.InterfaceC0179cd
    public final void a(boolean z) {
        j().a(z);
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0151bb, io.appmetrica.analytics.impl.InterfaceC0179cd
    public final void a(boolean z, boolean z2) {
        j().a(z, z2);
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0151bb, io.appmetrica.analytics.impl.InterfaceC0179cd
    public final void a(String str, String str2) {
        j().a(str, str2);
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0151bb, io.appmetrica.analytics.impl.InterfaceC0179cd
    public final void a(String str) {
        j().a(str);
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0151bb, io.appmetrica.analytics.impl.InterfaceC0487ob
    public final InterfaceC0461nb a() {
        return this.g;
    }
}
