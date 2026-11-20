package androidx.collection;

import com.scanflow.datacapture.barinternal.kotlin.Unit;
import kotlin.jvm.functions.Function1;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: IntSet.kt */
/* JADX INFO: loaded from: classes.dex */
public final class IntSetKt {
    private static final MutableIntSet EmptyIntSet = new MutableIntSet(0);
    private static final int[] EmptyIntArray = new int[0];

    public static final int[] getEmptyIntArray() {
        return EmptyIntArray;
    }

    public static final IntSet emptyIntSet() {
        return EmptyIntSet;
    }

    public static final IntSet intSetOf() {
        return EmptyIntSet;
    }

    public static final IntSet intSetOf(int i) {
        return mutableIntSetOf(i);
    }

    public static final IntSet intSetOf(int i, int i2) {
        return mutableIntSetOf(i, i2);
    }

    public static final IntSet intSetOf(int i, int i2, int i3) {
        return mutableIntSetOf(i, i2, i3);
    }

    public static final IntSet intSetOf(int... elements) {
        Intrinsics.checkNotNullParameter(elements, "elements");
        MutableIntSet mutableIntSet = new MutableIntSet(elements.length);
        mutableIntSet.plusAssign(elements);
        return mutableIntSet;
    }

    public static final MutableIntSet mutableIntSetOf() {
        return new MutableIntSet(0, 1, null);
    }

    public static final MutableIntSet mutableIntSetOf(int i) {
        MutableIntSet mutableIntSet = new MutableIntSet(1);
        mutableIntSet.plusAssign(i);
        return mutableIntSet;
    }

    public static final MutableIntSet mutableIntSetOf(int i, int i2) {
        MutableIntSet mutableIntSet = new MutableIntSet(2);
        mutableIntSet.plusAssign(i);
        mutableIntSet.plusAssign(i2);
        return mutableIntSet;
    }

    public static final MutableIntSet mutableIntSetOf(int i, int i2, int i3) {
        MutableIntSet mutableIntSet = new MutableIntSet(3);
        mutableIntSet.plusAssign(i);
        mutableIntSet.plusAssign(i2);
        mutableIntSet.plusAssign(i3);
        return mutableIntSet;
    }

    public static final MutableIntSet mutableIntSetOf(int... elements) {
        Intrinsics.checkNotNullParameter(elements, "elements");
        MutableIntSet mutableIntSet = new MutableIntSet(elements.length);
        mutableIntSet.plusAssign(elements);
        return mutableIntSet;
    }

    public static final IntSet buildIntSet(Function1<? super MutableIntSet, Unit> builderAction) {
        Intrinsics.checkNotNullParameter(builderAction, "builderAction");
        MutableIntSet mutableIntSet = new MutableIntSet(0, 1, null);
        builderAction.invoke(mutableIntSet);
        return mutableIntSet;
    }

    public static final IntSet buildIntSet(int i, Function1<? super MutableIntSet, Unit> builderAction) {
        Intrinsics.checkNotNullParameter(builderAction, "builderAction");
        MutableIntSet mutableIntSet = new MutableIntSet(i);
        builderAction.invoke(mutableIntSet);
        return mutableIntSet;
    }
}
