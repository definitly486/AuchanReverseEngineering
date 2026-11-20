package io.appmetrica.analytics.impl;

import android.util.Pair;
import io.appmetrica.analytics.coreapi.internal.data.ProtobufConverter;
import java.util.ArrayList;

/* JADX INFO: loaded from: classes3.dex */
public final class A2 implements ProtobufConverter {
    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final Em fromModel(C0764z2 c0764z2) {
        Cm cm;
        Em em = new Em();
        em.a = new Dm[c0764z2.a.size()];
        for (int i = 0; i < c0764z2.a.size(); i++) {
            Dm dm = new Dm();
            Pair pair = (Pair) c0764z2.a.get(i);
            dm.a = (String) pair.first;
            if (pair.second != null) {
                dm.b = new Cm();
                C0738y2 c0738y2 = (C0738y2) pair.second;
                if (c0738y2 == null) {
                    cm = null;
                } else {
                    Cm cm2 = new Cm();
                    cm2.a = c0738y2.a;
                    cm = cm2;
                }
                dm.b = cm;
            }
            em.a[i] = dm;
        }
        return em;
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final C0764z2 toModel(Em em) {
        ArrayList arrayList = new ArrayList();
        for (Dm dm : em.a) {
            String str = dm.a;
            Cm cm = dm.b;
            arrayList.add(new Pair(str, cm == null ? null : new C0738y2(cm.a)));
        }
        return new C0764z2(arrayList);
    }
}
