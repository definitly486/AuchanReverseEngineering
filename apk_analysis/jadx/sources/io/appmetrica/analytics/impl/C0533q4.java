package io.appmetrica.analytics.impl;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.q4, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0533q4 {
    public final String a;
    public final Integer b;
    public final String c;

    public C0533q4(String str, Integer num, String str2) {
        this.a = str;
        this.b = num;
        this.c = str2;
    }

    public final boolean equals(Object obj) {
        if (this == obj) {
            return true;
        }
        if (obj != null && C0533q4.class == obj.getClass()) {
            C0533q4 c0533q4 = (C0533q4) obj;
            if (!this.a.equals(c0533q4.a)) {
                return false;
            }
            Integer num = this.b;
            if (num == null ? c0533q4.b != null : !num.equals(c0533q4.b)) {
                return false;
            }
            String str = this.c;
            String str2 = c0533q4.c;
            if (str != null) {
                return str.equals(str2);
            }
            if (str2 == null) {
                return true;
            }
        }
        return false;
    }

    public final int hashCode() {
        int iHashCode = this.a.hashCode() * 31;
        Integer num = this.b;
        int iHashCode2 = (iHashCode + (num != null ? num.hashCode() : 0)) * 31;
        String str = this.c;
        return iHashCode2 + (str != null ? str.hashCode() : 0);
    }
}
