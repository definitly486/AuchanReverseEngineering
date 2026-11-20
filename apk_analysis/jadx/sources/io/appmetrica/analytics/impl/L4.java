package io.appmetrica.analytics.impl;

import android.content.Context;
import android.os.ResultReceiver;

/* JADX INFO: loaded from: classes3.dex */
public final class L4 implements InterfaceC0688w4 {
    public final Context a;
    public final N4 b;
    public final ResultReceiver c;

    public L4(Context context, N4 n4, G4 g4) {
        this.a = context;
        this.b = n4;
        this.c = g4.c;
        n4.a(this);
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0688w4
    public final void a(C0249f6 c0249f6, G4 g4) {
        this.b.a(g4.b);
        this.b.a(c0249f6, this);
    }

    public final N4 b() {
        return this.b;
    }

    public final Context c() {
        return this.a;
    }

    public final ResultReceiver d() {
        return this.c;
    }

    public final void a(C0350j4 c0350j4) {
        T6.a(this.c, c0350j4);
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0688w4
    public final void a() {
        this.b.b(this);
    }
}
