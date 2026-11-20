package com.scanflow.datacapture.barinternal.kotlinx.coroutines;

import com.scanflow.datacapture.barinternal.kotlin.Unit;
import com.scanflow.datacapture.barinternal.kotlin.coroutines.intrinsics.IntrinsicsKt;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.internal.DispatchedContinuation;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.internal.DispatchedContinuationKt;
import kotlin.coroutines.Continuation;
import kotlin.coroutines.CoroutineContext;
import kotlin.coroutines.jvm.internal.DebugProbesKt;

/* JADX INFO: compiled from: Yield.kt */
/* JADX INFO: loaded from: classes3.dex */
public abstract class YieldKt {
    public static final Object yield(Continuation continuation) {
        Object coroutine_suspended;
        CoroutineContext context = continuation.getContext();
        JobKt.ensureActive(context);
        Continuation continuationIntercepted = IntrinsicsKt.intercepted(continuation);
        DispatchedContinuation dispatchedContinuation = continuationIntercepted instanceof DispatchedContinuation ? (DispatchedContinuation) continuationIntercepted : null;
        if (dispatchedContinuation == null) {
            coroutine_suspended = Unit.INSTANCE;
        } else {
            if (DispatchedContinuationKt.safeIsDispatchNeeded(dispatchedContinuation.dispatcher, context)) {
                dispatchedContinuation.dispatchYield$kotlinx_coroutines_core(context, Unit.INSTANCE);
            } else {
                YieldContext yieldContext = new YieldContext();
                CoroutineContext coroutineContextPlus = context.plus(yieldContext);
                Unit unit = Unit.INSTANCE;
                dispatchedContinuation.dispatchYield$kotlinx_coroutines_core(coroutineContextPlus, unit);
                coroutine_suspended = (!yieldContext.dispatcherWasUnconfined || DispatchedContinuationKt.yieldUndispatched(dispatchedContinuation)) ? IntrinsicsKt.getCOROUTINE_SUSPENDED() : unit;
            }
            coroutine_suspended = IntrinsicsKt.getCOROUTINE_SUSPENDED();
        }
        if (coroutine_suspended == IntrinsicsKt.getCOROUTINE_SUSPENDED()) {
            DebugProbesKt.probeCoroutineSuspended(continuation);
        }
        return coroutine_suspended == IntrinsicsKt.getCOROUTINE_SUSPENDED() ? coroutine_suspended : Unit.INSTANCE;
    }
}
