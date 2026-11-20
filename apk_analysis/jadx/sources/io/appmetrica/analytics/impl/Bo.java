package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreutils.internal.services.UtilityServiceConfiguration;
import io.appmetrica.analytics.coreutils.internal.services.UtilityServiceProvider;

/* JADX INFO: loaded from: classes3.dex */
public final class Bo implements Bm {
    public final UtilityServiceProvider a;

    public Bo(UtilityServiceProvider utilityServiceProvider) {
        this.a = utilityServiceProvider;
    }

    @Override // io.appmetrica.analytics.impl.Bm
    public final void a(C0706wm c0706wm) {
        this.a.updateConfiguration(new UtilityServiceConfiguration(c0706wm.v, c0706wm.u));
    }
}
