package androidx.room;

import androidx.sqlite.db.SupportSQLiteOpenHelper;

/* JADX INFO: compiled from: DelegatingOpenHelper.android.kt */
/* JADX INFO: loaded from: classes.dex */
public interface DelegatingOpenHelper {
    SupportSQLiteOpenHelper getDelegate();
}
