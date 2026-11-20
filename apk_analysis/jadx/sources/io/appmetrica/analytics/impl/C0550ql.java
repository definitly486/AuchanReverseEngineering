package io.appmetrica.analytics.impl;

import android.app.Activity;
import io.appmetrica.analytics.coreapi.internal.lifecycle.ActivityEvent;
import io.appmetrica.analytics.coreapi.internal.lifecycle.ActivityLifecycleListener;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.ql, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0550ql {
    public final C0475o a;
    public final C5 b;
    public final ActivityLifecycleListener c;
    public final ActivityLifecycleListener d;
    public final C0528q e;
    public final C0423m f;
    public boolean g;

    public C0550ql(C0475o c0475o, C0423m c0423m) {
        this(c0475o, c0423m, new C5(), new C0528q());
    }

    public final void a(final Activity activity, ActivityEvent activityEvent) {
        synchronized (this) {
            C5 c5 = this.b;
            InterfaceC0672ve interfaceC0672ve = new InterfaceC0672ve() { // from class: io.appmetrica.analytics.impl.ql$$ExternalSyntheticLambda1
                @Override // io.appmetrica.analytics.impl.InterfaceC0672ve
                public final void consume(Object obj) {
                    this.f$0.a(activity, (Dc) obj);
                }
            };
            c5.getClass();
            C0584s4.l().c.a().execute(new B5(c5, interfaceC0672ve));
        }
    }

    public final void b(final Activity activity, ActivityEvent activityEvent) {
        synchronized (this) {
            C5 c5 = this.b;
            InterfaceC0672ve interfaceC0672ve = new InterfaceC0672ve() { // from class: io.appmetrica.analytics.impl.ql$$ExternalSyntheticLambda0
                @Override // io.appmetrica.analytics.impl.InterfaceC0672ve
                public final void consume(Object obj) {
                    this.f$0.b(activity, (Dc) obj);
                }
            };
            c5.getClass();
            C0584s4.l().c.a().execute(new B5(c5, interfaceC0672ve));
        }
    }

    public C0550ql(C0475o c0475o, C0423m c0423m, C5 c5, C0528q c0528q) {
        this.g = false;
        this.a = c0475o;
        this.f = c0423m;
        this.b = c5;
        this.e = c0528q;
        this.c = new ActivityLifecycleListener() { // from class: io.appmetrica.analytics.impl.ql$$ExternalSyntheticLambda2
            @Override // io.appmetrica.analytics.coreapi.internal.lifecycle.ActivityLifecycleListener
            public final void onEvent(Activity activity, ActivityEvent activityEvent) {
                this.f$0.a(activity, activityEvent);
            }
        };
        this.d = new ActivityLifecycleListener() { // from class: io.appmetrica.analytics.impl.ql$$ExternalSyntheticLambda3
            @Override // io.appmetrica.analytics.coreapi.internal.lifecycle.ActivityLifecycleListener
            public final void onEvent(Activity activity, ActivityEvent activityEvent) {
                this.f$0.b(activity, activityEvent);
            }
        };
    }

    public final void b(Activity activity, Dc dc) {
        if (this.g && this.e.a(activity, EnumC0501p.PAUSED)) {
            dc.b(activity);
        }
    }

    public final void a(Activity activity, Dc dc) {
        if (this.g && this.e.a(activity, EnumC0501p.RESUMED)) {
            dc.a(activity);
        }
    }

    public final synchronized EnumC0449n a() {
        try {
            if (!this.g) {
                this.a.registerListener(this.c, ActivityEvent.RESUMED);
                this.a.registerListener(this.d, ActivityEvent.PAUSED);
                this.g = true;
            }
        } catch (Throwable th) {
            throw th;
        }
        return this.a.b;
    }
}
