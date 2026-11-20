package com.scanflow.datacapture.barinternal.kotlinx.coroutines.flow;

import kotlinx.coroutines.flow.StateFlow;

/* JADX INFO: compiled from: StateFlow.kt */
/* JADX INFO: loaded from: classes3.dex */
public interface MutableStateFlow extends StateFlow, MutableSharedFlow {
    boolean compareAndSet(Object obj, Object obj2);

    @Override // kotlinx.coroutines.flow.StateFlow
    Object getValue();

    void setValue(Object obj);
}
