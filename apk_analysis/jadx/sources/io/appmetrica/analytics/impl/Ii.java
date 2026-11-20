package io.appmetrica.analytics.impl;

import android.text.TextUtils;
import io.appmetrica.analytics.coreapi.internal.executors.ICommonExecutor;
import java.util.concurrent.TimeUnit;

/* JADX INFO: loaded from: classes3.dex */
public final class Ii extends Bn {
    public final Hi d;
    public final ICommonExecutor e;

    public Ii(C0455n5 c0455n5, InterfaceC0162bm interfaceC0162bm, ICommonExecutor iCommonExecutor) {
        super(c0455n5, interfaceC0162bm);
        this.d = new Hi(this);
        this.e = iCommonExecutor;
    }

    @Override // io.appmetrica.analytics.impl.Bn
    public final void a() {
        this.e.remove(this.d);
    }

    @Override // io.appmetrica.analytics.impl.Bn
    public final void f() {
        this.b.a();
        C0727xh c0727xh = (C0727xh) ((C0455n5) this.a).k.a();
        if (c0727xh.k.a(c0727xh.j)) {
            String str = c0727xh.m;
            if (TextUtils.isEmpty(str) || "-1".equals(str)) {
                return;
            }
            try {
                a(C0543qe.a((C0455n5) this.a));
            } catch (Throwable unused) {
            }
        }
    }

    @Override // io.appmetrica.analytics.impl.Bn
    public final void g() {
        this.e.executeDelayed(this.d, TimeUnit.SECONDS.toMillis(1L));
    }

    public final void h() {
        if (this.c.get()) {
            return;
        }
        this.e.remove(this.d);
        if (((C0727xh) ((C0455n5) this.a).k.a()).g > 0) {
            this.e.executeDelayed(this.d, TimeUnit.SECONDS.toMillis(((C0727xh) ((C0455n5) this.a).k.a()).g));
        }
    }
}
