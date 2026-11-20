package com.scanflow.datacapture.barinternal.boofcv.alg.shapes.polyline;

import com.scanflow.datacapture.barinternal.boofcv.alg.fiducial.qrcode.QrCodeBinaryGridToPixel$$ExternalSyntheticLambda2;
import com.scanflow.datacapture.barinternal.boofcv.alg.shapes.polygon.RefinePolygonToContour$$ExternalSyntheticLambda0;
import com.scanflow.datacapture.barinternal.boofcv.misc.CircularIndex;
import com.scanflow.datacapture.barinternal.georegression.fitting.line.FitLine_F64;
import com.scanflow.datacapture.barinternal.georegression.geometry.UtilLine2D_F64;
import com.scanflow.datacapture.barinternal.georegression.geometry.UtilPoint2D_F64;
import com.scanflow.datacapture.barinternal.georegression.metric.Intersection2D_F64;
import com.scanflow.datacapture.barinternal.georegression.struct.line.LineGeneral2D_F64;
import com.scanflow.datacapture.barinternal.georegression.struct.line.LinePolar2D_F64;
import com.scanflow.datacapture.barinternal.georegression.struct.point.Point2D_F64;
import com.scanflow.datacapture.barinternal.georegression.struct.point.Point2D_I32;
import com.scanflow.datacapture.barinternal.org.ddogleg.struct.DogArray;
import com.scanflow.datacapture.barinternal.org.ddogleg.struct.DogArray_I32;
import java.util.Arrays;
import java.util.List;

/* JADX INFO: loaded from: classes.dex */
public class FitLinesToContour {
    int anchor0;
    int anchor1;
    List contour;
    int maxSamples = 20;
    int maxIterations = 5;
    int minimumLineLength = 4;
    DogArray lines = new DogArray(new RefinePolygonToContour$$ExternalSyntheticLambda0());
    DogArray pointsFit = new DogArray(new QrCodeBinaryGridToPixel$$ExternalSyntheticLambda2());
    private final LinePolar2D_F64 linePolar = new LinePolar2D_F64();
    private final Point2D_F64 intersection = new Point2D_F64();
    private final DogArray_I32 workCorners = new DogArray_I32();
    boolean verbose = false;
    DogArray_I32 skippedCorners = new DogArray_I32();

    public void setContour(List list) {
        this.contour = list;
    }

    public boolean fitAnchored(int i, int i2, DogArray_I32 dogArray_I32, DogArray_I32 dogArray_I33) {
        this.anchor0 = i;
        this.anchor1 = i2;
        int size = i == i2 ? dogArray_I32.size() : CircularIndex.distanceP(i, i2, dogArray_I32.size);
        if (size < 2) {
            throw new RuntimeException("The one line is anchored and can't be optimized");
        }
        this.lines.resize(size);
        if (this.verbose) {
            System.out.println("ENTER FitLinesToContour");
        }
        this.workCorners.setTo(dogArray_I32);
        for (int i3 = 0; i3 < this.maxIterations; i3++) {
            if (!fitLinesUsingCorners(size, this.workCorners) || !linesIntoCorners(size, this.workCorners) || !sanityCheckCornerOrder(size, this.workCorners)) {
                return false;
            }
        }
        if (this.verbose) {
            System.out.println("EXIT FitLinesToContour. " + dogArray_I32.size() + "  " + this.workCorners.size());
        }
        dogArray_I33.setTo(this.workCorners);
        return true;
    }

    boolean sanityCheckCornerOrder(int i, DogArray_I32 dogArray_I32) {
        int i2 = dogArray_I32.get(this.anchor0);
        int i3 = 0;
        int i4 = 1;
        while (i4 < i) {
            int iDistanceP = CircularIndex.distanceP(i2, dogArray_I32.get(CircularIndex.addOffset(this.anchor0, i4, dogArray_I32.size())), this.contour.size());
            if (iDistanceP < i3) {
                return false;
            }
            i4++;
            i3 = iDistanceP;
        }
        return true;
    }

    /* JADX WARN: Code duplicated, block: B:25:0x0082  */
    /* JADX WARN: Code duplicated, block: B:56:0x0087 A[SYNTHETIC] */
    boolean linesIntoCorners(int i, DogArray_I32 dogArray_I32) {
        this.skippedCorners.reset();
        int i2 = dogArray_I32.get(this.anchor0);
        int i3 = 1;
        while (true) {
            boolean z = false;
            if (i3 >= i) {
                break;
            }
            LineGeneral2D_F64 lineGeneral2D_F64 = (LineGeneral2D_F64) this.lines.get(i3 - 1);
            LineGeneral2D_F64 lineGeneral2D_F65 = (LineGeneral2D_F64) this.lines.get(i3);
            int iAddOffset = CircularIndex.addOffset(this.anchor0, i3, dogArray_I32.size);
            if (Intersection2D_F64.intersection(lineGeneral2D_F64, lineGeneral2D_F65, this.intersection) == null) {
                if (this.verbose) {
                    System.out.println("  SKIPPING no intersection");
                }
            } else {
                int iClosestPoint = closestPoint(this.intersection);
                if (iClosestPoint != i2) {
                    Point2D_I32 point2D_I32 = (Point2D_I32) this.contour.get(i2);
                    Point2D_I32 point2D_I33 = (Point2D_I32) this.contour.get(iClosestPoint);
                    if (point2D_I32.x == point2D_I33.x && point2D_I32.y == point2D_I33.y) {
                        if (this.verbose) {
                            System.out.println("  SKIPPING duplicate coordinate");
                        }
                    } else {
                        dogArray_I32.set(iAddOffset, iClosestPoint);
                        i2 = iClosestPoint;
                    }
                    if (z) {
                        this.skippedCorners.add(iAddOffset);
                    }
                    i3++;
                } else if (this.verbose) {
                    System.out.println("  SKIPPING duplicate corner index");
                }
            }
            z = true;
            if (z) {
                this.skippedCorners.add(iAddOffset);
            }
            i3++;
        }
        int iAddOffset2 = CircularIndex.addOffset(this.anchor0, i, dogArray_I32.size);
        Point2D_I32 point2D_I34 = (Point2D_I32) this.contour.get(i2);
        Point2D_I32 point2D_I35 = (Point2D_I32) this.contour.get(dogArray_I32.get(iAddOffset2));
        if (point2D_I34.x == point2D_I35.x && point2D_I34.y == point2D_I35.y) {
            this.skippedCorners.add(iAddOffset2);
        }
        DogArray_I32 dogArray_I33 = this.skippedCorners;
        Arrays.sort(dogArray_I33.data, 0, dogArray_I33.size);
        for (int i4 = this.skippedCorners.size - 1; i4 >= 0; i4--) {
            int i5 = this.skippedCorners.get(i4);
            dogArray_I32.remove(i5);
            int i6 = this.anchor0;
            if (i6 >= i5) {
                this.anchor0 = i6 - 1;
            }
            int i7 = this.anchor1;
            if (i7 >= i5) {
                this.anchor1 = i7 - 1;
            }
        }
        int i8 = i - this.skippedCorners.size;
        int i9 = 0;
        while (i9 < i8) {
            int iAddOffset3 = CircularIndex.addOffset(this.anchor0, i9, dogArray_I32.size);
            i9++;
            int iAddOffset4 = CircularIndex.addOffset(this.anchor0, i9, dogArray_I32.size);
            Point2D_I32 point2D_I36 = (Point2D_I32) this.contour.get(dogArray_I32.get(iAddOffset3));
            Point2D_I32 point2D_I37 = (Point2D_I32) this.contour.get(dogArray_I32.get(iAddOffset4));
            if (point2D_I36.x == point2D_I37.x && point2D_I36.y == point2D_I37.y) {
                throw new RuntimeException("Well I screwed up");
            }
        }
        return dogArray_I32.size() >= 3;
    }

    boolean fitLinesUsingCorners(int i, DogArray_I32 dogArray_I32) {
        for (int i2 = 1; i2 <= i; i2++) {
            int i3 = i2 - 1;
            int i4 = dogArray_I32.get(CircularIndex.addOffset(this.anchor0, i3, dogArray_I32.size));
            int i5 = dogArray_I32.get(CircularIndex.addOffset(this.anchor0, i2, dogArray_I32.size));
            if (i4 == i5 || !fitLine(i4, i5, (LineGeneral2D_F64) this.lines.get(i3))) {
                return false;
            }
            LineGeneral2D_F64 lineGeneral2D_F64 = (LineGeneral2D_F64) this.lines.get(i3);
            if (Double.isNaN(lineGeneral2D_F64.A) || Double.isNaN(lineGeneral2D_F64.B) || Double.isNaN(lineGeneral2D_F64.C)) {
                throw new RuntimeException("This should be impossible");
            }
        }
        return true;
    }

    boolean fitLine(int i, int i2, LineGeneral2D_F64 lineGeneral2D_F64) {
        int iDistanceP = CircularIndex.distanceP(i, i2, this.contour.size());
        boolean z = false;
        if (iDistanceP < this.minimumLineLength) {
            return false;
        }
        Point2D_I32 point2D_I32 = (Point2D_I32) this.contour.get(i);
        Point2D_I32 point2D_I33 = (Point2D_I32) this.contour.get(i2);
        double dDistance = point2D_I32.distance(point2D_I33);
        double d = ((double) (point2D_I33.x + point2D_I32.x)) / 2.0d;
        double d2 = ((double) (point2D_I33.y + point2D_I32.y)) / 2.0d;
        int iMin = Math.min(this.maxSamples, iDistanceP);
        this.pointsFit.reset();
        int i3 = 0;
        while (i3 < iMin) {
            List list = this.contour;
            Point2D_I32 point2D_I34 = (Point2D_I32) list.get(CircularIndex.addOffset(i, ((iDistanceP - 1) * i3) / (iMin - 1), list.size()));
            Point2D_F64 point2D_F64 = (Point2D_F64) this.pointsFit.grow();
            double d3 = dDistance;
            point2D_F64.x = (((double) point2D_I34.x) - d) / d3;
            point2D_F64.y = (((double) point2D_I34.y) - d2) / d3;
            i3++;
            z = z;
            dDistance = d3;
        }
        boolean z2 = z;
        double d4 = dDistance;
        if (FitLine_F64.polar(this.pointsFit.toList(), this.linePolar) == null) {
            return z2;
        }
        UtilLine2D_F64.convert(this.linePolar, lineGeneral2D_F64);
        lineGeneral2D_F64.C = ((d4 * lineGeneral2D_F64.C) - (d * lineGeneral2D_F64.A)) - (d2 * lineGeneral2D_F64.B);
        return true;
    }

    int closestPoint(Point2D_F64 point2D_F64) {
        double d = Double.MAX_VALUE;
        int i = -1;
        for (int i2 = 0; i2 < this.contour.size(); i2++) {
            Point2D_I32 point2D_I32 = (Point2D_I32) this.contour.get(i2);
            double dDistanceSq = UtilPoint2D_F64.distanceSq(point2D_F64.x, point2D_F64.y, point2D_I32.x, point2D_I32.y);
            if (dDistanceSq < d) {
                i = i2;
                d = dDistanceSq;
            }
        }
        return i;
    }
}
