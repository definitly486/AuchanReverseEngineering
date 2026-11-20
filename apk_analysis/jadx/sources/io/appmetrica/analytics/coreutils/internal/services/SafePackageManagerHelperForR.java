package io.appmetrica.analytics.coreutils.internal.services;

import android.annotation.TargetApi;
import android.content.pm.PackageManager;
import io.appmetrica.analytics.coreapi.internal.annotations.DoNotInline;

/* JADX INFO: loaded from: classes3.dex */
@DoNotInline
@TargetApi(30)
public final class SafePackageManagerHelperForR {
    public static final SafePackageManagerHelperForR INSTANCE = new SafePackageManagerHelperForR();

    private SafePackageManagerHelperForR() {
    }

    public static final String extractPackageInstaller(PackageManager packageManager, String str) {
        return packageManager.getInstallSourceInfo(str).getInstallingPackageName();
    }
}
