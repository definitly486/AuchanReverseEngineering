package com.scanflow.datacapture.barinternal.boofcv.alg.shapes.edge;

import com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageGray;
import com.scanflow.datacapture.barinternal.georegression.struct.point.Point2D_F64;
import com.scanflow.datacapture.barinternal.georegression.struct.shapes.Polygon2D_F64;

/* JADX INFO: loaded from: classes.dex */
public class EdgeIntensityPolygon {
    private double averageInside;
    private double averageOutside;
    private double cornerOffset;
    private final Point2D_F64 offsetA = new Point2D_F64();
    private final Point2D_F64 offsetB = new Point2D_F64();
    ScoreLineSegmentEdge scorer;
    private double tangentDistance;

    public EdgeIntensityPolygon(double d, double d2, int i, Class cls) {
        this.cornerOffset = d;
        this.tangentDistance = d2;
        this.scorer = new ScoreLineSegmentEdge(i, cls);
    }

    public void setImage(ImageGray imageGray) {
        this.scorer.setImage(imageGray);
    }

    public boolean computeEdge(Polygon2D_F64 polygon2D_F64, boolean z) {
        Polygon2D_F64 polygon2D_F65 = polygon2D_F64;
        this.averageInside = 0.0d;
        this.averageOutside = 0.0d;
        double d = z ? 1.0d : -1.0d;
        boolean z2 = true;
        int size = polygon2D_F65.size() - 1;
        int i = 0;
        int i2 = 0;
        while (i < polygon2D_F65.size()) {
            Point2D_F64 point2D_F64 = polygon2D_F65.get(size);
            Point2D_F64 point2D_F65 = polygon2D_F65.get(i);
            double d2 = point2D_F65.x - point2D_F64.x;
            boolean z3 = z2;
            double d3 = point2D_F65.y - point2D_F64.y;
            double dSqrt = Math.sqrt((d2 * d2) + (d3 * d3));
            double d4 = d2 / dSqrt;
            double d5 = d3 / dSqrt;
            double d6 = this.cornerOffset;
            if (dSqrt < 3.0d * d6) {
                this.offsetA.setTo(point2D_F64);
                this.offsetB.setTo(point2D_F65);
            } else {
                Point2D_F64 point2D_F66 = this.offsetA;
                point2D_F66.x = point2D_F64.x + (d6 * d4);
                point2D_F66.y = point2D_F64.y + (d6 * d5);
                Point2D_F64 point2D_F67 = this.offsetB;
                point2D_F67.x = point2D_F65.x - (d6 * d4);
                point2D_F67.y = point2D_F65.y - (d6 * d5);
            }
            double d7 = this.tangentDistance;
            this.scorer.computeAverageDerivative(this.offsetA, this.offsetB, (-d5) * d7 * d, d4 * d7 * d);
            if (this.scorer.getSamplesInside() > 0) {
                i2++;
                this.averageInside += this.scorer.getAverageUp() / this.tangentDistance;
                this.averageOutside += this.scorer.getAverageDown() / this.tangentDistance;
            }
            z2 = z3;
            size = i;
            i++;
            polygon2D_F65 = polygon2D_F64;
        }
        boolean z4 = z2;
        if (i2 > 0) {
            double d8 = i2;
            this.averageInside /= d8;
            this.averageOutside /= d8;
            return z4;
        }
        this.averageOutside = 0.0d;
        this.averageInside = 0.0d;
        return false;
    }

    public double getAverageInside() {
        return this.averageInside;
    }

    public double getAverageOutside() {
        return this.averageOutside;
    }
}
