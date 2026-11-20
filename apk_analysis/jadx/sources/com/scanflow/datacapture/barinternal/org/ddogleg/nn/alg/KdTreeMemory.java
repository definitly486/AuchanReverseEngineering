package com.scanflow.datacapture.barinternal.org.ddogleg.nn.alg;

import java.util.ArrayList;
import java.util.List;

/* JADX INFO: loaded from: classes3.dex */
public class KdTreeMemory {
    protected List unusedNodes = new ArrayList();
    protected List unusedTrees = new ArrayList();
    protected List open = new ArrayList();

    public KdTree.Node requestNode() {
        if (this.unusedNodes.isEmpty()) {
            return new KdTree.Node();
        }
        List list = this.unusedNodes;
        return (KdTree.Node) list.remove(list.size() - 1);
    }

    public KdTree.Node requestNode(Object obj, int i) {
        KdTree.Node nodeRequestNode = requestNode();
        nodeRequestNode.point = obj;
        nodeRequestNode.index = i;
        nodeRequestNode.split = -1;
        return nodeRequestNode;
    }

    public KdTree requestTree(int i) {
        if (this.unusedTrees.isEmpty()) {
            return new KdTree(i);
        }
        List list = this.unusedTrees;
        KdTree kdTree = (KdTree) list.remove(list.size() - 1);
        kdTree.N = i;
        return kdTree;
    }

    public void recycle(KdTree.Node node) {
        node.point = null;
        node.left = null;
        node.right = null;
        this.unusedNodes.add(node);
    }

    public void recycleGraph(KdTree kdTree) {
        KdTree.Node node = kdTree.root;
        if (node != null) {
            this.open.add(node);
            while (!this.open.isEmpty()) {
                List list = this.open;
                KdTree.Node node2 = (KdTree.Node) list.remove(list.size() - 1);
                KdTree.Node node3 = node2.left;
                if (node3 != null) {
                    this.open.add(node3);
                }
                KdTree.Node node4 = node2.right;
                if (node4 != null) {
                    this.open.add(node4);
                }
                recycle(node2);
            }
            kdTree.root = null;
        }
        this.unusedTrees.add(kdTree);
    }
}
