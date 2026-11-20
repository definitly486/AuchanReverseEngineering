package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.protobuf.nano.MessageNano;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.vg, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0674vg {
    public final String a;
    public final long b;
    public final long c;
    public final int d;

    public C0674vg(byte[] bArr) {
        C0700wg c0700wgA = C0700wg.a(bArr);
        this.a = c0700wgA.a;
        this.b = c0700wgA.c;
        this.c = c0700wgA.b;
        this.d = a(c0700wgA.d);
    }

    public static int a(int i) {
        if (i != 1) {
            return i != 2 ? 1 : 3;
        }
        return 2;
    }

    public final boolean equals(Object obj) {
        if (this == obj) {
            return true;
        }
        if (obj != null && C0674vg.class == obj.getClass()) {
            C0674vg c0674vg = (C0674vg) obj;
            if (this.b == c0674vg.b && this.c == c0674vg.c && this.a.equals(c0674vg.a) && this.d == c0674vg.d) {
                return true;
            }
        }
        return false;
    }

    public final int hashCode() {
        int iHashCode = this.a.hashCode() * 31;
        long j = this.b;
        int i = (iHashCode + ((int) (j ^ (j >>> 32)))) * 31;
        long j2 = this.c;
        return AbstractC0174c8.a(this.d) + ((i + ((int) (j2 ^ (j2 >>> 32)))) * 31);
    }

    public final String toString() {
        return "ReferrerInfo{installReferrer='" + this.a + "', referrerClickTimestampSeconds=" + this.b + ", installBeginTimestampSeconds=" + this.c + ", source=" + AbstractC0648ug.b(this.d) + '}';
    }

    public final byte[] a() {
        C0700wg c0700wg = new C0700wg();
        c0700wg.a = this.a;
        c0700wg.c = this.b;
        c0700wg.b = this.c;
        int iA = AbstractC0174c8.a(this.d);
        int i = 1;
        if (iA != 1) {
            i = 2;
            if (iA != 2) {
                i = 0;
            }
        }
        c0700wg.d = i;
        return MessageNano.toByteArray(c0700wg);
    }

    public C0674vg(String str, long j, long j2, int i) {
        this.a = str;
        this.b = j;
        this.c = j2;
        this.d = i;
    }
}
