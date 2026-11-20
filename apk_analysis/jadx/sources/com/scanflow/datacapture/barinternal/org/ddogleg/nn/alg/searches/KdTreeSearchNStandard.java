package com.scanflow.datacapture.barinternal.org.ddogleg.nn.alg.searches;

import com.scanflow.datacapture.barinternal.org.ddogleg.nn.alg.KdTree;
import com.scanflow.datacapture.barinternal.org.ddogleg.nn.alg.KdTreeDistance;
import com.scanflow.datacapture.barinternal.org.ddogleg.nn.alg.KdTreeResult;
import com.scanflow.datacapture.barinternal.org.ddogleg.nn.alg.KdTreeSearchN;
import com.scanflow.datacapture.barinternal.org.ddogleg.struct.DogArray;

/* JADX INFO: loaded from: classes3.dex */
public class KdTreeSearchNStandard implements KdTreeSearchN {
    KdTreeDistance distance;
    private double maxDistanceSq = Double.MAX_VALUE;
    private int mostDistantNeighborIndex;
    private double mostDistantNeighborSq;
    private int searchN;
    private Object target;
    private KdTree tree;

    public KdTreeSearchNStandard(KdTreeDistance kdTreeDistance) {
        this.distance = kdTreeDistance;
    }

    @Override // com.scanflow.datacapture.barinternal.org.ddogleg.nn.alg.KdTreeSearchN
    public void setTree(Object obj) {
        this.tree = (KdTree) obj;
    }

    @Override // com.scanflow.datacapture.barinternal.org.ddogleg.nn.alg.KdTreeSearchN
    public void setMaxDistance(double d) {
        this.maxDistanceSq = d;
    }

    @Override // com.scanflow.datacapture.barinternal.org.ddogleg.nn.alg.KdTreeSearchN
    public void findNeighbor(Object obj, int i, DogArray dogArray) {
        if (i <= 0) {
            throw new IllegalArgumentException("I'm sorry, but I refuse to search for less than or equal to 0 neighbors.");
        }
        KdTree.Node node = this.tree.root;
        if (node == null) {
            return;
        }
        this.searchN = i;
        this.target = obj;
        this.mostDistantNeighborSq = this.maxDistanceSq;
        stepClosest(node, dogArray);
    }

    @Override // com.scanflow.datacapture.barinternal.org.ddogleg.nn.alg.KdTreeSearchN
    public KdTreeSearchN copy() {
        return new KdTreeSearchNStandard(this.distance);
    }

    private void stepClosest(KdTree.Node node, DogArray dogArray) {
        KdTree.Node node2;
        KdTree.Node node3;
        if (node == null) {
            return;
        }
        checkBestDistance(node, dogArray);
        if (node.isLeaf()) {
            return;
        }
        double dValueAt = this.distance.valueAt(node.point, node.split);
        double dValueAt2 = this.distance.valueAt(this.target, node.split);
        if (dValueAt2 <= dValueAt) {
            node2 = node.left;
            node3 = node.right;
        } else {
            node2 = node.right;
            node3 = node.left;
        }
        stepClosest(node2, dogArray);
        double d = dValueAt - dValueAt2;
        double d2 = d * d;
        if (d2 <= this.mostDistantNeighborSq) {
            if (dogArray.size() < this.searchN || d2 < this.mostDistantNeighborSq) {
                stepClosest(node3, dogArray);
            }
        }
    }

    private void checkBestDistance(KdTree.Node node, DogArray dogArray) {
        double dDistance = this.distance.distance(node.point, this.target);
        if (dDistance <= this.mostDistantNeighborSq) {
            int i = 0;
            if (dogArray.size() < this.searchN) {
                KdTreeResult kdTreeResult = (KdTreeResult) dogArray.grow();
                kdTreeResult.distance = dDistance;
                kdTreeResult.node = node;
                if (dogArray.size() == this.searchN) {
                    this.mostDistantNeighborSq = -1.0d;
                    while (i < this.searchN) {
                        double d = ((KdTreeResult) dogArray.get(i)).distance;
                        if (d > this.mostDistantNeighborSq) {
                            this.mostDistantNeighborSq = d;
                            this.mostDistantNeighborIndex = i;
                        }
                        i++;
                    }
                    return;
                }
                return;
            }
            for (int i2 = 0; i2 < this.searchN; i2++) {
                if (((KdTreeResult) dogArray.get(i2)).distance > this.mostDistantNeighborSq) {
                    throw new RuntimeException("Most distant isn't the most distant");
                }
            }
            KdTreeResult kdTreeResult2 = (KdTreeResult) dogArray.get(this.mostDistantNeighborIndex);
            kdTreeResult2.node = node;
            kdTreeResult2.distance = dDistance;
            this.mostDistantNeighborSq = -1.0d;
            while (i < this.searchN) {
                double d2 = ((KdTreeResult) dogArray.get(i)).distance;
                if (d2 > this.mostDistantNeighborSq) {
                    this.mostDistantNeighborSq = d2;
                    this.mostDistantNeighborIndex = i;
                }
                i++;
            }
        }
    }
}
