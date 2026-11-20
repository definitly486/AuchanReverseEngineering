package io.appmetrica.analytics.impl;

import android.os.Bundle;
import io.appmetrica.analytics.coreapi.internal.backport.Consumer;
import io.appmetrica.analytics.coreutils.internal.logger.LoggerStorage;
import io.appmetrica.analytics.logger.appmetrica.internal.PublicLogger;
import java.util.Set;

/* JADX INFO: loaded from: classes3.dex */
public final class Wd implements Consumer {
    public final C0157bh a;
    public final J0 b;
    public final C0257fe c;

    public Wd(C0157bh c0157bh, J0 j0, C0257fe c0257fe) {
        this.a = c0157bh;
        this.b = j0;
        this.c = c0257fe;
    }

    @Override // io.appmetrica.analytics.coreapi.internal.backport.Consumer
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final void consume(String str) {
        C0157bh c0157bh = this.a;
        J0 j0 = this.b;
        String str2 = j0.a;
        String str3 = j0.b;
        Integer numValueOf = Integer.valueOf(j0.d);
        J0 j1 = this.b;
        C0273g4 c0273g4 = new C0273g4(str2, str3, numValueOf, j1.e, j1.c);
        C0257fe c0257fe = this.c;
        EnumC0721xb enumC0721xb = c0257fe.b;
        I0 i0 = c0257fe.a;
        String str4 = i0.c;
        PublicLogger orCreatePublicLogger = LoggerStorage.getOrCreatePublicLogger(i0.f.a);
        long jA = ((G6) c0257fe.c).a(c0257fe.a);
        Set set = Q9.a;
        Bundle bundle = new Bundle();
        bundle.putString("payload_crash_id", str4);
        C0196d4 c0196d4 = new C0196d4("", "", enumC0721xb.a, orCreatePublicLogger);
        c0196d4.b(jA);
        if (str != null) {
            c0196d4.f(str);
        }
        c0196d4.m = bundle;
        c0196d4.c = c0257fe.a.f.f;
        c0157bh.a(c0273g4, c0196d4, new G4(new C0551qm(), new F4(), null));
    }
}
