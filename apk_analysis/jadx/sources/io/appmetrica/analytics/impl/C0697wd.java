package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreapi.internal.executors.IHandlerExecutor;
import io.appmetrica.analytics.coreutils.internal.time.SystemTimeProvider;
import java.util.ArrayList;
import java.util.List;
import java.util.concurrent.Executor;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.wd, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0697wd {
    public final Executor a;
    public final Ol b;
    public final String c;
    public final SystemTimeProvider d;

    public C0697wd(IHandlerExecutor iHandlerExecutor, Sd sd, String str, SystemTimeProvider systemTimeProvider) {
        this.a = iHandlerExecutor;
        this.b = sd;
        this.c = str;
        this.d = systemTimeProvider;
    }

    public static final void a(C0697wd c0697wd, List list) {
        C0263fk c0263fk = Dj.a;
        C0749yd c0749yd = new C0749yd(c0697wd.b, c0697wd.c, c0697wd.d, list);
        c0263fk.getClass();
        c0263fk.a(new Tj(c0749yd));
    }

    public final void a(final ArrayList arrayList) {
        this.a.execute(new Runnable() { // from class: io.appmetrica.analytics.impl.wd$$ExternalSyntheticLambda0
            @Override // java.lang.Runnable
            public final void run() {
                C0697wd.a(this.f$0, arrayList);
            }
        });
    }
}
