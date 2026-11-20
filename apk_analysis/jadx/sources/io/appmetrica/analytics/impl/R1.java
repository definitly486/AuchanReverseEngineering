package io.appmetrica.analytics.impl;

import android.os.Bundle;

/* JADX INFO: loaded from: classes3.dex */
public final class R1 implements InterfaceC0652uk {
    public static final Q1 b = new Q1();
    public static final int c = 1;
    public final InterfaceC0632u0 a;

    public R1(InterfaceC0632u0 interfaceC0632u0) {
        this.a = interfaceC0632u0;
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0652uk
    public final void reportData(int i, Bundle bundle) {
        ((O1) this.a).a(bundle);
    }
}
