package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreutils.internal.ApiKeyUtils;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.g5, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public class C0274g5 {
    public final String a;
    public final String b;

    public C0274g5(String str, String str2) {
        this.a = str;
        this.b = str2;
    }

    public final String a() {
        return ApiKeyUtils.createPartialApiKey(this.b);
    }

    public final String b() {
        return this.b;
    }

    public final String c() {
        return this.a;
    }

    public boolean d() {
        return false;
    }

    public String e() {
        return this.a + "_" + ApiKeyUtils.createPartialApiKey(this.b);
    }

    public final boolean equals(Object obj) {
        if (this == obj) {
            return true;
        }
        if (obj != null && getClass() == obj.getClass()) {
            C0274g5 c0274g5 = (C0274g5) obj;
            String str = this.a;
            if (str == null ? c0274g5.a != null : !str.equals(c0274g5.a)) {
                return false;
            }
            String str2 = this.b;
            String str3 = c0274g5.b;
            if (str2 != null) {
                return str2.equals(str3);
            }
            if (str3 == null) {
                return true;
            }
        }
        return false;
    }

    public final int hashCode() {
        String str = this.a;
        int iHashCode = (str != null ? str.hashCode() : 0) * 31;
        String str2 = this.b;
        return iHashCode + (str2 != null ? str2.hashCode() : 0);
    }

    public String toString() {
        return this.a + "_" + this.b;
    }
}
