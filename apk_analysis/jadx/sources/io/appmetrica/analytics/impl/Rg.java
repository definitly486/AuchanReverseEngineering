package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.networktasks.internal.NetworkServiceLocator;
import io.appmetrica.analytics.networktasks.internal.NetworkTask;

/* JADX INFO: loaded from: classes3.dex */
public final class Rg implements InterfaceC0162bm {
    public final Rm a;

    public Rg(Rm rm) {
        this.a = rm;
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0162bm
    public final void a() {
        NetworkTask networkTaskC = this.a.c();
        if (networkTaskC != null) {
            Ka.I.getClass();
            NetworkServiceLocator.getInstance().getNetworkCore().startTask(networkTaskC);
        }
    }
}
