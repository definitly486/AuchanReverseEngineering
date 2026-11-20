package io.appmetrica.analytics.impl;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.dk, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0212dk implements InterfaceC0409lb {
    public final /* synthetic */ String a;
    public final /* synthetic */ String b;

    public C0212dk(String str, String str2) {
        this.a = str;
        this.b = str2;
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0409lb
    public final void a(InterfaceC0435mb interfaceC0435mb) {
        interfaceC0435mb.reportEvent(this.a, this.b);
    }
}
