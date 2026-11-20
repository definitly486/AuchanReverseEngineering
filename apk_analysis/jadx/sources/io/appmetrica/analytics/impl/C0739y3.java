package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.ecommerce.ECommerceCartItem;
import io.appmetrica.analytics.ecommerce.ECommerceEvent;
import java.util.List;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.y3, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0739y3 extends ECommerceEvent {
    public static final int d = 4;
    public static final int e = 5;
    public final int a;
    public final B3 b;
    public final InterfaceC0640u8 c;

    public C0739y3(int i, ECommerceCartItem eCommerceCartItem) {
        this(i, new B3(eCommerceCartItem), new C0765z3());
    }

    public final InterfaceC0640u8 a() {
        return this.c;
    }

    @Override // io.appmetrica.analytics.ecommerce.ECommerceEvent
    public final String getPublicDescription() {
        int i = this.a;
        if (i != 4) {
            return i != 5 ? "unknown cart action info" : "remove cart item info";
        }
        return "add cart item info";
    }

    @Override // io.appmetrica.analytics.ecommerce.ECommerceEvent, io.appmetrica.analytics.impl.InterfaceC0259fg
    public final List<Qi> toProto() {
        return (List) this.c.fromModel(this);
    }

    public final String toString() {
        return "CartActionInfoEvent{eventType=" + this.a + ", cartItem=" + this.b + ", converter=" + this.c + '}';
    }

    public C0739y3(int i, B3 b3, InterfaceC0640u8 interfaceC0640u8) {
        this.a = i;
        this.b = b3;
        this.c = interfaceC0640u8;
    }
}
