package io.appmetrica.analytics.impl;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.rh, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0571rh extends AbstractC0131ah {
    public C0571rh(C0455n5 c0455n5) {
        super(c0455n5);
    }

    @Override // io.appmetrica.analytics.impl.AbstractC0131ah
    public final boolean a(C0249f6 c0249f6) {
        C0455n5 c0455n5 = this.a;
        synchronized (c0455n5) {
            ((A5) c0455n5.p).d();
        }
        return false;
    }
}
