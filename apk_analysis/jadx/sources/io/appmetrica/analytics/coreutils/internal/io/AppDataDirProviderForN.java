package io.appmetrica.analytics.coreutils.internal.io;

import android.annotation.TargetApi;
import android.content.Context;
import io.appmetrica.analytics.coreapi.internal.annotations.DoNotInline;
import java.io.File;

/* JADX INFO: loaded from: classes3.dex */
@DoNotInline
@TargetApi(24)
public final class AppDataDirProviderForN {
    public static final AppDataDirProviderForN INSTANCE = new AppDataDirProviderForN();

    private AppDataDirProviderForN() {
    }

    public final File dataDir(Context context) {
        return context.getDataDir();
    }
}
