package com.scanflow.datacapture.barinternal.kotlin.collections;

import com.scanflow.datacapture.barinternal.kotlin.jvm.internal.markers.KMutableList;
import java.util.List;

/* JADX INFO: compiled from: AbstractMutableList.kt */
/* JADX INFO: loaded from: classes3.dex */
public abstract class AbstractMutableList extends java.util.AbstractList implements List, KMutableList {
    public abstract int getSize();

    public abstract Object removeAt(int i);

    protected AbstractMutableList() {
    }

    @Override // java.util.AbstractList, java.util.List
    public final /* bridge */ Object remove(int i) {
        return removeAt(i);
    }

    @Override // java.util.AbstractCollection, java.util.Collection, java.util.List
    public final /* bridge */ int size() {
        return getSize();
    }
}
