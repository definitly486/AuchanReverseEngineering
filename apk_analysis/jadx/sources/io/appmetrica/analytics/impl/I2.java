package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreapi.internal.data.ProtobufConverter;

/* JADX INFO: loaded from: classes3.dex */
public final class I2 implements ProtobufConverter {
    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final C0323i2 fromModel(K2 k2) {
        C0323i2 c0323i2 = new C0323i2();
        J2 j2 = k2.a;
        if (j2 != null) {
            int iOrdinal = j2.ordinal();
            if (iOrdinal == 0) {
                c0323i2.a = 6;
            } else if (iOrdinal == 1) {
                c0323i2.a = 1;
            } else if (iOrdinal == 2) {
                c0323i2.a = 2;
            } else if (iOrdinal == 3) {
                c0323i2.a = 3;
            } else if (iOrdinal == 4) {
                c0323i2.a = 4;
            } else if (iOrdinal != 5) {
                c0323i2.a = 0;
            } else {
                c0323i2.a = 5;
            }
        }
        Boolean bool = k2.b;
        if (bool != null) {
            if (bool.booleanValue()) {
                c0323i2.b = 1;
                return c0323i2;
            }
            c0323i2.b = 0;
        }
        return c0323i2;
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final K2 toModel(C0323i2 c0323i2) {
        J2 j2;
        Boolean bool = null;
        switch (c0323i2.a) {
            case 1:
                j2 = J2.ACTIVE;
                break;
            case 2:
                j2 = J2.WORKING_SET;
                break;
            case 3:
                j2 = J2.FREQUENT;
                break;
            case 4:
                j2 = J2.RARE;
                break;
            case 5:
                j2 = J2.RESTRICTED;
                break;
            case 6:
                j2 = J2.EXEMPTED;
                break;
            default:
                j2 = null;
                break;
        }
        int i = c0323i2.b;
        if (i == 0) {
            bool = Boolean.FALSE;
        } else if (i == 1) {
            bool = Boolean.TRUE;
        }
        return new K2(j2, bool);
    }
}
