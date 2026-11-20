package com.scanflow.datacapture.barinternal.org.ddogleg.nn.alg;

import com.scanflow.datacapture.barinternal.org.ddogleg.struct.DogArray_I32;
import java.util.ArrayList;
import java.util.List;

/* JADX INFO: loaded from: classes3.dex */
public class KdTreeConstructor {
    KdTreeMemory memory;
    AxisSplitter splitter;

    public KdTreeConstructor(KdTreeMemory kdTreeMemory, AxisSplitter axisSplitter) {
        this.memory = kdTreeMemory;
        this.splitter = axisSplitter;
    }

    public KdTree construct(List list, boolean z) {
        DogArray_I32 dogArray_I32;
        if (z) {
            dogArray_I32 = new DogArray_I32();
            dogArray_I32.resize(list.size());
            for (int i = 0; i < dogArray_I32.size; i++) {
                dogArray_I32.data[i] = i;
            }
        } else {
            dogArray_I32 = null;
        }
        KdTree kdTreeRequestTree = this.memory.requestTree(this.splitter.getPointLength());
        if (list.size() == 1) {
            kdTreeRequestTree.root = createLeaf(list, dogArray_I32);
            return kdTreeRequestTree;
        }
        if (list.size() > 1) {
            kdTreeRequestTree.root = computeBranch(list, dogArray_I32);
        }
        return kdTreeRequestTree;
    }

    protected KdTree.Node computeBranch(List list, DogArray_I32 dogArray_I32) {
        DogArray_I32 dogArray_I33;
        DogArray_I32 dogArray_I34;
        ArrayList arrayList = new ArrayList(list.size() / 2);
        ArrayList arrayList2 = new ArrayList(list.size() / 2);
        if (dogArray_I32 == null) {
            dogArray_I33 = null;
            dogArray_I34 = null;
        } else {
            dogArray_I33 = new DogArray_I32(list.size() / 2);
            dogArray_I34 = new DogArray_I32(list.size() / 2);
        }
        this.splitter.splitData(list, dogArray_I32, arrayList, dogArray_I33, arrayList2, dogArray_I34);
        KdTree.Node nodeRequestNode = this.memory.requestNode();
        nodeRequestNode.split = this.splitter.getSplitAxis();
        nodeRequestNode.point = this.splitter.getSplitPoint();
        nodeRequestNode.index = this.splitter.getSplitIndex();
        nodeRequestNode.left = computeChild(arrayList, dogArray_I33);
        nodeRequestNode.right = computeChild(arrayList2, dogArray_I34);
        return nodeRequestNode;
    }

    protected KdTree.Node computeChild(List list, DogArray_I32 dogArray_I32) {
        if (list.size() == 0) {
            return null;
        }
        if (list.size() == 1) {
            return createLeaf(list, dogArray_I32);
        }
        return computeBranch(list, dogArray_I32);
    }

    private KdTree.Node createLeaf(List list, DogArray_I32 dogArray_I32) {
        return this.memory.requestNode(list.get(0), dogArray_I32 == null ? -1 : dogArray_I32.get(0));
    }
}
