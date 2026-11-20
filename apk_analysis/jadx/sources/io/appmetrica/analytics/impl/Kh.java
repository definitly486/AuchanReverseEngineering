package io.appmetrica.analytics.impl;

import android.content.Context;
import android.content.Intent;
import android.os.RemoteException;
import androidx.lifecycle.CoroutineLiveDataKt;
import com.scanflow.datacapture.barinternal.kotlin.Unit;
import io.appmetrica.analytics.internal.IAppMetricaService;
import java.util.concurrent.Callable;
import java.util.concurrent.CountDownLatch;

/* JADX INFO: loaded from: classes3.dex */
public abstract class Kh implements Callable {
    public static final Jh d = new Jh();
    public final C0554r0 a;
    public final InterfaceC0627tl b;
    public boolean c;

    public Kh(C0554r0 c0554r0, InterfaceC0627tl interfaceC0627tl) {
        this.a = c0554r0;
        this.b = interfaceC0627tl;
    }

    public abstract void a(IAppMetricaService iAppMetricaService);

    public void a(Throwable th) {
    }

    public final C0554r0 b() {
        return this.a;
    }

    public boolean c() {
        C0554r0 c0554r0 = this.a;
        synchronized (c0554r0) {
            try {
                if (c0554r0.d == null) {
                    c0554r0.e = new CountDownLatch(1);
                    T1 t1 = c0554r0.h;
                    Context context = c0554r0.a;
                    t1.getClass();
                    Intent intentA = T1.a(context);
                    try {
                        c0554r0.g.b(c0554r0.a);
                        c0554r0.a.bindService(intentA, c0554r0.j, 1);
                    } catch (Throwable unused) {
                    }
                }
            } catch (Throwable th) {
                throw th;
            }
        }
        this.a.a(Long.valueOf(CoroutineLiveDataKt.DEFAULT_TIMEOUT));
        return true;
    }

    @Override // java.util.concurrent.Callable
    public /* bridge */ /* synthetic */ Object call() {
        a();
        return Unit.INSTANCE;
    }

    public final boolean d() {
        return this.c;
    }

    public final void a(boolean z) {
        this.c = z;
    }

    public void a() {
        IAppMetricaService iAppMetricaService;
        try {
            if (this.c) {
                return;
            }
            this.c = true;
            int i = 0;
            do {
                C0554r0 c0554r0 = this.a;
                synchronized (c0554r0) {
                    iAppMetricaService = c0554r0.d;
                }
                if (iAppMetricaService != null) {
                    try {
                        a(iAppMetricaService);
                        InterfaceC0627tl interfaceC0627tl = this.b;
                        if (interfaceC0627tl != null && !((C0676vi) interfaceC0627tl).a()) {
                            return;
                        }
                        this.a.c();
                        return;
                    } catch (RemoteException unused) {
                    }
                }
                i++;
                if (!c() || C0142b2.e.get()) {
                    return;
                }
            } while (i < 3);
        } catch (Throwable th) {
            a(th);
        }
    }
}
