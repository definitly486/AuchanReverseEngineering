package com.scanflow.datacapture.barinternal.kotlinx.coroutines;

import com.scanflow.datacapture.barinternal.kotlinx.coroutines.internal.LockFreeLinkedListHead;

/* JADX INFO: compiled from: JobSupport.kt */
/* JADX INFO: loaded from: classes3.dex */
public final class NodeList extends LockFreeLinkedListHead implements Incomplete {
    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.Incomplete
    public boolean isActive() {
        return true;
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.Incomplete
    public NodeList getList() {
        return this;
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.internal.LockFreeLinkedListNode
    public String toString() {
        return super.toString();
    }
}
