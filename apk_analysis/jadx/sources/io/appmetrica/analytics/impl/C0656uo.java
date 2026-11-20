package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.BuildConfig;
import io.appmetrica.analytics.coreutils.internal.network.UserAgent;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.uo, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0656uo {
    public final String a = UserAgent.getFor(BuildConfig.LIBRARY_PACKAGE_NAME, "8.1.0", "50162358");

    public final String a() {
        return this.a;
    }
}
