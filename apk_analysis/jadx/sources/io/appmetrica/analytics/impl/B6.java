package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.AppMetricaConfig;
import io.appmetrica.analytics.coreutils.internal.logger.LoggerStorage;
import java.util.Map;

/* JADX INFO: loaded from: classes3.dex */
public final class B6 implements InterfaceC0540qb {
    public final C6 a;
    public final Sh b;

    public B6(C6 c6) {
        this.a = c6;
        this.b = c6.a();
        C0584s4.l().getClass();
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0540qb
    public final void a(C0344io c0344io) {
        Ji ji = this.a.a;
        Ih ihA = ji.a(c0344io, this.b);
        Sh sh = ihA.e;
        InterfaceC0291gm interfaceC0291gm = ji.e;
        if (interfaceC0291gm != null) {
            sh.b.setUuid(((C0265fm) interfaceC0291gm).g());
        } else {
            sh.getClass();
        }
        ji.c.b(ihA);
        LoggerStorage.getMainPublicOrAnonymousLogger().info("Unhandled exception received: " + c0344io, new Object[0]);
    }

    public final void a(AppMetricaConfig appMetricaConfig) {
        Map<String, String> map = appMetricaConfig.errorEnvironment;
        if (map != null) {
            for (Map.Entry<String, String> entry : map.entrySet()) {
                Sh sh = this.b;
                String key = entry.getKey();
                String value = entry.getValue();
                synchronized (sh) {
                    W8 w8 = sh.c;
                    w8.b.b(w8.a, key, value);
                }
            }
        }
    }
}
