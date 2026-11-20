package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreapi.internal.executors.ICommonExecutor;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: loaded from: classes3.dex */
public final class T9 implements Bg {
    public final Bg a;
    public final ICommonExecutor b;

    public T9(Bg bg, ICommonExecutor iCommonExecutor) {
        this.a = bg;
        this.b = iCommonExecutor;
    }

    @Override // io.appmetrica.analytics.impl.Bg
    public final String a() {
        return this.a.a();
    }

    @Override // io.appmetrica.analytics.impl.Bg
    public final void a(final InterfaceC0726xg interfaceC0726xg) {
        this.b.execute(new Runnable() { // from class: io.appmetrica.analytics.impl.T9$$ExternalSyntheticLambda1
            @Override // java.lang.Runnable
            public final void run() {
                T9.a(this.f$0, interfaceC0726xg);
            }
        });
    }

    public static final void a(final T9 t9, final InterfaceC0726xg interfaceC0726xg) {
        final Thread threadCurrentThread = Thread.currentThread();
        t9.a.a(new InterfaceC0726xg() { // from class: io.appmetrica.analytics.impl.T9$$ExternalSyntheticLambda2
            @Override // io.appmetrica.analytics.impl.InterfaceC0726xg
            public final void a(Eg eg) {
                T9.a(threadCurrentThread, interfaceC0726xg, t9, eg);
            }
        });
    }

    public static final void a(Thread thread, final InterfaceC0726xg interfaceC0726xg, T9 t9, final Eg eg) {
        if (Intrinsics.areEqual(Thread.currentThread(), thread)) {
            interfaceC0726xg.a(eg);
        } else {
            t9.b.execute(new Runnable() { // from class: io.appmetrica.analytics.impl.T9$$ExternalSyntheticLambda0
                @Override // java.lang.Runnable
                public final void run() {
                    T9.a(interfaceC0726xg, eg);
                }
            });
        }
    }

    public static final void a(InterfaceC0726xg interfaceC0726xg, Eg eg) {
        interfaceC0726xg.a(eg);
    }
}
