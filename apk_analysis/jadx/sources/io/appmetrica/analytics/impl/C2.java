package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreutils.internal.time.SystemTimeProvider;
import java.util.Iterator;
import java.util.LinkedHashSet;
import java.util.Map;
import java.util.concurrent.TimeUnit;

/* JADX INFO: loaded from: classes3.dex */
public final class C2 {
    public final C0544qf a;
    public final long b;
    public final long c;
    public final SystemTimeProvider d;
    public final Map e;

    public C2(C0274g5 c0274g5, C0544qf c0544qf) {
        this.a = c0544qf;
        c0274g5.b();
        this.b = TimeUnit.MINUTES.toMillis(1L);
        this.c = TimeUnit.DAYS.toMillis(7L);
        this.d = new SystemTimeProvider();
        Map<String, Long> mapF = c0544qf.f();
        a(mapF);
        this.e = mapF;
    }

    public final void a(Map map) {
        long jCurrentTimeMillis = this.d.currentTimeMillis();
        LinkedHashSet linkedHashSet = new LinkedHashSet();
        for (Map.Entry entry : map.entrySet()) {
            String str = (String) entry.getKey();
            if (((Number) entry.getValue()).longValue() < jCurrentTimeMillis - this.c) {
                linkedHashSet.add(str);
            }
        }
        Iterator it = linkedHashSet.iterator();
        while (it.hasNext()) {
            map.remove((String) it.next());
        }
    }
}
