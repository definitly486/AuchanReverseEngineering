package com.google.common.collect;

import com.google.common.annotations.GwtCompatible;
import com.google.common.annotations.GwtIncompatible;
import com.google.common.annotations.J2ktIncompatible;

/* JADX INFO: loaded from: classes2.dex */
@GwtCompatible
@Deprecated
public class ComputationException extends RuntimeException {

    @J2ktIncompatible
    @GwtIncompatible
    private static final long serialVersionUID = 0;

    public ComputationException(Throwable th) {
        super(th);
    }
}
