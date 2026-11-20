package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreapi.internal.data.Converter;

/* JADX INFO: loaded from: classes3.dex */
public final class Jf implements Converter {
    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final Integer fromModel(EnumC0406l8 enumC0406l8) {
        int iOrdinal = enumC0406l8.ordinal();
        if (iOrdinal == 1) {
            return 1;
        }
        if (iOrdinal != 2) {
            return iOrdinal != 3 ? 0 : 2;
        }
        return 3;
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final EnumC0406l8 toModel(Integer num) {
        int iIntValue = num.intValue();
        if (iIntValue == 1) {
            return EnumC0406l8.d;
        }
        if (iIntValue == 2) {
            return EnumC0406l8.f;
        }
        if (iIntValue != 3) {
            return EnumC0406l8.c;
        }
        return EnumC0406l8.e;
    }
}
