package io.appmetrica.analytics.impl;

import android.os.Handler;
import io.appmetrica.analytics.coreapi.internal.executors.ICommonExecutor;
import io.appmetrica.analytics.coreapi.internal.executors.IHandlerExecutor;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.i4, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0325i4 {
    public final C0299h4 a;
    public volatile U9 b;
    public volatile U9 c;
    public volatile U9 d;

    public C0325i4() {
        this(new C0299h4());
    }

    public final IHandlerExecutor a() {
        if (this.b == null) {
            synchronized (this) {
                try {
                    if (this.b == null) {
                        this.a.getClass();
                        HandlerThreadC0747yb handlerThreadC0747ybA = U9.a("IAA-CDE");
                        this.b = new U9(handlerThreadC0747ybA, handlerThreadC0747ybA.getLooper(), new Handler(handlerThreadC0747ybA.getLooper()));
                    }
                } catch (Throwable th) {
                    throw th;
                }
            }
        }
        return this.b;
    }

    public final IHandlerExecutor b() {
        if (this.d == null) {
            synchronized (this) {
                try {
                    if (this.d == null) {
                        this.a.getClass();
                        HandlerThreadC0747yb handlerThreadC0747ybA = U9.a("IAA-CPT");
                        this.d = new U9(handlerThreadC0747ybA, handlerThreadC0747ybA.getLooper(), new Handler(handlerThreadC0747ybA.getLooper()));
                    }
                } catch (Throwable th) {
                    throw th;
                }
            }
        }
        return this.d;
    }

    public final ICommonExecutor c() {
        if (this.c == null) {
            synchronized (this) {
                try {
                    if (this.c == null) {
                        this.a.getClass();
                        HandlerThreadC0747yb handlerThreadC0747ybA = U9.a("IAA-CRS");
                        this.c = new U9(handlerThreadC0747ybA, handlerThreadC0747ybA.getLooper(), new Handler(handlerThreadC0747ybA.getLooper()));
                    }
                } catch (Throwable th) {
                    throw th;
                }
            }
        }
        return this.c;
    }

    public C0325i4(C0299h4 c0299h4) {
        this.a = c0299h4;
    }
}
