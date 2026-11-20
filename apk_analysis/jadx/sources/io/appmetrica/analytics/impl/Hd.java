package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreapi.internal.executors.IHandlerExecutor;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: loaded from: classes3.dex */
public final class Hd {
    public final B0 a;
    public final C0775zd b;
    public final Od c;
    public final IHandlerExecutor d;

    public Hd() {
        B0 b0D = C0584s4.l().d();
        this.a = b0D;
        this.b = new C0775zd(b0D);
        this.c = new Od();
        this.d = C0584s4.l().g().a();
    }

    public static final InterfaceC0306hb a(Hd hd) {
        hd.a.getClass();
        A0 a0 = A0.e;
        Intrinsics.checkNotNull(a0);
        Fc fcI = a0.f().i();
        Intrinsics.checkNotNull(fcI);
        return fcI.a;
    }
}
