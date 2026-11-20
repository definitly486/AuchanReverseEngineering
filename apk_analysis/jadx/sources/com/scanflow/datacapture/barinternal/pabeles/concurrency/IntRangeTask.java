package com.scanflow.datacapture.barinternal.pabeles.concurrency;

import java.util.Objects;
import java.util.concurrent.ForkJoinTask;

/* JADX INFO: loaded from: classes4.dex */
public class IntRangeTask extends ForkJoinTask {
    final IntRangeConsumer consumer;
    final int max;
    final int min;
    IntRangeTask next;
    final int step;
    final int stepLength;

    public IntRangeTask(int i, int i2, int i3, int i4, IntRangeConsumer intRangeConsumer) {
        this.step = i;
        this.min = i2;
        this.max = i3;
        this.stepLength = i4;
        this.consumer = intRangeConsumer;
    }

    public IntRangeTask(int i, int i2, int i3, IntRangeConsumer intRangeConsumer) {
        this(-1, i, i2, i3, intRangeConsumer);
    }

    @Override // java.util.concurrent.ForkJoinTask
    public Void getRawResult() {
        return null;
    }

    /* JADX INFO: Access modifiers changed from: protected */
    @Override // java.util.concurrent.ForkJoinTask
    public void setRawResult(Void r1) {
    }

    @Override // java.util.concurrent.ForkJoinTask
    protected boolean exec() {
        int i = this.max;
        int i2 = this.min;
        int i3 = this.stepLength;
        int i4 = (i - i2) / i3;
        int i5 = this.step;
        if (i5 == -1) {
            IntRangeTask intRangeTask = null;
            int i6 = 0;
            IntRangeTask intRangeTask2 = null;
            while (i6 < i4 - 1) {
                IntRangeTask intRangeTask3 = new IntRangeTask(i6, this.min, this.max, this.stepLength, this.consumer);
                if (intRangeTask == null) {
                    intRangeTask = intRangeTask3;
                } else {
                    Objects.requireNonNull(intRangeTask2);
                    intRangeTask2.next = intRangeTask3;
                }
                intRangeTask3.fork();
                i6++;
                intRangeTask2 = intRangeTask3;
            }
            this.consumer.accept((i6 * this.stepLength) + this.min, this.max);
            while (intRangeTask != null) {
                intRangeTask.join();
                intRangeTask = intRangeTask.next;
            }
        } else {
            int i7 = (i5 * i3) + i2;
            this.consumer.accept(i7, i3 + i7);
        }
        return true;
    }
}
