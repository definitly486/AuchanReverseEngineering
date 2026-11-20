package com.scanflow.datacapture.barinternal.boofcv.alg.fiducial.qrcode;

import com.scanflow.datacapture.barinternal.boofcv.alg.fiducial.calib.squares.SquareGraph;
import com.scanflow.datacapture.barinternal.boofcv.alg.shapes.polygon.DetectPolygonBinaryGrayRefine;
import com.scanflow.datacapture.barinternal.boofcv.alg.shapes.polygon.DetectPolygonFromContour;
import com.scanflow.datacapture.barinternal.georegression.geometry.UtilLine2D_F64;
import com.scanflow.datacapture.barinternal.georegression.geometry.UtilPoint2D_F64;
import com.scanflow.datacapture.barinternal.georegression.struct.line.LineParametric2D_F64;
import com.scanflow.datacapture.barinternal.georegression.struct.line.LineSegment2D_F64;
import com.scanflow.datacapture.barinternal.georegression.struct.point.Point2D_F64;
import com.scanflow.datacapture.barinternal.georegression.struct.point.Vector2D_F64;
import com.scanflow.datacapture.barinternal.georegression.struct.shapes.Polygon2D_F64;
import com.scanflow.datacapture.barinternal.org.ddogleg.struct.DProcess;
import com.scanflow.datacapture.barinternal.org.ddogleg.struct.DogArray;
import com.scanflow.datacapture.barinternal.org.ddogleg.struct.Factory;
import java.io.PrintStream;
import java.util.List;

/* JADX INFO: loaded from: classes.dex */
public class QrCodePositionPatternDetector extends SquareLocatorPatternDetectorBase {
    int[] length;
    LineParametric2D_F64 parametric;
    protected DogArray positionPatterns;
    float[] samples;
    LineSegment2D_F64 segment;
    int[] type;

    public DogArray getPositionPatterns() {
        return this.positionPatterns;
    }

    public QrCodePositionPatternDetector(DetectPolygonBinaryGrayRefine detectPolygonBinaryGrayRefine) {
        super(detectPolygonBinaryGrayRefine);
        this.positionPatterns = new DogArray(new Factory() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.fiducial.qrcode.QrCodePositionPatternDetector$$ExternalSyntheticLambda0
            @Override // com.scanflow.datacapture.barinternal.org.ddogleg.struct.Factory
            public final Object newInstance() {
                return new PositionPatternNode();
            }
        }, new DProcess() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.fiducial.qrcode.QrCodePositionPatternDetector$$ExternalSyntheticLambda1
            @Override // com.scanflow.datacapture.barinternal.org.ddogleg.struct.DProcess
            public final void process(Object obj) {
                ((PositionPatternNode) obj).reset();
            }
        });
        this.segment = new LineSegment2D_F64();
        this.parametric = new LineParametric2D_F64();
        this.samples = new float[46];
        this.length = new int[12];
        this.type = new int[12];
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.alg.fiducial.qrcode.SquareLocatorPatternDetectorBase
    protected void findLocatorPatternsFromSquares() {
        squaresToPositionList();
    }

    private void squaresToPositionList() {
        this.positionPatterns.reset();
        List polygonInfo = this.squareDetector.getPolygonInfo();
        for (int i = 0; i < polygonInfo.size(); i++) {
            DetectPolygonFromContour.Info info = (DetectPolygonFromContour.Info) polygonInfo.get(i);
            double d = (info.edgeInside + info.edgeOutside) / 2.0d;
            if (checkPositionPatternAppearance(info.polygon, (float) d)) {
                this.squareDetector.refine(info);
                PositionPatternNode positionPatternNode = (PositionPatternNode) this.positionPatterns.grow();
                positionPatternNode.square = info.polygon;
                positionPatternNode.grayThreshold = d;
                SquareGraph.computeNodeInfo(positionPatternNode);
            }
        }
        PrintStream printStream = this.verbose;
        if (printStream != null) {
            printStream.printf("squares=%d position_pattern=%d\n", Integer.valueOf(this.squareDetector.getPolygonInfo().size()), Integer.valueOf(this.positionPatterns.size));
        }
    }

    boolean checkPositionPatternAppearance(Polygon2D_F64 polygon2D_F64, float f) {
        return checkLine(polygon2D_F64, f, 0) || checkLine(polygon2D_F64, f, 1);
    }

    private boolean checkLine(Polygon2D_F64 polygon2D_F64, float f, int i) {
        float[] fArr;
        int i2;
        UtilPoint2D_F64.mean(polygon2D_F64.get(i), polygon2D_F64.get((i + 1) % 4), this.segment.a);
        UtilPoint2D_F64.mean(polygon2D_F64.get((i + 2) % 4), polygon2D_F64.get((i + 3) % 4), this.segment.b);
        UtilLine2D_F64.convert(this.segment, this.parametric);
        float[] fArr2 = this.samples;
        int length = fArr2.length / 9;
        double length2 = (fArr2.length - (length * 2)) - 1;
        int i3 = 0;
        while (true) {
            fArr = this.samples;
            if (i3 >= fArr.length) {
                break;
            }
            double d = ((double) (i3 - length)) / length2;
            LineParametric2D_F64 lineParametric2D_F64 = this.parametric;
            Point2D_F64 point2D_F64 = lineParametric2D_F64.p;
            double d2 = point2D_F64.x;
            Vector2D_F64 vector2D_F64 = lineParametric2D_F64.slope;
            fArr[i3] = this.interpolate.get((float) (d2 + (vector2D_F64.x * d)), (float) (point2D_F64.y + (d * vector2D_F64.y)));
            i3++;
            length = length;
        }
        int i4 = fArr[0] < f ? 1 : 0;
        this.type[0] = i4 ^ 1;
        int i5 = 0;
        int i6 = 0;
        while (true) {
            float[] fArr3 = this.samples;
            if (i5 >= fArr3.length) {
                break;
            }
            int i7 = fArr3[i5] < f ? 1 : 0;
            if (i4 == i7) {
                int[] iArr = this.length;
                iArr[i6] = iArr[i6] + 1;
            } else {
                int[] iArr2 = this.type;
                if (i6 >= iArr2.length - 1) {
                    break;
                }
                i6++;
                iArr2[i6] = i7 ^ 1;
                this.length[i6] = 1;
                i4 = i7;
            }
            i5++;
        }
        int i8 = i6 + 1;
        if (i8 >= 5 && i8 <= 9) {
            for (int i9 = 0; i9 + 5 <= i8; i9++) {
                if (this.type[i9] == 0) {
                    int[] iArr3 = this.length;
                    int i10 = iArr3[i9];
                    int i11 = iArr3[i9 + 2];
                    int i12 = iArr3[i9 + 4];
                    int i13 = iArr3[i9 + 1];
                    int i14 = iArr3[i9 + 3];
                    if (i10 >= ((double) i13) * 0.4d && i10 <= i13 * 3 && i12 >= ((double) i14) * 0.4d && i12 <= i14 * 3 && i11 >= (i2 = i10 + i12) && i11 <= i2 * 2) {
                        return true;
                    }
                }
            }
        }
        return false;
    }
}
