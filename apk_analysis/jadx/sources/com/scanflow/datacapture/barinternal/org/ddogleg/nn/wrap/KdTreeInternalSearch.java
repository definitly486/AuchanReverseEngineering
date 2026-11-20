package com.scanflow.datacapture.barinternal.org.ddogleg.nn.wrap;

import com.scanflow.datacapture.barinternal.org.ddogleg.nn.NearestNeighbor;
import com.scanflow.datacapture.barinternal.org.ddogleg.nn.NnData;
import com.scanflow.datacapture.barinternal.org.ddogleg.nn.alg.KdTree;
import com.scanflow.datacapture.barinternal.org.ddogleg.nn.alg.KdTreeResult;
import com.scanflow.datacapture.barinternal.org.ddogleg.nn.alg.KdTreeSearch1;
import com.scanflow.datacapture.barinternal.org.ddogleg.nn.alg.KdTreeSearchN;
import com.scanflow.datacapture.barinternal.org.ddogleg.struct.DogArray;
import com.scanflow.datacapture.barinternal.org.ddogleg.struct.Factory;

/* JADX INFO: loaded from: classes3.dex */
public abstract class KdTreeInternalSearch implements NearestNeighbor.Search {
    DogArray found = new DogArray(new Factory() { // from class: com.scanflow.datacapture.barinternal.org.ddogleg.nn.wrap.KdTreeInternalSearch$$ExternalSyntheticLambda0
        @Override // com.scanflow.datacapture.barinternal.org.ddogleg.struct.Factory
        public final Object newInstance() {
            return new KdTreeResult();
        }
    });
    KdTreeSearch1 search1;
    KdTreeSearchN searchN;

    abstract void setTree();

    KdTreeInternalSearch(KdTreeSearch1 kdTreeSearch1, KdTreeSearchN kdTreeSearchN) {
        this.search1 = kdTreeSearch1;
        this.searchN = kdTreeSearchN;
    }

    @Override // com.scanflow.datacapture.barinternal.org.ddogleg.nn.NearestNeighbor.Search
    public void findNearest(Object obj, double d, int i, DogArray dogArray) {
        setTree();
        dogArray.reset();
        if (d <= 0.0d) {
            this.searchN.setMaxDistance(Double.MAX_VALUE);
        } else {
            this.searchN.setMaxDistance(d);
        }
        this.found.reset();
        this.searchN.findNeighbor(obj, i, this.found);
        int i2 = 0;
        while (true) {
            DogArray dogArray2 = this.found;
            if (i2 >= dogArray2.size) {
                return;
            }
            KdTreeResult kdTreeResult = (KdTreeResult) dogArray2.get(i2);
            NnData nnData = (NnData) dogArray.grow();
            KdTree.Node node = kdTreeResult.node;
            nnData.point = node.point;
            nnData.index = node.index;
            nnData.distance = kdTreeResult.distance;
            i2++;
        }
    }
}
