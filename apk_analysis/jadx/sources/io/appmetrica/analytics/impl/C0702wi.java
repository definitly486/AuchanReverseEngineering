package io.appmetrica.analytics.impl;

import android.content.Context;
import android.os.Handler;
import com.scanflow.datacapture.barinternal.kotlin.collections.CollectionsKt;
import io.appmetrica.analytics.AppMetricaConfig;
import io.appmetrica.analytics.ReporterConfig;
import io.appmetrica.analytics.coreutils.internal.ApiKeyUtils;
import io.appmetrica.analytics.coreutils.internal.logger.LoggerStorage;
import io.appmetrica.analytics.logger.appmetrica.internal.ImportantLogger;
import io.appmetrica.analytics.logger.appmetrica.internal.PublicLogger;
import java.util.LinkedHashMap;
import java.util.List;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.wi, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0702wi implements InterfaceC0461nb {
    public final Context a;
    public final Wf b;
    public final Ji c;
    public final Handler d;
    public final C0265fm e;
    public final Nc f;
    public final LinkedHashMap g;
    public final Wn h;
    public final List i;
    public Dc j;
    public B6 k;

    public C0702wi(Context context, Wf wf, Ji ji, Handler handler, C0265fm c0265fm) {
        this.a = context;
        this.b = wf;
        this.c = ji;
        this.d = handler;
        this.e = c0265fm;
        this.f = new Nc(context, wf, ji, c0265fm);
        LinkedHashMap linkedHashMap = new LinkedHashMap();
        this.g = linkedHashMap;
        this.h = new Wn(new C0754yi(linkedHashMap));
        this.i = CollectionsKt.listOf((Object[]) new String[]{"20799a27-fa80-4b36-b2db-0f8141f24180", "0e5e9c33-f8c3-4568-86c5-2e4f57523f72"});
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0461nb, io.appmetrica.analytics.impl.InterfaceC0487ob
    public final InterfaceC0461nb a() {
        return this;
    }

    public final C0702wi b() {
        return this;
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0461nb
    /* JADX INFO: renamed from: c, reason: merged with bridge method [inline-methods] */
    public final synchronized Dc b(AppMetricaConfig appMetricaConfig, PublicLogger publicLogger, C0450n0 c0450n0) {
        Dc dc;
        try {
            dc = this.j;
            if (dc != null) {
                Nc nc = this.f;
                nc.getClass();
                publicLogger.info("Update anonymous config with value " + appMetricaConfig.toJson(), new Object[0]);
                nc.f.b.applyFromAnonymousConfig(appMetricaConfig);
            } else {
                this.h.a(appMetricaConfig.apiKey);
                Nc nc2 = this.f;
                nc2.getClass();
                publicLogger.info("Update anonymous config with value " + appMetricaConfig.toJson(), new Object[0]);
                nc2.f.b.applyFromAnonymousConfig(appMetricaConfig);
                dc = new Dc(this.f);
                dc.i = new Kb(this.d, dc);
                C0265fm c0265fm = this.e;
                Sh sh = dc.b;
                if (c0265fm != null) {
                    sh.b.setUuid(c0265fm.g());
                } else {
                    sh.getClass();
                }
                dc.a(appMetricaConfig, c0450n0);
                dc.k();
                this.c.f.c = new C0676vi(dc);
                this.g.put(appMetricaConfig.apiKey, dc);
                this.j = dc;
            }
        } catch (Throwable th) {
            throw th;
        }
        return dc;
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0461nb
    /* JADX INFO: renamed from: d, reason: merged with bridge method [inline-methods] */
    public final synchronized Dc a(AppMetricaConfig appMetricaConfig, PublicLogger publicLogger, C0450n0 c0450n0) {
        Dc dc;
        try {
            dc = this.j;
            if (dc != null) {
                this.f.a(appMetricaConfig, publicLogger);
                dc.a(appMetricaConfig, c0450n0);
                C0584s4.l().getClass();
                this.g.put(appMetricaConfig.apiKey, dc);
            } else {
                this.h.a(appMetricaConfig.apiKey);
                this.f.a(appMetricaConfig, publicLogger);
                dc = new Dc(this.f);
                dc.i = new Kb(this.d, dc);
                C0265fm c0265fm = this.e;
                Sh sh = dc.b;
                if (c0265fm != null) {
                    sh.b.setUuid(c0265fm.g());
                } else {
                    sh.getClass();
                }
                dc.a(appMetricaConfig, c0450n0);
                dc.k();
                this.c.f.c = new C0676vi(dc);
                this.g.put(appMetricaConfig.apiKey, dc);
                C0584s4.l().getClass();
                this.j = dc;
            }
        } catch (Throwable th) {
            throw th;
        }
        return dc;
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0461nb
    public final synchronized InterfaceC0435mb b(ReporterConfig reporterConfig) {
        InterfaceC0435mb interfaceC0435mb;
        try {
            InterfaceC0435mb interfaceC0435mb2 = (InterfaceC0435mb) this.g.get(reporterConfig.apiKey);
            interfaceC0435mb = interfaceC0435mb2;
            if (interfaceC0435mb2 == null) {
                if (!this.i.contains(reporterConfig.apiKey)) {
                    this.e.i();
                }
                Context context = this.a;
                Tc tc = new Tc(context, this.b, reporterConfig, this.c, new C0305ha(context));
                tc.i = new Kb(this.d, tc);
                C0265fm c0265fm = this.e;
                Sh sh = tc.b;
                if (c0265fm != null) {
                    sh.b.setUuid(c0265fm.g());
                } else {
                    sh.getClass();
                }
                tc.k();
                this.g.put(reporterConfig.apiKey, tc);
                interfaceC0435mb = tc;
            }
        } catch (Throwable th) {
            throw th;
        }
        return interfaceC0435mb;
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0461nb
    public final synchronized void a(ReporterConfig reporterConfig) {
        try {
            if (this.g.containsKey(reporterConfig.apiKey)) {
                LoggerStorage.getOrCreatePublicLogger(reporterConfig.apiKey).warning("Reporter with apiKey=%s already exists.", ApiKeyUtils.createPartialApiKey(reporterConfig.apiKey));
            } else {
                b(reporterConfig);
                ImportantLogger.INSTANCE.info("AppMetrica", "Activate reporter with APIKey " + ApiKeyUtils.createPartialApiKey(reporterConfig.apiKey), new Object[0]);
            }
        } catch (Throwable th) {
            throw th;
        }
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0461nb
    public final synchronized InterfaceC0540qb a(AppMetricaConfig appMetricaConfig) {
        B6 b6;
        try {
            b6 = this.k;
            if (b6 != null) {
                b6.a(appMetricaConfig);
            } else {
                B6 b7 = new B6(new C6(this.b, this.f.e, this.c, appMetricaConfig));
                this.k = b7;
                b6 = b7;
            }
        } catch (Throwable th) {
            throw th;
        }
        return b6;
    }
}
