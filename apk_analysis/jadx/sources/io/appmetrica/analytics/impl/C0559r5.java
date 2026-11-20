package io.appmetrica.analytics.impl;

import android.content.Context;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.r5, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0559r5 {
    public final Context a;
    public final C0274g5 b;
    public final Pk c = Ka.k().B();

    public C0559r5(Context context, C0274g5 c0274g5) {
        this.a = context;
        this.b = c0274g5;
    }

    public final C0544qf a() {
        return new C0544qf(this.c.b(this.a, this.b));
    }
}
