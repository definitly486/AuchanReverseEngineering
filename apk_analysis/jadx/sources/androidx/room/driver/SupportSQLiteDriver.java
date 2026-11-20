package androidx.room.driver;

import androidx.sqlite.SQLiteDriver;
import androidx.sqlite.db.SupportSQLiteOpenHelper;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: SupportSQLiteDriver.android.kt */
/* JADX INFO: loaded from: classes.dex */
public final class SupportSQLiteDriver implements SQLiteDriver {
    private final SupportSQLiteOpenHelper openHelper;

    public SupportSQLiteDriver(SupportSQLiteOpenHelper openHelper) {
        Intrinsics.checkNotNullParameter(openHelper, "openHelper");
        this.openHelper = openHelper;
    }

    public final SupportSQLiteOpenHelper getOpenHelper() {
        return this.openHelper;
    }

    @Override // androidx.sqlite.SQLiteDriver
    public SupportSQLiteConnection open(String fileName) {
        Intrinsics.checkNotNullParameter(fileName, "fileName");
        return new SupportSQLiteConnection(this.openHelper.getWritableDatabase());
    }
}
