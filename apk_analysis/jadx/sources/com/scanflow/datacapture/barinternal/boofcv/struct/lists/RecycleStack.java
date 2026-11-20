package com.scanflow.datacapture.barinternal.boofcv.struct.lists;

import java.util.ArrayList;
import java.util.List;

/* JADX INFO: loaded from: classes.dex */
public class RecycleStack {
    Factory factory;
    List list = new ArrayList();

    public interface Factory {
        Object newInstance();
    }

    public RecycleStack(Factory factory) {
        this.factory = factory;
    }

    public synchronized Object pop() {
        if (this.list.isEmpty()) {
            return this.factory.newInstance();
        }
        List list = this.list;
        return list.remove(list.size() - 1);
    }

    public synchronized void recycle(Object obj) {
        this.list.add(obj);
    }
}
