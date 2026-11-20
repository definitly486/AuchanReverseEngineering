package io.appmetrica.analytics.impl;

import android.content.Context;
import io.appmetrica.analytics.coreapi.internal.executors.IHandlerExecutor;
import java.util.HashMap;

/* JADX INFO: loaded from: classes3.dex */
public final class Bi {
    public final HashMap a = new HashMap();
    public final B0 b;

    public Bi(B0 b0) {
        this.b = b0;
    }

    public static Bi a() {
        return Ai.a;
    }

    public final C0624ti a(Context context, String str) {
        C0624ti c0624ti;
        C0624ti c0624ti2 = (C0624ti) this.a.get(str);
        if (c0624ti2 != null) {
            return c0624ti2;
        }
        synchronized (this.a) {
            try {
                c0624ti = (C0624ti) this.a.get(str);
                if (c0624ti == null) {
                    IHandlerExecutor iHandlerExecutorA = C0584s4.l().c.a();
                    this.b.getClass();
                    if (A0.e == null) {
                        ((U9) iHandlerExecutorA).b.post(new RunnableC0780zi(this, context));
                    }
                    c0624ti = new C0624ti(context.getApplicationContext(), str, new B0());
                    this.a.put(str, c0624ti);
                    c0624ti.c(str);
                }
            } catch (Throwable th) {
                throw th;
            }
        }
        return c0624ti;
    }
}
