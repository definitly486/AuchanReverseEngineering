package io.appmetrica.analytics.impl;

import android.os.Process;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.ae, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0128ae implements InterfaceC0653ul {
    public final int a;

    public C0128ae(int i) {
        this.a = i;
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0653ul
    public final boolean a(String str) {
        return this.a != Process.myPid();
    }
}
