package com.scanflow.datacapture.barinternal.kotlin.random;

/* JADX INFO: compiled from: PlatformRandom.kt */
/* JADX INFO: loaded from: classes3.dex */
public abstract class AbstractPlatformRandom extends Random {
    public abstract java.util.Random getImpl();

    @Override // com.scanflow.datacapture.barinternal.kotlin.random.Random
    public int nextInt(int i) {
        return getImpl().nextInt(i);
    }
}
