package io.appmetrica.analytics.impl;

import android.content.Context;
import com.scanflow.datacapture.barinternal.kotlin.Unit;
import io.appmetrica.analytics.coreapi.internal.backport.Consumer;
import io.appmetrica.analytics.coreapi.internal.executors.IHandlerExecutor;
import io.appmetrica.analytics.coreutils.internal.logger.LoggerStorage;
import io.appmetrica.analytics.ndkcrashesapi.internal.NativeCrash;
import io.appmetrica.analytics.ndkcrashesapi.internal.NativeCrashHandler;
import io.appmetrica.analytics.ndkcrashesapi.internal.NativeCrashSource;
import java.io.File;
import kotlin.jvm.functions.Function1;
import kotlin.jvm.internal.Intrinsics;
import kotlin.jvm.internal.Reflection;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.de, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0206de implements NativeCrashHandler {
    public final Function1 a;
    public final IHandlerExecutor b = Ka.k().w().f();
    public final C0283ge c;

    public C0206de(Context context, C0157bh c0157bh, Function1<? super String, Unit> function1, InterfaceC0438me interfaceC0438me, EnumC0721xb enumC0721xb, String str, InterfaceC0360je interfaceC0360je) {
        this.a = function1;
        this.c = new C0283ge(context, c0157bh, interfaceC0438me, enumC0721xb, interfaceC0360je);
    }

    public static final void a(C0206de c0206de, NativeCrash nativeCrash, File file) {
        c0206de.a.invoke(nativeCrash.getUuid());
    }

    @Override // io.appmetrica.analytics.ndkcrashesapi.internal.NativeCrashHandler
    public final void newCrash(final NativeCrash nativeCrash) {
        I0 i0;
        C0668va c0668va;
        try {
            NativeCrashSource source = nativeCrash.getSource();
            String handlerVersion = nativeCrash.getHandlerVersion();
            String uuid = nativeCrash.getUuid();
            String dumpFile = nativeCrash.getDumpFile();
            long creationTime = nativeCrash.getCreationTime();
            J0 j0A = K0.a(nativeCrash.getMetadata());
            Intrinsics.checkNotNull(j0A);
            i0 = new I0(source, handlerVersion, uuid, dumpFile, creationTime, j0A);
        } catch (Throwable unused) {
            i0 = null;
        }
        if (i0 == null) {
            this.a.invoke(nativeCrash.getUuid());
            return;
        }
        LoggerStorage.getOrCreatePublicLogger(i0.f.a).info("Detected native crash with uuid = " + i0.c, new Object[0]);
        IHandlerExecutor iHandlerExecutor = this.b;
        C0283ge c0283ge = this.c;
        Consumer consumer = new Consumer() { // from class: io.appmetrica.analytics.impl.de$$ExternalSyntheticLambda0
            @Override // io.appmetrica.analytics.coreapi.internal.backport.Consumer
            public final void consume(Object obj) {
                C0206de.a(this.f$0, nativeCrash, (File) obj);
            }
        };
        c0283ge.getClass();
        Zd zd = new Zd(new C0154be(i0.a, i0.b), c0283ge.g);
        Wd wd = new Wd(c0283ge.b, i0.f, new C0257fe(i0, c0283ge.d, c0283ge.e));
        C0694wa c0694wa = c0283ge.f;
        String str = i0.d;
        c0694wa.getClass();
        File file = new File(str);
        Context context = c0283ge.a;
        if (C0668va.c == null) {
            synchronized (Reflection.getOrCreateKotlinClass(C0668va.class)) {
                try {
                    if (C0668va.c == null) {
                        C0668va.c = new C0668va(context);
                    }
                    Unit unit = Unit.INSTANCE;
                } catch (Throwable th) {
                    throw th;
                }
            }
        }
        C0668va c0668va2 = C0668va.c;
        if (c0668va2 == null) {
            Intrinsics.throwUninitializedPropertyAccessException("INSTANCE");
            c0668va = null;
        } else {
            c0668va = c0668va2;
        }
        iHandlerExecutor.execute(new RunnableC0492og(file, zd, consumer, wd, c0668va, c0283ge.c.a(i0)));
    }
}
