package io.appmetrica.analytics.impl;

import android.database.sqlite.SQLiteDatabase;
import io.appmetrica.analytics.coreapi.internal.db.DatabaseScript;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.a5, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0119a5 extends DatabaseScript {
    public final Z4 a = new Z4();
    public final Y4 b = new Y4();

    @Override // io.appmetrica.analytics.coreapi.internal.db.DatabaseScript
    public final void runScript(SQLiteDatabase sQLiteDatabase) {
        this.a.runScript(sQLiteDatabase);
        this.b.runScript(sQLiteDatabase);
    }
}
