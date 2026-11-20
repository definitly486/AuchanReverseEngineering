package io.appmetrica.analytics.impl;

import android.util.SparseArray;
import java.util.HashMap;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.vo, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0682vo {
    public static final int[] c = {0, 1, 2, 3};
    public final SparseArray a = new SparseArray();
    public int b = 0;

    public C0682vo(int[] iArr) {
        for (int i : iArr) {
            this.a.put(i, new HashMap());
        }
    }
}
