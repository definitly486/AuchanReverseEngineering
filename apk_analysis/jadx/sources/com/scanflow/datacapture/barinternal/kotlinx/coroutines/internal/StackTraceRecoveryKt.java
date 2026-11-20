package com.scanflow.datacapture.barinternal.kotlinx.coroutines.internal;

import com.scanflow.datacapture.barinternal._COROUTINE.ArtificialStackFrames;
import com.scanflow.datacapture.barinternal.kotlin.Result;
import com.scanflow.datacapture.barinternal.kotlin.ResultKt;
import kotlin.coroutines.jvm.internal.BaseContinuationImpl;

/* JADX INFO: compiled from: StackTraceRecovery.kt */
/* JADX INFO: loaded from: classes3.dex */
public abstract class StackTraceRecoveryKt {
    private static final StackTraceElement ARTIFICIAL_FRAME = new ArtificialStackFrames().coroutineBoundary();
    private static final String baseContinuationImplClassName;
    private static final String stackTraceRecoveryClassName;

    static {
        Object objM681constructorimpl;
        Object objM681constructorimpl2;
        try {
            Result.Companion companion = Result.Companion;
            objM681constructorimpl = Result.m681constructorimpl(BaseContinuationImpl.class.getCanonicalName());
        } catch (Throwable th) {
            Result.Companion companion2 = Result.Companion;
            objM681constructorimpl = Result.m681constructorimpl(ResultKt.createFailure(th));
        }
        if (Result.m683exceptionOrNullimpl(objM681constructorimpl) != null) {
            objM681constructorimpl = "kotlin.coroutines.jvm.internal.BaseContinuationImpl";
        }
        baseContinuationImplClassName = (String) objM681constructorimpl;
        try {
            objM681constructorimpl2 = Result.m681constructorimpl(StackTraceRecoveryKt.class.getCanonicalName());
        } catch (Throwable th2) {
            Result.Companion companion3 = Result.Companion;
            objM681constructorimpl2 = Result.m681constructorimpl(ResultKt.createFailure(th2));
        }
        if (Result.m683exceptionOrNullimpl(objM681constructorimpl2) != null) {
            objM681constructorimpl2 = "kotlinx.coroutines.internal.StackTraceRecoveryKt";
        }
        stackTraceRecoveryClassName = (String) objM681constructorimpl2;
    }

    public static final Throwable recoverStackTrace(Throwable th) {
        return th;
    }
}
