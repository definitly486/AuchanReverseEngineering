package com.scanflow.datacapture.barinternal.boofcv.override;

import java.util.ArrayList;
import java.util.List;

/* JADX INFO: loaded from: classes.dex */
public abstract class BOverrideManager {
    public static final List list = new ArrayList();

    public static synchronized void register(Class cls) {
        if (BOverrideClass.class.isAssignableFrom(cls)) {
            list.add(cls);
        } else {
            throw new RuntimeException("Expected a class derived from " + BOverrideClass.class.getSimpleName());
        }
    }
}
