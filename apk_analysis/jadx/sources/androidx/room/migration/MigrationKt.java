package androidx.room.migration;

import androidx.sqlite.db.SupportSQLiteDatabase;
import com.scanflow.datacapture.barinternal.kotlin.Unit;
import kotlin.jvm.functions.Function1;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: Migration.android.kt */
/* JADX INFO: loaded from: classes.dex */
public final class MigrationKt {
    public static final Migration Migration(int i, int i2, Function1<? super SupportSQLiteDatabase, Unit> migrate) {
        Intrinsics.checkNotNullParameter(migrate, "migrate");
        return new MigrationImpl(i, i2, migrate);
    }
}
