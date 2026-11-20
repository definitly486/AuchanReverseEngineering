package com.scanflow.datacapture.barinternal.kotlinx.coroutines.flow;

import kotlin.jvm.functions.Function2;
import kotlinx.coroutines.flow.Flow;

/* JADX INFO: compiled from: Builders.kt */
/* JADX INFO: loaded from: classes3.dex */
abstract /* synthetic */ class FlowKt__BuildersKt {
    public static final Flow flow(Function2 function2) {
        return new SafeFlow(function2);
    }

    public static final Flow callbackFlow(Function2 function2) {
        return new CallbackFlowBuilder(function2, null, 0, null, 14, null);
    }
}
