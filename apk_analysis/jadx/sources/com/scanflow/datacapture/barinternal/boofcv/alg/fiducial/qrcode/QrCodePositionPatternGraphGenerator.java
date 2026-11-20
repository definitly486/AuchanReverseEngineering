package com.scanflow.datacapture.barinternal.boofcv.alg.fiducial.qrcode;

import com.scanflow.datacapture.barinternal.boofcv.alg.fiducial.calib.squares.SquareGraph;
import com.scanflow.datacapture.barinternal.boofcv.alg.fiducial.calib.squares.SquareNode;
import com.scanflow.datacapture.barinternal.georegression.struct.line.LineSegment2D_F64;
import com.scanflow.datacapture.barinternal.georegression.struct.point.Point2D_F64;
import com.scanflow.datacapture.barinternal.org.ddogleg.nn.FactoryNearestNeighbor;
import com.scanflow.datacapture.barinternal.org.ddogleg.nn.NearestNeighbor;
import com.scanflow.datacapture.barinternal.org.ddogleg.nn.NnData;
import com.scanflow.datacapture.barinternal.org.ddogleg.struct.DogArray;
import com.scanflow.datacapture.barinternal.org.ddogleg.struct.Factory;
import java.io.PrintStream;
import java.util.List;

/* JADX INFO: loaded from: classes.dex */
public class QrCodePositionPatternGraphGenerator {
    protected LineSegment2D_F64 connectLine;
    protected Point2D_F64 intersection;
    protected LineSegment2D_F64 lineA;
    protected LineSegment2D_F64 lineB;
    private final NearestNeighbor nn;
    private final NearestNeighbor.Search search;
    private final DogArray searchResults;
    protected PrintStream verbose;
    int maxVersionQR = 40;
    SquareGraph graph = new SquareGraph();

    public void setMaxVersionQR(int i) {
        this.maxVersionQR = i;
    }

    public QrCodePositionPatternGraphGenerator() {
        NearestNeighbor nearestNeighborKdtree = FactoryNearestNeighbor.kdtree(new SquareNode.KdTreeSquareNode());
        this.nn = nearestNeighborKdtree;
        this.search = nearestNeighborKdtree.createSearch();
        this.searchResults = new DogArray(new Factory() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.fiducial.qrcode.QrCodePositionPatternGraphGenerator$$ExternalSyntheticLambda0
            @Override // com.scanflow.datacapture.barinternal.org.ddogleg.struct.Factory
            public final Object newInstance() {
                return new NnData();
            }
        });
        this.lineA = new LineSegment2D_F64();
        this.lineB = new LineSegment2D_F64();
        this.connectLine = new LineSegment2D_F64();
        this.intersection = new Point2D_F64();
    }

    public void process(List list) {
        this.graph.reset();
        this.nn.setPoints(list, false);
        for (int i = 0; i < list.size(); i++) {
            PositionPatternNode positionPatternNode = (PositionPatternNode) list.get(i);
            double d = ((positionPatternNode.largestSide * (((double) ((this.maxVersionQR * 4) + 17)) - 7.0d)) / 7.0d) * 1.2d;
            this.search.findNearest(positionPatternNode, d * d, Integer.MAX_VALUE, this.searchResults);
            PrintStream printStream = this.verbose;
            if (printStream != null) {
                printStream.printf("PP: (%.1f %.1f) width=%.1f neighbors=%d\n", Double.valueOf(positionPatternNode.center.x), Double.valueOf(positionPatternNode.center.y), Double.valueOf(positionPatternNode.largestSide), Integer.valueOf(this.searchResults.size - 1));
            }
            if (this.searchResults.size > 1) {
                int i2 = 0;
                while (true) {
                    DogArray dogArray = this.searchResults;
                    if (i2 < dogArray.size) {
                        Object obj = ((NnData) dogArray.get(i2)).point;
                        if (obj != positionPatternNode) {
                            considerConnect(positionPatternNode, (SquareNode) obj);
                        }
                        i2++;
                    }
                }
            }
        }
    }

    void considerConnect(SquareNode squareNode, SquareNode squareNode2) {
        LineSegment2D_F64 lineSegment2D_F64 = this.lineA;
        lineSegment2D_F64.a = squareNode.center;
        lineSegment2D_F64.b = squareNode2.center;
        int iFindSideIntersect = this.graph.findSideIntersect(squareNode, lineSegment2D_F64, this.intersection, this.lineB);
        this.connectLine.a.setTo(this.intersection);
        int iFindSideIntersect2 = this.graph.findSideIntersect(squareNode2, this.lineA, this.intersection, this.lineB);
        this.connectLine.b.setTo(this.intersection);
        if (iFindSideIntersect2 < 0 || iFindSideIntersect < 0) {
            return;
        }
        double d = squareNode.sideLengths[iFindSideIntersect];
        double d2 = squareNode2.sideLengths[iFindSideIntersect2];
        double dDistance = this.connectLine.a.distance(squareNode.square.get(iFindSideIntersect)) / d;
        double dDistance2 = this.connectLine.b.distance(squareNode2.square.get(iFindSideIntersect2)) / d2;
        double d3 = dDistance - 0.5d;
        if (Math.abs(d3) <= 0.35d) {
            double d4 = dDistance2 - 0.5d;
            if (Math.abs(d4) > 0.35d) {
                return;
            }
            double dAbs = (Math.abs(d3) + Math.abs(d4)) / 2.0d;
            if (Math.abs(d - d2) / Math.max(d, d2) <= 0.25d && this.graph.almostParallel(squareNode, iFindSideIntersect, squareNode2, iFindSideIntersect2) && Math.max(squareNode.smallestSide / squareNode2.largestSide, squareNode2.smallestSide / squareNode.largestSide) <= 1.3d) {
                double dAcuteAngle = (this.graph.acuteAngle(squareNode, iFindSideIntersect, squareNode2, iFindSideIntersect2) + 1.0d + (dAbs / 2.0d)) * this.lineA.getLength();
                boolean zCheckConnect = this.graph.checkConnect(squareNode, iFindSideIntersect, squareNode2, iFindSideIntersect2, dAcuteAngle);
                PrintStream printStream = this.verbose;
                if (printStream != null) {
                    printStream.printf("_ (%.1f %.1f) score=%.2f change=%s\n", Double.valueOf(squareNode2.center.x), Double.valueOf(squareNode2.center.y), Double.valueOf(dAcuteAngle), Boolean.valueOf(zCheckConnect));
                }
            }
        }
    }
}
