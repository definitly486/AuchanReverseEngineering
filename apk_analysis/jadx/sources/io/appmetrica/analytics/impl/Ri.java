package io.appmetrica.analytics.impl;

import android.os.Bundle;
import io.appmetrica.analytics.internal.IAppMetricaService;

/* JADX INFO: loaded from: classes3.dex */
public final class Ri extends Kh {
    public final Wf e;

    public Ri(C0554r0 c0554r0, InterfaceC0627tl interfaceC0627tl, Wf wf) {
        super(c0554r0, interfaceC0627tl);
        this.e = wf;
    }

    @Override // io.appmetrica.analytics.impl.Kh
    public final void a(IAppMetricaService iAppMetricaService) {
        Bundle bundle = new Bundle();
        Wf wf = this.e;
        synchronized (wf) {
            bundle.putParcelable("PROCESS_CFG_OBJ", wf);
        }
        iAppMetricaService.resumeUserSession(bundle);
    }
}
