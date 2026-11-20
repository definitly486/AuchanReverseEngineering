package com.scanflow.datacapture.barinternal.pabeles.concurrency;

import java.lang.reflect.Array;

/* JADX INFO: loaded from: classes4.dex */
public class GrowArray {
    Object[] array;
    Class elementType;
    ConcurrencyOps.NewInstance factory;
    ConcurrencyOps.Reset reset;
    int size;

    public static /* synthetic */ void $r8$lambda$FLfXhh3lXI40rx0huoJhu6Ic5VM(Object obj) {
    }

    public GrowArray(ConcurrencyOps.NewInstance newInstance) {
        this(newInstance, new ConcurrencyOps.Reset() { // from class: com.scanflow.datacapture.barinternal.pabeles.concurrency.GrowArray$$ExternalSyntheticLambda0
            @Override // com.scanflow.datacapture.barinternal.pabeles.concurrency.ConcurrencyOps.Reset
            public final void reset(Object obj) {
                GrowArray.$r8$lambda$FLfXhh3lXI40rx0huoJhu6Ic5VM(obj);
            }
        });
    }

    public GrowArray(ConcurrencyOps.NewInstance newInstance, ConcurrencyOps.Reset reset) {
        this(newInstance, reset, newInstance.newInstance().getClass());
    }

    public GrowArray(ConcurrencyOps.NewInstance newInstance, ConcurrencyOps.Reset reset, Class cls) {
        this.factory = newInstance;
        this.reset = reset;
        this.elementType = cls;
        this.array = createArray(0);
        this.size = 0;
    }

    private Object[] createArray(int i) {
        return (Object[]) Array.newInstance((Class<?>) this.elementType, i);
    }

    public void reset() {
        this.size = 0;
    }

    public void resize(int i) {
        if (i >= this.array.length) {
            Object[] objArrCreateArray = createArray(i);
            Object[] objArr = this.array;
            System.arraycopy(objArr, 0, objArrCreateArray, 0, objArr.length);
            for (int length = this.array.length; length < objArrCreateArray.length; length++) {
                objArrCreateArray[length] = this.factory.newInstance();
            }
            this.array = objArrCreateArray;
        }
        for (int i2 = this.size; i2 < i; i2++) {
            this.reset.reset(this.array[i2]);
        }
        this.size = i;
    }

    public Object grow() {
        int i = this.size;
        if (i == this.array.length) {
            Object[] objArrCreateArray = createArray(Math.max(10, i < 1000 ? i * 2 : (i * 5) / 3));
            Object[] objArr = this.array;
            System.arraycopy(objArr, 0, objArrCreateArray, 0, objArr.length);
            for (int length = this.array.length; length < objArrCreateArray.length; length++) {
                objArrCreateArray[length] = this.factory.newInstance();
            }
            this.array = objArrCreateArray;
        }
        Object[] objArr2 = this.array;
        int i2 = this.size;
        this.size = i2 + 1;
        Object obj = objArr2[i2];
        this.reset.reset(obj);
        return obj;
    }

    public Object get(int i) {
        return this.array[i];
    }

    public int size() {
        return this.size;
    }
}
