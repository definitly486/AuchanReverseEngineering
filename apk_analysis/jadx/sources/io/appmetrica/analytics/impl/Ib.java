package io.appmetrica.analytics.impl;

import android.os.Process;

/* JADX INFO: loaded from: classes3.dex */
public final class Ib implements InterfaceC0653ul {
    @Override // io.appmetrica.analytics.impl.InterfaceC0653ul
    public final boolean a(Fb fb) {
        Integer num = fb.f;
        return num == null || num.intValue() != Process.myPid();
    }
}
