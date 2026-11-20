package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.ModuleEvent;

/* JADX INFO: loaded from: classes3.dex */
public final class Uj implements InterfaceC0409lb {
    public final /* synthetic */ ModuleEvent a;

    public Uj(ModuleEvent moduleEvent) {
        this.a = moduleEvent;
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0409lb
    public final void a(InterfaceC0435mb interfaceC0435mb) {
        interfaceC0435mb.reportEvent(this.a);
    }
}
