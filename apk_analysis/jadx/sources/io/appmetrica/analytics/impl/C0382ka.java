package io.appmetrica.analytics.impl;

import android.content.pm.FeatureInfo;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.ka, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0382ka extends AbstractC0408la {
    @Override // io.appmetrica.analytics.impl.AbstractC0408la
    public final C0434ma b(FeatureInfo featureInfo) {
        return new C0434ma(featureInfo.name, -1, (featureInfo.flags & 1) != 0);
    }
}
