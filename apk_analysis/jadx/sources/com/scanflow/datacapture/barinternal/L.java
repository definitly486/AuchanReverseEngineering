package com.scanflow.datacapture.barinternal;

import android.util.Log;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.CoroutineExceptionHandler;
import kotlin.coroutines.AbstractCoroutineContextElement;
import kotlin.coroutines.CoroutineContext;

/* JADX INFO: loaded from: classes3.dex */
public final class L extends AbstractCoroutineContextElement implements CoroutineExceptionHandler {
    public L(CoroutineExceptionHandler.Key key) {
        super(key);
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.CoroutineExceptionHandler
    public final void handleException(CoroutineContext coroutineContext, Throwable th) {
        String message = th.getMessage();
        if (message != null) {
            Log.d("Error", message);
        }
    }
}
