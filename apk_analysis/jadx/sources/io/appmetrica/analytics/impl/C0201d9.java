package io.appmetrica.analytics.impl;

import com.scanflow.datacapture.barinternal.kotlin.Pair;
import com.scanflow.datacapture.barinternal.kotlin.TuplesKt;
import com.scanflow.datacapture.barinternal.kotlin.collections.CollectionsKt;
import com.scanflow.datacapture.barinternal.kotlin.collections.MapsKt;
import com.scanflow.datacapture.barinternal.kotlin.ranges.RangesKt;
import io.appmetrica.analytics.coreapi.internal.data.Converter;
import io.appmetrica.analytics.protobuf.nano.MessageNano;
import java.util.LinkedHashMap;
import java.util.Map;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.d9, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0201d9 implements Converter {
    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final byte[] fromModel(Map<String, byte[]> map) {
        C0252f9 c0252f9 = new C0252f9();
        C0226e9[] c0226e9Arr = new C0226e9[map.size()];
        int i = 0;
        for (Object obj : map.entrySet()) {
            int i2 = i + 1;
            if (i < 0) {
                CollectionsKt.throwIndexOverflow();
            }
            Map.Entry entry = (Map.Entry) obj;
            C0226e9 c0226e9 = new C0226e9();
            c0226e9.a = (String) entry.getKey();
            c0226e9.b = (byte[]) entry.getValue();
            c0226e9Arr[i] = c0226e9;
            i = i2;
        }
        c0252f9.a = c0226e9Arr;
        return MessageNano.toByteArray(c0252f9);
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final Map<String, byte[]> toModel(byte[] bArr) {
        C0226e9[] c0226e9Arr = ((C0252f9) MessageNano.mergeFrom(new C0252f9(), bArr)).a;
        LinkedHashMap linkedHashMap = new LinkedHashMap(RangesKt.coerceAtLeast(MapsKt.mapCapacity(c0226e9Arr.length), 16));
        for (C0226e9 c0226e9 : c0226e9Arr) {
            Pair pair = TuplesKt.to(c0226e9.a, c0226e9.b);
            linkedHashMap.put(pair.getFirst(), pair.getSecond());
        }
        return linkedHashMap;
    }
}
