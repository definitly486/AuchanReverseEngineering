package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreutils.internal.logger.LoggerStorage;
import io.appmetrica.analytics.logger.appmetrica.internal.PublicLogger;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.q5, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0534q5 {
    public final String a;

    public C0534q5(String str) {
        this.a = str;
    }

    public final PublicLogger a() {
        return LoggerStorage.getOrCreatePublicLogger(this.a);
    }
}
