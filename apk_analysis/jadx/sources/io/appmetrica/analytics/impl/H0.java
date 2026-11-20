package io.appmetrica.analytics.impl;

import android.content.Context;
import androidx.core.app.NotificationCompat;
import com.scanflow.datacapture.barinternal.kotlin.Pair;
import com.scanflow.datacapture.barinternal.kotlin.TuplesKt;
import com.scanflow.datacapture.barinternal.kotlin.collections.CollectionsKt;
import com.scanflow.datacapture.barinternal.kotlin.collections.MapsKt;
import io.appmetrica.analytics.ModuleEvent;
import io.appmetrica.analytics.ModulesFacade;
import io.appmetrica.analytics.logger.appmetrica.internal.PublicLogger;
import java.util.Iterator;
import java.util.List;
import java.util.Map;

/* JADX INFO: loaded from: classes3.dex */
public final class H0 {
    public final Xb a = new Xb(C0584s4.l().d());
    public final Yb b = new Yb();
    public final C0126ac c = new C0126ac();

    public final void a(final String str, final String str2, final String str3) {
        Xb xb = this.a;
        if (xb.c.a((Void) null).a && xb.d.a(str).a && xb.e.a(str2).a && xb.f.a(str3).a) {
            this.b.getClass();
            ((U9) C0584s4.l().c.a()).b.post(new Runnable() { // from class: io.appmetrica.analytics.impl.H0$$ExternalSyntheticLambda0
                @Override // java.lang.Runnable
                public final void run() {
                    H0.a(this.f$0, str, str2, str3);
                }
            });
            return;
        }
        String str4 = "Failed report event from sender: " + str + " with name = " + str2 + " and payload = " + str3;
        PublicLogger.Companion.getAnonymousInstance().warning("[AppMetricaLibraryAdapterProxy]" + str4, new Object[0]);
    }

    public static final void a(H0 h0, String str, String str2, String str3) {
        List list;
        Context contextA;
        C0126ac c0126ac = h0.c;
        c0126ac.getClass();
        if (str == null) {
            str = "null";
        }
        Pair pair = TuplesKt.to("sender", str);
        if (str2 == null) {
            str2 = "null";
        }
        Pair pair2 = TuplesKt.to(NotificationCompat.CATEGORY_EVENT, str2);
        if (str3 == null) {
            str3 = "null";
        }
        Map<String, Object> mapMutableMapOf = MapsKt.mutableMapOf(pair, pair2, TuplesKt.to("payload", str3));
        ModuleEvent.Builder builderWithName = ModuleEvent.newBuilder(4).withName("appmetrica_system_event_42");
        synchronized (c0126ac) {
            try {
                if (c0126ac.a == null && (contextA = C0584s4.l().g.a()) != null) {
                    c0126ac.a = CollectionsKt.listOf((Object[]) new InterfaceC0631u[]{new C0386ke(), new C0681vn(contextA), new cp()});
                }
                list = c0126ac.a;
            } catch (Throwable th) {
                throw th;
            }
        }
        if (list != null) {
            Iterator it = list.iterator();
            while (it.hasNext()) {
                ((InterfaceC0631u) it.next()).a(mapMutableMapOf);
            }
        }
        ModulesFacade.reportEvent(builderWithName.withAttributes(mapMutableMapOf).build());
    }
}
