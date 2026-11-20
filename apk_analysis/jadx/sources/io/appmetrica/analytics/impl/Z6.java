package io.appmetrica.analytics.impl;

import android.content.ContentValues;
import android.database.Cursor;
import android.database.DatabaseUtils;
import android.database.sqlite.SQLiteDatabase;
import android.os.ResultReceiver;
import io.appmetrica.analytics.coreutils.internal.logger.LoggerStorage;
import io.appmetrica.analytics.internal.CounterConfiguration;
import io.appmetrica.analytics.internal.CounterConfigurationReporterType;
import io.appmetrica.analytics.logger.appmetrica.internal.PublicLogger;
import java.util.ArrayList;
import java.util.Map;
import java.util.Set;
import org.json.JSONArray;
import org.json.JSONObject;

/* JADX INFO: loaded from: classes3.dex */
public final class Z6 {
    public final CounterConfigurationReporterType a;

    public Z6(CounterConfigurationReporterType counterConfigurationReporterType) {
        this.a = counterConfigurationReporterType;
    }

    /* JADX WARN: Code duplicated, block: B:14:0x0040  */
    public final X6 a(SQLiteDatabase sQLiteDatabase, String str, String[] strArr, int i, String str2, boolean z) {
        Cursor cursorQuery;
        ArrayList arrayList;
        int iDelete;
        C0781zj c0781zj;
        C0196d4 c0196d4;
        Integer num;
        try {
            cursorQuery = sQLiteDatabase.query("events", new String[]{"global_number", "type", "event_description"}, str, strArr, null, null, null);
            if (cursorQuery != null) {
                try {
                    if (cursorQuery.getCount() > 0) {
                        arrayList = new ArrayList(cursorQuery.getCount());
                        while (cursorQuery.moveToNext()) {
                            ContentValues contentValues = new ContentValues();
                            DatabaseUtils.cursorRowToContentValues(cursorQuery, contentValues);
                            arrayList.add(contentValues);
                        }
                    } else {
                        arrayList = null;
                    }
                } catch (Throwable th) {
                    th = th;
                    try {
                        C0263fk c0263fk = Dj.a;
                        c0263fk.getClass();
                        c0263fk.a(new Ej("select_rows_to_delete_exception", th));
                        Do.a(cursorQuery);
                        arrayList = null;
                    } catch (Throwable th2) {
                        Do.a(cursorQuery);
                        throw th2;
                    }
                }
            } else {
                arrayList = null;
            }
            Do.a(cursorQuery);
        } catch (Throwable th3) {
            th = th3;
            cursorQuery = null;
        }
        int i2 = 0;
        try {
            iDelete = sQLiteDatabase.delete("events", str, strArr);
        } catch (Throwable unused) {
            iDelete = 0;
        }
        if (arrayList != null && arrayList.size() != 0 && iDelete == arrayList.size() && z) {
            Bj bj = Ka.I.f;
            if (str2 != null && bj != null) {
                CounterConfigurationReporterType counterConfigurationReporterType = this.a;
                synchronized (bj) {
                    c0781zj = (C0781zj) bj.c.get(str2);
                    if (c0781zj == null) {
                        c0781zj = new C0781zj(str2, bj.b, counterConfigurationReporterType, bj.a);
                        bj.c.put(str2, c0781zj);
                    }
                }
                try {
                    JSONObject jSONObject = new JSONObject();
                    JSONArray jSONArray = new JSONArray();
                    JSONArray jSONArray2 = new JSONArray();
                    int size = arrayList.size();
                    while (i2 < size) {
                        Object obj = arrayList.get(i2);
                        i2++;
                        ContentValues contentValues2 = (ContentValues) obj;
                        Integer asInteger = contentValues2.getAsInteger("global_number");
                        Integer asInteger2 = contentValues2.getAsInteger("type");
                        if (asInteger != null && asInteger2 != null) {
                            jSONArray.put(asInteger);
                            EnumC0721xb enumC0721xbA = EnumC0721xb.a(asInteger2.intValue());
                            if (enumC0721xbA == null) {
                                Map map = AbstractC0388kg.a;
                                num = null;
                            } else {
                                num = (Integer) AbstractC0388kg.c.get(enumC0721xbA);
                            }
                            jSONArray2.put(num);
                        }
                    }
                    jSONObject.put("global_number", jSONArray).put("event_type", jSONArray2);
                    JSONObject jSONObjectPut = new JSONObject().put("details", new JSONObject().put("reason", Y6.a(i)).put("cleared", jSONObject).put("actual_deleted_number", iDelete));
                    PublicLogger orCreatePublicLogger = LoggerStorage.getOrCreatePublicLogger(str2);
                    String string = jSONObjectPut.toString();
                    Set set = Q9.a;
                    EnumC0721xb enumC0721xb = EnumC0721xb.EVENT_TYPE_UNDEFINED;
                    c0196d4 = new C0196d4(string, "", 12290, 0, orCreatePublicLogger);
                } catch (Throwable unused2) {
                    c0196d4 = null;
                }
                if (c0196d4 != null && c0781zj.c != null) {
                    try {
                        CounterConfiguration counterConfiguration = new CounterConfiguration(c0781zj.a);
                        counterConfiguration.setReporterType(c0781zj.c);
                        c0781zj.d.a.reportData(1, c0196d4.d(new Sh(new Wf(c0781zj.b, (ResultReceiver) null), counterConfiguration, new W8(new Ll(LoggerStorage.getOrCreatePublicLogger(c0781zj.a), "Crash Environment")), null).c()));
                    } catch (Throwable unused3) {
                    }
                }
            }
        }
        return new X6(arrayList, iDelete);
    }
}
