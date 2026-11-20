package io.appmetrica.analytics.impl;

import com.scanflow.datacapture.barinternal.kotlin.NoWhenBranchMatchedException;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.z4, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0766z4 {
    public static InterfaceC0714x4 a(C0273g4 c0273g4) {
        switch (AbstractC0740y4.a[c0273g4.e.ordinal()]) {
            case 1:
                return new C0696wc();
            case 2:
                return new C0729xj();
            case 3:
                return new Aj();
            case 4:
                return new Ph(new Rh());
            case 5:
                return new Ph(new C0366jk());
            case 6:
                return new Hc();
            case 7:
                return new Hc();
            default:
                throw new NoWhenBranchMatchedException();
        }
    }
}
