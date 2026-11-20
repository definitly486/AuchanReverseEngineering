package io.appmetrica.analytics.impl;

import com.scanflow.datacapture.barinternal.kotlin.NoWhenBranchMatchedException;
import com.scanflow.datacapture.barinternal.kotlin.Pair;
import com.scanflow.datacapture.barinternal.kotlin.TuplesKt;
import com.scanflow.datacapture.barinternal.kotlin.collections.CollectionsKt;
import com.scanflow.datacapture.barinternal.kotlin.collections.MapsKt;
import com.scanflow.datacapture.barinternal.kotlin.ranges.RangesKt;
import com.scanflow.datacapture.barinternal.kotlin.text.Charsets;
import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Set;
import kotlin.jvm.internal.Intrinsics;
import org.json.JSONObject;

/* JADX INFO: loaded from: classes3.dex */
public final class Uc {
    /* JADX WARN: Code duplicated, block: B:24:0x007c  */
    public static final V9 a(Uc uc, EnumC0227ea enumC0227ea, Map map) {
        int i;
        Object value;
        uc.getClass();
        V9 v9 = new V9();
        switch (enumC0227ea.ordinal()) {
            case 0:
                i = 0;
                break;
            case 1:
                i = 1;
                break;
            case 2:
                i = 2;
                break;
            case 3:
                i = 3;
                break;
            case 4:
                i = 4;
                break;
            case 5:
                i = 5;
                break;
            case 6:
                i = 6;
                break;
            default:
                throw new NoWhenBranchMatchedException();
        }
        v9.a = i;
        Vc.b.getClass();
        Set<Map.Entry> setEntrySet = map.entrySet();
        LinkedHashMap linkedHashMap = new LinkedHashMap(RangesKt.coerceAtLeast(MapsKt.mapCapacity(CollectionsKt.collectionSizeOrDefault(setEntrySet, 10)), 16));
        for (Map.Entry entry : setEntrySet) {
            Object key = entry.getKey();
            if (entry.getValue() instanceof Number) {
                Object value2 = entry.getValue();
                Intrinsics.checkNotNull(value2, "null cannot be cast to non-null type kotlin.Number");
                double dDoubleValue = ((Number) value2).doubleValue();
                if (Double.isInfinite(dDoubleValue) || Double.isNaN(dDoubleValue)) {
                    value = null;
                } else {
                    value = entry.getValue();
                }
            } else {
                value = entry.getValue();
            }
            Pair pair = TuplesKt.to(key, value);
            linkedHashMap.put(pair.getFirst(), pair.getSecond());
        }
        String string = new JSONObject(linkedHashMap).toString();
        if (string != null) {
            v9.b = string.getBytes(Charsets.UTF_8);
        }
        return v9;
    }
}
