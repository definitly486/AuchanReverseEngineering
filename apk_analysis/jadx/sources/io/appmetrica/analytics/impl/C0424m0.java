package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.logger.appmetrica.internal.PublicLogger;
import java.util.HashMap;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.m0, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0424m0 {
    public final HashMap a = new HashMap();

    public final synchronized C0398l0 a(C0274g5 c0274g5, PublicLogger publicLogger, C0544qf c0544qf) {
        C0398l0 c0398l0;
        c0398l0 = (C0398l0) this.a.get(c0274g5.toString());
        if (c0398l0 == null) {
            C0372k0 c0372k0D = c0544qf.d();
            c0398l0 = new C0398l0(c0372k0D.a, c0372k0D.b, new Ll(publicLogger, "[App Environment]"));
            this.a.put(c0274g5.toString(), c0398l0);
        }
        return c0398l0;
    }

    public final synchronized void a(C0372k0 c0372k0, C0544qf c0544qf) {
        c0544qf.a(c0372k0);
    }
}
