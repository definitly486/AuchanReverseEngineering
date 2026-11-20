package io.appmetrica.analytics.impl;

import android.content.Context;

/* JADX INFO: loaded from: classes3.dex */
public abstract class Qd {
    public static R9 a;

    public static final synchronized R9 a(Context context) {
        R9 r9;
        r9 = a;
        if (r9 == null) {
            r9 = new R9(context, "uuid.dat");
            a = r9;
        }
        return r9;
    }
}
