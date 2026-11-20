package io.appmetrica.analytics.impl;

import android.os.Bundle;
import android.os.Looper;
import io.appmetrica.analytics.coreapi.internal.executors.ICommonExecutor;
import io.appmetrica.analytics.coreutils.internal.time.SystemTimeProvider;
import io.appmetrica.analytics.coreutils.internal.time.TimeProvider;
import java.util.concurrent.TimeUnit;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: loaded from: classes3.dex */
public final class Li implements InterfaceC0652uk {
    public static final Ki e = new Ki();
    public static final long f;
    public static final long g;
    public final C0554r0 a;
    public final C0522pk b;
    public final TimeProvider c;
    public final ICommonExecutor d;

    static {
        TimeUnit timeUnit = TimeUnit.SECONDS;
        f = timeUnit.toMillis(1L);
        g = timeUnit.toMillis(4L);
    }

    public Li(C0554r0 c0554r0, C0522pk c0522pk, TimeProvider timeProvider) {
        this.a = c0554r0;
        this.b = c0522pk;
        this.c = timeProvider;
        this.d = C0584s4.l().g().c();
    }

    public final void a(Ih ih) {
        Kh yg;
        ICommonExecutor iCommonExecutor = this.d;
        if (ih.b) {
            C0522pk c0522pk = this.b;
            yg = new C0586s6(c0522pk.a, c0522pk.b, c0522pk.c, ih, true);
        } else {
            C0522pk c0522pk2 = this.b;
            yg = new Yg(c0522pk2.b, c0522pk2.c, ih);
        }
        iCommonExecutor.submit(yg);
    }

    public final void b(Ih ih) {
        long jUptimeMillis = this.c.uptimeMillis();
        C0522pk c0522pk = this.b;
        C0586s6 c0586s6 = new C0586s6(c0522pk.a, c0522pk.b, c0522pk.c, ih, false);
        long j = Intrinsics.areEqual(Looper.myLooper(), Looper.getMainLooper()) ? f : g;
        if (this.a.a()) {
            try {
                this.d.submit(c0586s6).get(j, TimeUnit.MILLISECONDS);
            } catch (Throwable unused) {
            }
        }
        if (c0586s6.c) {
            return;
        }
        try {
            c0586s6.a();
            Thread.sleep(Math.max(0L, j - (this.c.uptimeMillis() - jUptimeMillis)));
        } catch (Throwable unused2) {
        }
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0652uk
    public final void reportData(int i, Bundle bundle) {
        ICommonExecutor iCommonExecutor = this.d;
        C0522pk c0522pk = this.b;
        iCommonExecutor.submit(new C0267fo(c0522pk.b, c0522pk.c, i, bundle));
    }

    public Li(C0554r0 c0554r0, C0522pk c0522pk) {
        this(c0554r0, c0522pk, new SystemTimeProvider());
    }

    public final void a(Wf wf) {
        ICommonExecutor iCommonExecutor = this.d;
        C0522pk c0522pk = this.b;
        iCommonExecutor.submit(new Me(c0522pk.b, c0522pk.c, wf));
    }

    public final void b(Wf wf) {
        ICommonExecutor iCommonExecutor = this.d;
        C0522pk c0522pk = this.b;
        iCommonExecutor.submit(new Ri(c0522pk.b, c0522pk.c, wf));
    }
}
