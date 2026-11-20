package com.scanflow.datacapture.barinternal.kotlin.enums;

import com.scanflow.datacapture.barinternal.kotlin.collections.AbstractList;
import com.scanflow.datacapture.barinternal.kotlin.collections.ArraysKt;
import java.io.Serializable;
import java.util.RandomAccess;
import kotlin.enums.EnumEntries;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: EnumEntries.kt */
/* JADX INFO: loaded from: classes3.dex */
final class EnumEntriesList extends AbstractList implements EnumEntries, RandomAccess, Serializable {
    private final Enum[] entries;

    public EnumEntriesList(Enum[] entries) {
        Intrinsics.checkNotNullParameter(entries, "entries");
        this.entries = entries;
    }

    @Override // com.scanflow.datacapture.barinternal.kotlin.collections.AbstractCollection, java.util.Collection
    public final /* bridge */ boolean contains(Object obj) {
        if (obj instanceof Enum) {
            return contains((Enum) obj);
        }
        return false;
    }

    @Override // com.scanflow.datacapture.barinternal.kotlin.collections.AbstractList, java.util.List
    public final /* bridge */ int indexOf(Object obj) {
        if (obj instanceof Enum) {
            return indexOf((Enum) obj);
        }
        return -1;
    }

    @Override // com.scanflow.datacapture.barinternal.kotlin.collections.AbstractList, java.util.List
    public final /* bridge */ int lastIndexOf(Object obj) {
        if (obj instanceof Enum) {
            return lastIndexOf((Enum) obj);
        }
        return -1;
    }

    @Override // com.scanflow.datacapture.barinternal.kotlin.collections.AbstractCollection
    public int getSize() {
        return this.entries.length;
    }

    @Override // com.scanflow.datacapture.barinternal.kotlin.collections.AbstractList, java.util.List
    public Enum get(int i) {
        AbstractList.Companion.checkElementIndex$kotlin_stdlib(i, this.entries.length);
        return this.entries[i];
    }

    public boolean contains(Enum element) {
        Intrinsics.checkNotNullParameter(element, "element");
        return ((Enum) ArraysKt.getOrNull(this.entries, element.ordinal())) == element;
    }

    public int indexOf(Enum element) {
        Intrinsics.checkNotNullParameter(element, "element");
        int iOrdinal = element.ordinal();
        if (((Enum) ArraysKt.getOrNull(this.entries, iOrdinal)) == element) {
            return iOrdinal;
        }
        return -1;
    }

    public int lastIndexOf(Enum element) {
        Intrinsics.checkNotNullParameter(element, "element");
        return indexOf(element);
    }
}
