package com.scanflow.datacapture.barinternal.kotlinx.coroutines.internal;

/* JADX INFO: compiled from: LockFreeLinkedList.kt */
/* JADX INFO: loaded from: classes3.dex */
final class ListClosed extends LockFreeLinkedListNode {
    public final int forbiddenElementsBitmask;

    public ListClosed(int i) {
        this.forbiddenElementsBitmask = i;
    }
}
