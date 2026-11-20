package io.appmetrica.analytics.impl;

/* JADX INFO: loaded from: classes3.dex */
public final class Vj implements InterfaceC0409lb {
    public final /* synthetic */ String a;
    public final /* synthetic */ byte[] b;

    public Vj(String str, byte[] bArr) {
        this.a = str;
        this.b = bArr;
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0409lb
    public final void a(InterfaceC0435mb interfaceC0435mb) {
        interfaceC0435mb.setSessionExtra(this.a, this.b);
    }
}
