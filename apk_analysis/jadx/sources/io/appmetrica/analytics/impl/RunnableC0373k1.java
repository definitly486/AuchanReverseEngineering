package io.appmetrica.analytics.impl;

import android.content.Context;
import io.appmetrica.analytics.StartupParamsCallback;
import java.util.List;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.k1, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class RunnableC0373k1 implements Runnable {
    public final /* synthetic */ Context a;
    public final /* synthetic */ StartupParamsCallback b;
    public final /* synthetic */ List c;
    public final /* synthetic */ C0659v1 d;

    public RunnableC0373k1(C0659v1 c0659v1, Context context, StartupParamsCallback startupParamsCallback, List list) {
        this.d = c0659v1;
        this.a = context;
        this.b = startupParamsCallback;
        this.c = list;
    }

    @Override // java.lang.Runnable
    public final void run() {
        B0 b0 = this.d.a;
        Context applicationContext = this.a.getApplicationContext();
        b0.getClass();
        A0 a0A = A0.a(applicationContext);
        a0A.f().a(this.b, this.c);
    }
}
