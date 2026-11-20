package io.appmetrica.analytics;

import android.content.Context;
import io.appmetrica.analytics.impl.Ai;
import io.appmetrica.analytics.impl.B0;
import io.appmetrica.analytics.impl.Bd;
import io.appmetrica.analytics.impl.C0775zd;
import io.appmetrica.analytics.impl.Cd;
import io.appmetrica.analytics.impl.Dd;
import io.appmetrica.analytics.impl.Ed;
import io.appmetrica.analytics.impl.Fd;
import io.appmetrica.analytics.impl.Gd;
import io.appmetrica.analytics.impl.Hd;

/* JADX INFO: loaded from: classes3.dex */
public final class ModulesFacade {
    public static final int EXTERNAL_ATTRIBUTION_ADJUST = 2;
    public static final int EXTERNAL_ATTRIBUTION_AIRBRIDGE = 5;
    public static final int EXTERNAL_ATTRIBUTION_APPSFLYER = 1;
    public static final int EXTERNAL_ATTRIBUTION_KOCHAVA = 3;
    public static final int EXTERNAL_ATTRIBUTION_SINGULAR = 6;
    public static final int EXTERNAL_ATTRIBUTION_TENJIN = 4;
    private static Hd a = new Hd();

    public static IModuleReporter getModuleReporter(Context context, String str) {
        Hd hd = a;
        C0775zd c0775zd = hd.b;
        c0775zd.b.a(context);
        c0775zd.d.a(str);
        hd.c.a.a(context.getApplicationContext().getApplicationContext());
        return Ai.a.a(context.getApplicationContext(), str);
    }

    public static boolean isActivatedForApp() {
        Hd hd = a;
        hd.b.getClass();
        hd.c.getClass();
        hd.a.getClass();
        return B0.a();
    }

    public static void reportAdRevenue(AdRevenue adRevenue) {
        reportAdRevenue(adRevenue, Boolean.TRUE);
    }

    public static void reportEvent(ModuleEvent moduleEvent) {
        Hd hd = a;
        hd.b.a.a(null);
        hd.c.getClass();
        hd.d.execute(new Cd(hd, moduleEvent));
    }

    public static void reportExternalAttribution(int i, String str) {
        Hd hd = a;
        hd.b.getClass();
        hd.c.getClass();
        hd.d.execute(new Dd(hd, i, str));
    }

    public static void sendEventsBuffer() {
        Hd hd = a;
        hd.b.getClass();
        hd.c.getClass();
        AppMetrica.sendEventsBuffer();
    }

    public static void setAdvIdentifiersTracking(boolean z) {
        Hd hd = a;
        hd.b.getClass();
        hd.c.getClass();
        hd.d.execute(new Ed(hd, z));
    }

    public static void setProxy(Hd hd) {
        a = hd;
    }

    public static void setSessionExtra(String str, byte[] bArr) {
        Hd hd = a;
        hd.b.c.a(str);
        hd.c.getClass();
        hd.d.execute(new Fd(hd, str, bArr));
    }

    public static void subscribeForAutoCollectedData(Context context, String str) {
        Hd hd = a;
        C0775zd c0775zd = hd.b;
        c0775zd.b.a(context);
        c0775zd.d.a(str);
        hd.c.a.a(context.getApplicationContext());
        hd.d.execute(new Gd(str));
    }

    public static void reportAdRevenue(AdRevenue adRevenue, Boolean bool) {
        Hd hd = a;
        boolean zBooleanValue = bool.booleanValue();
        hd.b.getClass();
        hd.c.getClass();
        hd.d.execute(new Bd(hd, adRevenue, zBooleanValue));
    }
}
