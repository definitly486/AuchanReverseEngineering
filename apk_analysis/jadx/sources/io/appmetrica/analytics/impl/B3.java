package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.ecommerce.ECommerceCartItem;
import java.math.BigDecimal;

/* JADX INFO: loaded from: classes3.dex */
public final class B3 {
    public final C0182cg a;
    public final BigDecimal b;
    public final Uf c;
    public final Gg d;

    public B3(ECommerceCartItem eCommerceCartItem) {
        this(new C0182cg(eCommerceCartItem.getProduct()), eCommerceCartItem.getQuantity(), new Uf(eCommerceCartItem.getRevenue()), eCommerceCartItem.getReferrer() == null ? null : new Gg(eCommerceCartItem.getReferrer()));
    }

    public final String toString() {
        return "CartItemWrapper{product=" + this.a + ", quantity=" + this.b + ", revenue=" + this.c + ", referrer=" + this.d + '}';
    }

    public B3(C0182cg c0182cg, BigDecimal bigDecimal, Uf uf, Gg gg) {
        this.a = c0182cg;
        this.b = bigDecimal;
        this.c = uf;
        this.d = gg;
    }
}
