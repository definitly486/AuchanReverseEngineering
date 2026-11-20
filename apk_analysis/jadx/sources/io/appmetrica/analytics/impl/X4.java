package io.appmetrica.analytics.impl;

import java.util.Arrays;

/* JADX INFO: loaded from: classes3.dex */
public final class X4 implements InterfaceC0483o7 {
    public final String a;
    public final String b;

    public X4(C0274g5 c0274g5) {
        this.a = String.format("component_%s.db", Arrays.copyOf(new Object[]{c0274g5.d() ? "main" : c0274g5.b()}, 1));
        this.b = "db_metrica_" + c0274g5;
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0483o7
    public final String a() {
        return this.b;
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0483o7
    public final String b() {
        return this.a;
    }
}
