package com.scanflow.datacapture.barinternal.org.ddogleg.nn;

import com.scanflow.datacapture.barinternal.org.ddogleg.nn.alg.KdTreeDistance;
import com.scanflow.datacapture.barinternal.org.ddogleg.nn.wrap.KdTreeNearestNeighbor;

/* JADX INFO: loaded from: classes3.dex */
public abstract class FactoryNearestNeighbor {
    public static NearestNeighbor kdtree(KdTreeDistance kdTreeDistance) {
        return new KdTreeNearestNeighbor(kdTreeDistance);
    }
}
