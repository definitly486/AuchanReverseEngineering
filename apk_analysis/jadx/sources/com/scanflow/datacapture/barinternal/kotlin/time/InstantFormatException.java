package com.scanflow.datacapture.barinternal.kotlin.time;

import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: Instant.kt */
/* JADX INFO: loaded from: classes3.dex */
final class InstantFormatException extends IllegalArgumentException {
    /* JADX WARN: 'super' call moved to the top of the method (can break code semantics) */
    public InstantFormatException(String message) {
        super(message);
        Intrinsics.checkNotNullParameter(message, "message");
    }
}
