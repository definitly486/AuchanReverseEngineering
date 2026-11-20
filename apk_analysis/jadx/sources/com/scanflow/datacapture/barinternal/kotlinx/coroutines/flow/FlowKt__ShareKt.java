package com.scanflow.datacapture.barinternal.kotlinx.coroutines.flow;

import kotlinx.coroutines.flow.StateFlow;

/* JADX INFO: compiled from: Share.kt */
/* JADX INFO: loaded from: classes3.dex */
abstract /* synthetic */ class FlowKt__ShareKt {
    public static final StateFlow asStateFlow(MutableStateFlow mutableStateFlow) {
        return new ReadonlyStateFlow(mutableStateFlow, null);
    }
}
