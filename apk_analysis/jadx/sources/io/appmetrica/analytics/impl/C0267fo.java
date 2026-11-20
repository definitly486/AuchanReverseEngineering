package io.appmetrica.analytics.impl;

import android.os.Bundle;
import io.appmetrica.analytics.internal.IAppMetricaService;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.fo, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0267fo extends Kh {
    public final int e;
    public final Bundle f;

    public C0267fo(C0554r0 c0554r0, InterfaceC0627tl interfaceC0627tl, int i, Bundle bundle) {
        super(c0554r0, interfaceC0627tl);
        this.e = i;
        this.f = bundle;
    }

    @Override // io.appmetrica.analytics.impl.Kh
    public final void a(IAppMetricaService iAppMetricaService) {
        iAppMetricaService.reportData(this.e, this.f);
    }
}
