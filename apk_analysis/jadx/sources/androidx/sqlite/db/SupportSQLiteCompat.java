package androidx.sqlite.db;

import android.content.Context;
import java.io.File;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: SupportSQLiteCompat.android.kt */
/* JADX INFO: loaded from: classes.dex */
public final class SupportSQLiteCompat {
    private SupportSQLiteCompat() {
    }

    /* JADX INFO: compiled from: SupportSQLiteCompat.android.kt */
    public static final class Api21Impl {
        public static final Api21Impl INSTANCE = new Api21Impl();

        private Api21Impl() {
        }

        public static final File getNoBackupFilesDir(Context context) {
            Intrinsics.checkNotNullParameter(context, "context");
            File noBackupFilesDir = context.getNoBackupFilesDir();
            Intrinsics.checkNotNullExpressionValue(noBackupFilesDir, "getNoBackupFilesDir(...)");
            return noBackupFilesDir;
        }
    }
}
