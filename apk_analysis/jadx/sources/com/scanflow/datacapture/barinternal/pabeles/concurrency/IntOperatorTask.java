package com.scanflow.datacapture.barinternal.pabeles.concurrency;

import java.util.Objects;
import java.util.concurrent.ForkJoinTask;

/* JADX INFO: loaded from: classes4.dex */
public abstract class IntOperatorTask extends ForkJoinTask {
    final IntProducerNumber consumer;
    final int max;
    Class primitiveType;
    Number result;
    final int value;
    boolean master = true;
    IntOperatorTask next = null;

    protected abstract IntOperatorTask newInstance(int i, int i2, Class cls, IntProducerNumber intProducerNumber);

    protected abstract void operator(Number number);

    protected IntOperatorTask(int i, int i2, Class cls, IntProducerNumber intProducerNumber) {
        this.value = i;
        this.max = i2;
        this.primitiveType = cls;
        this.consumer = intProducerNumber;
    }

    @Override // java.util.concurrent.ForkJoinTask
    public Number getRawResult() {
        return this.result;
    }

    protected void setRawResult(Number number) {
        this.result = number;
    }

    @Override // java.util.concurrent.ForkJoinTask
    protected boolean exec() {
        IntOperatorTask intOperatorTask;
        if (this.master) {
            int i = this.value;
            intOperatorTask = null;
            IntOperatorTask intOperatorTask2 = null;
            while (true) {
                int i2 = i + 1;
                int i3 = this.max;
                if (i2 >= i3) {
                    break;
                }
                IntOperatorTask intOperatorTaskNewInstance = newInstance(i, i3, this.primitiveType, this.consumer);
                intOperatorTaskNewInstance.master = false;
                if (intOperatorTask == null) {
                    intOperatorTask = intOperatorTaskNewInstance;
                } else {
                    Objects.requireNonNull(intOperatorTask2);
                    intOperatorTask2.next = intOperatorTaskNewInstance;
                }
                intOperatorTaskNewInstance.fork();
                intOperatorTask2 = intOperatorTaskNewInstance;
                i = i2;
            }
            this.result = this.consumer.accept(i);
        } else {
            this.result = this.consumer.accept(this.value);
            intOperatorTask = null;
        }
        while (intOperatorTask != null) {
            intOperatorTask.join();
            operator(intOperatorTask.result);
            IntOperatorTask intOperatorTask3 = intOperatorTask.next;
            intOperatorTask.next = null;
            intOperatorTask = intOperatorTask3;
        }
        return true;
    }

    public static class Max extends IntOperatorTask {
        @Override // java.util.concurrent.ForkJoinTask
        public /* bridge */ /* synthetic */ Object getRawResult() {
            return super.getRawResult();
        }

        @Override // java.util.concurrent.ForkJoinTask
        protected /* bridge */ /* synthetic */ void setRawResult(Object obj) {
            super.setRawResult((Number) obj);
        }

        public Max(int i, int i2, Class cls, IntProducerNumber intProducerNumber) {
            super(i, i2, cls, intProducerNumber);
        }

        @Override // com.scanflow.datacapture.barinternal.pabeles.concurrency.IntOperatorTask
        protected IntOperatorTask newInstance(int i, int i2, Class cls, IntProducerNumber intProducerNumber) {
            return new Max(i, i2, cls, intProducerNumber);
        }

        @Override // com.scanflow.datacapture.barinternal.pabeles.concurrency.IntOperatorTask
        protected void operator(Number number) {
            Class cls = this.primitiveType;
            if (cls == Byte.TYPE) {
                this.result = Integer.valueOf(Math.max((int) this.result.byteValue(), (int) number.byteValue()));
                return;
            }
            if (cls == Short.TYPE) {
                this.result = Integer.valueOf(Math.max((int) this.result.shortValue(), (int) number.shortValue()));
                return;
            }
            if (cls == Integer.TYPE) {
                this.result = Integer.valueOf(Math.max(this.result.intValue(), number.intValue()));
                return;
            }
            if (cls == Long.TYPE) {
                this.result = Long.valueOf(Math.max(this.result.longValue(), number.longValue()));
                return;
            }
            if (cls == Float.TYPE) {
                this.result = Float.valueOf(Math.max(this.result.floatValue(), number.floatValue()));
                return;
            }
            if (cls == Double.TYPE) {
                this.result = Double.valueOf(Math.max(this.result.doubleValue(), number.doubleValue()));
                return;
            }
            throw new RuntimeException("Unknown primitive type " + this.primitiveType);
        }
    }

    public static class Min extends IntOperatorTask {
        @Override // java.util.concurrent.ForkJoinTask
        public /* bridge */ /* synthetic */ Object getRawResult() {
            return super.getRawResult();
        }

        @Override // java.util.concurrent.ForkJoinTask
        protected /* bridge */ /* synthetic */ void setRawResult(Object obj) {
            super.setRawResult((Number) obj);
        }

        public Min(int i, int i2, Class cls, IntProducerNumber intProducerNumber) {
            super(i, i2, cls, intProducerNumber);
        }

        @Override // com.scanflow.datacapture.barinternal.pabeles.concurrency.IntOperatorTask
        protected IntOperatorTask newInstance(int i, int i2, Class cls, IntProducerNumber intProducerNumber) {
            return new Min(i, i2, cls, intProducerNumber);
        }

        @Override // com.scanflow.datacapture.barinternal.pabeles.concurrency.IntOperatorTask
        protected void operator(Number number) {
            Class cls = this.primitiveType;
            if (cls == Byte.TYPE) {
                this.result = Integer.valueOf(Math.min((int) this.result.byteValue(), (int) number.byteValue()));
                return;
            }
            if (cls == Short.TYPE) {
                this.result = Integer.valueOf(Math.min((int) this.result.shortValue(), (int) number.shortValue()));
                return;
            }
            if (cls == Integer.TYPE) {
                this.result = Integer.valueOf(Math.min(this.result.intValue(), number.intValue()));
                return;
            }
            if (cls == Long.TYPE) {
                this.result = Long.valueOf(Math.min(this.result.longValue(), number.longValue()));
                return;
            }
            if (cls == Float.TYPE) {
                this.result = Float.valueOf(Math.min(this.result.floatValue(), number.floatValue()));
                return;
            }
            if (cls == Double.TYPE) {
                this.result = Double.valueOf(Math.min(this.result.doubleValue(), number.doubleValue()));
                return;
            }
            throw new RuntimeException("Unknown primitive type " + this.primitiveType);
        }
    }
}
