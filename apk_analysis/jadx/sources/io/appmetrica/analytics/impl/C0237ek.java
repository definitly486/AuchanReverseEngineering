package io.appmetrica.analytics.impl;

import java.util.Map;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.ek, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0237ek implements InterfaceC0409lb {
    public final /* synthetic */ String a;
    public final /* synthetic */ Map b;

    public C0237ek(String str, Map map) {
        this.a = str;
        this.b = map;
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0409lb
    public final void a(InterfaceC0435mb interfaceC0435mb) {
        interfaceC0435mb.reportEvent(this.a, this.b);
    }
}
