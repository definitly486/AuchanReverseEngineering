package io.appmetrica.analytics.impl;

/* JADX INFO: loaded from: classes3.dex */
public final class Qi implements InterfaceC0557r3 {
    public final Object a;
    public final InterfaceC0557r3 b;

    public Qi(Object obj, InterfaceC0557r3 interfaceC0557r3) {
        this.a = obj;
        this.b = interfaceC0557r3;
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0557r3
    public final int getBytesTruncated() {
        return this.b.getBytesTruncated();
    }

    public final String toString() {
        return "Result{result=" + this.a + ", metaInfo=" + this.b + '}';
    }
}
