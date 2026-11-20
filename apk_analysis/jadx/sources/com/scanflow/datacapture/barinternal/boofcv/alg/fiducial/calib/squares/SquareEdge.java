package com.scanflow.datacapture.barinternal.boofcv.alg.fiducial.calib.squares;

/* JADX INFO: loaded from: classes.dex */
public class SquareEdge {
    public SquareNode a;
    public SquareNode b;
    public double distance;
    public int sideA;
    public int sideB;

    public SquareNode destination(SquareNode squareNode) {
        SquareNode squareNode2 = this.a;
        if (squareNode2 == squareNode) {
            return this.b;
        }
        if (this.b == squareNode) {
            return squareNode2;
        }
        throw new IllegalArgumentException("BUG! src is not a or b");
    }

    public boolean isEndPoint(SquareNode squareNode) {
        return this.a == squareNode || this.b == squareNode;
    }

    public void reset() {
        this.b = null;
        this.a = null;
        this.sideB = -1;
        this.sideA = -1;
        this.distance = -1.0d;
    }
}
