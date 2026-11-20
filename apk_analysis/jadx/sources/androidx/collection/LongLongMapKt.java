package androidx.collection;

import com.scanflow.datacapture.barinternal.kotlin.Unit;
import kotlin.jvm.functions.Function1;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: LongLongMap.kt */
/* JADX INFO: loaded from: classes.dex */
public final class LongLongMapKt {
    private static final MutableLongLongMap EmptyLongLongMap = new MutableLongLongMap(0);

    public static final LongLongMap emptyLongLongMap() {
        return EmptyLongLongMap;
    }

    public static final LongLongMap longLongMapOf() {
        return EmptyLongLongMap;
    }

    public static final LongLongMap longLongMapOf(long j, long j2) {
        MutableLongLongMap mutableLongLongMap = new MutableLongLongMap(0, 1, null);
        mutableLongLongMap.set(j, j2);
        return mutableLongLongMap;
    }

    public static final LongLongMap longLongMapOf(long j, long j2, long j3, long j4) {
        MutableLongLongMap mutableLongLongMap = new MutableLongLongMap(0, 1, null);
        mutableLongLongMap.set(j, j2);
        mutableLongLongMap.set(j3, j4);
        return mutableLongLongMap;
    }

    public static final LongLongMap longLongMapOf(long j, long j2, long j3, long j4, long j5, long j6) {
        MutableLongLongMap mutableLongLongMap = new MutableLongLongMap(0, 1, null);
        mutableLongLongMap.set(j, j2);
        mutableLongLongMap.set(j3, j4);
        mutableLongLongMap.set(j5, j6);
        return mutableLongLongMap;
    }

    public static final LongLongMap longLongMapOf(long j, long j2, long j3, long j4, long j5, long j6, long j7, long j8) {
        MutableLongLongMap mutableLongLongMap = new MutableLongLongMap(0, 1, null);
        mutableLongLongMap.set(j, j2);
        mutableLongLongMap.set(j3, j4);
        mutableLongLongMap.set(j5, j6);
        mutableLongLongMap.set(j7, j8);
        return mutableLongLongMap;
    }

    public static final LongLongMap longLongMapOf(long j, long j2, long j3, long j4, long j5, long j6, long j7, long j8, long j9, long j10) {
        MutableLongLongMap mutableLongLongMap = new MutableLongLongMap(0, 1, null);
        mutableLongLongMap.set(j, j2);
        mutableLongLongMap.set(j3, j4);
        mutableLongLongMap.set(j5, j6);
        mutableLongLongMap.set(j7, j8);
        mutableLongLongMap.set(j9, j10);
        return mutableLongLongMap;
    }

    public static final MutableLongLongMap mutableLongLongMapOf() {
        return new MutableLongLongMap(0, 1, null);
    }

    public static final MutableLongLongMap mutableLongLongMapOf(long j, long j2) {
        MutableLongLongMap mutableLongLongMap = new MutableLongLongMap(0, 1, null);
        mutableLongLongMap.set(j, j2);
        return mutableLongLongMap;
    }

    public static final MutableLongLongMap mutableLongLongMapOf(long j, long j2, long j3, long j4) {
        MutableLongLongMap mutableLongLongMap = new MutableLongLongMap(0, 1, null);
        mutableLongLongMap.set(j, j2);
        mutableLongLongMap.set(j3, j4);
        return mutableLongLongMap;
    }

    public static final MutableLongLongMap mutableLongLongMapOf(long j, long j2, long j3, long j4, long j5, long j6) {
        MutableLongLongMap mutableLongLongMap = new MutableLongLongMap(0, 1, null);
        mutableLongLongMap.set(j, j2);
        mutableLongLongMap.set(j3, j4);
        mutableLongLongMap.set(j5, j6);
        return mutableLongLongMap;
    }

    public static final MutableLongLongMap mutableLongLongMapOf(long j, long j2, long j3, long j4, long j5, long j6, long j7, long j8) {
        MutableLongLongMap mutableLongLongMap = new MutableLongLongMap(0, 1, null);
        mutableLongLongMap.set(j, j2);
        mutableLongLongMap.set(j3, j4);
        mutableLongLongMap.set(j5, j6);
        mutableLongLongMap.set(j7, j8);
        return mutableLongLongMap;
    }

    public static final MutableLongLongMap mutableLongLongMapOf(long j, long j2, long j3, long j4, long j5, long j6, long j7, long j8, long j9, long j10) {
        MutableLongLongMap mutableLongLongMap = new MutableLongLongMap(0, 1, null);
        mutableLongLongMap.set(j, j2);
        mutableLongLongMap.set(j3, j4);
        mutableLongLongMap.set(j5, j6);
        mutableLongLongMap.set(j7, j8);
        mutableLongLongMap.set(j9, j10);
        return mutableLongLongMap;
    }

    public static final LongLongMap buildLongLongMap(Function1<? super MutableLongLongMap, Unit> builderAction) {
        Intrinsics.checkNotNullParameter(builderAction, "builderAction");
        MutableLongLongMap mutableLongLongMap = new MutableLongLongMap(0, 1, null);
        builderAction.invoke(mutableLongLongMap);
        return mutableLongLongMap;
    }

    public static final LongLongMap buildLongLongMap(int i, Function1<? super MutableLongLongMap, Unit> builderAction) {
        Intrinsics.checkNotNullParameter(builderAction, "builderAction");
        MutableLongLongMap mutableLongLongMap = new MutableLongLongMap(i);
        builderAction.invoke(mutableLongLongMap);
        return mutableLongLongMap;
    }
}
