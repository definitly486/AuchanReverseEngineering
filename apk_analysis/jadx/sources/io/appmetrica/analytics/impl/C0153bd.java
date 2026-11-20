package io.appmetrica.analytics.impl;

import android.util.SparseArray;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.bd, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0153bd {
    public static final SparseArray c;
    public final String a;
    public final String b;

    static {
        SparseArray sparseArray = new SparseArray();
        c = sparseArray;
        EnumC0721xb enumC0721xb = EnumC0721xb.EVENT_TYPE_UNDEFINED;
        sparseArray.put(5891, new C0153bd("jvm", "binder"));
        sparseArray.put(5890, new C0153bd("jvm", "file"));
        sparseArray.put(5889, new C0153bd("jvm", "file"));
        sparseArray.put(5897, new C0153bd("jni_native", "file"));
        sparseArray.put(5898, new C0153bd("jni_native", "file"));
    }

    public C0153bd(String str, String str2) {
        this.a = str;
        this.b = str2;
    }
}
