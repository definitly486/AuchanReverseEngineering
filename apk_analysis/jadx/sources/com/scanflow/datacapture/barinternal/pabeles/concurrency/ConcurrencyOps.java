package com.scanflow.datacapture.barinternal.pabeles.concurrency;

import java.util.concurrent.ExecutionException;
import java.util.concurrent.ForkJoinPool;
import java.util.function.IntConsumer;
import java.util.stream.IntStream;

/* JADX INFO: loaded from: classes4.dex */
public abstract class ConcurrencyOps {
    private static ForkJoinPool pool = new ForkJoinPool();

    public interface NewInstance {
        Object newInstance();
    }

    public interface Reset {
        void reset(Object obj);
    }

    public static void loopFor(final int i, final int i2, final IntConsumer intConsumer) {
        try {
            pool.submit(new Runnable() { // from class: com.scanflow.datacapture.barinternal.pabeles.concurrency.ConcurrencyOps$$ExternalSyntheticLambda0
                @Override // java.lang.Runnable
                public final void run() {
                    IntStream.range(i, i2).parallel().forEach(intConsumer);
                }
            }).get();
        } catch (InterruptedException | ExecutionException e) {
            e.printStackTrace();
        }
    }

    static int selectBlockSize(int i, int i2, int i3) {
        return i / Math.max(1, i / Math.max(i2, i / i3));
    }

    public static void loopBlocks(int i, int i2, IntRangeConsumer intRangeConsumer) {
        ForkJoinPool forkJoinPool = pool;
        int parallelism = forkJoinPool.getParallelism();
        int i3 = i2 - i;
        if (i3 == 0) {
            return;
        }
        if (i3 < 0) {
            throw new IllegalArgumentException("end must be more than start. " + i + " -> " + i2);
        }
        try {
            forkJoinPool.submit(new IntRangeTask(i, i2, Math.max(1, i3 / parallelism), intRangeConsumer)).get();
        } catch (InterruptedException | ExecutionException e) {
            throw new RuntimeException(e);
        }
    }

    public static void loopBlocks(int i, int i2, GrowArray growArray, IntRangeObjectConsumer intRangeObjectConsumer) {
        ForkJoinPool forkJoinPool = pool;
        int parallelism = forkJoinPool.getParallelism();
        int i3 = i2 - i;
        if (i3 == 0) {
            return;
        }
        if (i3 < 0) {
            throw new IllegalArgumentException("end must be more than start. " + i + " -> " + i2);
        }
        runLoopBlocks(i, i2, growArray, intRangeObjectConsumer, forkJoinPool, Math.max(1, i3 / parallelism));
    }

    public static void loopBlocks(int i, int i2, int i3, GrowArray growArray, IntRangeObjectConsumer intRangeObjectConsumer) {
        ForkJoinPool forkJoinPool = pool;
        int parallelism = forkJoinPool.getParallelism();
        int i4 = i2 - i;
        if (i4 == 0) {
            return;
        }
        if (i4 < 0) {
            throw new IllegalArgumentException("end must be more than start. " + i + " -> " + i2);
        }
        runLoopBlocks(i, i2, growArray, intRangeObjectConsumer, forkJoinPool, selectBlockSize(i4, i3, parallelism));
    }

    private static void runLoopBlocks(int i, int i2, GrowArray growArray, IntRangeObjectConsumer intRangeObjectConsumer, ForkJoinPool forkJoinPool, int i3) {
        growArray.reset();
        try {
            forkJoinPool.submit(new IntRangeObjectTask(i, i2, i3, growArray, intRangeObjectConsumer)).get();
        } catch (InterruptedException | ExecutionException e) {
            throw new RuntimeException(e);
        }
    }

    public static Number max(int i, int i2, Class cls, IntProducerNumber intProducerNumber) {
        try {
            return (Number) pool.submit(new IntOperatorTask.Max(i, i2, cls, intProducerNumber)).get();
        } catch (InterruptedException | ExecutionException e) {
            throw new RuntimeException(e);
        }
    }

    public static Number min(int i, int i2, Class cls, IntProducerNumber intProducerNumber) {
        try {
            return (Number) pool.submit(new IntOperatorTask.Min(i, i2, cls, intProducerNumber)).get();
        } catch (InterruptedException | ExecutionException e) {
            throw new RuntimeException(e);
        }
    }
}
