package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.modulesapi.internal.client.ClientStorageProvider;
import io.appmetrica.analytics.modulesapi.internal.common.ModulePreferences;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.u4, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0636u4 implements ClientStorageProvider {
    public final Ol a;

    public C0636u4(Ol ol) {
        this.a = ol;
    }

    @Override // io.appmetrica.analytics.modulesapi.internal.client.ClientStorageProvider
    public final ModulePreferences modulePreferences(String str) {
        return new C0567rd(str, this.a);
    }
}
