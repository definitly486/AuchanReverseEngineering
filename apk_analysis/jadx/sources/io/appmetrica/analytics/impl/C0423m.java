package io.appmetrica.analytics.impl;

import android.app.Activity;
import io.appmetrica.analytics.coreapi.internal.lifecycle.ActivityEvent;
import io.appmetrica.analytics.coreapi.internal.lifecycle.ActivityLifecycleListener;
import java.util.HashSet;
import java.util.Iterator;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.m, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0423m implements ActivityLifecycleListener {
    public final HashSet a = new HashSet();

    public C0423m(C0475o c0475o) {
        c0475o.registerListener(this, new ActivityEvent[0]);
    }

    public final synchronized void a(InterfaceC0397l interfaceC0397l) {
        this.a.add(interfaceC0397l);
    }

    @Override // io.appmetrica.analytics.coreapi.internal.lifecycle.ActivityLifecycleListener
    public final void onEvent(Activity activity, ActivityEvent activityEvent) {
        C0584s4.l().c.a().execute(new RunnableC0371k(this, activity));
    }

    public final void a(Activity activity) {
        HashSet hashSet;
        synchronized (this) {
            hashSet = new HashSet(this.a);
        }
        Iterator it = hashSet.iterator();
        while (it.hasNext()) {
            ((C0573rj) ((InterfaceC0397l) it.next())).a(activity);
        }
    }
}
