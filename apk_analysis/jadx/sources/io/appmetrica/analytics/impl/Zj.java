package io.appmetrica.analytics.impl;

/* JADX INFO: loaded from: classes3.dex */
public final class Zj implements InterfaceC0409lb {
    public final /* synthetic */ String a;
    public final /* synthetic */ String b;

    public Zj(String str, String str2) {
        this.a = str;
        this.b = str2;
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0409lb
    public final void a(InterfaceC0435mb interfaceC0435mb) {
        interfaceC0435mb.putAppEnvironmentValue(this.a, this.b);
    }
}
