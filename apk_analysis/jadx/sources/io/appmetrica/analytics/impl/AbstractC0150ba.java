package io.appmetrica.analytics.impl;

import com.scanflow.datacapture.barinternal.kotlin.text.Charsets;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.ba, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public abstract class AbstractC0150ba {
    public static final V9 a(int i, String str) {
        byte[] bytes;
        V9 v9 = new V9();
        v9.a = i;
        if (str == null || (bytes = str.getBytes(Charsets.UTF_8)) == null) {
            bytes = v9.b;
        }
        v9.b = bytes;
        return v9;
    }
}
