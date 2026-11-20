package androidx.collection;

import com.bumptech.glide.util.CachedHashCodeArrayMap;
import com.scanflow.datacapture.barinternal.kotlin.Pair;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: ArrayMap.jvm.kt */
/* JADX INFO: loaded from: classes.dex */
public final class ArrayMapKt {
    public static final <K, V> ArrayMap<K, V> arrayMapOf() {
        return new ArrayMap<>();
    }

    /* JADX WARN: Multi-variable type inference failed */
    public static final <K, V> ArrayMap<K, V> arrayMapOf(Pair... pairs) {
        Intrinsics.checkNotNullParameter(pairs, "pairs");
        CachedHashCodeArrayMap cachedHashCodeArrayMap = (ArrayMap<K, V>) new ArrayMap(pairs.length);
        for (Pair pair : pairs) {
            cachedHashCodeArrayMap.put(pair.getFirst(), pair.getSecond());
        }
        return cachedHashCodeArrayMap;
    }
}
