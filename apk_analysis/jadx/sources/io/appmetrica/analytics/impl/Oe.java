package io.appmetrica.analytics.impl;

import java.util.List;
import java.util.concurrent.atomic.AtomicLong;

/* JADX INFO: loaded from: classes3.dex */
public final class Oe implements InterfaceC0433m9, Pe {
    public final C0173c7 a;
    public final AtomicLong b;

    public Oe(C0173c7 c0173c7) {
        this.a = c0173c7;
        this.b = new AtomicLong(c0173c7.a());
        c0173c7.a(this);
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0433m9
    public final void a(List<Integer> list) {
        this.b.addAndGet(list.size());
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0433m9
    public final void b(List<Integer> list) {
        this.b.addAndGet(-list.size());
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0433m9
    public final void a() {
        this.b.set(this.a.a());
    }

    public final long b() {
        return this.b.get();
    }
}
