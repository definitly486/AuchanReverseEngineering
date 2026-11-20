package io.appmetrica.analytics.impl;

import android.content.ContentValues;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import io.appmetrica.analytics.coreapi.internal.db.DatabaseScript;
import java.util.ArrayList;

/* JADX INFO: loaded from: classes3.dex */
public final class Z4 extends DatabaseScript {
    public final String a = "sessions";
    public final int b = 200;
    public final String c = "id";
    public final String d = "start_time";
    public final String e = "report_request_parameters";
    public final String f = "server_time_offset";
    public final String g = "type";
    public final String h = "obtained_before_first_sync";
    public final K7 i = new K7(null, 1, 0 == true ? 1 : 0);

    public final J7 a(Cursor cursor) {
        try {
            Long lValueOf = Long.valueOf(cursor.getLong(cursor.getColumnIndexOrThrow(this.c)));
            int i = cursor.getInt(cursor.getColumnIndexOrThrow(this.g));
            EnumC0523pl enumC0523pl = EnumC0523pl.FOREGROUND;
            boolean z = true;
            if (i != 0) {
                enumC0523pl = EnumC0523pl.BACKGROUND;
                if (i != 1) {
                    enumC0523pl = null;
                }
            }
            String string = cursor.getString(cursor.getColumnIndexOrThrow(this.e));
            Long lValueOf2 = Long.valueOf(cursor.getLong(cursor.getColumnIndexOrThrow(this.d)));
            Long lValueOf3 = Long.valueOf(cursor.getLong(cursor.getColumnIndexOrThrow(this.f)));
            if (cursor.getInt(cursor.getColumnIndexOrThrow(this.h)) != 1) {
                z = false;
            }
            return new J7(lValueOf, enumC0523pl, string, new I7(lValueOf2, lValueOf3, Boolean.valueOf(z)));
        } catch (Throwable unused) {
            return null;
        }
    }

    /* JADX WARN: Code duplicated, block: B:33:0x0080  */
    @Override // io.appmetrica.analytics.coreapi.internal.db.DatabaseScript
    public final void runScript(SQLiteDatabase sQLiteDatabase) {
        SQLiteDatabase sQLiteDatabase2;
        Cursor cursorQuery;
        int size;
        int i;
        Long l;
        String str;
        Long l2;
        ArrayList arrayList = new ArrayList();
        try {
            sQLiteDatabase2 = sQLiteDatabase;
            try {
                cursorQuery = sQLiteDatabase2.query(this.a, null, null, null, null, null, null, String.valueOf(this.b));
                while (cursorQuery.moveToNext()) {
                    try {
                        J7 j7A = a(cursorQuery);
                        if (j7A != null && (l = j7A.a) != null && l.longValue() >= 0 && j7A.b != null && (str = j7A.c) != null && str.length() != 0 && (l2 = j7A.d.a) != null && l2.longValue() > 0) {
                            arrayList.add(this.i.fromModel(j7A));
                        }
                    } catch (Throwable unused) {
                        if (cursorQuery != null) {
                        }
                        sQLiteDatabase2.execSQL("DROP TABLE IF EXISTS " + this.a);
                        sQLiteDatabase2.execSQL("CREATE TABLE IF NOT EXISTS sessions (id INTEGER,type INTEGER,report_request_parameters TEXT,session_description BLOB )");
                        size = arrayList.size();
                        i = 0;
                        while (i < size) {
                            Object obj = arrayList.get(i);
                            i++;
                            try {
                                sQLiteDatabase2.insertOrThrow("sessions", null, (ContentValues) obj);
                            } catch (Throwable unused2) {
                            }
                        }
                    }
                }
            } catch (Throwable unused3) {
                cursorQuery = null;
                if (cursorQuery != null) {
                    cursorQuery.close();
                }
                sQLiteDatabase2.execSQL("DROP TABLE IF EXISTS " + this.a);
                sQLiteDatabase2.execSQL("CREATE TABLE IF NOT EXISTS sessions (id INTEGER,type INTEGER,report_request_parameters TEXT,session_description BLOB )");
                size = arrayList.size();
                i = 0;
                while (i < size) {
                    Object obj2 = arrayList.get(i);
                    i++;
                    sQLiteDatabase2.insertOrThrow("sessions", null, (ContentValues) obj2);
                }
            }
        } catch (Throwable unused4) {
            sQLiteDatabase2 = sQLiteDatabase;
        }
        cursorQuery.close();
        sQLiteDatabase2.execSQL("DROP TABLE IF EXISTS " + this.a);
        sQLiteDatabase2.execSQL("CREATE TABLE IF NOT EXISTS sessions (id INTEGER,type INTEGER,report_request_parameters TEXT,session_description BLOB )");
        size = arrayList.size();
        i = 0;
        while (i < size) {
            Object obj3 = arrayList.get(i);
            i++;
            sQLiteDatabase2.insertOrThrow("sessions", null, (ContentValues) obj3);
        }
    }
}
