package com.scanflow.datacapture.barinternal.boofcv.alg.shapes.polyline;

import com.scanflow.datacapture.barinternal.boofcv.misc.CircularIndex;
import com.scanflow.datacapture.barinternal.georegression.geometry.UtilLine2D_F64;
import com.scanflow.datacapture.barinternal.georegression.struct.line.LineGeneral2D_F64;
import com.scanflow.datacapture.barinternal.georegression.struct.line.LineSegment2D_F64;
import com.scanflow.datacapture.barinternal.georegression.struct.point.Point2D_I32;
import com.scanflow.datacapture.barinternal.org.ddogleg.struct.DogArray_I32;
import java.util.List;

/* JADX INFO: loaded from: classes.dex */
public class RefinePolyLineCorner {
    boolean looping;
    private int maxIterations;
    protected int searchRadius;
    private final int maxLineSamples = 20;
    private final LineSegment2D_F64 work = new LineSegment2D_F64();
    LineGeneral2D_F64 line0 = new LineGeneral2D_F64();
    LineGeneral2D_F64 line1 = new LineGeneral2D_F64();

    public RefinePolyLineCorner(boolean z, int i) {
        this.maxIterations = 10;
        this.looping = z;
        this.maxIterations = i;
    }

    public boolean fit(List list, DogArray_I32 dogArray_I32) {
        int i;
        int i2;
        if (dogArray_I32.size() < 3) {
            return false;
        }
        this.searchRadius = Math.min(6, Math.max(list.size() / 12, 3));
        if (this.looping) {
            i = dogArray_I32.size;
            i2 = 0;
        } else {
            i = dogArray_I32.size - 1;
            i2 = 1;
        }
        boolean z = true;
        for (int i3 = 0; i3 < this.maxIterations && z; i3++) {
            z = false;
            for (int i4 = i2; i4 < i; i4++) {
                int iOptimize = optimize(list, dogArray_I32.get(CircularIndex.minusPOffset(i4, 1, dogArray_I32.size())), dogArray_I32.get(i4), dogArray_I32.get(CircularIndex.plusPOffset(i4, 1, dogArray_I32.size())));
                if (iOptimize != dogArray_I32.get(i4)) {
                    dogArray_I32.set(i4, iOptimize);
                    z = true;
                }
            }
        }
        return true;
    }

    protected int optimize(List list, int i, int i2, int i3) {
        RefinePolyLineCorner refinePolyLineCorner = this;
        double dComputeCost = refinePolyLineCorner.computeCost(list, i, i2, i3, 0);
        int i4 = 0;
        int i5 = -refinePolyLineCorner.searchRadius;
        while (i5 <= refinePolyLineCorner.searchRadius) {
            if (i5 != 0) {
                double dComputeCost2 = refinePolyLineCorner.computeCost(list, i, i2, i3, i5);
                if (dComputeCost2 < dComputeCost) {
                    i4 = i5;
                    dComputeCost = dComputeCost2;
                }
            } else if (i4 != 0) {
                break;
            }
            i5++;
            refinePolyLineCorner = this;
        }
        return CircularIndex.addOffset(i2, i4, list.size());
    }

    protected double computeCost(List list, int i, int i2, int i3, int i4) {
        int iAddOffset = CircularIndex.addOffset(i2, i4, list.size());
        createLine(i, iAddOffset, list, this.line0);
        createLine(iAddOffset, i3, list, this.line1);
        return distanceSum(this.line0, i, iAddOffset, list) + distanceSum(this.line1, iAddOffset, i3, list);
    }

    protected double distanceSum(LineGeneral2D_F64 lineGeneral2D_F64, int i, int i2, List list) {
        int i3 = 0;
        double dDistance = 0.0d;
        if (i < i2) {
            int i4 = i2 - i;
            int iMin = Math.min(20, i4 + 1);
            while (i3 < iMin) {
                dDistance += distance(lineGeneral2D_F64, (Point2D_I32) list.get(((i3 * i4) / (iMin - 1)) + i));
                i3++;
            }
            return dDistance;
        }
        int size = list.size() - i;
        int i5 = i2 + 1;
        int i6 = i2 + size + 1;
        int iMin2 = Math.min(20, i6);
        int i7 = (iMin2 * size) / i6;
        int i8 = (iMin2 * i5) / i6;
        for (int i9 = 0; i9 < i7; i9++) {
            dDistance += distance(lineGeneral2D_F64, (Point2D_I32) list.get(((i9 * size) / (iMin2 - 1)) + i));
        }
        while (i3 < i8) {
            dDistance += distance(lineGeneral2D_F64, (Point2D_I32) list.get((i3 * i5) / (iMin2 - 1)));
            i3++;
        }
        return dDistance;
    }

    protected static double distance(LineGeneral2D_F64 lineGeneral2D_F64, Point2D_I32 point2D_I32) {
        return Math.abs((lineGeneral2D_F64.A * ((double) point2D_I32.x)) + (lineGeneral2D_F64.B * ((double) point2D_I32.y)) + lineGeneral2D_F64.C);
    }

    private void createLine(int i, int i2, List list, LineGeneral2D_F64 lineGeneral2D_F64) {
        if (i2 < 0) {
            System.out.println("SHIT");
        }
        Point2D_I32 point2D_I32 = (Point2D_I32) list.get(i);
        Point2D_I32 point2D_I33 = (Point2D_I32) list.get(i2);
        this.work.a.setTo(point2D_I32.x, point2D_I32.y);
        this.work.b.setTo(point2D_I33.x, point2D_I33.y);
        UtilLine2D_F64.convert(this.work, lineGeneral2D_F64);
        lineGeneral2D_F64.normalize();
    }
}
