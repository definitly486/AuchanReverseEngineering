package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.ecommerce.ECommerceEvent;
import io.appmetrica.analytics.ecommerce.ECommerceOrder;
import java.util.List;

/* JADX INFO: loaded from: classes3.dex */
public final class Ie extends ECommerceEvent {
    public static final int d = 6;
    public static final int e = 7;
    public final int a;
    public final Ke b;
    public final InterfaceC0640u8 c;

    public Ie(int i, ECommerceOrder eCommerceOrder) {
        this(i, new Ke(eCommerceOrder), new Je());
    }

    public final InterfaceC0640u8 a() {
        return this.c;
    }

    @Override // io.appmetrica.analytics.ecommerce.ECommerceEvent
    public final String getPublicDescription() {
        return "order info";
    }

    @Override // io.appmetrica.analytics.ecommerce.ECommerceEvent, io.appmetrica.analytics.impl.InterfaceC0259fg
    public final List<Qi> toProto() {
        return (List) this.c.fromModel(this);
    }

    public final String toString() {
        return "OrderInfoEvent{eventType=" + this.a + ", order=" + this.b + ", converter=" + this.c + '}';
    }

    public Ie(int i, Ke ke, InterfaceC0640u8 interfaceC0640u8) {
        this.a = i;
        this.b = ke;
        this.c = interfaceC0640u8;
    }
}
