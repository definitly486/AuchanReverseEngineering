package com.scanflow.datacapture.barinternal.kotlinx.coroutines;

/* JADX INFO: compiled from: JobSupport.kt */
/* JADX INFO: loaded from: classes3.dex */
final class InactiveNodeList implements Incomplete {
    private final NodeList list;

    public InactiveNodeList(NodeList nodeList) {
        this.list = nodeList;
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.Incomplete
    public NodeList getList() {
        return this.list;
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.Incomplete
    public boolean isActive() {
        return false;
    }

    public String toString() {
        return super.toString();
    }
}
