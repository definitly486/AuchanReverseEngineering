package io.appmetrica.analytics.impl;

import com.scanflow.datacapture.barinternal.kotlin.collections.CollectionsKt;
import java.util.Iterator;
import java.util.List;
import java.util.concurrent.CopyOnWriteArrayList;

/* JADX INFO: loaded from: classes3.dex */
public final class A6 implements InterfaceC0228eb {
    public final CopyOnWriteArrayList a = new CopyOnWriteArrayList();

    @Override // io.appmetrica.analytics.impl.InterfaceC0228eb
    public final void a(Throwable th, X x) {
        Iterator it = this.a.iterator();
        while (it.hasNext()) {
            ((InterfaceC0228eb) it.next()).a(th, x);
        }
    }

    public final void a(InterfaceC0228eb... interfaceC0228ebArr) {
        CollectionsKt.addAll(this.a, interfaceC0228ebArr);
    }

    public final void a(List<? extends InterfaceC0228eb> list) {
        this.a.addAll(list);
    }

    public final void a() {
        this.a.clear();
    }
}
