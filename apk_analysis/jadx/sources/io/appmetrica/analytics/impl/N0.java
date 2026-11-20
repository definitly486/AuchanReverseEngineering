package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreapi.internal.executors.IHandlerExecutor;
import io.appmetrica.analytics.plugins.PluginErrorDetails;
import java.util.Collection;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: loaded from: classes3.dex */
public final class N0 {
    public final IHandlerExecutor a = C0584s4.l().g().a();
    public final B0 b;
    public final C0413lf c;
    public final C0491of d;

    public N0() {
        B0 b0 = new B0();
        this.b = b0;
        this.c = new C0413lf(b0);
        this.d = new C0491of();
    }

    public final void a(final PluginErrorDetails pluginErrorDetails) {
        C0413lf c0413lf = this.c;
        c0413lf.a.a(null);
        c0413lf.b.a(pluginErrorDetails);
        C0491of c0491of = this.d;
        Intrinsics.checkNotNull(pluginErrorDetails);
        c0491of.getClass();
        this.a.execute(new Runnable() { // from class: io.appmetrica.analytics.impl.N0$$ExternalSyntheticLambda0
            @Override // java.lang.Runnable
            public final void run() {
                N0.a(this.f$0, pluginErrorDetails);
            }
        });
    }

    public final void a(final PluginErrorDetails pluginErrorDetails, final String str) {
        C0413lf c0413lf = this.c;
        c0413lf.a.a(null);
        c0413lf.b.a(pluginErrorDetails);
        if (c0413lf.d.a((Collection<Object>) (pluginErrorDetails != null ? pluginErrorDetails.getStacktrace() : null)).a) {
            C0491of c0491of = this.d;
            Intrinsics.checkNotNull(pluginErrorDetails);
            c0491of.getClass();
            this.a.execute(new Runnable() { // from class: io.appmetrica.analytics.impl.N0$$ExternalSyntheticLambda1
                @Override // java.lang.Runnable
                public final void run() {
                    N0.a(this.f$0, pluginErrorDetails, str);
                }
            });
        }
    }

    public final void a(final String str, final String str2, final PluginErrorDetails pluginErrorDetails) {
        C0413lf c0413lf = this.c;
        c0413lf.a.a(null);
        c0413lf.c.a(str);
        C0491of c0491of = this.d;
        Intrinsics.checkNotNull(str);
        c0491of.getClass();
        this.a.execute(new Runnable() { // from class: io.appmetrica.analytics.impl.N0$$ExternalSyntheticLambda2
            @Override // java.lang.Runnable
            public final void run() {
                N0.a(this.f$0, str, str2, pluginErrorDetails);
            }
        });
    }

    public static final void a(N0 n0, PluginErrorDetails pluginErrorDetails, String str) {
        n0.b.getClass();
        A0 a0 = A0.e;
        Intrinsics.checkNotNull(a0);
        Fc fcI = a0.f().i();
        Intrinsics.checkNotNull(fcI);
        fcI.a.getPluginExtension().reportError(pluginErrorDetails, str);
    }

    public static final void a(N0 n0, String str, String str2, PluginErrorDetails pluginErrorDetails) {
        n0.b.getClass();
        A0 a0 = A0.e;
        Intrinsics.checkNotNull(a0);
        Fc fcI = a0.f().i();
        Intrinsics.checkNotNull(fcI);
        fcI.a.getPluginExtension().reportError(str, str2, pluginErrorDetails);
    }

    public static final void a(N0 n0, PluginErrorDetails pluginErrorDetails) {
        n0.b.getClass();
        A0 a0 = A0.e;
        Intrinsics.checkNotNull(a0);
        Fc fcI = a0.f().i();
        Intrinsics.checkNotNull(fcI);
        fcI.a.getPluginExtension().reportUnhandledException(pluginErrorDetails);
    }
}
