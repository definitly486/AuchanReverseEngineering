package io.appmetrica.analytics.impl;

import com.scanflow.datacapture.barinternal.kotlin.NoWhenBranchMatchedException;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.ze, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0776ze {
    public static final V9 a(C0776ze c0776ze, EnumC0227ea enumC0227ea) {
        int i;
        c0776ze.getClass();
        V9 v9 = new V9();
        switch (enumC0227ea.ordinal()) {
            case 0:
                i = 0;
                break;
            case 1:
                i = 1;
                break;
            case 2:
                i = 2;
                break;
            case 3:
                i = 3;
                break;
            case 4:
                i = 4;
                break;
            case 5:
                i = 5;
                break;
            case 6:
                i = 6;
                break;
            default:
                throw new NoWhenBranchMatchedException();
        }
        v9.a = i;
        return v9;
    }
}
