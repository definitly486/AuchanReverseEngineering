package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreapi.internal.backport.BiFunction;
import java.util.ArrayList;
import java.util.Map;
import java.util.TreeMap;

/* JADX INFO: loaded from: classes3.dex */
public final class Vn {
    public final Un a;
    public final BiFunction b;
    public final Xf c;

    public Vn() {
        this(new Sn(), new Ia(), C0584s4.l().n());
    }

    public final ArrayList a(Thread thread, Thread thread2) {
        Map mapC;
        ArrayList arrayList = new ArrayList();
        TreeMap treeMap = new TreeMap(new Tn());
        try {
            mapC = this.a.c();
        } catch (SecurityException unused) {
            mapC = null;
        }
        if (mapC != null) {
            treeMap.putAll(mapC);
        }
        if (thread2 != null) {
            treeMap.remove(thread2);
        }
        for (Map.Entry entry : treeMap.entrySet()) {
            Thread thread3 = (Thread) entry.getKey();
            if (thread3 != thread && thread3 != thread2) {
                arrayList.add((On) this.b.apply(thread3, (StackTraceElement[]) entry.getValue()));
            }
        }
        return arrayList;
    }

    public Vn(Un un, Ia ia, J6 j6) {
        this.a = un;
        this.b = ia;
        this.c = j6;
    }
}
