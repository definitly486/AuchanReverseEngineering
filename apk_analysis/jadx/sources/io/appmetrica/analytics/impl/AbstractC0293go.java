package io.appmetrica.analytics.impl;

import android.util.SparseArray;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.go, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public abstract class AbstractC0293go {
    public static final SparseArray a;

    static {
        SparseArray sparseArray = new SparseArray();
        a = sparseArray;
        sparseArray.put(0, "String");
        sparseArray.put(1, "Number");
        sparseArray.put(2, "Counter");
    }
}
