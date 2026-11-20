package io.appmetrica.analytics;

import android.content.Context;
import io.appmetrica.analytics.coreutils.internal.ApiKeyUtils;
import io.appmetrica.analytics.impl.C0166c0;
import io.appmetrica.analytics.impl.C0192d0;
import io.appmetrica.analytics.impl.C0584s4;
import io.appmetrica.analytics.impl.H0;
import io.appmetrica.analytics.impl.Xb;
import io.appmetrica.analytics.impl.Yb;
import io.appmetrica.analytics.logger.appmetrica.internal.ImportantLogger;

/* JADX INFO: loaded from: classes3.dex */
public class AppMetricaLibraryAdapter {
    private static H0 a = new H0();

    public static void activate(Context context) {
        H0 h0 = a;
        if (!h0.a.a.a(context).a) {
            ImportantLogger.INSTANCE.info("[AppMetricaLibraryAdapterProxy]", "Activation failed due to context is null", new Object[0]);
            return;
        }
        Yb yb = h0.b;
        Context applicationContext = context.getApplicationContext();
        yb.getClass();
        C0584s4.l().g.a(applicationContext);
        C0584s4.l().b().a(applicationContext, AppMetricaLibraryAdapterConfig.newConfigBuilder().build());
    }

    public static void reportEvent(String str, String str2, String str3) {
        a.a(str, str2, str3);
    }

    public static void setAdvIdentifiersTracking(boolean z) {
        H0 h0 = a;
        if (h0.a.c.a((Void) null).a) {
            h0.b.getClass();
            ModulesFacade.setAdvIdentifiersTracking(z);
        }
    }

    public static void setProxy(H0 h0) {
        a = h0;
    }

    public static void subscribeForAutoCollectedData(Context context, String str) {
        H0 h0 = a;
        h0.getClass();
        ImportantLogger.INSTANCE.info("[AppMetricaLibraryAdapterProxy]", "Subscribe for auto-collected data with api key: " + ApiKeyUtils.createPartialApiKey(str), new Object[0]);
        Xb xb = h0.a;
        if (xb.g.a(str).a && xb.a.a(context).a) {
            h0.b.getClass();
            C0584s4.l().g.a(context);
            C0192d0 c0192d0B = C0584s4.l().b();
            c0192d0B.c.a().executeDelayed(new C0166c0(c0192d0B, context), c0192d0B.d);
            ModulesFacade.subscribeForAutoCollectedData(context, str);
        }
    }

    public static void activate(Context context, AppMetricaLibraryAdapterConfig appMetricaLibraryAdapterConfig) {
        H0 h0 = a;
        Xb xb = h0.a;
        if (xb.a.a(context).a && xb.b.a(appMetricaLibraryAdapterConfig).a) {
            Yb yb = h0.b;
            Context applicationContext = context.getApplicationContext();
            yb.getClass();
            C0584s4.l().g.a(applicationContext);
            C0584s4.l().b().a(applicationContext, appMetricaLibraryAdapterConfig);
            return;
        }
        ImportantLogger.INSTANCE.info("[AppMetricaLibraryAdapterProxy]", "Activation failed due to context is null or invalid config", new Object[0]);
    }
}
