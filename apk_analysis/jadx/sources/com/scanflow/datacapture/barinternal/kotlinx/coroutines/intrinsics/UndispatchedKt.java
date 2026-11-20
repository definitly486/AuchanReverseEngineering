package com.scanflow.datacapture.barinternal.kotlinx.coroutines.intrinsics;

import com.scanflow.datacapture.barinternal.kotlin.KotlinNothingValueException;
import com.scanflow.datacapture.barinternal.kotlin.Result;
import com.scanflow.datacapture.barinternal.kotlin.ResultKt;
import com.scanflow.datacapture.barinternal.kotlin.coroutines.intrinsics.IntrinsicsKt;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.CompletedExceptionally;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.DispatchException;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.JobSupportKt;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.TimeoutCancellationException;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.internal.ScopeCoroutine;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.internal.ThreadContextKt;
import kotlin.coroutines.Continuation;
import kotlin.coroutines.CoroutineContext;
import kotlin.coroutines.jvm.internal.BaseContinuationImpl;
import kotlin.coroutines.jvm.internal.DebugProbesKt;
import kotlin.jvm.functions.Function2;
import kotlin.jvm.internal.TypeIntrinsics;

/* JADX INFO: compiled from: Undispatched.kt */
/* JADX INFO: loaded from: classes3.dex */
public abstract class UndispatchedKt {
    public static final Object startUndispatchedOrReturn(ScopeCoroutine scopeCoroutine, Object obj, Function2 function2) {
        return startUndspatched(scopeCoroutine, true, obj, function2);
    }

    public static final Object startUndispatchedOrReturnIgnoreTimeout(ScopeCoroutine scopeCoroutine, Object obj, Function2 function2) {
        return startUndspatched(scopeCoroutine, false, obj, function2);
    }

    private static final Object startUndspatched(ScopeCoroutine scopeCoroutine, boolean z, Object obj, Function2 function2) throws Throwable {
        Object completedExceptionally;
        Object objMakeCompletingOnce$kotlinx_coroutines_core;
        try {
            completedExceptionally = !(function2 instanceof BaseContinuationImpl) ? IntrinsicsKt.wrapWithContinuationImpl(function2, obj, scopeCoroutine) : ((Function2) TypeIntrinsics.beforeCheckcastToFunctionOfArity(function2, 2)).invoke(obj, scopeCoroutine);
        } catch (DispatchException e) {
            dispatchExceptionAndMakeCompleting(scopeCoroutine, e);
            throw new KotlinNothingValueException();
        } catch (Throwable th) {
            completedExceptionally = new CompletedExceptionally(th, false, 2, null);
        }
        if (completedExceptionally != IntrinsicsKt.getCOROUTINE_SUSPENDED() && (objMakeCompletingOnce$kotlinx_coroutines_core = scopeCoroutine.makeCompletingOnce$kotlinx_coroutines_core(completedExceptionally)) != JobSupportKt.COMPLETING_WAITING_CHILDREN) {
            scopeCoroutine.afterCompletionUndispatched();
            if (objMakeCompletingOnce$kotlinx_coroutines_core instanceof CompletedExceptionally) {
                if (!z && !notOwnTimeout(scopeCoroutine, ((CompletedExceptionally) objMakeCompletingOnce$kotlinx_coroutines_core).cause)) {
                    if (completedExceptionally instanceof CompletedExceptionally) {
                        throw ((CompletedExceptionally) completedExceptionally).cause;
                    }
                    return completedExceptionally;
                }
                throw ((CompletedExceptionally) objMakeCompletingOnce$kotlinx_coroutines_core).cause;
            }
            return JobSupportKt.unboxState(objMakeCompletingOnce$kotlinx_coroutines_core);
        }
        return IntrinsicsKt.getCOROUTINE_SUSPENDED();
    }

    private static final boolean notOwnTimeout(ScopeCoroutine scopeCoroutine, Throwable th) {
        return ((th instanceof TimeoutCancellationException) && ((TimeoutCancellationException) th).coroutine == scopeCoroutine) ? false : true;
    }

    private static final Void dispatchExceptionAndMakeCompleting(ScopeCoroutine scopeCoroutine, DispatchException dispatchException) throws Throwable {
        scopeCoroutine.makeCompleting$kotlinx_coroutines_core(new CompletedExceptionally(dispatchException.getCause(), false, 2, null));
        throw dispatchException.getCause();
    }

    public static final void startCoroutineUndispatched(Function2 function2, Object obj, Continuation continuation) {
        Continuation continuationProbeCoroutineCreated = DebugProbesKt.probeCoroutineCreated(continuation);
        try {
            CoroutineContext context = continuationProbeCoroutineCreated.getContext();
            Object objUpdateThreadContext = ThreadContextKt.updateThreadContext(context, null);
            try {
                DebugProbesKt.probeCoroutineResumed(continuationProbeCoroutineCreated);
                Object objWrapWithContinuationImpl = !(function2 instanceof BaseContinuationImpl) ? IntrinsicsKt.wrapWithContinuationImpl(function2, obj, continuationProbeCoroutineCreated) : ((Function2) TypeIntrinsics.beforeCheckcastToFunctionOfArity(function2, 2)).invoke(obj, continuationProbeCoroutineCreated);
                ThreadContextKt.restoreThreadContext(context, objUpdateThreadContext);
                if (objWrapWithContinuationImpl != IntrinsicsKt.getCOROUTINE_SUSPENDED()) {
                    continuationProbeCoroutineCreated.resumeWith(Result.m681constructorimpl(objWrapWithContinuationImpl));
                }
            } catch (Throwable th) {
                ThreadContextKt.restoreThreadContext(context, objUpdateThreadContext);
                throw th;
            }
        } catch (Throwable th2) {
            th = th2;
            if (th instanceof DispatchException) {
                th = ((DispatchException) th).getCause();
            }
            Result.Companion companion = Result.Companion;
            continuationProbeCoroutineCreated.resumeWith(Result.m681constructorimpl(ResultKt.createFailure(th)));
        }
    }
}
