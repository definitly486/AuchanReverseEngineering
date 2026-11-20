package com.scanflow.datacapture.barinternal.boofcv.alg.shapes.polyline;

import com.scanflow.datacapture.barinternal.boofcv.misc.CircularIndex;
import com.scanflow.datacapture.barinternal.georegression.metric.Distance2D_F64;
import com.scanflow.datacapture.barinternal.georegression.struct.line.LineParametric2D_F64;
import com.scanflow.datacapture.barinternal.georegression.struct.point.Point2D_F64;
import com.scanflow.datacapture.barinternal.georegression.struct.point.Point2D_I32;
import com.scanflow.datacapture.barinternal.org.ddogleg.struct.DogArray_I32;
import java.util.List;

/* JADX INFO: loaded from: classes.dex */
public class MinimizeEnergyPrune {
    List contour;
    double splitPenalty;
    LineParametric2D_F64 line = new LineParametric2D_F64();
    Point2D_F64 point = new Point2D_F64();
    double[] energySegment = new double[1];
    DogArray_I32 bestCorners = new DogArray_I32();
    DogArray_I32 workCorners1 = new DogArray_I32();
    DogArray_I32 workCorners2 = new DogArray_I32();

    public MinimizeEnergyPrune(double d) {
        this.splitPenalty = d;
    }

    public boolean prune(List list, DogArray_I32 dogArray_I32, DogArray_I32 dogArray_I33) {
        this.contour = list;
        dogArray_I33.setTo(dogArray_I32);
        removeDuplicates(dogArray_I33);
        int i = 0;
        int i2 = 3;
        if (dogArray_I33.size() <= 3) {
            return false;
        }
        computeSegmentEnergy(dogArray_I33);
        double d = 0.0d;
        for (int i3 = 0; i3 < dogArray_I33.size(); i3++) {
            d += this.energySegment[i3];
        }
        FitLinesToContour fitLinesToContour = new FitLinesToContour();
        fitLinesToContour.setContour(list);
        boolean z = false;
        while (dogArray_I33.size() > i2) {
            this.bestCorners.reset();
            int i4 = i;
            int i5 = i4;
            while (i4 < dogArray_I33.size()) {
                this.workCorners1.reset();
                for (int i6 = i; i6 < dogArray_I33.size(); i6++) {
                    if (i4 != i6) {
                        this.workCorners1.add(dogArray_I33.get(i6));
                    }
                }
                removeDuplicates(this.workCorners1);
                if (this.workCorners1.size() > i2 && fitLinesToContour.fitAnchored(CircularIndex.addOffset(i4, -2, this.workCorners1.size()), CircularIndex.addOffset(i4, 1, this.workCorners1.size()), this.workCorners1, this.workCorners2)) {
                    int size = this.workCorners2.size() - 1;
                    double dComputeSegmentEnergy = 0.0d;
                    for (int i7 = 0; i7 < this.workCorners2.size(); i7++) {
                        dComputeSegmentEnergy += computeSegmentEnergy(this.workCorners2, size, i7);
                        size = i7;
                    }
                    if (dComputeSegmentEnergy < d) {
                        this.bestCorners.reset();
                        this.bestCorners.addAll(this.workCorners2);
                        i5 = 1;
                        d = dComputeSegmentEnergy;
                    }
                }
                i4++;
                i = 0;
                i2 = 3;
            }
            if (i5 == 0) {
                break;
            }
            dogArray_I33.setTo(this.bestCorners);
            z = true;
            i = 0;
            i2 = 3;
        }
        return z;
    }

    void removeDuplicates(DogArray_I32 dogArray_I32) {
        for (int i = 0; i < dogArray_I32.size(); i++) {
            Point2D_I32 point2D_I32 = (Point2D_I32) this.contour.get(dogArray_I32.get(i));
            for (int size = dogArray_I32.size() - 1; size > i; size--) {
                Point2D_I32 point2D_I33 = (Point2D_I32) this.contour.get(dogArray_I32.get(size));
                if (point2D_I32.x == point2D_I33.x && point2D_I32.y == point2D_I33.y) {
                    dogArray_I32.remove(size);
                }
            }
        }
    }

    void computeSegmentEnergy(DogArray_I32 dogArray_I32) {
        if (this.energySegment.length < dogArray_I32.size()) {
            this.energySegment = new double[dogArray_I32.size()];
        }
        int size = dogArray_I32.size() - 1;
        int i = 0;
        while (true) {
            int i2 = i;
            int i3 = size;
            size = i2;
            if (size >= dogArray_I32.size()) {
                return;
            }
            this.energySegment[i3] = computeSegmentEnergy(dogArray_I32, i3, size);
            i = size + 1;
        }
    }

    protected double computeSegmentEnergy(DogArray_I32 dogArray_I32, int i, int i2) {
        int i3 = dogArray_I32.get(i);
        int i4 = dogArray_I32.get(i2);
        if (i3 == i4) {
            return 100000.0d;
        }
        Point2D_I32 point2D_I32 = (Point2D_I32) this.contour.get(i3);
        Point2D_I32 point2D_I33 = (Point2D_I32) this.contour.get(i4);
        LineParametric2D_F64 lineParametric2D_F64 = this.line;
        Point2D_F64 point2D_F64 = lineParametric2D_F64.p;
        int i5 = point2D_I32.x;
        point2D_F64.x = i5;
        int i6 = point2D_I32.y;
        point2D_F64.y = i6;
        lineParametric2D_F64.slope.setTo(point2D_I33.x - i5, point2D_I33.y - i6);
        int iCircularDistance = circularDistance(i3, i4);
        double dDistanceSq = 0.0d;
        for (int i7 = 1; i7 < iCircularDistance; i7++) {
            Point2D_I32 contour = getContour(i3 + 1 + i7);
            this.point.setTo(contour.x, contour.y);
            dDistanceSq += Distance2D_F64.distanceSq(this.line, this.point);
        }
        return (dDistanceSq + this.splitPenalty) / ((double) point2D_I32.distance2(point2D_I33));
    }

    protected Point2D_I32 getContour(int i) {
        List list = this.contour;
        return (Point2D_I32) list.get(i % list.size());
    }

    protected int circularDistance(int i, int i2) {
        return CircularIndex.distanceP(i, i2, this.contour.size());
    }
}
