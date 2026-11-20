package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreapi.internal.executors.ICommonExecutor;
import io.appmetrica.analytics.coreapi.internal.executors.IHandlerExecutor;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.q2, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0531q2 {
    public final Cc a;
    public final ICommonExecutor b;
    public final long c;
    public boolean d = true;
    public final Runnable e = new Runnable() { // from class: io.appmetrica.analytics.impl.q2$$ExternalSyntheticLambda0
        @Override // java.lang.Runnable
        public final void run() {
            C0531q2.a(this.f$0);
        }
    };

    public C0531q2(Cc cc, IHandlerExecutor iHandlerExecutor, long j) {
        this.a = cc;
        this.b = iHandlerExecutor;
        this.c = j;
    }

    public static final void a(C0531q2 c0531q2) {
        Dc dc = c0531q2.a.a;
        Ji ji = dc.h;
        ji.c.a(dc.b.a);
    }
}
