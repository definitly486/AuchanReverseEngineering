package com.scanflow.datacapture.barinternal.kotlinx.coroutines.flow;

import com.scanflow.datacapture.barinternal.kotlin.collections.ArraysKt;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.flow.internal.ChannelLimitedFlowMerge;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.internal.SystemPropsKt;
import kotlinx.coroutines.flow.Flow;

/* JADX INFO: compiled from: Merge.kt */
/* JADX INFO: loaded from: classes3.dex */
abstract /* synthetic */ class FlowKt__MergeKt {
    private static final int DEFAULT_CONCURRENCY = SystemPropsKt.systemProp("kotlinx.coroutines.flow.defaultConcurrency", 16, 1, Integer.MAX_VALUE);

    public static final Flow merge(Iterable iterable) {
        return new ChannelLimitedFlowMerge(iterable, null, 0, null, 14, null);
    }

    public static final Flow merge(Flow... flowArr) {
        return FlowKt.merge(ArraysKt.asIterable(flowArr));
    }
}
