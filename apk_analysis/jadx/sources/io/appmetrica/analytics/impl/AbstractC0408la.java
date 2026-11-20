package io.appmetrica.analytics.impl;

import android.content.pm.FeatureInfo;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.la, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public abstract class AbstractC0408la {
    public final C0434ma a(FeatureInfo featureInfo) {
        if (featureInfo.name != null) {
            return b(featureInfo);
        }
        int i = featureInfo.reqGlEsVersion;
        if (i == 0) {
            return b(featureInfo);
        }
        return new C0434ma("openGlFeature", i, (featureInfo.flags & 1) != 0);
    }

    public abstract C0434ma b(FeatureInfo featureInfo);
}
