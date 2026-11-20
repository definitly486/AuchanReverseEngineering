package io.appmetrica.analytics.impl;

import android.content.ContentValues;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import com.scanflow.datacapture.barinternal.kotlin.TuplesKt;
import com.scanflow.datacapture.barinternal.kotlin.Unit;
import com.scanflow.datacapture.barinternal.kotlin.collections.CollectionsKt;
import com.scanflow.datacapture.barinternal.kotlin.collections.MapsKt;
import com.scanflow.datacapture.barinternal.kotlin.io.CloseableKt;
import io.appmetrica.analytics.coreapi.internal.executors.IHandlerExecutor;
import io.appmetrica.analytics.coreutils.internal.buffering.BatchProcessor;
import io.appmetrica.analytics.coreutils.internal.buffering.DeferredBatchExecutor;
import io.appmetrica.analytics.coreutils.internal.buffering.MapMergingBuffer;
import io.appmetrica.analytics.coreutils.internal.parsing.ParseUtils;
import java.io.Closeable;
import java.util.ArrayList;
import java.util.HashSet;
import java.util.Iterator;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;
import java.util.Set;
import kotlin.jvm.internal.ArrayIteratorKt;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: loaded from: classes3.dex */
public final class Ob implements InterfaceC0280gb, Closeable {
    public static final Nb g = new Nb();
    public final String a;
    public final Q6 b;
    public final LinkedHashMap c = new LinkedHashMap();
    public final Object d = new Object();
    public volatile boolean e;
    public final DeferredBatchExecutor f;

    public Ob(String str, Q6 q6, IHandlerExecutor iHandlerExecutor) {
        this.a = str;
        this.b = q6;
        this.f = new DeferredBatchExecutor(iHandlerExecutor, new MapMergingBuffer(), new BatchProcessor() { // from class: io.appmetrica.analytics.impl.Ob$$ExternalSyntheticLambda0
            @Override // io.appmetrica.analytics.coreutils.internal.buffering.BatchProcessor
            public final void processBatch(List list) {
                Ob.a(this.f$0, list);
            }
        }, 1000L, "[KeyValueTableDbHelper-(" + str + ")]");
        iHandlerExecutor.execute(new Runnable() { // from class: io.appmetrica.analytics.impl.Ob$$ExternalSyntheticLambda1
            @Override // java.lang.Runnable
            public final void run() {
                Ob.a(this.f$0);
            }
        });
    }

    public static final void a(Ob ob, List list) {
        SQLiteDatabase sQLiteDatabaseA;
        Map map = (Map) CollectionsKt.first(list);
        ob.getClass();
        ArrayList arrayList = new ArrayList(map.size());
        for (Map.Entry entry : map.entrySet()) {
            String str = (String) entry.getKey();
            Object value = entry.getValue();
            ContentValues contentValues = new ContentValues();
            contentValues.put("key", str);
            if (value == ob) {
                contentValues.putNull("value");
            } else if (value instanceof String) {
                contentValues.put("value", (String) value);
                contentValues.put("type", (Integer) 4);
            } else if (value instanceof Long) {
                contentValues.put("value", (Long) value);
                contentValues.put("type", (Integer) 3);
            } else if (value instanceof Integer) {
                contentValues.put("value", (Integer) value);
                contentValues.put("type", (Integer) 2);
            } else if (value instanceof Boolean) {
                contentValues.put("value", String.valueOf(((Boolean) value).booleanValue()));
                contentValues.put("type", (Integer) 1);
            } else if (value instanceof Float) {
                contentValues.put("value", (Float) value);
                contentValues.put("type", (Integer) 5);
            }
            arrayList.add(contentValues);
        }
        ContentValues[] contentValuesArr = (ContentValues[]) arrayList.toArray(new ContentValues[0]);
        if (contentValuesArr == null) {
            return;
        }
        SQLiteDatabase sQLiteDatabase = null;
        try {
            sQLiteDatabaseA = ob.b.a();
            if (sQLiteDatabaseA != null) {
                try {
                    sQLiteDatabaseA.beginTransaction();
                    try {
                        Iterator it = ArrayIteratorKt.iterator(contentValuesArr);
                        while (it.hasNext()) {
                            ContentValues contentValues2 = (ContentValues) it.next();
                            if (contentValues2.getAsString("value") == null) {
                                sQLiteDatabaseA.delete(ob.a, "key = ?", new String[]{contentValues2.getAsString("key")});
                            } else {
                                sQLiteDatabaseA.insertWithOnConflict(ob.a, null, contentValues2, 5);
                            }
                        }
                        sQLiteDatabaseA.setTransactionSuccessful();
                        Do.a(sQLiteDatabaseA);
                    } catch (Throwable th) {
                        Do.a(sQLiteDatabaseA);
                        throw th;
                    }
                } catch (Throwable unused) {
                    sQLiteDatabase = sQLiteDatabaseA;
                    sQLiteDatabaseA = sQLiteDatabase;
                }
            }
        } catch (Throwable unused2) {
        }
        ob.b.a(sQLiteDatabaseA);
    }

    public final float b(String str, float f) {
        Object objB = b(str);
        return objB instanceof Float ? ((Number) objB).floatValue() : f;
    }

    public final void c() {
        SQLiteDatabase sQLiteDatabaseA;
        Object obj;
        SQLiteDatabase sQLiteDatabase = null;
        try {
            sQLiteDatabaseA = this.b.a();
            if (sQLiteDatabaseA != null) {
                try {
                    Cursor cursorQuery = sQLiteDatabaseA.query(this.a, new String[]{"key", "value", "type"}, null, null, null, null, null);
                    if (cursorQuery != null) {
                        while (cursorQuery.moveToNext()) {
                            try {
                                String string = cursorQuery.getString(cursorQuery.getColumnIndexOrThrow("key"));
                                String string2 = cursorQuery.getString(cursorQuery.getColumnIndexOrThrow("value"));
                                int i = cursorQuery.getInt(cursorQuery.getColumnIndexOrThrow("type"));
                                if (string != null && string.length() != 0) {
                                    if (i != 1) {
                                        if (i == 2) {
                                            obj = ParseUtils.parseInt(string2);
                                        } else if (i == 3) {
                                            obj = ParseUtils.parseLong(string2);
                                        } else if (i != 4) {
                                            if (i != 5) {
                                                obj = string2;
                                            } else {
                                                obj = string2;
                                                obj = ParseUtils.parseFloat(string2);
                                            }
                                        }
                                    } else if (Intrinsics.areEqual(string2, "true")) {
                                        obj = Boolean.TRUE;
                                    } else {
                                        obj = Intrinsics.areEqual(string2, "false") ? Boolean.FALSE : null;
                                    }
                                    if (obj != null) {
                                        this.c.put(string, obj);
                                    }
                                }
                            } catch (Throwable th) {
                                try {
                                    throw th;
                                } catch (Throwable th2) {
                                    CloseableKt.closeFinally(cursorQuery, th);
                                    throw th2;
                                }
                            }
                        }
                        Unit unit = Unit.INSTANCE;
                        CloseableKt.closeFinally(cursorQuery, null);
                    }
                } catch (Throwable unused) {
                    sQLiteDatabase = sQLiteDatabaseA;
                    sQLiteDatabaseA = sQLiteDatabase;
                }
            }
        } catch (Throwable unused2) {
        }
        this.b.a(sQLiteDatabaseA);
    }

    @Override // java.io.Closeable, java.lang.AutoCloseable
    public final void close() {
        this.f.flush();
    }

    public final void d() {
        if (this.e) {
            return;
        }
        try {
            Object obj = this.d;
            Intrinsics.checkNotNull(obj, "null cannot be cast to non-null type java.lang.Object");
            obj.wait();
        } catch (InterruptedException unused) {
        }
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0280gb
    public final void flushAsync() {
        this.f.flushAsync();
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0280gb
    public final boolean getBoolean(String str, boolean z) {
        Object objB = b(str);
        return objB instanceof Boolean ? ((Boolean) objB).booleanValue() : z;
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0280gb
    public final int getInt(String str, int i) {
        Object objB = b(str);
        return objB instanceof Integer ? ((Number) objB).intValue() : i;
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0280gb
    public final long getLong(String str, long j) {
        Object objB = b(str);
        return objB instanceof Long ? ((Number) objB).longValue() : j;
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0280gb
    public final String getString(String str, String str2) {
        Object objB = b(str);
        return objB instanceof String ? (String) objB : str2;
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0280gb
    public final InterfaceC0280gb remove(String str) {
        synchronized (this.d) {
            d();
            this.c.remove(str);
        }
        DeferredBatchExecutor.submit$default(this.f, MapsKt.mapOf(TuplesKt.to(str, this)), false, 2, null);
        return this;
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0280gb
    public final Set<String> b() {
        HashSet hashSet;
        synchronized (this.d) {
            hashSet = new HashSet(this.c.keySet());
        }
        return hashSet;
    }

    public final Object b(String str) {
        Object obj;
        synchronized (this.d) {
            d();
            obj = this.c.get(str);
        }
        return obj;
    }

    public static final void a(Ob ob) {
        synchronized (ob.d) {
            ob.c();
            ob.e = true;
            Object obj = ob.d;
            Intrinsics.checkNotNull(obj, "null cannot be cast to non-null type java.lang.Object");
            obj.notifyAll();
            Unit unit = Unit.INSTANCE;
        }
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0280gb
    public final void a() {
        this.f.flush();
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0280gb
    public final InterfaceC0280gb a(String str, String str2) {
        a(str, (Object) str2);
        return this;
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0280gb
    public final InterfaceC0280gb a(String str, long j) {
        a(str, Long.valueOf(j));
        return this;
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0280gb
    public final InterfaceC0280gb a(String str, int i) {
        a(str, Integer.valueOf(i));
        return this;
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0280gb
    public final InterfaceC0280gb a(String str, boolean z) {
        a(str, Boolean.valueOf(z));
        return this;
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0280gb
    public final InterfaceC0280gb a(String str, float f) {
        a(str, Float.valueOf(f));
        return this;
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0280gb
    public final boolean a(String str) {
        boolean zContainsKey;
        synchronized (this.d) {
            d();
            zContainsKey = this.c.containsKey(str);
        }
        return zContainsKey;
    }

    public final void a(String str, Object obj) {
        synchronized (this.d) {
            d();
            this.c.put(str, obj);
            Unit unit = Unit.INSTANCE;
        }
        DeferredBatchExecutor.submit$default(this.f, MapsKt.mapOf(TuplesKt.to(str, obj)), false, 2, null);
    }
}
