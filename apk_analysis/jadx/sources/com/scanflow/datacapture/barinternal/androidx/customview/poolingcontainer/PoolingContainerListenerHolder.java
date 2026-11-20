package com.scanflow.datacapture.barinternal.androidx.customview.poolingcontainer;

import com.scanflow.datacapture.barinternal.a.a$$ExternalSyntheticThrowCCEIfNotNull0;
import com.scanflow.datacapture.barinternal.kotlin.collections.CollectionsKt;
import java.util.ArrayList;

/* JADX INFO: compiled from: PoolingContainer.kt */
/* JADX INFO: loaded from: classes.dex */
final class PoolingContainerListenerHolder {
    private final ArrayList listeners = new ArrayList();

    public final void onRelease() {
        int lastIndex = CollectionsKt.getLastIndex(this.listeners);
        if (-1 >= lastIndex) {
            return;
        }
        a$$ExternalSyntheticThrowCCEIfNotNull0.m(this.listeners.get(lastIndex));
        throw null;
    }
}
