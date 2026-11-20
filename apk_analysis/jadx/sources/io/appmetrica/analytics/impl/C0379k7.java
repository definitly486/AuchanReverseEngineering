package io.appmetrica.analytics.impl;

import android.database.sqlite.SQLiteDatabase;
import io.appmetrica.analytics.coreapi.internal.db.DatabaseScript;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.k7, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0379k7 extends DatabaseScript {
    @Override // io.appmetrica.analytics.coreapi.internal.db.DatabaseScript
    public final void runScript(SQLiteDatabase sQLiteDatabase) {
        sQLiteDatabase.execSQL("DROP TABLE IF EXISTS preferences");
    }
}
