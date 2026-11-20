package com.scanflow.datacapture.barinternal.androidx.room.support;

import androidx.sqlite.db.SupportSQLiteProgram;
import java.util.ArrayList;
import java.util.List;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: QueryInterceptorProgram.android.kt */
/* JADX INFO: loaded from: classes.dex */
public final class QueryInterceptorProgram implements SupportSQLiteProgram {
    private final List bindArgsCache = new ArrayList();

    public final List getBindArgsCache$room_runtime_release() {
        return this.bindArgsCache;
    }

    @Override // androidx.sqlite.db.SupportSQLiteProgram
    public void bindNull(int i) {
        saveArgsToCache(i, null);
    }

    @Override // androidx.sqlite.db.SupportSQLiteProgram
    public void bindLong(int i, long j) {
        saveArgsToCache(i, Long.valueOf(j));
    }

    @Override // androidx.sqlite.db.SupportSQLiteProgram
    public void bindDouble(int i, double d) {
        saveArgsToCache(i, Double.valueOf(d));
    }

    @Override // androidx.sqlite.db.SupportSQLiteProgram
    public void bindString(int i, String value) {
        Intrinsics.checkNotNullParameter(value, "value");
        saveArgsToCache(i, value);
    }

    @Override // androidx.sqlite.db.SupportSQLiteProgram
    public void bindBlob(int i, byte[] value) {
        Intrinsics.checkNotNullParameter(value, "value");
        saveArgsToCache(i, value);
    }

    @Override // java.io.Closeable, java.lang.AutoCloseable
    public void close() {
    }

    private final void saveArgsToCache(int i, Object obj) {
        int size;
        int i2 = i - 1;
        if (i2 >= this.bindArgsCache.size() && (size = this.bindArgsCache.size()) <= i2) {
            while (true) {
                this.bindArgsCache.add(null);
                if (size == i2) {
                    break;
                } else {
                    size++;
                }
            }
        }
        this.bindArgsCache.set(i2, obj);
    }
}
