package io.appmetrica.analytics.impl;

import com.scanflow.datacapture.barinternal.kotlin.Pair;
import com.scanflow.datacapture.barinternal.kotlin.TuplesKt;
import io.appmetrica.analytics.coreapi.internal.data.ProtobufConverter;
import java.math.BigDecimal;
import java.math.BigInteger;

/* JADX INFO: loaded from: classes3.dex */
public final class N7 implements ProtobufConverter {
    public final BigDecimal a(C0770z8 c0770z8) {
        throw new UnsupportedOperationException();
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    public final Object toModel(Object obj) {
        throw new UnsupportedOperationException();
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final C0770z8 fromModel(BigDecimal bigDecimal) {
        BigInteger bigInteger = P7.a;
        int i = -bigDecimal.scale();
        BigInteger bigIntegerUnscaledValue = bigDecimal.unscaledValue();
        while (true) {
            if (bigIntegerUnscaledValue.compareTo(P7.a) <= 0 && bigIntegerUnscaledValue.compareTo(P7.b) >= 0) {
                Pair pair = TuplesKt.to(Long.valueOf(bigIntegerUnscaledValue.longValue()), Integer.valueOf(i));
                O7 o7 = new O7(((Number) pair.getFirst()).longValue(), ((Number) pair.getSecond()).intValue());
                C0770z8 c0770z8 = new C0770z8();
                c0770z8.a = o7.a;
                c0770z8.b = o7.b;
                return c0770z8;
            }
            bigIntegerUnscaledValue = bigIntegerUnscaledValue.divide(BigInteger.TEN);
            i++;
        }
    }
}
