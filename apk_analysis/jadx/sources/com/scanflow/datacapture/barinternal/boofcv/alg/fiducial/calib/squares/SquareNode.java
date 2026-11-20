package com.scanflow.datacapture.barinternal.boofcv.alg.fiducial.calib.squares;

import com.scanflow.datacapture.barinternal.georegression.struct.point.Point2D_F64;
import com.scanflow.datacapture.barinternal.georegression.struct.shapes.Polygon2D_F64;
import com.scanflow.datacapture.barinternal.org.ddogleg.nn.alg.KdTreeDistance;
import com.scanflow.datacapture.barinternal.org.ddogleg.struct.DogArray_B;

/* JADX INFO: loaded from: classes.dex */
public abstract class SquareNode {
    public int graph;
    public double largestSide;
    public double smallestSide;
    public Polygon2D_F64 square;
    public DogArray_B touch;
    public Point2D_F64 center = new Point2D_F64();
    public double[] sideLengths = new double[4];
    public SquareEdge[] edges = new SquareEdge[4];

    public void reset() {
        this.square = null;
        this.touch = null;
        this.center.setTo(-1.0d, -1.0d);
        this.largestSide = 0.0d;
        this.smallestSide = Double.MAX_VALUE;
        this.graph = -2;
        int i = 0;
        while (true) {
            SquareEdge[] squareEdgeArr = this.edges;
            if (i >= squareEdgeArr.length) {
                return;
            }
            squareEdgeArr[i] = null;
            this.sideLengths[i] = 0.0d;
            i++;
        }
    }

    public int findEdgeIndex(SquareNode squareNode) {
        for (int i = 0; i < 4; i++) {
            SquareEdge squareEdge = this.edges[i];
            if (squareEdge != null && squareEdge.isEndPoint(squareNode)) {
                return i;
            }
        }
        return -1;
    }

    public static class KdTreeSquareNode implements KdTreeDistance {
        @Override // com.scanflow.datacapture.barinternal.org.ddogleg.nn.alg.KdTreeDistance
        public double distance(SquareNode squareNode, SquareNode squareNode2) {
            return squareNode.center.distance2(squareNode2.center);
        }

        @Override // com.scanflow.datacapture.barinternal.org.ddogleg.nn.alg.KdTreeDistance
        public double valueAt(SquareNode squareNode, int i) {
            if (i == 0) {
                return squareNode.center.x;
            }
            if (i == 1) {
                return squareNode.center.y;
            }
            throw new IllegalArgumentException("Out of bounds. " + i);
        }

        @Override // com.scanflow.datacapture.barinternal.org.ddogleg.nn.alg.KdTreeDistance
        public int length() {
            return 2;
        }
    }
}
