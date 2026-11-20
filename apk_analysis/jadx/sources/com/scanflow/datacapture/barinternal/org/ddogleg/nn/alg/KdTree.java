package com.scanflow.datacapture.barinternal.org.ddogleg.nn.alg;

/* JADX INFO: loaded from: classes3.dex */
public class KdTree {
    public int N;
    public Node root;

    public KdTree(int i) {
        this.N = i;
    }

    public static class Node {
        public int index;
        public Node left;
        public Object point;
        public Node right;
        public int split = -1;

        public boolean isLeaf() {
            return this.split == -1;
        }
    }
}
