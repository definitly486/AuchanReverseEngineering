package androidx.room.util;

import androidx.collection.ArrayMap;
import androidx.collection.LongSparseArray;
import com.scanflow.datacapture.barinternal.kotlin.Unit;
import java.util.HashMap;
import java.util.Map;
import kotlin.jvm.functions.Function1;

/* JADX INFO: loaded from: classes.dex */
public final class RelationUtil {
    public static final <K, V> void recursiveFetchArrayMap(ArrayMap<K, V> arrayMap, boolean z, Function1<? super ArrayMap<K, V>, Unit> function1) {
        RelationUtil__RelationUtil_androidKt.recursiveFetchArrayMap(arrayMap, z, function1);
    }

    public static final <K, V> void recursiveFetchHashMap(HashMap<K, V> map, boolean z, Function1<? super HashMap<K, V>, Unit> function1) {
        RelationUtil__RelationUtil_androidKt.recursiveFetchHashMap(map, z, function1);
    }

    public static final <V> void recursiveFetchLongSparseArray(LongSparseArray<V> longSparseArray, boolean z, Function1<? super LongSparseArray<V>, Unit> function1) {
        RelationUtil__RelationUtilKt.recursiveFetchLongSparseArray(longSparseArray, z, function1);
    }

    public static final <K, V> void recursiveFetchMap(Map<K, V> map, boolean z, Function1<? super Map<K, V>, Unit> function1) {
        RelationUtil__RelationUtilKt.recursiveFetchMap(map, z, function1);
    }
}
