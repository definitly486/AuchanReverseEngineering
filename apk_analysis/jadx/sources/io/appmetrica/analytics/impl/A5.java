package io.appmetrica.analytics.impl;

import java.util.Iterator;
import java.util.List;
import java.util.Objects;
import java.util.concurrent.atomic.AtomicBoolean;

/* JADX INFO: loaded from: classes3.dex */
public final class A5 implements K9 {
    public final P9 a;
    public final List b;
    public final List c;
    public final AtomicBoolean d;

    public A5(P9 p9, List<? extends Z8> list, List<? extends Z8> list2, C0274g5 c0274g5) {
        this.a = p9;
        this.b = list;
        this.c = list2;
        Objects.toString(c0274g5);
        this.d = new AtomicBoolean(true);
    }

    public final boolean a() {
        List list = this.c;
        if (!list.isEmpty() && !list.isEmpty()) {
            Iterator it = list.iterator();
            while (it.hasNext()) {
                if (!((Z8) it.next()).b()) {
                    return false;
                }
            }
        }
        List list2 = this.b;
        if (list2.isEmpty() || list2.isEmpty()) {
            return false;
        }
        Iterator it2 = list2.iterator();
        while (it2.hasNext()) {
            if (((Z8) it2.next()).b()) {
                return true;
            }
        }
        return false;
    }

    public final void b() {
        this.d.set(false);
    }

    public final void c() {
        this.d.set(true);
    }

    public final void d() {
        if (this.d.get()) {
            List list = this.c;
            if (!list.isEmpty() && !list.isEmpty()) {
                Iterator it = list.iterator();
                while (it.hasNext()) {
                    if (!((Z8) it.next()).b()) {
                        return;
                    }
                }
            }
            ((Bn) this.a).c();
        }
    }

    public final void e() {
        if (this.d.get() && a()) {
            ((Bn) this.a).c();
        }
    }

    public final void f() {
        if (this.d.get() && a()) {
            ((Bn) this.a).b();
        }
    }
}
