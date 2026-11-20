package io.appmetrica.analytics.impl;

import android.content.Context;
import java.util.concurrent.locks.ReentrantLock;

/* JADX INFO: loaded from: classes3.dex */
public final class R9 {
    public final ReentrantLock a;
    public final C0642ua b;

    public R9(Context context, String str) {
        this(new ReentrantLock(), new C0642ua(context, str));
    }

    public final void a() {
        this.a.lock();
        this.b.a();
    }

    public final void b() {
        this.b.b();
        this.a.unlock();
    }

    public final void c() {
        C0642ua c0642ua = this.b;
        synchronized (c0642ua) {
            c0642ua.b();
            c0642ua.a.delete();
        }
        this.a.unlock();
    }

    public R9(ReentrantLock reentrantLock, C0642ua c0642ua) {
        this.a = reentrantLock;
        this.b = c0642ua;
    }
}
