package com.scanflow.datacapture.barinternal.boofcv.alg.shapes.polygon;

import com.scanflow.datacapture.barinternal.boofcv.alg.shapes.edge.SnapToLineEdge;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageGray;
import com.scanflow.datacapture.barinternal.georegression.geometry.UtilLine2D_F64;
import com.scanflow.datacapture.barinternal.georegression.metric.Intersection2D_F64;
import com.scanflow.datacapture.barinternal.georegression.struct.line.LineGeneral2D_F64;
import com.scanflow.datacapture.barinternal.georegression.struct.point.Point2D_F64;
import com.scanflow.datacapture.barinternal.georegression.struct.shapes.Polygon2D_F64;

/* JADX INFO: loaded from: classes.dex */
public class RefinePolygonToGrayLine implements RefinePolygonToGray {
    private double convergeTolPixels;
    private double cornerOffset;
    protected ImageGray image;
    private final Class imageType;
    private double maxCornerChangePixel;
    private int maxIterations;
    private final SnapToLineEdge snapToEdge;
    private LineGeneral2D_F64[] general = new LineGeneral2D_F64[0];
    private final Point2D_F64 adjA = new Point2D_F64();
    private final Point2D_F64 adjB = new Point2D_F64();
    private final Point2D_F64 tempA = new Point2D_F64();
    private final Point2D_F64 tempB = new Point2D_F64();
    private final LineGeneral2D_F64 before = new LineGeneral2D_F64();
    private final Polygon2D_F64 previous = new Polygon2D_F64(1);

    public RefinePolygonToGrayLine(double d, int i, int i2, int i3, double d2, double d3, Class cls) {
        this.cornerOffset = 2.0d;
        this.maxIterations = 10;
        this.convergeTolPixels = 0.01d;
        this.maxCornerChangePixel = 2.0d;
        this.cornerOffset = d;
        this.maxIterations = i3;
        this.convergeTolPixels = d2;
        this.maxCornerChangePixel = d3;
        this.snapToEdge = new SnapToLineEdge(i, i2, cls);
        this.imageType = cls;
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.alg.shapes.polygon.RefinePolygonToGray
    public void setImage(ImageGray imageGray) {
        this.image = imageGray;
        this.snapToEdge.setImage(imageGray);
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.alg.shapes.polygon.RefinePolygonToGray
    public boolean refine(Polygon2D_F64 polygon2D_F64, Polygon2D_F64 polygon2D_F65) {
        if (polygon2D_F64.size() != polygon2D_F65.size()) {
            throw new IllegalArgumentException("Input and output sides do not match. " + polygon2D_F64.size() + " " + polygon2D_F65.size());
        }
        int i = 0;
        if (checkShapeTooSmall(polygon2D_F64)) {
            return false;
        }
        if (this.general.length < polygon2D_F64.size()) {
            this.general = new LineGeneral2D_F64[polygon2D_F64.size()];
            while (true) {
                LineGeneral2D_F64[] lineGeneral2D_F64Arr = this.general;
                if (i >= lineGeneral2D_F64Arr.length) {
                    break;
                }
                lineGeneral2D_F64Arr[i] = new LineGeneral2D_F64();
                i++;
            }
        }
        return optimize(polygon2D_F64, polygon2D_F65);
    }

    private boolean checkShapeTooSmall(Polygon2D_F64 polygon2D_F64) {
        double d = (this.cornerOffset * 2.0d) + 2.0d;
        int i = 0;
        while (i < polygon2D_F64.size()) {
            int i2 = i + 1;
            if (polygon2D_F64.get(i).distance2(polygon2D_F64.get(i2 % polygon2D_F64.size())) < d * d) {
                return true;
            }
            i = i2;
        }
        return false;
    }

    /* JADX WARN: Code duplicated, block: B:25:0x00a9  */
    protected boolean optimize(Polygon2D_F64 polygon2D_F64, Polygon2D_F64 polygon2D_F65) {
        this.previous.setTo(polygon2D_F64);
        double d = this.convergeTolPixels;
        double d2 = d * d;
        int i = 0;
        while (i < polygon2D_F64.size()) {
            int i2 = i + 1;
            UtilLine2D_F64.convert(polygon2D_F64.get(i), polygon2D_F64.get(i2 % polygon2D_F64.size()), this.general[i]);
            i = i2;
        }
        boolean z = false;
        loop1: for (int i3 = 0; i3 < this.maxIterations; i3++) {
            int i4 = 0;
            while (i4 < this.previous.size()) {
                int i5 = i4 + 1;
                int size = i5 % this.previous.size();
                Point2D_F64 point2D_F64 = this.previous.get(i4);
                Point2D_F64 point2D_F65 = this.previous.get(size);
                this.before.setTo(this.general[i4]);
                if (optimize(point2D_F64, point2D_F65, this.general[i4])) {
                    int size2 = ((this.previous.size() + i4) - 1) % this.previous.size();
                    LineGeneral2D_F64[] lineGeneral2D_F64Arr = this.general;
                    if (Intersection2D_F64.intersection(lineGeneral2D_F64Arr[size2], lineGeneral2D_F64Arr[i4], this.tempA) != null) {
                        LineGeneral2D_F64[] lineGeneral2D_F64Arr2 = this.general;
                        if (Intersection2D_F64.intersection(lineGeneral2D_F64Arr2[i4], lineGeneral2D_F64Arr2[size], this.tempB) == null || this.tempA.distance(point2D_F64) > this.maxCornerChangePixel || this.tempB.distance(point2D_F65) > this.maxCornerChangePixel) {
                            this.general[i4].setTo(this.before);
                        } else {
                            z = true;
                        }
                    } else {
                        this.general[i4].setTo(this.before);
                    }
                } else {
                    this.general[i4].setTo(this.before);
                }
                i4 = i5;
            }
            if (!UtilShapePolygon.convert(this.general, polygon2D_F65)) {
                return false;
            }
            for (int i6 = 0; i6 < polygon2D_F65.size(); i6++) {
                if (polygon2D_F65.get(i6).distance2(this.previous.get(i6)) > d2) {
                    this.previous.setTo(polygon2D_F65);
                }
            }
            break loop1;
        }
        return z;
    }

    protected boolean optimize(Point2D_F64 point2D_F64, Point2D_F64 point2D_F65, LineGeneral2D_F64 lineGeneral2D_F64) {
        computeAdjustedEndPoints(point2D_F64, point2D_F65);
        return this.snapToEdge.refine(this.adjA, this.adjB, lineGeneral2D_F64);
    }

    private void computeAdjustedEndPoints(Point2D_F64 point2D_F64, Point2D_F64 point2D_F65) {
        double d = point2D_F65.x - point2D_F64.x;
        double d2 = point2D_F65.y - point2D_F64.y;
        double dSqrt = Math.sqrt((d * d) + (d2 * d2));
        double d3 = d / dSqrt;
        double d4 = d2 / dSqrt;
        Point2D_F64 point2D_F66 = this.adjA;
        double d5 = point2D_F64.x;
        double d6 = this.cornerOffset;
        point2D_F66.x = d5 + (d3 * d6);
        point2D_F66.y = point2D_F64.y + (d4 * d6);
        Point2D_F64 point2D_F67 = this.adjB;
        point2D_F67.x = point2D_F65.x - (d3 * d6);
        point2D_F67.y = point2D_F65.y - (d4 * d6);
    }
}
