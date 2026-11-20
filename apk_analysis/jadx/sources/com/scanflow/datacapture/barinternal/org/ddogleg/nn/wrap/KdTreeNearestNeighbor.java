package com.scanflow.datacapture.barinternal.org.ddogleg.nn.wrap;

import com.scanflow.datacapture.barinternal.org.ddogleg.nn.NearestNeighbor;
import com.scanflow.datacapture.barinternal.org.ddogleg.nn.alg.AxisSplitter;
import com.scanflow.datacapture.barinternal.org.ddogleg.nn.alg.AxisSplitterMedian;
import com.scanflow.datacapture.barinternal.org.ddogleg.nn.alg.KdTree;
import com.scanflow.datacapture.barinternal.org.ddogleg.nn.alg.KdTreeConstructor;
import com.scanflow.datacapture.barinternal.org.ddogleg.nn.alg.KdTreeDistance;
import com.scanflow.datacapture.barinternal.org.ddogleg.nn.alg.KdTreeMemory;
import com.scanflow.datacapture.barinternal.org.ddogleg.nn.alg.KdTreeSearch1;
import com.scanflow.datacapture.barinternal.org.ddogleg.nn.alg.KdTreeSearchN;
import com.scanflow.datacapture.barinternal.org.ddogleg.nn.alg.searches.KdTreeSearch1Standard;
import com.scanflow.datacapture.barinternal.org.ddogleg.nn.alg.searches.KdTreeSearchNStandard;
import java.util.List;

/* JADX INFO: loaded from: classes3.dex */
public class KdTreeNearestNeighbor implements NearestNeighbor {
    KdTreeConstructor constructor;
    KdTreeMemory memory;
    KdTreeSearch1 search1;
    KdTreeSearchN searchN;
    AxisSplitter splitter;
    KdTree tree;

    public KdTreeNearestNeighbor(KdTreeSearch1 kdTreeSearch1, KdTreeSearchN kdTreeSearchN, AxisSplitter axisSplitter) {
        KdTreeMemory kdTreeMemory = new KdTreeMemory();
        this.memory = kdTreeMemory;
        this.search1 = kdTreeSearch1;
        this.searchN = kdTreeSearchN;
        this.splitter = axisSplitter;
        this.constructor = new KdTreeConstructor(kdTreeMemory, axisSplitter);
    }

    public KdTreeNearestNeighbor(KdTreeDistance kdTreeDistance) {
        this(new KdTreeSearch1Standard(kdTreeDistance), new KdTreeSearchNStandard(kdTreeDistance), new AxisSplitterMedian(kdTreeDistance));
    }

    @Override // com.scanflow.datacapture.barinternal.org.ddogleg.nn.NearestNeighbor
    public void setPoints(List list, boolean z) {
        KdTree kdTree = this.tree;
        if (kdTree != null) {
            this.memory.recycleGraph(kdTree);
        }
        this.tree = this.constructor.construct(list, z);
    }

    @Override // com.scanflow.datacapture.barinternal.org.ddogleg.nn.NearestNeighbor
    public NearestNeighbor.Search createSearch() {
        return new InternalSearch(this.search1.copy(), this.searchN.copy());
    }

    private class InternalSearch extends KdTreeInternalSearch {
        InternalSearch(KdTreeSearch1 kdTreeSearch1, KdTreeSearchN kdTreeSearchN) {
            super(kdTreeSearch1, kdTreeSearchN);
        }

        @Override // com.scanflow.datacapture.barinternal.org.ddogleg.nn.wrap.KdTreeInternalSearch
        void setTree() {
            this.search1.setTree(KdTreeNearestNeighbor.this.tree);
            this.searchN.setTree(KdTreeNearestNeighbor.this.tree);
        }
    }
}
