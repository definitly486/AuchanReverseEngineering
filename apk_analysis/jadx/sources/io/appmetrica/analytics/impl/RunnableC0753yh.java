package io.appmetrica.analytics.impl;

import android.content.Context;
import android.os.Bundle;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.yh, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class RunnableC0753yh implements Runnable {
    public final Context a;
    public final C0249f6 b;
    public final Bundle c;
    public final C0558r4 d;

    public RunnableC0753yh(Context context, C0249f6 c0249f6, Bundle bundle, C0558r4 c0558r4) {
        this.a = context;
        this.b = c0249f6;
        this.c = bundle;
        this.d = c0558r4;
    }

    @Override // java.lang.Runnable
    public final void run() {
        try {
            Y3 y3A = Y3.a(this.a, this.c);
            if (y3A == null) {
                return;
            }
            C0273g4 c0273g4A = C0273g4.a(y3A);
            C0651uj c0651ujV = Ka.I.v();
            c0651ujV.a(y3A.b.getAppVersion(), y3A.b.getAppBuildNumber());
            c0651ujV.a(y3A.b.getDeviceType());
            G4 g4 = new G4(new C0551qm(y3A), new F4(y3A.b, Cb.c(y3A.a.a.getAsString("PROCESS_CFG_CLIDS"))), y3A.a.b);
            this.d.a(c0273g4A, g4).a(this.b, g4);
        } catch (Throwable th) {
            C0263fk c0263fk = Dj.a;
            String str = "Exception during processing event with type: " + this.b.d + " (" + this.b.e + "): " + th.getMessage();
            c0263fk.getClass();
            c0263fk.a(new Ej(str, th));
        }
    }
}
