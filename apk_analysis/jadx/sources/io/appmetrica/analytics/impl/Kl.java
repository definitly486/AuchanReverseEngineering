package io.appmetrica.analytics.impl;

import android.database.sqlite.SQLiteDatabase;

/* JADX INFO: loaded from: classes3.dex */
public final class Kl implements Q6 {
    public final C0509p7 a;

    public Kl(C0509p7 c0509p7) {
        this.a = c0509p7;
    }

    @Override // io.appmetrica.analytics.impl.Q6
    public final void a(SQLiteDatabase sQLiteDatabase) {
    }

    @Override // io.appmetrica.analytics.impl.Q6
    public final SQLiteDatabase a() {
        try {
            return this.a.getWritableDatabase();
        } catch (Throwable unused) {
            return null;
        }
    }
}
