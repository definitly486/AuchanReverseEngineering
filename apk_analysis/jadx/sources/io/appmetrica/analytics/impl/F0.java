package io.appmetrica.analytics.impl;

import android.content.Context;
import android.os.Handler;
import io.appmetrica.analytics.coreapi.internal.executors.ICommonExecutor;
import io.appmetrica.analytics.coreutils.internal.time.SystemTimeProvider;

/* JADX INFO: loaded from: classes3.dex */
public abstract class F0 {
    public static T6 a(Handler handler, E0 e0) {
        return new T6(handler, e0);
    }

    public static Wf a(Context context, T6 t6) {
        return new Wf(context, t6);
    }

    public static Ji a(Wf wf, Context context, ICommonExecutor iCommonExecutor) {
        C0554r0 c0554r0 = new C0554r0(context, iCommonExecutor);
        return new Ji(c0554r0, new C0396ko(new Hb()), new V4(wf), new C0522pk(context, c0554r0));
    }

    public static C0265fm a(Context context, Ji ji, Handler handler) {
        return new C0265fm(ji, C0584s4.l().d(context), handler);
    }

    public static C0622tg a(Ji ji, C0517pf c0517pf, Handler handler) {
        return new C0622tg(ji, c0517pf, handler, c0517pf.s());
    }

    public static C0702wi a(Context context, Wf wf, Ji ji, Handler handler, C0265fm c0265fm) {
        return new C0702wi(context, wf, ji, handler, c0265fm);
    }

    public static C0697wd a(Context context) {
        return new C0697wd(C0584s4.l().c.a(), C0584s4.l().b(context), "client_modules", new SystemTimeProvider());
    }
}
