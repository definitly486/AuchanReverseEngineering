package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreutils.internal.logger.LoggerStorage;
import java.util.ArrayList;
import java.util.concurrent.atomic.AtomicBoolean;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.b2, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0142b2 implements Thread.UncaughtExceptionHandler {
    public static final AtomicBoolean e = new AtomicBoolean();
    public final InterfaceC0228eb a;
    public final J6 b = C0584s4.l().n();
    public final F6 c = new F6();
    public final Vn d = new Vn();

    public C0142b2(A6 a6) {
        this.a = a6;
    }

    @Override // java.lang.Thread.UncaughtExceptionHandler
    public final void uncaughtException(Thread thread, Throwable th) {
        StackTraceElement[] stackTraceElementArrB;
        try {
            e.set(true);
            InterfaceC0228eb interfaceC0228eb = this.a;
            On onApply = this.c.apply(thread);
            Vn vn = this.d;
            Thread threadA = vn.a.a();
            ArrayList arrayListA = vn.a(threadA, thread);
            if (thread != threadA) {
                try {
                    stackTraceElementArrB = vn.a.b();
                    if (stackTraceElementArrB == null) {
                        try {
                            stackTraceElementArrB = threadA.getStackTrace();
                        } catch (SecurityException unused) {
                        }
                    }
                } catch (SecurityException unused2) {
                    stackTraceElementArrB = null;
                }
                arrayListA.add(0, (On) vn.b.apply(threadA, stackTraceElementArrB));
            }
            interfaceC0228eb.a(th, new X(onApply, arrayListA, this.b.a.a()));
        } catch (Throwable th2) {
            LoggerStorage.getMainPublicOrAnonymousLogger().error(th2, th2.getMessage(), new Object[0]);
        }
    }
}
