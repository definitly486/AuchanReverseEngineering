package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.ecommerce.ECommerceEvent;
import io.appmetrica.analytics.ecommerce.ECommerceProduct;
import io.appmetrica.analytics.ecommerce.ECommerceScreen;
import java.util.List;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.vl, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0679vl extends ECommerceEvent {
    public final C0182cg a;
    public final C0599sj b;
    public final InterfaceC0640u8 c;

    public C0679vl(ECommerceProduct eCommerceProduct, ECommerceScreen eCommerceScreen) {
        this(new C0182cg(eCommerceProduct), new C0599sj(eCommerceScreen), new C0705wl());
    }

    public final InterfaceC0640u8 a() {
        return this.c;
    }

    @Override // io.appmetrica.analytics.ecommerce.ECommerceEvent
    public final String getPublicDescription() {
        return "shown product card info";
    }

    @Override // io.appmetrica.analytics.ecommerce.ECommerceEvent, io.appmetrica.analytics.impl.InterfaceC0259fg
    public final List<Qi> toProto() {
        return (List) this.c.fromModel(this);
    }

    public final String toString() {
        return "ShownProductCardInfoEvent{product=" + this.a + ", screen=" + this.b + ", converter=" + this.c + '}';
    }

    public C0679vl(C0182cg c0182cg, C0599sj c0599sj, InterfaceC0640u8 interfaceC0640u8) {
        this.a = c0182cg;
        this.b = c0599sj;
        this.c = interfaceC0640u8;
    }
}
