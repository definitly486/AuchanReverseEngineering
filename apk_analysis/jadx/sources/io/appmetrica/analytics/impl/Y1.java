package io.appmetrica.analytics.impl;

import android.content.Context;
import android.content.Intent;
import android.content.res.Configuration;
import android.os.IBinder;
import com.scanflow.datacapture.barinternal.kotlin.text.StringsKt;
import io.appmetrica.analytics.logger.appmetrica.internal.PublicLogger;
import java.util.ArrayList;
import java.util.LinkedHashMap;
import java.util.List;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: loaded from: classes3.dex */
public final class Y1 {
    public static C1 d;
    public final Context a;
    public final B1 b;
    public A1 c;

    public Y1(Context context, B1 b1) {
        this.a = context;
        this.b = b1;
    }

    public final void b() {
        Ka.a(this.a);
        PublicLogger.Companion.init(this.a);
        Context context = this.a;
        B1 b1 = this.b;
        if (d == null) {
            O1 o1 = new O1(context, b1, new C0611t5(context));
            C0678vk c0678vk = Ka.I.v;
            R1 r1 = new R1(o1);
            LinkedHashMap linkedHashMap = c0678vk.a;
            Object arrayList = linkedHashMap.get(1);
            if (arrayList == null) {
                arrayList = new ArrayList();
                linkedHashMap.put(1, arrayList);
            }
            ((List) arrayList).add(r1);
            d = new N1(Ka.I.d.b(), o1);
        }
        C1 c1 = d;
        if (c1 != null) {
            this.c = new A1(c1);
            Ka ka = Ka.I;
            ka.f = new Bj(ka.a, new Cj(c1));
            c1.onCreate();
        }
    }

    public final boolean c(Intent intent) {
        C1 c1 = d;
        if (c1 != null) {
            c1.b(intent);
        }
        String action = intent.getAction();
        return (action == null || !StringsKt.startsWith$default(action, "io.appmetrica.analytics.ACTION_SERVICE_WAKELOCK", false, 2, (Object) null)) && intent.getData() == null;
    }

    public final void d() {
        d = null;
    }

    public final void a(Intent intent, int i) {
        C1 c1 = d;
        if (c1 != null) {
            c1.a(intent, i);
        }
    }

    public final int a(Intent intent, int i, int i2) {
        C1 c1 = d;
        if (c1 == null) {
            return 2;
        }
        c1.a(intent, i, i2);
        return 2;
    }

    public final void c() {
        C1 c1 = d;
        if (c1 != null) {
            c1.onDestroy();
        }
    }

    public final IBinder a(Intent intent) {
        C1 c1 = d;
        if (c1 != null) {
            c1.a(intent);
        }
        String action = intent.getAction();
        if (action != null && StringsKt.startsWith$default(action, "io.appmetrica.analytics.ACTION_SERVICE_WAKELOCK", false, 2, (Object) null)) {
            return new Vo();
        }
        A1 a1 = this.c;
        if (a1 != null) {
            return a1;
        }
        Intrinsics.throwUninitializedPropertyAccessException("coreBinder");
        return null;
    }

    public final void a(Configuration configuration) {
        C1 c1 = d;
        if (c1 != null) {
            c1.onConfigurationChanged(configuration);
        }
    }

    public final void b(Intent intent) {
        C1 c1 = d;
        if (c1 != null) {
            c1.c(intent);
        }
    }
}
