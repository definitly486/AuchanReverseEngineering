package io.appmetrica.analytics.impl;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.rd, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0567rd extends Q2 {
    public final String b;

    public C0567rd(String str, Ol ol) {
        super(ol);
        this.b = str;
    }

    @Override // io.appmetrica.analytics.impl.Q2
    public final String a(String str) {
        return str + '-' + this.b;
    }
}
