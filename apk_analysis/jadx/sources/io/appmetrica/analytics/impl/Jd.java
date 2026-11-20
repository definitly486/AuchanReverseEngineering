package io.appmetrica.analytics.impl;

import com.scanflow.datacapture.barinternal.kotlin.Pair;
import com.scanflow.datacapture.barinternal.kotlin.TuplesKt;
import com.scanflow.datacapture.barinternal.kotlin.collections.MapsKt;
import io.appmetrica.analytics.coreapi.internal.data.Converter;
import java.util.ArrayList;
import java.util.Map;

/* JADX INFO: loaded from: classes3.dex */
public final class Jd implements Converter {
    public final Ok a = Ka.k().p();

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final Jm[] fromModel(Map<String, ? extends Object> map) {
        Jm jm;
        Map<String, C0593sd> mapB = this.a.b();
        ArrayList arrayList = new ArrayList();
        for (Map.Entry<String, ? extends Object> entry : map.entrySet()) {
            String key = entry.getKey();
            Object value = entry.getValue();
            C0593sd c0593sd = mapB.get(key);
            if (c0593sd == null || value == null) {
                jm = null;
            } else {
                jm = new Jm();
                jm.a = key;
                jm.b = (byte[]) c0593sd.c.fromModel(value);
            }
            if (jm != null) {
                arrayList.add(jm);
            }
        }
        return (Jm[]) arrayList.toArray(new Jm[0]);
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final Map<String, Object> toModel(Jm[] jmArr) {
        Map<String, C0593sd> mapB = this.a.b();
        ArrayList arrayList = new ArrayList();
        for (Jm jm : jmArr) {
            C0593sd c0593sd = mapB.get(jm.a);
            Pair pair = c0593sd != null ? TuplesKt.to(jm.a, c0593sd.c.toModel(jm.b)) : null;
            if (pair != null) {
                arrayList.add(pair);
            }
        }
        return MapsKt.toMap(arrayList);
    }
}
