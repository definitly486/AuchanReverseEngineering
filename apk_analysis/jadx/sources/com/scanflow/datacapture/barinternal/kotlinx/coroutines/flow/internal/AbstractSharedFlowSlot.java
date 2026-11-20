package com.scanflow.datacapture.barinternal.kotlinx.coroutines.flow.internal;

import kotlin.coroutines.Continuation;

/* JADX INFO: compiled from: AbstractSharedFlow.kt */
/* JADX INFO: loaded from: classes3.dex */
public abstract class AbstractSharedFlowSlot {
    public abstract boolean allocateLocked(Object obj);

    public abstract Continuation[] freeLocked(Object obj);
}
