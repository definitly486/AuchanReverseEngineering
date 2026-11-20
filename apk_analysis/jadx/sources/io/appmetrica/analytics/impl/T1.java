package io.appmetrica.analytics.impl;

import android.content.Context;
import android.content.Intent;
import android.net.Uri;
import android.os.Process;
import io.appmetrica.analytics.coreapi.internal.model.ScreenInfo;
import io.appmetrica.analytics.internal.AppMetricaService;

/* JADX INFO: loaded from: classes3.dex */
public final class T1 {
    public static Intent a(Context context) {
        C0573rj c0573rj;
        C0584s4.l().v.getClass();
        Intent data = new Intent(context, (Class<?>) AppMetricaService.class).setAction("io.appmetrica.analytics.IAppMetricaService").setData(new Uri.Builder().scheme(Y7.b).authority(context.getPackageName()).path("client").appendQueryParameter("pid", String.valueOf(Process.myPid())).appendQueryParameter("psid", Wf.c).build());
        C0584s4 c0584s4L = C0584s4.l();
        synchronized (c0584s4L) {
            try {
                if (c0584s4L.p == null) {
                    C0573rj c0573rj2 = new C0573rj();
                    c0584s4L.p = c0573rj2;
                    c0584s4L.h.a(c0573rj2);
                }
                c0573rj = c0584s4L.p;
            } catch (Throwable th) {
                throw th;
            }
        }
        ScreenInfo screenInfoA = c0573rj.a(context);
        return data.putExtra("screen_size", screenInfoA != null ? Cb.a(screenInfoA) : null);
    }
}
