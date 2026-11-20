package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.ecommerce.ECommerceEvent;
import io.appmetrica.analytics.ecommerce.ECommerceScreen;
import java.util.List;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.zl, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0783zl extends ECommerceEvent {
    public final C0599sj a;
    public final InterfaceC0640u8 b;

    public C0783zl(ECommerceScreen eCommerceScreen) {
        this(new C0599sj(eCommerceScreen), new Al());
    }

    public final InterfaceC0640u8 a() {
        return this.b;
    }

    @Override // io.appmetrica.analytics.ecommerce.ECommerceEvent
    public final String getPublicDescription() {
        return "shown screen info";
    }

    @Override // io.appmetrica.analytics.ecommerce.ECommerceEvent, io.appmetrica.analytics.impl.InterfaceC0259fg
    public final List<Qi> toProto() {
        return (List) this.b.fromModel(this);
    }

    public final String toString() {
        return "ShownScreenInfoEvent{screen=" + this.a + ", converter=" + this.b + '}';
    }

    public C0783zl(C0599sj c0599sj, InterfaceC0640u8 interfaceC0640u8) {
        this.a = c0599sj;
        this.b = interfaceC0640u8;
    }
}
