package io.appmetrica.analytics.impl;

import android.os.Handler;
import io.appmetrica.analytics.logger.appmetrica.internal.PublicLogger;
import java.lang.ref.WeakReference;
import java.util.Map;
import java.util.Set;

/* JADX INFO: loaded from: classes3.dex */
public final class Lb implements Runnable {
    public final WeakReference a;
    public final WeakReference b;

    public Lb(Handler handler, V2 v2) {
        this.a = new WeakReference(handler);
        this.b = new WeakReference(v2);
    }

    @Override // java.lang.Runnable
    public final void run() {
        Handler handler = (Handler) this.a.get();
        V2 v2 = (V2) this.b.get();
        if (handler == null || v2 == null) {
            return;
        }
        boolean zF = v2.b.f();
        if (!zF) {
            PublicLogger publicLogger = v2.c;
            Set set = Q9.a;
            EnumC0721xb enumC0721xb = EnumC0721xb.EVENT_TYPE_UNDEFINED;
            C0196d4 c0196d4 = new C0196d4("", "", 3, 0, publicLogger);
            Ji ji = v2.h;
            Sh sh = v2.b;
            ji.getClass();
            ji.a(Ji.a(c0196d4, sh), sh, 1, (Map) null);
        }
        if (zF) {
            return;
        }
        Kb.a(handler, v2, this);
    }
}
