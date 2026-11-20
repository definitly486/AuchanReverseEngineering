package io.appmetrica.analytics.impl;

import android.app.Activity;
import android.content.Context;
import android.location.Location;
import io.appmetrica.analytics.AnrListener;
import io.appmetrica.analytics.AppMetricaConfig;
import io.appmetrica.analytics.ExternalAttribution;
import io.appmetrica.analytics.coreapi.internal.backport.Consumer;
import io.appmetrica.analytics.coreutils.internal.WrapUtils;
import io.appmetrica.analytics.coreutils.internal.collection.CollectionUtils;
import io.appmetrica.analytics.coreutils.internal.io.FileUtils;
import io.appmetrica.analytics.internal.CounterConfigurationReporterType;
import io.appmetrica.analytics.logger.appmetrica.internal.PublicLogger;
import io.appmetrica.analytics.ndkcrashesapi.internal.NativeCrashClientConfig;
import io.appmetrica.analytics.ndkcrashesapi.internal.NativeCrashClientModule;
import java.io.File;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Set;
import java.util.concurrent.TimeUnit;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: loaded from: classes3.dex */
public final class Dc extends V2 implements InterfaceC0306hb {
    public static final Long r = Long.valueOf(TimeUnit.SECONDS.toMillis(1));
    public final Nc p;
    public final Ec q;

    public Dc(Nc nc) {
        super(nc.b(), nc.i(), nc.h(), nc.d(), nc.f(), nc.j(), nc.g(), nc.c(), nc.a(), nc.e());
        this.p = nc;
        this.q = new Ec(this);
        l();
    }

    public final void a(AppMetricaConfig appMetricaConfig, C0450n0 c0450n0) {
        if (c0450n0.b) {
            clearAppEnvironment();
        }
        List<String> list = c0450n0.a;
        if (!CollectionUtils.isNullOrEmpty(list)) {
            this.b.b.addAutoCollectedDataSubscribers(list);
        }
        a(appMetricaConfig.appEnvironment);
        b(appMetricaConfig.errorEnvironment);
        Boolean bool = (Boolean) WrapUtils.getOrDefault(appMetricaConfig.nativeCrashReporting, Boolean.TRUE);
        boolean zBooleanValue = bool.booleanValue();
        this.c.info("native crash reporting enabled: %b", bool);
        if (zBooleanValue) {
            Vd vd = this.p.c;
            Context context = this.a;
            vd.d = new J0(this.b.b.getApiKey(), vd.a.a.getAsString("PROCESS_CFG_PACKAGE_NAME"), CounterConfigurationReporterType.MAIN, vd.a.a.getAsInteger("PROCESS_CFG_PROCESS_ID").intValue(), vd.a.a.getAsString("PROCESS_CFG_PROCESS_SESSION_ID"), this.b.d());
            File nativeCrashDirectory = FileUtils.getNativeCrashDirectory(context);
            J0 j0 = null;
            String absolutePath = nativeCrashDirectory != null ? nativeCrashDirectory.getAbsolutePath() : null;
            if (absolutePath != null) {
                NativeCrashClientModule nativeCrashClientModule = vd.b;
                K0 k0 = vd.c;
                J0 j1 = vd.d;
                if (j1 == null) {
                    Intrinsics.throwUninitializedPropertyAccessException("nativeCrashMetadata");
                } else {
                    j0 = j1;
                }
                k0.getClass();
                nativeCrashClientModule.initHandling(context, new NativeCrashClientConfig(absolutePath, K0.a(j0)));
            }
        }
        Ec ec = this.q;
        synchronized (ec) {
            try {
                Integer num = appMetricaConfig.anrMonitoringTimeout;
                ec.a = num != null ? num.intValue() : 5;
                Boolean bool2 = appMetricaConfig.anrMonitoring;
                if (bool2 == null) {
                    bool2 = Boolean.FALSE;
                }
                if (bool2.booleanValue()) {
                    ec.b.a(ec.a);
                } else {
                    ec.b.b();
                }
            } catch (Throwable th) {
                throw th;
            }
        }
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0306hb
    public final void b(Activity activity) {
        if (this.p.i.a(activity, EnumC0501p.PAUSED)) {
            this.c.info("Pause session", new Object[0]);
            c(activity != null ? activity.getClass().getSimpleName() : null);
            C0556r2 c0556r2 = this.p.g;
            synchronized (c0556r2) {
                for (C0531q2 c0531q2 : c0556r2.a) {
                    if (!c0531q2.d) {
                        c0531q2.d = true;
                        c0531q2.b.executeDelayed(c0531q2.e, c0531q2.c);
                    }
                }
            }
        }
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0306hb
    public final void c() {
        Ec ec = this.q;
        synchronized (ec) {
            ec.b.a(ec.a);
        }
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0306hb
    public final List<String> f() {
        return this.b.a.b();
    }

    @Override // io.appmetrica.analytics.impl.V2
    public final String j() {
        return "[MainReporter]";
    }

    @Override // io.appmetrica.analytics.impl.V2
    public final void k() {
        super.k();
        C0584s4.l().m().c();
    }

    public final void l() {
        Ji ji = this.h;
        ji.c.a(this.b.a);
        C0556r2 c0556r2 = this.p.g;
        Cc cc = new Cc(this);
        long jLongValue = r.longValue();
        synchronized (c0556r2) {
            c0556r2.a(cc, jLongValue);
        }
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0306hb
    public final void a(String str, boolean z) {
        this.c.info("App opened via deeplink: " + WrapUtils.wrapToTag(str), new Object[0]);
        Ji ji = this.h;
        PublicLogger publicLogger = this.c;
        Set set = Q9.a;
        HashMap map = new HashMap();
        map.put("type", "open");
        map.put("link", str);
        map.put("auto", Boolean.valueOf(z));
        String strB = Cb.b(map);
        EnumC0721xb enumC0721xb = EnumC0721xb.EVENT_TYPE_UNDEFINED;
        C0196d4 c0196d4 = new C0196d4(strB, "", 8208, 0, publicLogger);
        Sh sh = this.b;
        ji.getClass();
        ji.a(Ji.a(c0196d4, sh), sh, 1, (Map) null);
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0306hb
    public final void a(EnumC0449n enumC0449n) {
        if (enumC0449n == EnumC0449n.b) {
            this.c.info("Enable activity auto tracking", new Object[0]);
            return;
        }
        this.c.warning("Could not enable activity auto tracking. " + enumC0449n.a, new Object[0]);
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0306hb
    public final void a(Activity activity) {
        if (this.p.i.a(activity, EnumC0501p.RESUMED)) {
            this.c.info("Resume session", new Object[0]);
            d(activity != null ? activity.getClass().getSimpleName() : null);
            C0556r2 c0556r2 = this.p.g;
            synchronized (c0556r2) {
                for (C0531q2 c0531q2 : c0556r2.a) {
                    if (c0531q2.d) {
                        c0531q2.d = false;
                        c0531q2.b.remove(c0531q2.e);
                        Dc dc = c0531q2.a.a;
                        dc.h.c.b(dc.b.a);
                    }
                }
            }
        }
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0306hb, io.appmetrica.analytics.impl.InterfaceC0179cd
    public final void a(Location location) {
        this.b.b.setManualLocation(location);
        this.c.info("Set location: %s", location);
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0306hb, io.appmetrica.analytics.impl.InterfaceC0179cd
    public final void a(boolean z) {
        this.b.b.setLocationTracking(z);
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0306hb, io.appmetrica.analytics.impl.InterfaceC0179cd
    public final void a(boolean z, boolean z2) {
        this.c.info("Set advIdentifiersTracking to %s", Boolean.valueOf(z));
        this.b.b.setAdvIdentifiersTracking(z, z2);
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0306hb
    public final void a(ap apVar) {
        PublicLogger publicLogger = this.c;
        synchronized (apVar) {
            apVar.b = publicLogger;
        }
        ArrayList arrayList = apVar.a;
        int size = arrayList.size();
        int i = 0;
        while (i < size) {
            Object obj = arrayList.get(i);
            i++;
            ((Consumer) obj).consume(publicLogger);
        }
        apVar.a.clear();
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0306hb
    public final void a(AnrListener anrListener) {
        this.q.a(anrListener);
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0306hb
    public final void a(ExternalAttribution externalAttribution) {
        this.c.info("External attribution received: %s", externalAttribution);
        Ji ji = this.h;
        byte[] bytes = externalAttribution.toBytes();
        PublicLogger publicLogger = this.c;
        Set set = Q9.a;
        EnumC0721xb enumC0721xb = EnumC0721xb.EVENT_TYPE_UNDEFINED;
        C0196d4 c0196d4 = new C0196d4(bytes, "", 42, publicLogger);
        Sh sh = this.b;
        ji.getClass();
        ji.a(Ji.a(c0196d4, sh), sh, 1, (Map) null);
    }

    @Override // io.appmetrica.analytics.impl.V2, io.appmetrica.analytics.impl.InterfaceC0306hb, io.appmetrica.analytics.impl.InterfaceC0179cd
    public final void a(String str, String str2) {
        super.a(str, str2);
        Vd vd = this.p.c;
        String strD = this.b.d();
        J0 j0 = vd.d;
        if (j0 != null) {
            J0 j1 = new J0(j0.a, j0.b, j0.c, j0.d, j0.e, strD);
            vd.d = j1;
            NativeCrashClientModule nativeCrashClientModule = vd.b;
            vd.c.getClass();
            nativeCrashClientModule.updateAppMetricaMetadata(K0.a(j1));
        }
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0306hb, io.appmetrica.analytics.impl.InterfaceC0179cd
    public final void a(String str) {
        this.c.info("Add auto collected data subscriber: %s", str);
        this.b.b.addAutoCollectedDataSubscriber(str);
    }
}
