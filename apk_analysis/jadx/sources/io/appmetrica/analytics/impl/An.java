package io.appmetrica.analytics.impl;

import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import java.util.Arrays;
import java.util.Collections;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

/* JADX INFO: loaded from: classes3.dex */
public final class An implements InterfaceC0785zn {
    public final HashMap a;

    public An(String str, HashMap<String, List<String>> map) {
        this.a = map;
    }

    public final HashMap<String, List<String>> a() {
        return this.a;
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0785zn
    public final boolean a(SQLiteDatabase sQLiteDatabase) {
        try {
            boolean zEquals = true;
            for (Map.Entry entry : this.a.entrySet()) {
                try {
                    SQLiteDatabase sQLiteDatabase2 = sQLiteDatabase;
                    Cursor cursorQuery = sQLiteDatabase2.query((String) entry.getKey(), null, null, null, null, null, null);
                    if (cursorQuery == null) {
                        Do.a(cursorQuery);
                        return false;
                    }
                    List list = (List) entry.getValue();
                    List listAsList = Arrays.asList(cursorQuery.getColumnNames());
                    Collections.sort(listAsList);
                    zEquals &= list.equals(listAsList);
                    Do.a(cursorQuery);
                    sQLiteDatabase = sQLiteDatabase2;
                } catch (Throwable th) {
                    Do.a((Cursor) null);
                    throw th;
                }
            }
            return zEquals;
        } catch (Throwable unused) {
            return false;
        }
    }
}
