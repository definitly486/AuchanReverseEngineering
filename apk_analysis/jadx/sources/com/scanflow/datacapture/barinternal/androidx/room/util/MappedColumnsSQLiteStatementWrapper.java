package com.scanflow.datacapture.barinternal.androidx.room.util;

import androidx.sqlite.SQLiteStatement;
import com.scanflow.datacapture.barinternal.kotlin.collections.MapsKt;
import java.util.Map;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: StatementUtil.kt */
/* JADX INFO: loaded from: classes.dex */
public final class MappedColumnsSQLiteStatementWrapper implements SQLiteStatement {
    private final Map columnNameToIndexMap;
    private final String[] columnNames;
    private final SQLiteStatement delegate;
    private final int[] mapping;

    @Override // androidx.sqlite.SQLiteStatement
    /* JADX INFO: renamed from: bindBlob */
    public void mo129bindBlob(int i, byte[] value) {
        Intrinsics.checkNotNullParameter(value, "value");
        this.delegate.mo129bindBlob(i, value);
    }

    @Override // androidx.sqlite.SQLiteStatement
    /* JADX INFO: renamed from: bindDouble */
    public void mo130bindDouble(int i, double d) {
        this.delegate.mo130bindDouble(i, d);
    }

    @Override // androidx.sqlite.SQLiteStatement
    /* JADX INFO: renamed from: bindLong */
    public void mo131bindLong(int i, long j) {
        this.delegate.mo131bindLong(i, j);
    }

    @Override // androidx.sqlite.SQLiteStatement
    /* JADX INFO: renamed from: bindNull */
    public void mo132bindNull(int i) {
        this.delegate.mo132bindNull(i);
    }

    @Override // androidx.sqlite.SQLiteStatement
    /* JADX INFO: renamed from: bindText */
    public void mo133bindText(int i, String value) {
        Intrinsics.checkNotNullParameter(value, "value");
        this.delegate.mo133bindText(i, value);
    }

    @Override // androidx.sqlite.SQLiteStatement, java.lang.AutoCloseable
    public void close() {
        this.delegate.close();
    }

    @Override // androidx.sqlite.SQLiteStatement
    public boolean getBoolean(int i) {
        return this.delegate.getBoolean(i);
    }

    @Override // androidx.sqlite.SQLiteStatement
    public int getColumnCount() {
        return this.delegate.getColumnCount();
    }

    @Override // androidx.sqlite.SQLiteStatement
    public String getColumnName(int i) {
        return this.delegate.getColumnName(i);
    }

    @Override // androidx.sqlite.SQLiteStatement
    public long getLong(int i) {
        return this.delegate.getLong(i);
    }

    @Override // androidx.sqlite.SQLiteStatement
    public String getText(int i) {
        return this.delegate.getText(i);
    }

    @Override // androidx.sqlite.SQLiteStatement
    public boolean isNull(int i) {
        return this.delegate.isNull(i);
    }

    @Override // androidx.sqlite.SQLiteStatement
    public void reset() {
        this.delegate.reset();
    }

    @Override // androidx.sqlite.SQLiteStatement
    public boolean step() {
        return this.delegate.step();
    }

    public MappedColumnsSQLiteStatementWrapper(SQLiteStatement delegate, String[] columnNames, int[] mapping) {
        Intrinsics.checkNotNullParameter(delegate, "delegate");
        Intrinsics.checkNotNullParameter(columnNames, "columnNames");
        Intrinsics.checkNotNullParameter(mapping, "mapping");
        this.delegate = delegate;
        this.columnNames = columnNames;
        this.mapping = mapping;
        if (columnNames.length != mapping.length) {
            throw new IllegalArgumentException("Expected columnNames.size == mapping.size");
        }
        Map mapCreateMapBuilder = MapsKt.createMapBuilder();
        int length = columnNames.length;
        int i = 0;
        int i2 = 0;
        while (i < length) {
            mapCreateMapBuilder.put(columnNames[i], Integer.valueOf(this.mapping[i2]));
            i++;
            i2++;
        }
        int columnCount = getColumnCount();
        for (int i3 = 0; i3 < columnCount; i3++) {
            if (!mapCreateMapBuilder.containsKey(getColumnName(i3))) {
                mapCreateMapBuilder.put(getColumnName(i3), Integer.valueOf(i3));
            }
        }
        this.columnNameToIndexMap = MapsKt.build(mapCreateMapBuilder);
    }

    public final int getColumnIndex(String name) {
        Intrinsics.checkNotNullParameter(name, "name");
        Integer num = (Integer) this.columnNameToIndexMap.get(name);
        if (num != null) {
            return num.intValue();
        }
        return -1;
    }
}
