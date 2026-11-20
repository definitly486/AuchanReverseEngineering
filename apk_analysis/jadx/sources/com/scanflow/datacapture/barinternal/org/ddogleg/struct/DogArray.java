package com.scanflow.datacapture.barinternal.org.ddogleg.struct;

import java.lang.reflect.Array;
import java.util.List;

/* JADX INFO: loaded from: classes3.dex */
public class DogArray extends FastAccess {
    private Factory factory;
    private DProcess initialize;
    private final DogArrayList list;
    private DProcess reset;

    public DogArray(Class cls, Factory factory) {
        super(cls);
        this.initialize = new DProcess.DoNothing();
        this.list = new DogArrayList(this);
        init(10, factory);
    }

    public DogArray(Factory factory) {
        super(factory.newInstance().getClass());
        this.initialize = new DProcess.DoNothing();
        this.list = new DogArrayList(this);
        init(10, factory);
    }

    public DogArray(Factory factory, DProcess dProcess) {
        super(factory.newInstance().getClass());
        this.initialize = new DProcess.DoNothing();
        this.list = new DogArrayList(this);
        this.reset = dProcess;
        init(10, factory);
    }

    public DogArray(int i, Factory factory) {
        super(factory.newInstance().getClass());
        this.initialize = new DProcess.DoNothing();
        this.list = new DogArrayList(this);
        init(i, factory);
    }

    protected void init(int i, Factory factory) {
        this.size = 0;
        this.factory = factory;
        if (this.reset == null) {
            this.reset = new DProcess.DoNothing();
        }
        this.data = (Object[]) Array.newInstance((Class<?>) this.type, i);
        if (factory != null) {
            for (int i2 = 0; i2 < i; i2++) {
                try {
                    this.data[i2] = createInstance();
                } catch (RuntimeException unused) {
                    throw new RuntimeException("declareInstances is true, but createInstance() can't create a new instance.  Maybe override createInstance()?");
                }
            }
        }
    }

    public List toList() {
        return this.list;
    }

    public Object removeTail() {
        int i = this.size;
        if (i > 0) {
            int i2 = i - 1;
            this.size = i2;
            return this.data[i2];
        }
        throw new IllegalArgumentException("Size is already zero");
    }

    public DogArray reset() {
        this.size = 0;
        return this;
    }

    public Object grow() {
        int i = this.size;
        Object[] objArr = this.data;
        if (i < objArr.length) {
            this.size = i + 1;
            Object obj = objArr[i];
            this.reset.process(obj);
            return obj;
        }
        reserve((objArr.length + 1) * 2);
        Object[] objArr2 = this.data;
        int i2 = this.size;
        this.size = i2 + 1;
        return objArr2[i2];
    }

    public Object remove(int i) {
        Object obj = this.data[i];
        while (true) {
            i++;
            int i2 = this.size;
            if (i < i2) {
                Object[] objArr = this.data;
                objArr[i - 1] = objArr[i];
            } else {
                this.data[i2 - 1] = obj;
                this.size = i2 - 1;
                return obj;
            }
        }
    }

    public void reserve(int i) {
        if (this.data.length >= i) {
            return;
        }
        Object[] objArr = (Object[]) Array.newInstance((Class<?>) this.type, i);
        Object[] objArr2 = this.data;
        System.arraycopy(objArr2, 0, objArr, 0, objArr2.length);
        if (this.factory != null) {
            for (int length = this.data.length; length < i; length++) {
                objArr[length] = createInstance();
            }
        }
        this.data = objArr;
    }

    public DogArray resize(int i) {
        reserve(i);
        for (int i2 = this.size; i2 < i; i2++) {
            this.reset.process(this.data[i2]);
        }
        this.size = i;
        return this;
    }

    protected Object createInstance() {
        Object objNewInstance = this.factory.newInstance();
        this.initialize.process(objNewInstance);
        this.reset.process(objNewInstance);
        return objNewInstance;
    }
}
