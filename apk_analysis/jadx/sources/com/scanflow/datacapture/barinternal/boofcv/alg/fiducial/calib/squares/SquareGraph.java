package com.scanflow.datacapture.barinternal.boofcv.alg.fiducial.calib.squares;

import com.scanflow.datacapture.barinternal.boofcv.misc.CircularIndex;
import com.scanflow.datacapture.barinternal.georegression.metric.Intersection2D_F64;
import com.scanflow.datacapture.barinternal.georegression.metric.UtilAngle;
import com.scanflow.datacapture.barinternal.georegression.struct.line.LineSegment2D_F64;
import com.scanflow.datacapture.barinternal.georegression.struct.point.Point2D_F64;
import com.scanflow.datacapture.barinternal.georegression.struct.point.Vector2D_F64;
import com.scanflow.datacapture.barinternal.org.ddogleg.struct.DProcess;
import com.scanflow.datacapture.barinternal.org.ddogleg.struct.DogArray;
import com.scanflow.datacapture.barinternal.org.ddogleg.struct.Factory;
import java.util.ArrayDeque;
import java.util.Deque;

/* JADX INFO: loaded from: classes.dex */
public class SquareGraph {
    protected DogArray declaredEdges = new DogArray(new Factory() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.fiducial.calib.squares.SquareGraph$$ExternalSyntheticLambda0
        @Override // com.scanflow.datacapture.barinternal.org.ddogleg.struct.Factory
        public final Object newInstance() {
            return new SquareEdge();
        }
    }, new DProcess() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.fiducial.calib.squares.SquareGraph$$ExternalSyntheticLambda1
        @Override // com.scanflow.datacapture.barinternal.org.ddogleg.struct.DProcess
        public final void process(Object obj) {
            ((SquareEdge) obj).reset();
        }
    });
    protected Deque unused = new ArrayDeque();
    Vector2D_F64 vector0 = new Vector2D_F64();
    Vector2D_F64 vector1 = new Vector2D_F64();
    double parallelThreshold = UtilAngle.radian(45.0f);

    public void reset() {
        int i = 0;
        while (true) {
            DogArray dogArray = this.declaredEdges;
            if (i < dogArray.size) {
                ((SquareEdge) dogArray.get(i)).reset();
                i++;
            } else {
                this.unused.clear();
                this.unused.addAll(this.declaredEdges.toList());
                return;
            }
        }
    }

    public static void computeNodeInfo(SquareNode squareNode) {
        int i = 3;
        if (Intersection2D_F64.intersection(squareNode.square.get(0), squareNode.square.get(2), squareNode.square.get(1), squareNode.square.get(3), squareNode.center) == null) {
            throw new RuntimeException("BAD");
        }
        squareNode.largestSide = 0.0d;
        squareNode.smallestSide = Double.MAX_VALUE;
        for (int i2 = 0; i2 < 4; i2++) {
            double dDistance = squareNode.square.get(i2).distance(squareNode.square.get(i));
            squareNode.sideLengths[i] = dDistance;
            squareNode.largestSide = Math.max(squareNode.largestSide, dDistance);
            squareNode.smallestSide = Math.min(squareNode.smallestSide, dDistance);
            i = i2;
        }
    }

    public void detachEdge(SquareEdge squareEdge) {
        squareEdge.a.edges[squareEdge.sideA] = null;
        squareEdge.b.edges[squareEdge.sideB] = null;
        squareEdge.reset();
        this.unused.add(squareEdge);
    }

    public int findSideIntersect(SquareNode squareNode, LineSegment2D_F64 lineSegment2D_F64, Point2D_F64 point2D_F64, LineSegment2D_F64 lineSegment2D_F65) {
        int i = 3;
        for (int i2 = 0; i2 < 4; i2++) {
            lineSegment2D_F65.a = squareNode.square.get(i);
            lineSegment2D_F65.b = squareNode.square.get(i2);
            if (Intersection2D_F64.intersection(lineSegment2D_F64, lineSegment2D_F65, point2D_F64) != null) {
                return i;
            }
            i = i2;
        }
        return -1;
    }

    public boolean checkConnect(SquareNode squareNode, int i, SquareNode squareNode2, int i2, double d) {
        SquareEdge squareEdge = squareNode.edges[i];
        if (squareEdge != null && squareEdge.distance > d) {
            detachEdge(squareEdge);
        }
        SquareEdge squareEdge2 = squareNode2.edges[i2];
        if (squareEdge2 != null && squareEdge2.distance > d) {
            detachEdge(squareEdge2);
        }
        if (squareNode.edges[i] != null || squareNode2.edges[i2] != null) {
            return false;
        }
        connect(squareNode, i, squareNode2, i2, d);
        return true;
    }

    void connect(SquareNode squareNode, int i, SquareNode squareNode2, int i2, double d) {
        SquareEdge unusedEdge = getUnusedEdge();
        unusedEdge.a = squareNode;
        unusedEdge.sideA = i;
        unusedEdge.b = squareNode2;
        unusedEdge.sideB = i2;
        unusedEdge.distance = d;
        squareNode.edges[i] = unusedEdge;
        squareNode2.edges[i2] = unusedEdge;
    }

    public boolean almostParallel(SquareNode squareNode, int i, SquareNode squareNode2, int i2) {
        return acuteAngle(squareNode, i, squareNode2, i2) <= this.parallelThreshold;
    }

    public double acuteAngle(SquareNode squareNode, int i, SquareNode squareNode2, int i2) {
        Point2D_F64 point2D_F64 = squareNode.square.get(i);
        Point2D_F64 point2D_F65 = squareNode.square.get(add(i, 1));
        Point2D_F64 point2D_F66 = squareNode2.square.get(i2);
        Point2D_F64 point2D_F67 = squareNode2.square.get(add(i2, 1));
        this.vector0.setTo(point2D_F65.x - point2D_F64.x, point2D_F65.y - point2D_F64.y);
        this.vector1.setTo(point2D_F67.x - point2D_F66.x, point2D_F67.y - point2D_F66.y);
        double dAcute = this.vector0.acute(this.vector1);
        return Math.min(UtilAngle.dist(3.141592653589793d, dAcute), dAcute);
    }

    private static int add(int i, int i2) {
        return CircularIndex.addOffset(i, i2, 4);
    }

    private SquareEdge getUnusedEdge() {
        if (!this.unused.isEmpty()) {
            return (SquareEdge) this.unused.remove();
        }
        return (SquareEdge) this.declaredEdges.grow();
    }
}
