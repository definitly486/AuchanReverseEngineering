package io.appmetrica.analytics.impl;

import android.content.Context;
import io.appmetrica.analytics.AppMetricaConfig;
import io.appmetrica.analytics.PreloadInfo;
import io.appmetrica.analytics.coreutils.internal.logger.LoggerStorage;
import io.appmetrica.analytics.internal.CounterConfiguration;
import io.appmetrica.analytics.internal.CounterConfigurationReporterType;
import io.appmetrica.analytics.logger.appmetrica.internal.PublicLogger;

/* JADX INFO: loaded from: classes3.dex */
public final class Nc {
    public final Context a;
    public final Ji b;
    public final Vd c;
    public final C0305ha d;
    public final W8 e;
    public final Sh f;
    public final C0556r2 g;
    public final J6 h;
    public final C0528q i;
    public final C0232ef j;
    public final C0370jo k;
    public final Ng l;
    public final N6 m;
    public final C0243f0 n;

    public Nc(Context context, Wf wf, Ji ji, C0265fm c0265fm) {
        this.a = context;
        this.b = ji;
        this.c = new Vd(wf);
        C0305ha c0305ha = new C0305ha(context);
        this.d = c0305ha;
        W8 w8 = new W8(new Ll(LoggerStorage.getMainPublicOrAnonymousLogger(), "Crash Environment"));
        this.e = w8;
        this.f = new Sh(wf, new CounterConfiguration(CounterConfigurationReporterType.MAIN), w8);
        this.g = new C0556r2();
        this.h = C0584s4.l().n();
        this.i = new C0528q();
        this.j = new C0232ef(c0305ha);
        this.k = new C0370jo();
        this.l = new Ng();
        this.m = new N6();
        this.n = new C0243f0();
    }

    public final C0243f0 a() {
        return this.n;
    }

    public final Context b() {
        return this.a;
    }

    public final N6 c() {
        return this.m;
    }

    public final C0305ha d() {
        return this.d;
    }

    public final C0232ef e() {
        return this.j;
    }

    public final J6 f() {
        return this.h;
    }

    public final Ng g() {
        return this.l;
    }

    public final Sh h() {
        return this.f;
    }

    public final Ji i() {
        return this.b;
    }

    public final C0370jo j() {
        return this.k;
    }

    public final void a(AppMetricaConfig appMetricaConfig, PublicLogger publicLogger) {
        publicLogger.info("Update config with value " + appMetricaConfig.toJson(), new Object[0]);
        this.f.b.applyFromConfig(appMetricaConfig);
        Sh sh = this.f;
        String str = appMetricaConfig.userProfileID;
        synchronized (sh) {
            sh.f = str;
        }
        Sh sh2 = this.f;
        PreloadInfo preloadInfo = appMetricaConfig.preloadInfo;
        Boolean bool = (Boolean) appMetricaConfig.additionalConfig.get("YMM_preloadInfoAutoTracking");
        sh2.d = new Of(preloadInfo, publicLogger, bool != null ? bool.booleanValue() : false);
        StringBuilder sb = new StringBuilder("Actual session timeout is ");
        Integer num = appMetricaConfig.sessionTimeout;
        if (num == null) {
            num = 10;
        }
        sb.append(num.intValue());
        publicLogger.info(sb.toString(), new Object[0]);
    }
}
