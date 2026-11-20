package io.appmetrica.analytics.impl;

import android.content.ContentValues;
import android.database.sqlite.SQLiteDatabase;
import com.scanflow.datacapture.barinternal.kotlin.Unit;
import com.scanflow.datacapture.barinternal.kotlin.collections.CollectionsKt;
import io.appmetrica.analytics.logger.appmetrica.internal.PublicLogger;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Iterator;
import java.util.List;
import java.util.concurrent.atomic.AtomicLong;
import java.util.concurrent.locks.ReentrantReadWriteLock;
import kotlin.jvm.internal.StringCompanionObject;

/* JADX INFO: loaded from: classes3.dex */
public final class X8 {
    public final C0509p7 a;
    public final C0455n5 b;
    public final AtomicLong c;
    public final List d;
    public final Z6 e;
    public final ReentrantReadWriteLock.WriteLock f;

    public X8(C0509p7 c0509p7, C0455n5 c0455n5, AtomicLong atomicLong, ArrayList arrayList, Z6 z6, ReentrantReadWriteLock reentrantReadWriteLock) {
        this.a = c0509p7;
        this.b = c0455n5;
        this.c = atomicLong;
        this.d = arrayList;
        this.e = z6;
        this.f = reentrantReadWriteLock.writeLock();
    }

    public final int a(SQLiteDatabase sQLiteDatabase) {
        try {
            StringCompanionObject stringCompanionObject = StringCompanionObject.INSTANCE;
            return this.e.a(sQLiteDatabase, String.format("id IN (SELECT id FROM events ORDER BY CASE WHEN type IN (%1$s) THEN 2 WHEN type IN (%2$s) THEN 1 ELSE 0 END, id LIMIT (SELECT count() FROM events) / %3$s)", Arrays.copyOf(new Object[]{CollectionsKt.joinToString$default(Q9.i, ", ", null, null, 0, null, null, 62, null), CollectionsKt.joinToString$default(Q9.j, ", ", null, null, 0, null, null, 62, null), 10}, 3)), null, 2, this.b.b.b, true).b;
        } catch (Throwable th) {
            C0263fk c0263fk = Dj.a;
            c0263fk.getClass();
            c0263fk.a(new Ej("deleteExcessiveReports exception", th));
            return 0;
        }
    }

    public final void b(List list) {
        int iA;
        if (list.isEmpty()) {
            return;
        }
        long j = ((C0727xh) this.b.k.a()).v;
        ReentrantReadWriteLock.WriteLock writeLock = this.f;
        writeLock.lock();
        SQLiteDatabase sQLiteDatabase = null;
        try {
            try {
                SQLiteDatabase writableDatabase = this.a.getWritableDatabase();
                if (writableDatabase != null) {
                    try {
                        writableDatabase.beginTransaction();
                        Iterator it = list.iterator();
                        while (it.hasNext()) {
                            ContentValues contentValues = (ContentValues) it.next();
                            writableDatabase.insertOrThrow("events", null, contentValues);
                            this.c.incrementAndGet();
                            a(contentValues);
                        }
                        if (this.c.get() > j) {
                            iA = a(writableDatabase);
                            this.c.addAndGet(-iA);
                        } else {
                            iA = 0;
                        }
                        writableDatabase.setTransactionSuccessful();
                        if (iA != 0) {
                            Iterator it2 = this.d.iterator();
                            while (it2.hasNext()) {
                                ((InterfaceC0433m9) it2.next()).a();
                            }
                        }
                        Unit unit = Unit.INSTANCE;
                    } catch (Throwable unused) {
                        sQLiteDatabase = writableDatabase;
                        try {
                            Unit unit2 = Unit.INSTANCE;
                            Do.a(sQLiteDatabase);
                        } catch (Throwable th) {
                            Do.a(sQLiteDatabase);
                            throw th;
                        }
                    }
                }
                Do.a(writableDatabase);
            } catch (Throwable th2) {
                writeLock.unlock();
                throw th2;
            }
        } catch (Throwable unused2) {
        }
        writeLock.unlock();
    }

    /* JADX WARN: Multi-variable type inference failed */
    public final void a(ContentValues contentValues) {
        Integer asInteger = contentValues.getAsInteger("type");
        if (Q9.d.contains(EnumC0721xb.a(asInteger != null ? asInteger.intValue() : -1))) {
            C0665v7 model = new C0691w7(null, 1, 0 == true ? 1 : 0).toModel(contentValues);
            PublicLogger publicLogger = this.b.m;
            EnumC0721xb enumC0721xb = model.d;
            C0639u7 c0639u7 = model.g;
            publicLogger.info(AbstractC0414lg.a("Event saved to db", enumC0721xb, c0639u7.b, c0639u7.c), new Object[0]);
        }
    }

    public final void a(List list) {
        ArrayList arrayList = new ArrayList(CollectionsKt.collectionSizeOrDefault(list, 10));
        Iterator it = list.iterator();
        while (it.hasNext()) {
            Integer asInteger = ((ContentValues) it.next()).getAsInteger("type");
            arrayList.add(Integer.valueOf(asInteger != null ? asInteger.intValue() : -1));
        }
        Iterator it2 = this.d.iterator();
        while (it2.hasNext()) {
            ((InterfaceC0433m9) it2.next()).a(arrayList);
        }
        ((A5) this.b.p).e();
    }
}
