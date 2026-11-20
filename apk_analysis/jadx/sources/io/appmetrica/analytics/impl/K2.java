package io.appmetrica.analytics.impl;

/* JADX INFO: loaded from: classes3.dex */
public final class K2 {
    public final J2 a;
    public final Boolean b;

    public K2(J2 j2, Boolean bool) {
        this.a = j2;
        this.b = bool;
    }

    public final boolean equals(Object obj) {
        if (this == obj) {
            return true;
        }
        if (obj != null && K2.class == obj.getClass()) {
            K2 k2 = (K2) obj;
            if (this.a != k2.a) {
                return false;
            }
            Boolean bool = this.b;
            if (bool != null) {
                return bool.equals(k2.b);
            }
            if (k2.b == null) {
                return true;
            }
        }
        return false;
    }

    public final int hashCode() {
        J2 j2 = this.a;
        int iHashCode = (j2 != null ? j2.hashCode() : 0) * 31;
        Boolean bool = this.b;
        return iHashCode + (bool != null ? bool.hashCode() : 0);
    }

    public final String toString() {
        return "BackgroundRestrictionsState{mAppStandByBucket=" + this.a + ", mBackgroundRestricted=" + this.b + '}';
    }
}
