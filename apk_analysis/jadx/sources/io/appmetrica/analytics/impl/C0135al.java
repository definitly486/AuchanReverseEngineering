package io.appmetrica.analytics.impl;

import com.scanflow.datacapture.barinternal.kotlin.Pair;
import com.scanflow.datacapture.barinternal.kotlin.TuplesKt;
import com.scanflow.datacapture.barinternal.kotlin.collections.MapsKt;
import com.scanflow.datacapture.barinternal.kotlin.ranges.RangesKt;
import com.scanflow.datacapture.barinternal.kotlin.text.Charsets;
import io.appmetrica.analytics.coreapi.internal.data.ProtobufConverter;
import java.util.ArrayList;
import java.util.LinkedHashMap;
import java.util.Map;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.al, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0135al implements ProtobufConverter {
    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final C0187cl fromModel(Map<String, byte[]> map) {
        C0187cl c0187cl = new C0187cl();
        ArrayList arrayList = new ArrayList(map.size());
        for (Map.Entry<String, byte[]> entry : map.entrySet()) {
            C0213dl c0213dl = new C0213dl();
            c0213dl.a = entry.getKey().getBytes(Charsets.UTF_8);
            c0213dl.b = entry.getValue();
            arrayList.add(c0213dl);
        }
        c0187cl.a = (C0213dl[]) arrayList.toArray(new C0213dl[0]);
        return c0187cl;
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final Map<String, byte[]> toModel(C0187cl c0187cl) {
        C0213dl[] c0213dlArr = c0187cl.a;
        LinkedHashMap linkedHashMap = new LinkedHashMap(RangesKt.coerceAtLeast(MapsKt.mapCapacity(c0213dlArr.length), 16));
        for (C0213dl c0213dl : c0213dlArr) {
            Pair pair = TuplesKt.to(new String(c0213dl.a, Charsets.UTF_8), c0213dl.b);
            linkedHashMap.put(pair.getFirst(), pair.getSecond());
        }
        return linkedHashMap;
    }
}
