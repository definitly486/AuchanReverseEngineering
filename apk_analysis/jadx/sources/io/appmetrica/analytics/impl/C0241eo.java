package io.appmetrica.analytics.impl;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.eo, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0241eo implements InterfaceC0557r3 {
    public final Object a;
    public final InterfaceC0557r3 b;

    public C0241eo(Object obj, InterfaceC0557r3 interfaceC0557r3) {
        this.a = obj;
        this.b = interfaceC0557r3;
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0557r3
    public final int getBytesTruncated() {
        return this.b.getBytesTruncated();
    }

    public final String toString() {
        return "TrimmingResult{value=" + this.a + ", metaInfo=" + this.b + '}';
    }
}
