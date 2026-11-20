package androidx.collection;

import com.scanflow.datacapture.barinternal.kotlin.Unit;
import kotlin.jvm.functions.Function1;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: LongList.kt */
/* JADX INFO: loaded from: classes.dex */
public final class LongListKt {
    private static final LongList EmptyLongList = new MutableLongList(0);

    public static final LongList emptyLongList() {
        return EmptyLongList;
    }

    public static final LongList longListOf() {
        return EmptyLongList;
    }

    public static final LongList longListOf(long j) {
        return mutableLongListOf(j);
    }

    public static final LongList longListOf(long j, long j2) {
        return mutableLongListOf(j, j2);
    }

    public static final LongList longListOf(long j, long j2, long j3) {
        return mutableLongListOf(j, j2, j3);
    }

    public static final LongList longListOf(long... elements) {
        Intrinsics.checkNotNullParameter(elements, "elements");
        MutableLongList mutableLongList = new MutableLongList(elements.length);
        mutableLongList.addAll(mutableLongList._size, elements);
        return mutableLongList;
    }

    public static final MutableLongList mutableLongListOf() {
        return new MutableLongList(0, 1, null);
    }

    public static final MutableLongList mutableLongListOf(long j) {
        MutableLongList mutableLongList = new MutableLongList(1);
        mutableLongList.add(j);
        return mutableLongList;
    }

    public static final MutableLongList mutableLongListOf(long j, long j2) {
        MutableLongList mutableLongList = new MutableLongList(2);
        mutableLongList.add(j);
        mutableLongList.add(j2);
        return mutableLongList;
    }

    public static final MutableLongList mutableLongListOf(long j, long j2, long j3) {
        MutableLongList mutableLongList = new MutableLongList(3);
        mutableLongList.add(j);
        mutableLongList.add(j2);
        mutableLongList.add(j3);
        return mutableLongList;
    }

    public static final MutableLongList mutableLongListOf(long... elements) {
        Intrinsics.checkNotNullParameter(elements, "elements");
        MutableLongList mutableLongList = new MutableLongList(elements.length);
        mutableLongList.addAll(mutableLongList._size, elements);
        return mutableLongList;
    }

    public static final LongList buildLongList(Function1<? super MutableLongList, Unit> builderAction) {
        Intrinsics.checkNotNullParameter(builderAction, "builderAction");
        MutableLongList mutableLongList = new MutableLongList(0, 1, null);
        builderAction.invoke(mutableLongList);
        return mutableLongList;
    }

    public static final LongList buildLongList(int i, Function1<? super MutableLongList, Unit> builderAction) {
        Intrinsics.checkNotNullParameter(builderAction, "builderAction");
        MutableLongList mutableLongList = new MutableLongList(i);
        builderAction.invoke(mutableLongList);
        return mutableLongList;
    }
}
