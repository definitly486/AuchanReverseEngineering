package io.appmetrica.analytics.screenshot.impl;

import android.os.Bundle;
import io.appmetrica.analytics.modulesapi.internal.client.BundleToServiceConfigConverter;
import io.appmetrica.analytics.screenshot.internal.config.ParcelableRemoteScreenshotConfig;

/* JADX INFO: renamed from: io.appmetrica.analytics.screenshot.impl.h, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0794h implements BundleToServiceConfigConverter {
    @Override // io.appmetrica.analytics.modulesapi.internal.client.BundleToServiceConfigConverter
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final ParcelableRemoteScreenshotConfig fromBundle(Bundle bundle) {
        bundle.setClassLoader(ParcelableRemoteScreenshotConfig.class.getClassLoader());
        ParcelableRemoteScreenshotConfig parcelableRemoteScreenshotConfig = (ParcelableRemoteScreenshotConfig) bundle.getParcelable("config");
        return parcelableRemoteScreenshotConfig == null ? new ParcelableRemoteScreenshotConfig() : parcelableRemoteScreenshotConfig;
    }
}
