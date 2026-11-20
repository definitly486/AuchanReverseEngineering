package io.appmetrica.analytics.impl;

import android.content.Context;
import io.appmetrica.analytics.modulesapi.internal.client.ModuleClientActivator;

/* JADX INFO: loaded from: classes3.dex */
public final class Z3 implements ModuleClientActivator {
    @Override // io.appmetrica.analytics.modulesapi.internal.client.ModuleClientActivator
    public final void activate(Context context) {
        C0192d0 c0192d0B = C0584s4.l().b();
        c0192d0B.c.a().executeDelayed(new C0166c0(c0192d0B, context), c0192d0B.d);
    }
}
