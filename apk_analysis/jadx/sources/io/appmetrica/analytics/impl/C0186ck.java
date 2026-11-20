package io.appmetrica.analytics.impl;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.ck, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0186ck implements InterfaceC0409lb {
    public final /* synthetic */ String a;

    public C0186ck(String str) {
        this.a = str;
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0409lb
    public final void a(InterfaceC0435mb interfaceC0435mb) {
        interfaceC0435mb.reportEvent(this.a);
    }
}
