package io.appmetrica.analytics.impl;

import android.app.Activity;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.o1, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class RunnableC0477o1 implements Runnable {
    public final /* synthetic */ Activity a;
    public final /* synthetic */ C0659v1 b;

    public RunnableC0477o1(C0659v1 c0659v1, Activity activity) {
        this.b = c0659v1;
        this.a = activity;
    }

    @Override // java.lang.Runnable
    public final void run() {
        C0659v1 c0659v1 = this.b;
        C0550ql c0550ql = c0659v1.h;
        Activity activity = this.a;
        InterfaceC0306hb interfaceC0306hb = c0659v1.c().a;
        if (activity != null) {
            c0550ql.f.a(activity);
        }
        if (c0550ql.e.a(activity, EnumC0501p.PAUSED)) {
            interfaceC0306hb.b(activity);
        }
    }
}
