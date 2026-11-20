package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreutils.internal.WrapUtils;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.gk, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0289gk extends AbstractC0623th {
    public C0289gk(W6 w6) {
        super(w6);
    }

    @Override // io.appmetrica.analytics.impl.AbstractC0623th, io.appmetrica.analytics.impl.InterfaceC0649uh
    public final boolean a(Boolean bool) {
        return !this.a.isRestrictedForSdk() && ((Boolean) WrapUtils.getOrDefault(bool, Boolean.TRUE)).booleanValue();
    }
}
