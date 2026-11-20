package com.scanflow.datacapture.barinternal.kotlin.random.jdk8;

import com.scanflow.datacapture.barinternal.kotlin.random.AbstractPlatformRandom;
import java.util.Random;
import java.util.concurrent.ThreadLocalRandom;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: PlatformThreadLocalRandom.kt */
/* JADX INFO: loaded from: classes3.dex */
public final class PlatformThreadLocalRandom extends AbstractPlatformRandom {
    @Override // com.scanflow.datacapture.barinternal.kotlin.random.AbstractPlatformRandom
    public Random getImpl() {
        ThreadLocalRandom threadLocalRandomCurrent = ThreadLocalRandom.current();
        Intrinsics.checkNotNullExpressionValue(threadLocalRandomCurrent, "current(...)");
        return threadLocalRandomCurrent;
    }
}
