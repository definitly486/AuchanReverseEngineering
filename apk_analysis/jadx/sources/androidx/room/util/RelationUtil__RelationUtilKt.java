package androidx.room.util;

import androidx.collection.LongSparseArray;
import java.util.Iterator;
import java.util.LinkedHashMap;
import java.util.Map;
import kotlin.jvm.functions.Function1;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: RelationUtil.kt */
/* JADX INFO: loaded from: classes.dex */
abstract /* synthetic */ class RelationUtil__RelationUtilKt {
    public static final void recursiveFetchMap(Map map, boolean z, Function1 fetchBlock) {
        int i;
        Intrinsics.checkNotNullParameter(map, "map");
        Intrinsics.checkNotNullParameter(fetchBlock, "fetchBlock");
        LinkedHashMap linkedHashMap = new LinkedHashMap();
        Iterator it = map.keySet().iterator();
        loop0: while (true) {
            i = 0;
            do {
                if (!it.hasNext()) {
                    break loop0;
                }
                Object next = it.next();
                if (z) {
                    linkedHashMap.put(next, map.get(next));
                } else {
                    linkedHashMap.put(next, null);
                }
                i++;
            } while (i != 999);
            fetchBlock.invoke(linkedHashMap);
            if (!z) {
                map.putAll(linkedHashMap);
            }
            linkedHashMap.clear();
        }
        if (i > 0) {
            fetchBlock.invoke(linkedHashMap);
            if (z) {
                return;
            }
            map.putAll(linkedHashMap);
        }
    }

    public static final void recursiveFetchLongSparseArray(LongSparseArray map, boolean z, Function1 fetchBlock) {
        Intrinsics.checkNotNullParameter(map, "map");
        Intrinsics.checkNotNullParameter(fetchBlock, "fetchBlock");
        LongSparseArray longSparseArray = new LongSparseArray(999);
        int size = map.size();
        int i = 0;
        int i2 = 0;
        while (i < size) {
            if (z) {
                longSparseArray.put(map.keyAt(i), map.valueAt(i));
            } else {
                longSparseArray.put(map.keyAt(i), null);
            }
            i++;
            i2++;
            if (i2 == 999) {
                fetchBlock.invoke(longSparseArray);
                if (!z) {
                    map.putAll(longSparseArray);
                }
                longSparseArray.clear();
                i2 = 0;
            }
        }
        if (i2 > 0) {
            fetchBlock.invoke(longSparseArray);
            if (z) {
                return;
            }
            map.putAll(longSparseArray);
        }
    }
}
