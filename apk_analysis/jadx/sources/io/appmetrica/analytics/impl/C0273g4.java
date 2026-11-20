package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.internal.CounterConfigurationReporterType;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.g4, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0273g4 {
    public final String a;
    public final String b;
    public final Integer c;
    public final String d;
    public final CounterConfigurationReporterType e;

    public C0273g4(String str, String str2, Integer num, String str3, CounterConfigurationReporterType counterConfigurationReporterType) {
        this.a = str;
        this.b = str2;
        this.c = num;
        this.d = str3;
        this.e = counterConfigurationReporterType;
    }

    public static C0273g4 a(Y3 y3) {
        return new C0273g4(y3.b.getApiKey(), y3.a.a.getAsString("PROCESS_CFG_PACKAGE_NAME"), y3.a.a.getAsInteger("PROCESS_CFG_PROCESS_ID"), y3.a.a.getAsString("PROCESS_CFG_PROCESS_SESSION_ID"), y3.b.getReporterType());
    }

    public final boolean equals(Object obj) {
        if (this == obj) {
            return true;
        }
        if (obj != null && C0273g4.class == obj.getClass()) {
            C0273g4 c0273g4 = (C0273g4) obj;
            String str = this.a;
            if (str == null ? c0273g4.a != null : !str.equals(c0273g4.a)) {
                return false;
            }
            if (!this.b.equals(c0273g4.b)) {
                return false;
            }
            Integer num = this.c;
            if (num == null ? c0273g4.c != null : !num.equals(c0273g4.c)) {
                return false;
            }
            String str2 = this.d;
            if (str2 == null ? c0273g4.d != null : !str2.equals(c0273g4.d)) {
                return false;
            }
            if (this.e == c0273g4.e) {
                return true;
            }
        }
        return false;
    }

    public final int hashCode() {
        String str = this.a;
        int iHashCode = (this.b.hashCode() + ((str != null ? str.hashCode() : 0) * 31)) * 31;
        Integer num = this.c;
        int iHashCode2 = (iHashCode + (num != null ? num.hashCode() : 0)) * 31;
        String str2 = this.d;
        return this.e.hashCode() + ((iHashCode2 + (str2 != null ? str2.hashCode() : 0)) * 31);
    }

    public final String toString() {
        return "ClientDescription{mApiKey='" + this.a + "', mPackageName='" + this.b + "', mProcessID=" + this.c + ", mProcessSessionID='" + this.d + "', mReporterType=" + this.e + '}';
    }
}
