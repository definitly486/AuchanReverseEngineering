package com.scanflow.datacapture.barinternal.boofcv.concurrency;

import com.scanflow.datacapture.barinternal.pabeles.concurrency.ConcurrencyOps;

/* JADX INFO: loaded from: classes.dex */
public abstract class BoofConcurrency extends ConcurrencyOps {
    public static int SMALL_IMAGE = 10000;
    public static boolean USE_CONCURRENT = true;

    public static boolean isUseConcurrent() {
        return USE_CONCURRENT;
    }
}
