package io.appmetrica.analytics.impl;

/* JADX INFO: loaded from: classes3.dex */
public final class Ej implements InterfaceC0409lb {
    public final /* synthetic */ String a;
    public final /* synthetic */ Throwable b;

    public Ej(String str, Throwable th) {
        this.a = str;
        this.b = th;
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0409lb
    public final void a(InterfaceC0435mb interfaceC0435mb) {
        interfaceC0435mb.reportError(this.a, this.b);
    }
}
