package com.scanflow.datacapture.barinternal.androidx.core.os;

import com.scanflow.datacapture.barinternal.androidx.core.util.ObjectsCompat;

/* JADX INFO: loaded from: classes.dex */
public class OperationCanceledException extends RuntimeException {
    public OperationCanceledException() {
        this(null);
    }

    public OperationCanceledException(String str) {
        super(ObjectsCompat.toString(str, "The operation has been canceled."));
    }
}
