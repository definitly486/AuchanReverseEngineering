package io.appmetrica.analytics.impl;

import com.scanflow.datacapture.barinternal.kotlin.collections.CollectionsKt;
import java.util.Collection;
import java.util.Iterator;
import java.util.List;
import java.util.concurrent.atomic.AtomicLong;

/* JADX INFO: loaded from: classes3.dex */
public final class N5 implements Z8, InterfaceC0433m9 {
    public final C0173c7 a;
    public final AtomicLong b;

    public N5(C0173c7 c0173c7) {
        this.a = c0173c7;
        this.b = new AtomicLong(c0173c7.a(AbstractC0630to.a()));
        c0173c7.a(this);
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0433m9
    public final void a() {
        this.b.set(this.a.a(AbstractC0630to.a));
    }

    @Override // io.appmetrica.analytics.impl.Z8
    public final boolean b() {
        return this.b.get() > 0;
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0433m9
    public final void b(List<Integer> list) {
        int i = 0;
        if (!(list instanceof Collection) || !list.isEmpty()) {
            Iterator<T> it = list.iterator();
            while (it.hasNext()) {
                if (AbstractC0630to.a.contains(Integer.valueOf(((Number) it.next()).intValue())) && (i = i + 1) < 0) {
                    CollectionsKt.throwCountOverflow();
                }
            }
        }
        this.b.addAndGet(-i);
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0433m9
    public final void a(List<Integer> list) {
        int i = 0;
        if (!(list instanceof Collection) || !list.isEmpty()) {
            Iterator<T> it = list.iterator();
            while (it.hasNext()) {
                if (AbstractC0630to.a.contains(Integer.valueOf(((Number) it.next()).intValue())) && (i = i + 1) < 0) {
                    CollectionsKt.throwCountOverflow();
                }
            }
        }
        this.b.addAndGet(i);
    }
}
