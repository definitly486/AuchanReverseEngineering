package io.appmetrica.analytics.impl;

import android.app.Activity;
import android.content.Intent;
import io.appmetrica.analytics.coreapi.internal.lifecycle.ActivityEvent;
import io.appmetrica.analytics.coreapi.internal.lifecycle.ActivityLifecycleListener;
import io.appmetrica.analytics.coreutils.internal.StringUtils;
import io.appmetrica.analytics.coreutils.internal.system.SystemServiceUtils;
import java.util.ArrayList;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.f2, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0245f2 implements ActivityLifecycleListener {
    public final ArrayList a = new ArrayList();
    public volatile Q7 b = null;

    public final void a(Q7 q7) {
        ArrayList arrayListA;
        synchronized (this) {
            this.b = q7;
            arrayListA = a();
        }
        int size = arrayListA.size();
        int i = 0;
        while (i < size) {
            Object obj = arrayListA.get(i);
            i++;
            ((InterfaceC0672ve) obj).consume(q7);
        }
    }

    public final void b() {
        C0584s4.l().e.registerListener(this, ActivityEvent.CREATED);
    }

    public final void c() {
        C0584s4.l().e.unregisterListener(this, ActivityEvent.CREATED);
    }

    @Override // io.appmetrica.analytics.coreapi.internal.lifecycle.ActivityLifecycleListener
    public final void onEvent(Activity activity, ActivityEvent activityEvent) {
        Intent intent = (Intent) SystemServiceUtils.accessSystemServiceSafely(activity, "getting intent", "activity", new C0194d2());
        String dataString = intent == null ? null : intent.getDataString();
        if (StringUtils.isNullOrEmpty(dataString)) {
            return;
        }
        C0219e2 c0219e2 = new C0219e2(dataString);
        synchronized (this) {
            try {
                Q7 q7 = this.b;
                if (q7 == null) {
                    this.a.add(c0219e2);
                } else {
                    ((U9) C0584s4.l().c.a()).b.post(new RunnableC0168c2(c0219e2, q7));
                }
            } catch (Throwable th) {
                throw th;
            }
        }
    }

    public final synchronized ArrayList a() {
        ArrayList arrayList;
        arrayList = new ArrayList(this.a);
        this.a.clear();
        return arrayList;
    }
}
