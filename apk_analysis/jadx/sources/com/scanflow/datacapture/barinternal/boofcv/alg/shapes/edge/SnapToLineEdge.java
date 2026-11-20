package com.scanflow.datacapture.barinternal.boofcv.alg.shapes.edge;

import com.scanflow.datacapture.barinternal.boofcv.alg.fiducial.qrcode.QrCodeBinaryGridToPixel$$ExternalSyntheticLambda2;
import com.scanflow.datacapture.barinternal.georegression.fitting.line.FitLine_F64;
import com.scanflow.datacapture.barinternal.georegression.geometry.UtilLine2D_F64;
import com.scanflow.datacapture.barinternal.georegression.struct.line.LineGeneral2D_F64;
import com.scanflow.datacapture.barinternal.georegression.struct.line.LinePolar2D_F64;
import com.scanflow.datacapture.barinternal.georegression.struct.point.Point2D_F64;
import com.scanflow.datacapture.barinternal.org.ddogleg.struct.DogArray;
import com.scanflow.datacapture.barinternal.org.ddogleg.struct.DogArray_F64;

/* JADX INFO: loaded from: classes.dex */
public class SnapToLineEdge extends BaseIntegralEdge {
    protected Point2D_F64 center;
    protected int lineSamples;
    protected double localScale;
    private final LinePolar2D_F64 polar;
    protected int radialSamples;
    protected DogArray samplePts;
    protected DogArray_F64 weights;

    public SnapToLineEdge(int i, int i2, Class cls) {
        super(cls);
        this.polar = new LinePolar2D_F64();
        this.weights = new DogArray_F64();
        this.samplePts = new DogArray(new QrCodeBinaryGridToPixel$$ExternalSyntheticLambda2());
        this.center = new Point2D_F64();
        if (i2 < 1) {
            throw new IllegalArgumentException("Tangential samples must be >= 1 or else it won't work");
        }
        this.lineSamples = i;
        this.radialSamples = i2;
    }

    public boolean refine(Point2D_F64 point2D_F64, Point2D_F64 point2D_F65, LineGeneral2D_F64 lineGeneral2D_F64) {
        Point2D_F64 point2D_F66 = this.center;
        point2D_F66.x = (point2D_F64.x + point2D_F65.x) / 2.0d;
        point2D_F66.y = (point2D_F64.y + point2D_F65.y) / 2.0d;
        this.localScale = point2D_F64.distance(point2D_F66);
        double d = point2D_F65.x - point2D_F64.x;
        double d2 = point2D_F65.y - point2D_F64.y;
        double dSqrt = Math.sqrt((d * d) + (d2 * d2));
        computePointsAndWeights(d, d2, point2D_F64.x, point2D_F64.y, d2 / dSqrt, (-d) / dSqrt);
        if (this.samplePts.size() < 4) {
            return false;
        }
        if (FitLine_F64.polar(this.samplePts.toList(), this.weights.data, this.polar) == null) {
            throw new RuntimeException("All weights were zero, bug some place");
        }
        UtilLine2D_F64.convert(this.polar, lineGeneral2D_F64);
        localToGlobal(lineGeneral2D_F64);
        return true;
    }

    protected void computePointsAndWeights(double d, double d2, double d3, double d4, double d5, double d6) {
        int i;
        int i2;
        double d7;
        SnapToLineEdge snapToLineEdge = this;
        snapToLineEdge.samplePts.reset();
        snapToLineEdge.weights.reset();
        int i3 = snapToLineEdge.radialSamples * 2;
        int i4 = i3 + 1;
        double d8 = i3 + 2;
        double d9 = d8 * d5;
        double d10 = d8 * d6;
        int i5 = 0;
        while (true) {
            int i6 = snapToLineEdge.lineSamples;
            if (i5 >= i6) {
                return;
            }
            double d11 = ((double) i5) / ((double) (i6 - 1));
            double d12 = (d3 + (d * d11)) - (d9 / 2.0d);
            double d13 = (d4 + (d11 * d2)) - (d10 / 2.0d);
            if (snapToLineEdge.integral.isInside(d12, d13)) {
                int i7 = i4;
                if (snapToLineEdge.integral.isInside(d12 + d9, d13 + d10)) {
                    double d14 = d12 + d5;
                    double d15 = d13 + d6;
                    double dCompute = snapToLineEdge.integral.compute(d12, d13, d14, d15);
                    i2 = i7;
                    int i8 = 0;
                    while (true) {
                        double d16 = d14;
                        double d17 = d15;
                        if (i8 >= i2 || (i8 == i3 && !snapToLineEdge.integral.isInside(d16 + d5, d17 + d6))) {
                            break;
                        }
                        d14 = d16 + d5;
                        d15 = d17 + d6;
                        double dCompute2 = snapToLineEdge.integral.compute(d16, d17, d14, d15);
                        double d18 = dCompute - dCompute2;
                        if (d18 < 0.0d) {
                            d18 = -d18;
                        }
                        if (d18 > 0.0d) {
                            snapToLineEdge.weights.add(d18);
                            Point2D_F64 point2D_F64 = (Point2D_F64) snapToLineEdge.samplePts.grow();
                            Point2D_F64 point2D_F65 = snapToLineEdge.center;
                            double d19 = d16 - point2D_F65.x;
                            double d20 = snapToLineEdge.localScale;
                            point2D_F64.setTo(d19 / d20, (d17 - point2D_F65.y) / d20);
                        }
                        i8++;
                        snapToLineEdge = this;
                        dCompute = dCompute2;
                        i3 = i3;
                        d10 = d10;
                    }
                    i = i3;
                } else {
                    i = i3;
                    d7 = d10;
                    i2 = i7;
                }
                i5++;
                snapToLineEdge = this;
                i4 = i2;
                i3 = i;
                d10 = d7;
            } else {
                i = i3;
                i2 = i4;
            }
            d7 = d10;
            i5++;
            snapToLineEdge = this;
            i4 = i2;
            i3 = i;
            d10 = d7;
        }
    }

    protected void localToGlobal(LineGeneral2D_F64 lineGeneral2D_F64) {
        double d = this.localScale * lineGeneral2D_F64.C;
        Point2D_F64 point2D_F64 = this.center;
        lineGeneral2D_F64.C = (d - (point2D_F64.x * lineGeneral2D_F64.A)) - (point2D_F64.y * lineGeneral2D_F64.B);
    }
}
