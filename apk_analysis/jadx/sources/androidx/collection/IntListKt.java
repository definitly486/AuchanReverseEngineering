package androidx.collection;

import com.scanflow.datacapture.barinternal.kotlin.Unit;
import kotlin.jvm.functions.Function1;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: IntList.kt */
/* JADX INFO: loaded from: classes.dex */
public final class IntListKt {
    private static final IntList EmptyIntList = new MutableIntList(0);

    public static final IntList emptyIntList() {
        return EmptyIntList;
    }

    public static final IntList intListOf() {
        return EmptyIntList;
    }

    public static final IntList intListOf(int i) {
        return mutableIntListOf(i);
    }

    public static final IntList intListOf(int i, int i2) {
        return mutableIntListOf(i, i2);
    }

    public static final IntList intListOf(int i, int i2, int i3) {
        return mutableIntListOf(i, i2, i3);
    }

    public static final IntList intListOf(int... elements) {
        Intrinsics.checkNotNullParameter(elements, "elements");
        MutableIntList mutableIntList = new MutableIntList(elements.length);
        mutableIntList.addAll(mutableIntList._size, elements);
        return mutableIntList;
    }

    public static final MutableIntList mutableIntListOf() {
        return new MutableIntList(0, 1, null);
    }

    public static final MutableIntList mutableIntListOf(int i) {
        MutableIntList mutableIntList = new MutableIntList(1);
        mutableIntList.add(i);
        return mutableIntList;
    }

    public static final MutableIntList mutableIntListOf(int i, int i2) {
        MutableIntList mutableIntList = new MutableIntList(2);
        mutableIntList.add(i);
        mutableIntList.add(i2);
        return mutableIntList;
    }

    public static final MutableIntList mutableIntListOf(int i, int i2, int i3) {
        MutableIntList mutableIntList = new MutableIntList(3);
        mutableIntList.add(i);
        mutableIntList.add(i2);
        mutableIntList.add(i3);
        return mutableIntList;
    }

    public static final MutableIntList mutableIntListOf(int... elements) {
        Intrinsics.checkNotNullParameter(elements, "elements");
        MutableIntList mutableIntList = new MutableIntList(elements.length);
        mutableIntList.addAll(mutableIntList._size, elements);
        return mutableIntList;
    }

    public static final IntList buildIntList(Function1<? super MutableIntList, Unit> builderAction) {
        Intrinsics.checkNotNullParameter(builderAction, "builderAction");
        MutableIntList mutableIntList = new MutableIntList(0, 1, null);
        builderAction.invoke(mutableIntList);
        return mutableIntList;
    }

    public static final IntList buildIntList(int i, Function1<? super MutableIntList, Unit> builderAction) {
        Intrinsics.checkNotNullParameter(builderAction, "builderAction");
        MutableIntList mutableIntList = new MutableIntList(i);
        builderAction.invoke(mutableIntList);
        return mutableIntList;
    }
}
