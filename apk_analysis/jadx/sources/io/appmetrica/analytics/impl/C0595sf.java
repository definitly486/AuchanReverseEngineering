package io.appmetrica.analytics.impl;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.sf, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0595sf {
    public final String a;
    public final String b;

    public C0595sf(String str, String str2) {
        this.a = str;
        this.b = a(str2);
    }

    public final String a(String str) {
        if (str == null) {
            return this.a;
        }
        return this.a + str;
    }
}
