package io.appmetrica.analytics.impl;

/* JADX INFO: loaded from: classes3.dex */
public final class Gj implements InterfaceC0409lb {
    public final /* synthetic */ Throwable a;

    public Gj(Throwable th) {
        this.a = th;
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0409lb
    public final void a(InterfaceC0435mb interfaceC0435mb) {
        interfaceC0435mb.reportUnhandledException(this.a);
    }
}
