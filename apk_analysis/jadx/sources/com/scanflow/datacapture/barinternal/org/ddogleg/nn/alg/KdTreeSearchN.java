package com.scanflow.datacapture.barinternal.org.ddogleg.nn.alg;

import com.scanflow.datacapture.barinternal.org.ddogleg.struct.DogArray;

/* JADX INFO: loaded from: classes3.dex */
public interface KdTreeSearchN {
    KdTreeSearchN copy();

    void findNeighbor(Object obj, int i, DogArray dogArray);

    void setMaxDistance(double d);

    void setTree(Object obj);
}
