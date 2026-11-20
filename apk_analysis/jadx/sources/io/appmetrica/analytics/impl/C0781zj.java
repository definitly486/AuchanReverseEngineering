package io.appmetrica.analytics.impl;

import android.content.Context;
import io.appmetrica.analytics.internal.CounterConfigurationReporterType;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.zj, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0781zj {
    public final String a;
    public final Context b;
    public final CounterConfigurationReporterType c;
    public final Cj d;

    public C0781zj(String str, Context context, CounterConfigurationReporterType counterConfigurationReporterType, Cj cj) {
        this.a = str;
        this.b = context;
        int i = AbstractC0755yj.a[counterConfigurationReporterType.ordinal()];
        if (i == 1) {
            this.c = CounterConfigurationReporterType.SELF_DIAGNOSTIC_MAIN;
        } else if (i != 2) {
            this.c = null;
        } else {
            this.c = CounterConfigurationReporterType.SELF_DIAGNOSTIC_MANUAL;
        }
        this.d = cj;
    }
}
