package io.appmetrica.analytics.coreutils.internal.services;

import android.annotation.TargetApi;
import android.content.pm.PackageManager;
import android.content.pm.ProviderInfo;
import io.appmetrica.analytics.coreapi.internal.annotations.DoNotInline;

/* JADX INFO: loaded from: classes3.dex */
@DoNotInline
@TargetApi(33)
public final class PackageManagerUtilsTiramisu {
    public static final PackageManagerUtilsTiramisu INSTANCE = new PackageManagerUtilsTiramisu();
    private static final String a = "[PackageManagerUtilsTiramisu]";

    private PackageManagerUtilsTiramisu() {
    }

    public final ProviderInfo resolveContentProvider(PackageManager packageManager, String str) {
        try {
            return packageManager.resolveContentProvider(str, PackageManager.ComponentInfoFlags.of(8L));
        } catch (Throwable unused) {
            return null;
        }
    }
}
