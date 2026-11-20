package io.appmetrica.analytics.impl;

import java.util.List;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.xf, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0725xf implements InterfaceC0329i8 {
    public final Kf a;
    public final List<C0699wf> b;

    public C0725xf(Kf kf, List<C0699wf> list) {
        this.a = kf;
        this.b = list;
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0329i8
    public final List<C0699wf> a() {
        return this.b;
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0329i8
    public final Object b() {
        return this.a;
    }

    public final Kf c() {
        return this.a;
    }

    public final String toString() {
        return "PreloadInfoData{chosenPreloadInfo=" + this.a + ", candidates=" + this.b + '}';
    }
}
