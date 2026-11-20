package io.appmetrica.analytics.impl;

import android.annotation.TargetApi;
import android.content.pm.FeatureInfo;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.ja, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0356ja extends AbstractC0408la {
    @Override // io.appmetrica.analytics.impl.AbstractC0408la
    @TargetApi(24)
    public final C0434ma b(FeatureInfo featureInfo) {
        return new C0434ma(featureInfo.name, featureInfo.version, (featureInfo.flags & 1) != 0);
    }
}
