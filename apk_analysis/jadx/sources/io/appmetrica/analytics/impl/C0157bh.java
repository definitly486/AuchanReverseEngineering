package io.appmetrica.analytics.impl;

import android.content.Context;
import android.os.Bundle;
import io.appmetrica.analytics.coreapi.internal.executors.IHandlerExecutor;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.bh, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0157bh implements InterfaceC0612t6 {
    public final Context a;
    public final C0558r4 b;
    public final IHandlerExecutor c = Ka.k().w().f();

    public C0157bh(Context context, C0558r4 c0558r4) {
        this.a = context;
        this.b = c0558r4;
    }

    public final void a(C0249f6 c0249f6, Bundle bundle) {
        if (c0249f6.m()) {
            return;
        }
        this.c.execute(new RunnableC0753yh(this.a, c0249f6, bundle, this.b));
    }

    public final void a(C0273g4 c0273g4, C0249f6 c0249f6, G4 g4) {
        this.b.a(c0273g4, g4).a(c0249f6, g4);
        this.b.a(c0273g4.b, c0273g4.c, c0273g4.d);
    }
}
