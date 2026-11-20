package com.scanflow.datacapture.barinternal.org.ddogleg.struct;

import java.io.Serializable;

/* JADX INFO: loaded from: classes3.dex */
public abstract class FastAccess implements Serializable {
    public Object[] data;
    public int size;
    public final Class type;

    protected FastAccess(Class cls) {
        this.type = cls;
    }

    public Object get(int i) {
        if (i < 0 || i >= this.size) {
            throw new IllegalArgumentException("Out of bounds. index=" + i + " max size " + this.size);
        }
        return this.data[i];
    }

    public int size() {
        return this.size;
    }

    public Object getTail() {
        return this.data[this.size - 1];
    }

    public boolean contains(Object obj) {
        for (int i = 0; i < this.size; i++) {
            if (this.data[i].equals(obj)) {
                return true;
            }
        }
        return false;
    }

    public int indexOf(Object obj) {
        for (int i = 0; i < this.size; i++) {
            if (this.data[i].equals(obj)) {
                return i;
            }
        }
        return -1;
    }
}
