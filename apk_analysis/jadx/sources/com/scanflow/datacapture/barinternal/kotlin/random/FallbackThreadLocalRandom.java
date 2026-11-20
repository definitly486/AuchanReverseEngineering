package com.scanflow.datacapture.barinternal.kotlin.random;

import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: PlatformRandom.kt */
/* JADX INFO: loaded from: classes3.dex */
public final class FallbackThreadLocalRandom extends AbstractPlatformRandom {
    private final FallbackThreadLocalRandom$implStorage$1 implStorage = new ThreadLocal() { // from class: com.scanflow.datacapture.barinternal.kotlin.random.FallbackThreadLocalRandom$implStorage$1
        /* JADX INFO: Access modifiers changed from: protected */
        @Override // java.lang.ThreadLocal
        public java.util.Random initialValue() {
            return new java.util.Random();
        }
    };

    @Override // com.scanflow.datacapture.barinternal.kotlin.random.AbstractPlatformRandom
    public java.util.Random getImpl() {
        Object obj = get();
        Intrinsics.checkNotNullExpressionValue(obj, "get(...)");
        return (java.util.Random) obj;
    }
}
