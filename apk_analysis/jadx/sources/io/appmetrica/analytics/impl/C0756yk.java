package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.internal.AppMetricaService;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.yk, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0756yk {
    public final String a;

    public C0756yk(String str) {
        this.a = str;
    }

    public final String toString() {
        return "ServiceDescription(packageName='" + this.a + "', serviceScheme='appmetrica', serviceClass=" + AppMetricaService.class + ')';
    }
}
