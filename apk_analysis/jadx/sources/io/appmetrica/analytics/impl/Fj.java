package io.appmetrica.analytics.impl;

/* JADX INFO: loaded from: classes3.dex */
public final class Fj implements InterfaceC0409lb {
    public final /* synthetic */ String a;
    public final /* synthetic */ String b;
    public final /* synthetic */ Throwable c;

    public Fj(String str, String str2, Throwable th) {
        this.a = str;
        this.b = str2;
        this.c = th;
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0409lb
    public final void a(InterfaceC0435mb interfaceC0435mb) {
        interfaceC0435mb.reportError(this.a, this.b, this.c);
    }
}
