package io.appmetrica.analytics.impl;

import android.os.Bundle;
import android.os.Handler;
import androidx.core.view.InputDeviceCompat;
import io.appmetrica.analytics.DeferredDeeplinkListener;
import io.appmetrica.analytics.DeferredDeeplinkParametersListener;
import io.appmetrica.analytics.logger.appmetrica.internal.PublicLogger;
import java.util.Map;
import java.util.Set;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.tg, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0622tg {
    public final boolean a;
    public final Ji b;
    public final C0517pf c;
    public final C0200d8 d;
    public final Ag e;
    public final Handler f;

    public C0622tg(Ji ji, C0517pf c0517pf, Handler handler) {
        this(ji, c0517pf, handler, c0517pf.s());
    }

    public final void a() {
        if (this.a) {
            return;
        }
        Ji ji = this.b;
        Fg fg = new Fg(this.f, this);
        ji.getClass();
        Bundle bundle = new Bundle();
        bundle.putParcelable("io.appmetrica.analytics.impl.referrer.common.ReferrerResultReceiver", fg);
        PublicLogger anonymousInstance = PublicLogger.getAnonymousInstance();
        Set set = Q9.a;
        EnumC0721xb enumC0721xb = EnumC0721xb.EVENT_TYPE_UNDEFINED;
        C0196d4 c0196d4 = new C0196d4("", "", InputDeviceCompat.SOURCE_TOUCHSCREEN, 0, anonymousInstance);
        c0196d4.m = bundle;
        V4 v4 = ji.a;
        ji.a(Ji.a(c0196d4, v4), v4, 1, (Map) null);
    }

    public C0622tg(Ji ji, C0517pf c0517pf, Handler handler, boolean z) {
        this(ji, c0517pf, handler, z, new C0200d8(z), new Ag());
    }

    public C0622tg(Ji ji, C0517pf c0517pf, Handler handler, boolean z, C0200d8 c0200d8, Ag ag) {
        this.b = ji;
        this.c = c0517pf;
        this.a = z;
        this.d = c0200d8;
        this.e = ag;
        this.f = handler;
    }

    public final void a(C0674vg c0674vg) {
        String str = c0674vg == null ? null : c0674vg.a;
        if (this.a) {
            return;
        }
        synchronized (this) {
            C0200d8 c0200d8 = this.d;
            this.e.getClass();
            c0200d8.d = Ag.a(str);
            c0200d8.a();
        }
    }

    public final synchronized void a(DeferredDeeplinkParametersListener deferredDeeplinkParametersListener) {
        try {
            C0200d8 c0200d8 = this.d;
            c0200d8.c = deferredDeeplinkParametersListener;
            if (c0200d8.a) {
                c0200d8.a(1);
            } else {
                c0200d8.a();
            }
            this.c.u();
        } catch (Throwable th) {
            this.c.u();
            throw th;
        }
    }

    public final synchronized void a(DeferredDeeplinkListener deferredDeeplinkListener) {
        try {
            C0200d8 c0200d8 = this.d;
            c0200d8.b = deferredDeeplinkListener;
            if (c0200d8.a) {
                c0200d8.a(1);
            } else {
                c0200d8.a();
            }
            this.c.u();
        } catch (Throwable th) {
            this.c.u();
            throw th;
        }
    }
}
