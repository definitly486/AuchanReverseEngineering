package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreutils.internal.time.SystemTimeProvider;
import io.appmetrica.analytics.coreutils.internal.time.TimeProvider;
import java.util.concurrent.TimeUnit;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.ok, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0496ok {
    public volatile long a;
    public C0621tf b;
    public TimeProvider c;

    public static C0496ok c() {
        return AbstractC0470nk.a;
    }

    public final synchronized long a() {
        return (System.currentTimeMillis() / 1000) + this.a;
    }

    public final synchronized void b() {
        this.b.d(false);
    }

    public final synchronized long d() {
        return this.a;
    }

    public final synchronized void e() {
        a(Ka.I.y(), new SystemTimeProvider());
    }

    public final synchronized boolean f() {
        return this.b.b(true);
    }

    public final synchronized void a(long j, Long l) {
        try {
            this.a = (j - this.c.currentTimeMillis()) / 1000;
            boolean z = true;
            if (this.b.b(true)) {
                if (l != null) {
                    long jAbs = Math.abs(j - this.c.currentTimeMillis());
                    C0621tf c0621tf = this.b;
                    if (jAbs <= TimeUnit.SECONDS.toMillis(l.longValue())) {
                        z = false;
                    }
                    c0621tf.d(z);
                } else {
                    this.b.d(false);
                }
            }
            this.b.b(this.a);
        } catch (Throwable th) {
            throw th;
        }
    }

    public final void a(C0621tf c0621tf, TimeProvider timeProvider) {
        this.b = c0621tf;
        this.a = c0621tf.a(0);
        this.c = timeProvider;
    }
}
