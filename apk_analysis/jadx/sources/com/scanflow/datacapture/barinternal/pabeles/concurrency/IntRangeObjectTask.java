package com.scanflow.datacapture.barinternal.pabeles.concurrency;

import java.util.Objects;
import java.util.concurrent.ForkJoinTask;

/* JADX INFO: loaded from: classes4.dex */
public class IntRangeObjectTask extends ForkJoinTask {
    final IntRangeObjectConsumer consumer;
    final int max;
    final int min;
    IntRangeObjectTask next;
    final int step;
    final int stepLength;
    final GrowArray workspace;

    public IntRangeObjectTask(int i, int i2, int i3, int i4, GrowArray growArray, IntRangeObjectConsumer intRangeObjectConsumer) {
        this.step = i;
        this.min = i2;
        this.max = i3;
        this.stepLength = i4;
        this.consumer = intRangeObjectConsumer;
        this.workspace = growArray;
    }

    public IntRangeObjectTask(int i, int i2, int i3, GrowArray growArray, IntRangeObjectConsumer intRangeObjectConsumer) {
        this(-1, i, i2, i3, growArray, intRangeObjectConsumer);
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
        int i;
        int i2 = this.max;
        int i3 = this.min;
        int i4 = this.stepLength;
        int i5 = (i2 - i3) / i4;
        int i6 = this.step;
        if (i6 == -1) {
            this.workspace.resize(i5);
            IntRangeObjectTask intRangeObjectTask = null;
            int i7 = 0;
            IntRangeObjectTask intRangeObjectTask2 = null;
            while (true) {
                i = i5 - 1;
                if (i7 >= i) {
                    break;
                }
                IntRangeObjectTask intRangeObjectTask3 = new IntRangeObjectTask(i7, this.min, this.max, this.stepLength, this.workspace, this.consumer);
                if (intRangeObjectTask == null) {
                    intRangeObjectTask = intRangeObjectTask3;
                } else {
                    Objects.requireNonNull(intRangeObjectTask2);
                    intRangeObjectTask2.next = intRangeObjectTask3;
                }
                intRangeObjectTask3.fork();
                i7++;
                intRangeObjectTask2 = intRangeObjectTask3;
            }
            this.consumer.accept(this.workspace.get(i), (i7 * this.stepLength) + this.min, this.max);
            while (intRangeObjectTask != null) {
                intRangeObjectTask.join();
                intRangeObjectTask = intRangeObjectTask.next;
            }
        } else {
            int i8 = (i6 * i4) + i3;
            this.consumer.accept(this.workspace.get(i6), i8, i4 + i8);
        }
        return true;
    }
}
