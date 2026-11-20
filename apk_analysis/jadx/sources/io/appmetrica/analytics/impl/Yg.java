package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.internal.IAppMetricaService;

/* JADX INFO: loaded from: classes3.dex */
public class Yg extends Kh {
    public final Ih e;

    public Yg(C0554r0 c0554r0, InterfaceC0627tl interfaceC0627tl, Ih ih) {
        super(c0554r0, interfaceC0627tl);
        this.e = ih;
    }

    @Override // io.appmetrica.analytics.impl.Kh
    public final void a(Throwable th) {
    }

    @Override // io.appmetrica.analytics.impl.Kh
    public final void a(IAppMetricaService iAppMetricaService) {
        Ih ih = this.e;
        iAppMetricaService.reportData(ih.c, ih.a.d(ih.e.c()));
    }
}
