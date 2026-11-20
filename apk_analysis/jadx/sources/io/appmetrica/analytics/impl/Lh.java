package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreutils.internal.WrapUtils;

/* JADX INFO: loaded from: classes3.dex */
public final class Lh extends AbstractC0623th {
    public Lh(W6 w6) {
        super(w6);
    }

    @Override // io.appmetrica.analytics.impl.AbstractC0623th, io.appmetrica.analytics.impl.InterfaceC0649uh
    public final boolean a(Boolean bool) {
        return !this.a.isRestrictedForSdk() && ((Boolean) WrapUtils.getOrDefault(bool, Boolean.TRUE)).booleanValue();
    }
}
