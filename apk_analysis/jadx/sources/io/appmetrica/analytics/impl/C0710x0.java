package io.appmetrica.analytics.impl;

import android.os.Handler;
import io.appmetrica.analytics.AppMetricaConfig;
import io.appmetrica.analytics.coreapi.internal.executors.ICommonExecutor;
import io.appmetrica.analytics.coreapi.internal.executors.IHandlerExecutor;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.x0, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0710x0 implements InterfaceC0125ab {
    public final Handler a;
    public final IHandlerExecutor b;
    public final C0662v4 c;

    public C0710x0() {
        IHandlerExecutor iHandlerExecutorA = C0584s4.l().g().a();
        this.b = iHandlerExecutorA;
        this.a = iHandlerExecutorA.getHandler();
        this.c = new C0662v4();
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0125ab
    public final void a(AppMetricaConfig appMetricaConfig, InterfaceC0487ob interfaceC0487ob) {
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0125ab
    public final Handler b() {
        return this.a;
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0125ab
    public final C0245f2 c() {
        return new C0245f2();
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0125ab
    public final Gb d() {
        return new Gb();
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0125ab
    public final ICommonExecutor getDefaultExecutor() {
        return this.b;
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0125ab
    public final C0662v4 a() {
        return this.c;
    }
}
