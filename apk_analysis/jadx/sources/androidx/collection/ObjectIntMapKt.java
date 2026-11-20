package androidx.collection;

import com.scanflow.datacapture.barinternal.kotlin.Unit;
import kotlin.jvm.functions.Function1;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: ObjectIntMap.kt */
/* JADX INFO: loaded from: classes.dex */
public final class ObjectIntMapKt {
    private static final MutableObjectIntMap EmptyObjectIntMap = new MutableObjectIntMap(0);

    public static final <K> ObjectIntMap<K> emptyObjectIntMap() {
        MutableObjectIntMap mutableObjectIntMap = EmptyObjectIntMap;
        Intrinsics.checkNotNull(mutableObjectIntMap, "null cannot be cast to non-null type androidx.collection.ObjectIntMap<K of androidx.collection.ObjectIntMapKt.emptyObjectIntMap>");
        return mutableObjectIntMap;
    }

    public static final <K> ObjectIntMap<K> objectIntMap() {
        MutableObjectIntMap mutableObjectIntMap = EmptyObjectIntMap;
        Intrinsics.checkNotNull(mutableObjectIntMap, "null cannot be cast to non-null type androidx.collection.ObjectIntMap<K of androidx.collection.ObjectIntMapKt.objectIntMap>");
        return mutableObjectIntMap;
    }

    public static final <K> ObjectIntMap<K> objectIntMapOf(K k, int i) {
        MutableObjectIntMap mutableObjectIntMap = new MutableObjectIntMap(0, 1, null);
        mutableObjectIntMap.set(k, i);
        return mutableObjectIntMap;
    }

    public static final <K> ObjectIntMap<K> objectIntMapOf(K k, int i, K k2, int i2) {
        MutableObjectIntMap mutableObjectIntMap = new MutableObjectIntMap(0, 1, null);
        mutableObjectIntMap.set(k, i);
        mutableObjectIntMap.set(k2, i2);
        return mutableObjectIntMap;
    }

    public static final <K> ObjectIntMap<K> objectIntMapOf(K k, int i, K k2, int i2, K k3, int i3) {
        MutableObjectIntMap mutableObjectIntMap = new MutableObjectIntMap(0, 1, null);
        mutableObjectIntMap.set(k, i);
        mutableObjectIntMap.set(k2, i2);
        mutableObjectIntMap.set(k3, i3);
        return mutableObjectIntMap;
    }

    public static final <K> ObjectIntMap<K> objectIntMapOf(K k, int i, K k2, int i2, K k3, int i3, K k4, int i4) {
        MutableObjectIntMap mutableObjectIntMap = new MutableObjectIntMap(0, 1, null);
        mutableObjectIntMap.set(k, i);
        mutableObjectIntMap.set(k2, i2);
        mutableObjectIntMap.set(k3, i3);
        mutableObjectIntMap.set(k4, i4);
        return mutableObjectIntMap;
    }

    public static final <K> ObjectIntMap<K> objectIntMapOf(K k, int i, K k2, int i2, K k3, int i3, K k4, int i4, K k5, int i5) {
        MutableObjectIntMap mutableObjectIntMap = new MutableObjectIntMap(0, 1, null);
        mutableObjectIntMap.set(k, i);
        mutableObjectIntMap.set(k2, i2);
        mutableObjectIntMap.set(k3, i3);
        mutableObjectIntMap.set(k4, i4);
        mutableObjectIntMap.set(k5, i5);
        return mutableObjectIntMap;
    }

    public static final <K> MutableObjectIntMap<K> mutableObjectIntMapOf() {
        return new MutableObjectIntMap<>(0, 1, null);
    }

    public static final <K> MutableObjectIntMap<K> mutableObjectIntMapOf(K k, int i) {
        MutableObjectIntMap<K> mutableObjectIntMap = new MutableObjectIntMap<>(0, 1, null);
        mutableObjectIntMap.set(k, i);
        return mutableObjectIntMap;
    }

    public static final <K> MutableObjectIntMap<K> mutableObjectIntMapOf(K k, int i, K k2, int i2) {
        MutableObjectIntMap<K> mutableObjectIntMap = new MutableObjectIntMap<>(0, 1, null);
        mutableObjectIntMap.set(k, i);
        mutableObjectIntMap.set(k2, i2);
        return mutableObjectIntMap;
    }

    public static final <K> MutableObjectIntMap<K> mutableObjectIntMapOf(K k, int i, K k2, int i2, K k3, int i3) {
        MutableObjectIntMap<K> mutableObjectIntMap = new MutableObjectIntMap<>(0, 1, null);
        mutableObjectIntMap.set(k, i);
        mutableObjectIntMap.set(k2, i2);
        mutableObjectIntMap.set(k3, i3);
        return mutableObjectIntMap;
    }

    public static final <K> MutableObjectIntMap<K> mutableObjectIntMapOf(K k, int i, K k2, int i2, K k3, int i3, K k4, int i4) {
        MutableObjectIntMap<K> mutableObjectIntMap = new MutableObjectIntMap<>(0, 1, null);
        mutableObjectIntMap.set(k, i);
        mutableObjectIntMap.set(k2, i2);
        mutableObjectIntMap.set(k3, i3);
        mutableObjectIntMap.set(k4, i4);
        return mutableObjectIntMap;
    }

    public static final <K> MutableObjectIntMap<K> mutableObjectIntMapOf(K k, int i, K k2, int i2, K k3, int i3, K k4, int i4, K k5, int i5) {
        MutableObjectIntMap<K> mutableObjectIntMap = new MutableObjectIntMap<>(0, 1, null);
        mutableObjectIntMap.set(k, i);
        mutableObjectIntMap.set(k2, i2);
        mutableObjectIntMap.set(k3, i3);
        mutableObjectIntMap.set(k4, i4);
        mutableObjectIntMap.set(k5, i5);
        return mutableObjectIntMap;
    }

    public static final <K> ObjectIntMap<K> buildObjectIntMap(Function1<? super MutableObjectIntMap<K>, Unit> builderAction) {
        Intrinsics.checkNotNullParameter(builderAction, "builderAction");
        MutableObjectIntMap mutableObjectIntMap = new MutableObjectIntMap(0, 1, null);
        builderAction.invoke(mutableObjectIntMap);
        return mutableObjectIntMap;
    }

    public static final <K> ObjectIntMap<K> buildObjectIntMap(int i, Function1<? super MutableObjectIntMap<K>, Unit> builderAction) {
        Intrinsics.checkNotNullParameter(builderAction, "builderAction");
        MutableObjectIntMap mutableObjectIntMap = new MutableObjectIntMap(i);
        builderAction.invoke(mutableObjectIntMap);
        return mutableObjectIntMap;
    }
}
