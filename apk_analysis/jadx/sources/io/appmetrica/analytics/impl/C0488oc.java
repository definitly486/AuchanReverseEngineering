package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreapi.internal.control.Toggle;
import io.appmetrica.analytics.coreapi.internal.control.ToggleObserver;
import io.appmetrica.analytics.coreapi.internal.executors.IHandlerExecutor;
import io.appmetrica.analytics.locationapi.internal.LocationControllerObserver;
import java.util.ArrayList;
import kotlin.jvm.functions.Function1;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.oc, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0488oc implements InterfaceC0410lc, ToggleObserver {
    public final ArrayList a = new ArrayList();
    public final IHandlerExecutor b = Ka.k().w().c();
    public C0190co c;
    public boolean d;

    public final void a(Toggle toggle) {
        C0190co c0190co = new C0190co(toggle);
        this.c = c0190co;
        c0190co.c.registerObserver(this, true);
    }

    public final void b(Object obj) {
        C0190co c0190co = this.c;
        if (c0190co == null) {
            Intrinsics.throwUninitializedPropertyAccessException("togglesHolder");
            c0190co = null;
        }
        c0190co.b.b(obj);
    }

    @Override // io.appmetrica.analytics.coreapi.internal.control.ToggleObserver
    public final void onStateChanged(final boolean z) {
        this.b.execute(new Runnable() { // from class: io.appmetrica.analytics.impl.oc$$ExternalSyntheticLambda1
            @Override // java.lang.Runnable
            public final void run() {
                C0488oc.a(this.f$0, z);
            }
        });
    }

    public final void a(final LocationControllerObserver locationControllerObserver, final boolean z) {
        this.b.execute(new Runnable() { // from class: io.appmetrica.analytics.impl.oc$$ExternalSyntheticLambda0
            @Override // java.lang.Runnable
            public final void run() {
                C0488oc.a(this.f$0, locationControllerObserver, z);
            }
        });
    }

    public static final void a(C0488oc c0488oc, LocationControllerObserver locationControllerObserver, boolean z) {
        c0488oc.a.add(locationControllerObserver);
        if (z) {
            if (c0488oc.d) {
                locationControllerObserver.startLocationTracking();
            } else {
                locationControllerObserver.stopLocationTracking();
            }
        }
    }

    public static final void a(C0488oc c0488oc, boolean z) {
        if (c0488oc.d != z) {
            c0488oc.d = z;
            Function1 function1 = z ? C0436mc.a : C0462nc.a;
            ArrayList arrayList = c0488oc.a;
            int size = arrayList.size();
            int i = 0;
            while (i < size) {
                Object obj = arrayList.get(i);
                i++;
                function1.invoke((LocationControllerObserver) obj);
            }
        }
    }

    public final void a(Object obj) {
        C0190co c0190co = this.c;
        if (c0190co == null) {
            Intrinsics.throwUninitializedPropertyAccessException("togglesHolder");
            c0190co = null;
        }
        c0190co.b.a(obj);
    }

    public final void a(boolean z) {
        C0190co c0190co = this.c;
        if (c0190co == null) {
            Intrinsics.throwUninitializedPropertyAccessException("togglesHolder");
            c0190co = null;
        }
        c0190co.a.a(z);
    }
}
