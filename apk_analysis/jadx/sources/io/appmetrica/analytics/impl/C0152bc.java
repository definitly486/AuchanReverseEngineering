package io.appmetrica.analytics.impl;

import java.util.ArrayList;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.bc, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0152bc {
    public final C0143b3 a;
    public final C0608t2 b;
    public final ArrayList c;

    public C0152bc(C0143b3 c0143b3, C0608t2 c0608t2) {
        ArrayList arrayList = new ArrayList();
        this.c = arrayList;
        this.a = c0143b3;
        arrayList.add(c0143b3);
        this.b = c0608t2;
        arrayList.add(c0608t2);
    }

    public final synchronized void a() {
        ArrayList arrayList = this.c;
        int size = arrayList.size();
        int i = 0;
        while (i < size) {
            Object obj = arrayList.get(i);
            i++;
            ((Ck) obj).onCreate();
        }
    }

    public final synchronized void a(Ja ja) {
        this.c.add(ja);
    }
}
