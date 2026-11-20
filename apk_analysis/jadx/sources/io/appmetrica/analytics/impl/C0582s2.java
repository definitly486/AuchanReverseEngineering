package io.appmetrica.analytics.impl;

import android.content.Context;
import io.appmetrica.analytics.AppMetricaConfig;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.s2, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0582s2 {
    public static final boolean a(Throwable th) {
        return true;
    }

    public final InterfaceC0228eb a(Context context, AppMetricaConfig appMetricaConfig, InterfaceC0487ob interfaceC0487ob) {
        return new Oh(new Bc(interfaceC0487ob, appMetricaConfig), new InterfaceC0742y6() { // from class: io.appmetrica.analytics.impl.s2$$ExternalSyntheticLambda0
            @Override // io.appmetrica.analytics.impl.InterfaceC0742y6
            public final boolean a(Throwable th) {
                return C0582s2.a(th);
            }
        }, appMetricaConfig.crashTransformer, new C0305ha(context));
    }
}
