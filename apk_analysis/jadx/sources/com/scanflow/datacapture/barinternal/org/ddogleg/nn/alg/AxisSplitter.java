package com.scanflow.datacapture.barinternal.org.ddogleg.nn.alg;

import com.scanflow.datacapture.barinternal.org.ddogleg.struct.DogArray_I32;
import java.util.List;

/* JADX INFO: loaded from: classes3.dex */
public interface AxisSplitter {
    int getPointLength();

    int getSplitAxis();

    int getSplitIndex();

    Object getSplitPoint();

    void splitData(List list, DogArray_I32 dogArray_I32, List list2, DogArray_I32 dogArray_I33, List list3, DogArray_I32 dogArray_I34);
}
