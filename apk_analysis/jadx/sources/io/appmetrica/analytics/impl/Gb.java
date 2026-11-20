package io.appmetrica.analytics.impl;

import android.content.Context;
import com.scanflow.datacapture.barinternal.kotlin.collections.CollectionsKt;
import io.appmetrica.analytics.AppMetricaConfig;
import java.util.ArrayList;
import java.util.Iterator;

/* JADX INFO: loaded from: classes3.dex */
public final class Gb {
    public final C0582s2 a = new C0582s2();
    public final A6 b = new A6();
    public Rn c;
    public boolean d;
    public boolean e;

    public final synchronized void a(Context context, AppMetricaConfig appMetricaConfig, InterfaceC0487ob interfaceC0487ob) {
        if (this.e) {
            return;
        }
        CollectionsKt.addAll(this.b.a, new InterfaceC0228eb[]{this.a.a(context, appMetricaConfig, interfaceC0487ob)});
        this.e = true;
    }

    public final synchronized void b() {
        if (this.d) {
            return;
        }
        A6 a6 = this.b;
        ArrayList arrayList = C0584s4.l().i.a;
        ArrayList arrayList2 = new ArrayList(CollectionsKt.collectionSizeOrDefault(arrayList, 10));
        Iterator it = arrayList.iterator();
        if (it.hasNext()) {
            it.next().getClass();
            throw new ClassCastException();
        }
        a6.a.addAll(arrayList2);
        this.d = true;
    }

    public final synchronized void c() {
        try {
            if (this.c != null) {
                return;
            }
            C0142b2 c0142b2 = new C0142b2(this.b);
            this.c = new Rn(c0142b2);
            Qn qn = new Qn();
            qn.a.add(c0142b2);
            Thread.UncaughtExceptionHandler defaultUncaughtExceptionHandler = Thread.getDefaultUncaughtExceptionHandler();
            if (defaultUncaughtExceptionHandler != null) {
                qn.a.add(defaultUncaughtExceptionHandler);
            }
            Thread.setDefaultUncaughtExceptionHandler(qn);
        } catch (Throwable th) {
            throw th;
        }
    }

    public final synchronized void a() {
        this.b.a.clear();
        this.d = false;
        this.e = false;
    }
}
