package io.appmetrica.analytics.impl;

import android.util.SparseArray;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.m4, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0428m4 extends AbstractC0230ed {
    public final C0517pf a;

    public C0428m4(C0517pf c0517pf) {
        this.a = c0517pf;
    }

    @Override // io.appmetrica.analytics.impl.AbstractC0230ed
    public final void a(int i) {
        this.a.c(i);
    }

    @Override // io.appmetrica.analytics.impl.AbstractC0230ed
    public final int b() {
        return (int) this.a.a(-1L);
    }

    @Override // io.appmetrica.analytics.impl.AbstractC0230ed
    public final SparseArray<InterfaceC0205dd> c() {
        return new SparseArray<>();
    }
}
