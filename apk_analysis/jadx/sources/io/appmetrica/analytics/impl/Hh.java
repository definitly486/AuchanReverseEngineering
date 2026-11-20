package io.appmetrica.analytics.impl;

import android.content.ContentValues;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import com.scanflow.datacapture.barinternal.kotlin.Unit;
import com.scanflow.datacapture.barinternal.kotlin.collections.CollectionsKt;
import com.scanflow.datacapture.barinternal.kotlin.io.CloseableKt;
import io.appmetrica.analytics.coreutils.internal.db.DBUtils;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Iterator;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;

/* JADX INFO: loaded from: classes3.dex */
public final class Hh {
    public final C0173c7 a;
    public final C0393kl b;
    public final Po c;

    public Hh(C0455n5 c0455n5) {
        this.a = c0455n5.i();
        this.b = c0455n5.s();
        this.c = c0455n5.u();
    }

    public final List a(LinkedHashMap linkedHashMap) {
        Cursor cursorQuery;
        C0173c7 c0173c7 = this.a;
        c0173c7.a.lock();
        try {
            SQLiteDatabase readableDatabase = c0173c7.c.getReadableDatabase();
            if (readableDatabase != null) {
                String strA = C0173c7.a(linkedHashMap);
                ArrayList arrayList = new ArrayList(Arrays.asList(Long.toString(0L)));
                Iterator it = linkedHashMap.entrySet().iterator();
                while (it.hasNext()) {
                    arrayList.add((String) ((Map.Entry) it.next()).getValue());
                }
                cursorQuery = readableDatabase.query("sessions", null, strA, (String[]) arrayList.toArray(new String[0]), null, null, "id ASC", null);
            } else {
                cursorQuery = null;
            }
        } catch (Throwable unused) {
        }
        c0173c7.a.unlock();
        if (cursorQuery == null) {
            return CollectionsKt.emptyList();
        }
        ArrayList arrayList2 = new ArrayList();
        while (cursorQuery.moveToNext()) {
            try {
                try {
                    ContentValues contentValues = new ContentValues();
                    DBUtils.cursorRowToContentValues(cursorQuery, contentValues);
                    arrayList2.add(new K7(null, 1, null).toModel(contentValues));
                } catch (Throwable th) {
                    try {
                        throw th;
                    } catch (Throwable th2) {
                        CloseableKt.closeFinally(cursorQuery, th);
                        throw th2;
                    }
                }
            } catch (Throwable unused2) {
            }
        }
        Unit unit = Unit.INSTANCE;
        CloseableKt.closeFinally(cursorQuery, null);
        return arrayList2;
    }

    public final int a() {
        int iOptInt;
        Po po = this.c;
        synchronized (po) {
            iOptInt = po.a.a().optInt("report_request_id", -1);
        }
        return iOptInt + 1;
    }
}
