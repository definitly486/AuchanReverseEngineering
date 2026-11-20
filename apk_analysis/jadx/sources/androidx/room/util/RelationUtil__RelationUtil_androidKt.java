package androidx.room.util;

import androidx.collection.ArrayMap;
import java.util.HashMap;
import java.util.Iterator;
import java.util.Map;
import kotlin.jvm.functions.Function1;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: RelationUtil.android.kt */
/* JADX INFO: loaded from: classes.dex */
abstract /* synthetic */ class RelationUtil__RelationUtil_androidKt {
    public static final void recursiveFetchHashMap(HashMap map, boolean z, Function1 fetchBlock) {
        int i;
        Intrinsics.checkNotNullParameter(map, "map");
        Intrinsics.checkNotNullParameter(fetchBlock, "fetchBlock");
        HashMap map2 = new HashMap(999);
        Iterator it = map.keySet().iterator();
        loop0: while (true) {
            i = 0;
            do {
                if (!it.hasNext()) {
                    break loop0;
                }
                Object next = it.next();
                Intrinsics.checkNotNullExpressionValue(next, "next(...)");
                if (z) {
                    map2.put(next, map.get(next));
                } else {
                    map2.put(next, null);
                }
                i++;
            } while (i != 999);
            fetchBlock.invoke(map2);
            if (!z) {
                map.putAll(map2);
            }
            map2.clear();
        }
        if (i > 0) {
            fetchBlock.invoke(map2);
            if (z) {
                return;
            }
            map.putAll(map2);
        }
    }

    public static final void recursiveFetchArrayMap(ArrayMap map, boolean z, Function1 fetchBlock) {
        Intrinsics.checkNotNullParameter(map, "map");
        Intrinsics.checkNotNullParameter(fetchBlock, "fetchBlock");
        ArrayMap arrayMap = new ArrayMap(999);
        int size = map.size();
        int i = 0;
        int i2 = 0;
        while (i < size) {
            if (z) {
                arrayMap.put(map.keyAt(i), map.valueAt(i));
            } else {
                arrayMap.put(map.keyAt(i), null);
            }
            i++;
            i2++;
            if (i2 == 999) {
                fetchBlock.invoke(arrayMap);
                if (!z) {
                    map.putAll((Map) arrayMap);
                }
                arrayMap.clear();
                i2 = 0;
            }
        }
        if (i2 > 0) {
            fetchBlock.invoke(arrayMap);
            if (z) {
                return;
            }
            map.putAll((Map) arrayMap);
        }
    }
}
