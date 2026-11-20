package com.scanflow.datacapture.barinternal.org.ddogleg.struct;

import java.lang.reflect.Array;

/* JADX INFO: loaded from: classes3.dex */
public class FastArray extends FastAccess {
    private final FastArrayList list;

    public FastArray(Class cls, int i) {
        super(cls);
        this.list = new FastArrayList(this);
        this.size = 0;
        this.data = (Object[]) Array.newInstance((Class<?>) cls, i);
    }

    public FastArray(Class cls) {
        this(cls, 10);
    }

    public void add(Object obj) {
        int i = this.size;
        Object[] objArr = this.data;
        if (i >= objArr.length) {
            reserve((objArr.length + 1) * 2);
        }
        Object[] objArr2 = this.data;
        int i2 = this.size;
        this.size = i2 + 1;
        objArr2[i2] = obj;
    }

    public void reset() {
        this.size = 0;
    }

    public void reserve(int i) {
        reserve(i, true);
    }

    public void reserve(int i, boolean z) {
        if (this.data.length >= i) {
            return;
        }
        Object[] objArr = (Object[]) Array.newInstance((Class<?>) this.type, i);
        if (z) {
            System.arraycopy(this.data, 0, objArr, 0, this.size);
        }
        this.data = objArr;
    }
}
