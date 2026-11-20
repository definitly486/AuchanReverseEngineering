package com.scanflow.datacapture.barinternal.kotlinx.coroutines;

import kotlin.jvm.functions.Function1;

/* JADX INFO: compiled from: CancellableContinuationImpl.kt */
/* JADX INFO: loaded from: classes3.dex */
public interface CancelHandler extends NotCompleted {
    void invoke(Throwable th);

    /* JADX INFO: compiled from: CancellableContinuationImpl.kt */
    public static final class UserSupplied implements CancelHandler {
        private final Function1 handler;

        public UserSupplied(Function1 function1) {
            this.handler = function1;
        }

        @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.CancelHandler
        public void invoke(Throwable th) {
            this.handler.invoke(th);
        }

        public String toString() {
            return "CancelHandler.UserSupplied[" + DebugStringsKt.getClassSimpleName(this.handler) + '@' + DebugStringsKt.getHexAddress(this) + ']';
        }
    }
}
