package io.appmetrica.analytics.impl;

import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import io.appmetrica.analytics.coreapi.internal.db.DatabaseScript;
import io.appmetrica.analytics.modulesapi.internal.client.adrevenue.AdRevenueConstants;
import okhttp3.internal.connection.RealConnection;

/* JADX INFO: loaded from: classes3.dex */
public final class Y4 extends DatabaseScript {
    public final int a = 2000;
    public final String b = "number";
    public final String c = "global_number";
    public final String d = "number_of_type";
    public final String e = "name";
    public final String f = "value";
    public final String g = "type";
    public final String h = "time";
    public final String i = "session_id";
    public final String j = "error_environment";
    public final String k = "session_type";
    public final String l = "app_environment";
    public final String m = "app_environment_revision";
    public final String n = "truncated";
    public final String o = "custom_type";
    public final String p = "encrypting_mode";
    public final String q = "profile_id";
    public final String r = "first_occurrence_status";
    public final String s = AdRevenueConstants.SOURCE_KEY;
    public final String t = "attribution_id_changed";
    public final String u = "open_id";
    public final String v = "extras";
    public final String w = "reports";
    public final C0691w7 x = new C0691w7(null, 1, 0 == true ? 1 : 0);

    public static boolean a(C0665v7 c0665v7) {
        Long l;
        EnumC0721xb enumC0721xb;
        Long l2;
        Long l3;
        Long l4 = c0665v7.a;
        if (l4 == null || l4.longValue() < RealConnection.IDLE_CONNECTION_HEALTHY_NS || c0665v7.b == null || (l = c0665v7.c) == null || l.longValue() < 0 || (enumC0721xb = c0665v7.d) == null || enumC0721xb == EnumC0721xb.EVENT_TYPE_UNDEFINED || (l2 = c0665v7.e) == null || l2.longValue() < 0 || (l3 = c0665v7.f) == null || l3.longValue() < 0) {
            return false;
        }
        Long l5 = c0665v7.g.d;
        if (l5 != null && l5.longValue() < 0) {
            return false;
        }
        Integer num = c0665v7.g.i;
        return num == null || num.intValue() >= 0;
    }

    @Override // io.appmetrica.analytics.coreapi.internal.db.DatabaseScript
    public final void runScript(SQLiteDatabase sQLiteDatabase) {
        SQLiteDatabase sQLiteDatabase2;
        Cursor cursorQuery;
        sQLiteDatabase.execSQL("CREATE TABLE IF NOT EXISTS events (id INTEGER PRIMARY KEY,session_id INTEGER,session_type INTEGER,number_in_session INTEGER,type INTEGER,global_number INTEGER,time INTEGER,event_description BLOB )");
        Cursor cursor = null;
        try {
            sQLiteDatabase2 = sQLiteDatabase;
            try {
                cursorQuery = sQLiteDatabase2.query(this.w, null, null, null, null, null, null, String.valueOf(this.a));
                while (cursorQuery.moveToNext()) {
                    try {
                        C0665v7 c0665v7A = a(cursorQuery);
                        if (c0665v7A != null && a(c0665v7A)) {
                            try {
                                sQLiteDatabase2.insertOrThrow("events", null, this.x.fromModel(c0665v7A));
                            } catch (Throwable unused) {
                            }
                        }
                    } catch (Throwable unused2) {
                        cursor = cursorQuery;
                        if (cursor != null) {
                            cursorQuery = cursor;
                        }
                        sQLiteDatabase2.execSQL("DROP TABLE IF EXISTS " + this.w);
                    }
                }
            } catch (Throwable unused3) {
            }
        } catch (Throwable unused4) {
            sQLiteDatabase2 = sQLiteDatabase;
        }
        cursorQuery.close();
        sQLiteDatabase2.execSQL("DROP TABLE IF EXISTS " + this.w);
    }

    /* JADX WARN: Code duplicated, block: B:33:0x0115 A[PHI: r4
      0x0115: PHI (r4v8 io.appmetrica.analytics.impl.G9) = (r4v7 io.appmetrica.analytics.impl.G9), (r4v9 io.appmetrica.analytics.impl.G9), (r4v10 io.appmetrica.analytics.impl.G9) binds: [B:38:0x0120, B:32:0x0113, B:35:0x011a] A[DONT_GENERATE, DONT_INLINE]] */
    public final C0665v7 a(Cursor cursor) {
        EnumC0523pl enumC0523pl;
        EnumC0175c9 enumC0175c9;
        Aa aa;
        Aa aa2;
        G9 g9;
        G9 g10;
        boolean z;
        int i;
        try {
            Long lValueOf = Long.valueOf(cursor.getLong(cursor.getColumnIndexOrThrow(this.i)));
            int i2 = cursor.getInt(cursor.getColumnIndexOrThrow(this.k));
            EnumC0523pl enumC0523pl2 = EnumC0523pl.FOREGROUND;
            if (i2 != 0) {
                enumC0523pl2 = EnumC0523pl.BACKGROUND;
                enumC0523pl = i2 == 1 ? enumC0523pl2 : null;
            }
            Long lValueOf2 = Long.valueOf(cursor.getLong(cursor.getColumnIndexOrThrow(this.b)));
            EnumC0721xb enumC0721xbA = EnumC0721xb.a(cursor.getInt(cursor.getColumnIndexOrThrow(this.g)));
            Long lValueOf3 = Long.valueOf(cursor.getLong(cursor.getColumnIndexOrThrow(this.c)));
            Long lValueOf4 = Long.valueOf(cursor.getLong(cursor.getColumnIndexOrThrow(this.h)));
            Integer numValueOf = Integer.valueOf(cursor.getInt(cursor.getColumnIndexOrThrow(this.o)));
            String string = cursor.getString(cursor.getColumnIndexOrThrow(this.e));
            String string2 = cursor.getString(cursor.getColumnIndexOrThrow(this.f));
            Long lValueOf5 = Long.valueOf(cursor.getLong(cursor.getColumnIndexOrThrow(this.d)));
            String string3 = cursor.getString(cursor.getColumnIndexOrThrow(this.j));
            String string4 = cursor.getString(cursor.getColumnIndexOrThrow(this.l));
            Long lValueOf6 = Long.valueOf(cursor.getLong(cursor.getColumnIndexOrThrow(this.m)));
            Integer numValueOf2 = Integer.valueOf(cursor.getInt(cursor.getColumnIndexOrThrow(this.n)));
            int i3 = cursor.getInt(cursor.getColumnIndexOrThrow(this.p));
            EnumC0175c9 enumC0175c10 = EnumC0175c9.NONE;
            if (i3 == 0) {
                enumC0175c9 = enumC0175c10;
            } else {
                enumC0175c10 = EnumC0175c9.AES_VALUE_ENCRYPTION;
                if (i3 != 2) {
                    enumC0175c10 = EnumC0175c9.EXTERNALLY_ENCRYPTED_EVENT_CRYPTER;
                    if (i3 != 1) {
                        enumC0175c9 = null;
                    }
                }
                enumC0175c9 = enumC0175c10;
            }
            String string5 = cursor.getString(cursor.getColumnIndexOrThrow(this.q));
            try {
                int i4 = cursor.getInt(cursor.getColumnIndexOrThrow(this.r));
                aa2 = Aa.FIRST_OCCURRENCE;
                if (i4 != 1) {
                    aa2 = Aa.NON_FIRST_OCCURENCE;
                    if (i4 != 2) {
                        aa = Aa.UNKNOWN;
                    }
                    aa2 = aa;
                }
            } catch (Throwable unused) {
                aa = Aa.UNKNOWN;
            }
            Aa aa3 = aa2;
            try {
                int i5 = cursor.getInt(cursor.getColumnIndexOrThrow(this.s));
                g9 = G9.NATIVE;
                if (i5 == 0) {
                    g10 = g9;
                } else {
                    g9 = G9.JS;
                    if (i5 == 1) {
                        g10 = g9;
                    } else {
                        g10 = null;
                    }
                }
            } catch (Throwable unused2) {
                g9 = G9.NATIVE;
            }
            try {
                z = cursor.getInt(cursor.getColumnIndexOrThrow(this.t)) == 1;
            } catch (Throwable unused3) {
            }
            Boolean boolValueOf = Boolean.valueOf(z);
            try {
                i = cursor.getInt(cursor.getColumnIndexOrThrow(this.u));
            } catch (Throwable unused4) {
                i = -1;
            }
            Integer numValueOf3 = Integer.valueOf(i);
            int columnIndex = cursor.getColumnIndex(this.v);
            return new C0665v7(lValueOf, enumC0523pl, lValueOf2, enumC0721xbA, lValueOf3, lValueOf4, new C0639u7(numValueOf, string, string2, lValueOf5, null, string3, string4, lValueOf6, numValueOf2, null, null, enumC0175c9, string5, aa3, g10, boolValueOf, numValueOf3, columnIndex < 0 ? null : cursor.getBlob(columnIndex)));
        } catch (Throwable unused5) {
            return null;
        }
    }
}
