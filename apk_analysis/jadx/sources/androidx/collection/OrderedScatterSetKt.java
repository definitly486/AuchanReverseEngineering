package androidx.collection;

import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: OrderedScatterSet.kt */
/* JADX INFO: loaded from: classes.dex */
public final class OrderedScatterSetKt {
    private static final MutableOrderedScatterSet EmptyOrderedScatterSet = new MutableOrderedScatterSet(0);

    public static final <E> OrderedScatterSet<E> emptyOrderedScatterSet() {
        MutableOrderedScatterSet mutableOrderedScatterSet = EmptyOrderedScatterSet;
        Intrinsics.checkNotNull(mutableOrderedScatterSet, "null cannot be cast to non-null type androidx.collection.OrderedScatterSet<E of androidx.collection.OrderedScatterSetKt.emptyOrderedScatterSet>");
        return mutableOrderedScatterSet;
    }

    public static final <E> OrderedScatterSet<E> orderedScatterSetOf() {
        MutableOrderedScatterSet mutableOrderedScatterSet = EmptyOrderedScatterSet;
        Intrinsics.checkNotNull(mutableOrderedScatterSet, "null cannot be cast to non-null type androidx.collection.OrderedScatterSet<E of androidx.collection.OrderedScatterSetKt.orderedScatterSetOf>");
        return mutableOrderedScatterSet;
    }

    public static final <E> OrderedScatterSet<E> orderedScatterSetOf(E e) {
        return mutableOrderedScatterSetOf(e);
    }

    public static final <E> OrderedScatterSet<E> orderedScatterSetOf(E e, E e2) {
        return mutableOrderedScatterSetOf(e, e2);
    }

    public static final <E> OrderedScatterSet<E> orderedScatterSetOf(E e, E e2, E e3) {
        return mutableOrderedScatterSetOf(e, e2, e3);
    }

    public static final <E> OrderedScatterSet<E> orderedScatterSetOf(E... elements) {
        Intrinsics.checkNotNullParameter(elements, "elements");
        MutableOrderedScatterSet mutableOrderedScatterSet = new MutableOrderedScatterSet(elements.length);
        mutableOrderedScatterSet.plusAssign((Object[]) elements);
        return mutableOrderedScatterSet;
    }

    public static final <E> MutableOrderedScatterSet<E> mutableOrderedScatterSetOf() {
        return new MutableOrderedScatterSet<>(0, 1, null);
    }

    public static final <E> MutableOrderedScatterSet<E> mutableOrderedScatterSetOf(E e) {
        MutableOrderedScatterSet<E> mutableOrderedScatterSet = new MutableOrderedScatterSet<>(1);
        mutableOrderedScatterSet.plusAssign(e);
        return mutableOrderedScatterSet;
    }

    public static final <E> MutableOrderedScatterSet<E> mutableOrderedScatterSetOf(E e, E e2) {
        MutableOrderedScatterSet<E> mutableOrderedScatterSet = new MutableOrderedScatterSet<>(2);
        mutableOrderedScatterSet.plusAssign(e);
        mutableOrderedScatterSet.plusAssign(e2);
        return mutableOrderedScatterSet;
    }

    public static final <E> MutableOrderedScatterSet<E> mutableOrderedScatterSetOf(E e, E e2, E e3) {
        MutableOrderedScatterSet<E> mutableOrderedScatterSet = new MutableOrderedScatterSet<>(3);
        mutableOrderedScatterSet.plusAssign(e);
        mutableOrderedScatterSet.plusAssign(e2);
        mutableOrderedScatterSet.plusAssign(e3);
        return mutableOrderedScatterSet;
    }

    public static final <E> MutableOrderedScatterSet<E> mutableOrderedScatterSetOf(E... elements) {
        Intrinsics.checkNotNullParameter(elements, "elements");
        MutableOrderedScatterSet<E> mutableOrderedScatterSet = new MutableOrderedScatterSet<>(elements.length);
        mutableOrderedScatterSet.plusAssign((Object[]) elements);
        return mutableOrderedScatterSet;
    }
}
