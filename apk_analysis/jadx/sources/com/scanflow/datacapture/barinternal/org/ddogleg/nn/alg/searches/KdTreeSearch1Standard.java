package com.scanflow.datacapture.barinternal.org.ddogleg.nn.alg.searches;

import com.scanflow.datacapture.barinternal.org.ddogleg.nn.alg.KdTree;
import com.scanflow.datacapture.barinternal.org.ddogleg.nn.alg.KdTreeDistance;
import com.scanflow.datacapture.barinternal.org.ddogleg.nn.alg.KdTreeSearch1;

/* JADX INFO: loaded from: classes3.dex */
public class KdTreeSearch1Standard implements KdTreeSearch1 {
    KdTreeDistance distance;
    private double maxDistanceSq = Double.MAX_VALUE;
    private KdTree tree;

    public KdTreeSearch1Standard(KdTreeDistance kdTreeDistance) {
        this.distance = kdTreeDistance;
    }

    @Override // com.scanflow.datacapture.barinternal.org.ddogleg.nn.alg.KdTreeSearch1
    public void setTree(Object obj) {
        this.tree = (KdTree) obj;
    }

    @Override // com.scanflow.datacapture.barinternal.org.ddogleg.nn.alg.KdTreeSearch1
    public KdTreeSearch1 copy() {
        return new KdTreeSearch1Standard(this.distance);
    }
}
