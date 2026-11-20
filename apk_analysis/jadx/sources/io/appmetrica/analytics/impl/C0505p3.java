package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.logger.appmetrica.internal.PublicLogger;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.p3, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0505p3 extends Z2 {
    public C0505p3(int i, String str, PublicLogger publicLogger) {
        super(i, str, publicLogger);
    }

    public final int b() {
        return this.a;
    }

    @Override // io.appmetrica.analytics.impl.Cdo
    public final byte[] a(byte[] bArr) {
        if (bArr != null) {
            int length = bArr.length;
            int i = this.a;
            if (length > i) {
                byte[] bArr2 = new byte[i];
                System.arraycopy(bArr, 0, bArr2, 0, i);
                this.c.warning("\"%s\" %s exceeded limit of %d bytes", this.b, bArr, Integer.valueOf(this.a));
                return bArr2;
            }
        }
        return bArr;
    }

    public final String a() {
        return this.b;
    }
}
