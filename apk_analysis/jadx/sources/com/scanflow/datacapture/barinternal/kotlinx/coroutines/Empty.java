package com.scanflow.datacapture.barinternal.kotlinx.coroutines;

/* JADX INFO: compiled from: JobSupport.kt */
/* JADX INFO: loaded from: classes3.dex */
final class Empty implements Incomplete {
    private final boolean isActive;

    public Empty(boolean z) {
        this.isActive = z;
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.Incomplete
    public boolean isActive() {
        return this.isActive;
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.Incomplete
    public NodeList getList() {
        return null;
    }

    public String toString() {
        StringBuilder sb = new StringBuilder();
        sb.append("Empty{");
        sb.append(isActive() ? "Active" : "New");
        sb.append('}');
        return sb.toString();
    }
}
