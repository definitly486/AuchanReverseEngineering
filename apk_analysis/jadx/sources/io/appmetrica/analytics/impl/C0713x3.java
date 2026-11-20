package io.appmetrica.analytics.impl;

import com.scanflow.datacapture.barinternal.kotlin.Unit;
import com.scanflow.datacapture.barinternal.kotlin.collections.CollectionsKt;
import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.x3, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0713x3 implements Bg {
    public final Bg a;
    public final InterfaceC0570rg b;
    public boolean c;
    public final ArrayList d = new ArrayList();
    public final Object e = new Object();

    public C0713x3(Bg bg, InterfaceC0570rg interfaceC0570rg) {
        this.a = bg;
        this.b = interfaceC0570rg;
    }

    @Override // io.appmetrica.analytics.impl.Bg
    public final String a() {
        return this.a.a();
    }

    public final void b() {
        synchronized (this.e) {
            if (this.c) {
                return;
            }
            this.c = true;
            if (((Uo) this.b).c()) {
                return;
            }
            Unit unit = Unit.INSTANCE;
            try {
                this.a.a(new InterfaceC0726xg() { // from class: io.appmetrica.analytics.impl.x3$$ExternalSyntheticLambda0
                    @Override // io.appmetrica.analytics.impl.InterfaceC0726xg
                    public final void a(Eg eg) {
                        C0713x3.a(this.f$0, eg);
                    }
                });
            } catch (Throwable th) {
                a(new Cg("Failed to request referrer", th));
            }
        }
    }

    @Override // io.appmetrica.analytics.impl.Bg
    public final void a(InterfaceC0726xg interfaceC0726xg) {
        Eg eg;
        synchronized (this.e) {
            try {
                eg = null;
                if (((Uo) this.b).c()) {
                    Eg egB = ((Uo) this.b).b();
                    if (egB == null) {
                        egB = new Cg("Referrer is null", null, 2, null);
                    }
                    eg = egB;
                } else {
                    this.d.add(interfaceC0726xg);
                }
            } catch (Throwable th) {
                throw th;
            }
        }
        if (eg != null) {
            interfaceC0726xg.a(eg);
        }
        b();
    }

    public static final void a(C0713x3 c0713x3, Eg eg) {
        synchronized (c0713x3.e) {
            ((Uo) c0713x3.b).a(eg);
            Unit unit = Unit.INSTANCE;
        }
        c0713x3.a(eg);
    }

    public final void a(Eg eg) {
        List list;
        synchronized (this.e) {
            list = CollectionsKt.toList(this.d);
            this.d.clear();
        }
        Iterator it = list.iterator();
        while (it.hasNext()) {
            ((InterfaceC0726xg) it.next()).a(eg);
        }
    }
}
