package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.ecommerce.ECommerceAmount;
import java.math.BigDecimal;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.b0, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0140b0 {
    public final BigDecimal a;
    public final String b;

    public C0140b0(ECommerceAmount eCommerceAmount) {
        this(eCommerceAmount.getAmount(), eCommerceAmount.getUnit());
    }

    public final String toString() {
        return "AmountWrapper{amount=" + this.a + ", unit='" + this.b + "'}";
    }

    public C0140b0(BigDecimal bigDecimal, String str) {
        this.a = bigDecimal;
        this.b = str;
    }
}
