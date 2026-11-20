package io.appmetrica.analytics.impl;

import java.util.List;
import java.util.concurrent.CopyOnWriteArrayList;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.h5, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0300h5 {
    public final CopyOnWriteArrayList a = new CopyOnWriteArrayList();

    public final void a(InterfaceC0688w4 interfaceC0688w4) {
        this.a.add(interfaceC0688w4);
    }

    public final void b(InterfaceC0688w4 interfaceC0688w4) {
        this.a.remove(interfaceC0688w4);
    }

    public final List<InterfaceC0688w4> a() {
        return this.a;
    }
}
