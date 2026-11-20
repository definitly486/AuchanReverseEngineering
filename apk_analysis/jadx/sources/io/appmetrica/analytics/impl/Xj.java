package io.appmetrica.analytics.impl;

import java.util.Map;

/* JADX INFO: loaded from: classes3.dex */
public final class Xj implements InterfaceC0409lb {
    public final /* synthetic */ Map a;

    public Xj(Map map) {
        this.a = map;
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0409lb
    public final void a(InterfaceC0435mb interfaceC0435mb) {
        interfaceC0435mb.reportAnr(this.a);
    }
}
