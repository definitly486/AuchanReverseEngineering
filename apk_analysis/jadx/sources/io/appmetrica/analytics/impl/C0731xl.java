package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.ecommerce.ECommerceEvent;
import io.appmetrica.analytics.ecommerce.ECommerceProduct;
import io.appmetrica.analytics.ecommerce.ECommerceReferrer;
import java.util.List;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.xl, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0731xl extends ECommerceEvent {
    public final C0182cg a;
    public final Gg b;
    public final InterfaceC0640u8 c;

    public C0731xl(ECommerceProduct eCommerceProduct, ECommerceReferrer eCommerceReferrer) {
        this(new C0182cg(eCommerceProduct), eCommerceReferrer == null ? null : new Gg(eCommerceReferrer), new C0757yl());
    }

    public final InterfaceC0640u8 a() {
        return this.c;
    }

    @Override // io.appmetrica.analytics.ecommerce.ECommerceEvent
    public final String getPublicDescription() {
        return "shown product details info";
    }

    @Override // io.appmetrica.analytics.ecommerce.ECommerceEvent, io.appmetrica.analytics.impl.InterfaceC0259fg
    public final List<Qi> toProto() {
        return (List) this.c.fromModel(this);
    }

    public final String toString() {
        return "ShownProductDetailInfoEvent{product=" + this.a + ", referrer=" + this.b + ", converter=" + this.c + '}';
    }

    public C0731xl(C0182cg c0182cg, Gg gg, InterfaceC0640u8 interfaceC0640u8) {
        this.a = c0182cg;
        this.b = gg;
        this.c = interfaceC0640u8;
    }
}
