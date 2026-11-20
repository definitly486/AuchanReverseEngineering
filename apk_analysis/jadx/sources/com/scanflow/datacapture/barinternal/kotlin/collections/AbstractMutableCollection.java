package com.scanflow.datacapture.barinternal.kotlin.collections;

import java.util.Collection;
import kotlin.jvm.internal.markers.KMappedMarker;

/* JADX INFO: compiled from: AbstractMutableCollection.kt */
/* JADX INFO: loaded from: classes3.dex */
public abstract class AbstractMutableCollection extends java.util.AbstractCollection implements Collection, KMappedMarker {
    public abstract int getSize();

    protected AbstractMutableCollection() {
    }

    @Override // java.util.AbstractCollection, java.util.Collection
    public final /* bridge */ int size() {
        return getSize();
    }
}
