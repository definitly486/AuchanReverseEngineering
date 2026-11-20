package com.scanflow.datacapture.barinternal.boofcv.alg.shapes.polygon;

import com.scanflow.datacapture.barinternal.boofcv.abst.filter.binary.BinaryContourFinder;
import com.scanflow.datacapture.barinternal.boofcv.abst.filter.binary.BinaryContourInterface;
import com.scanflow.datacapture.barinternal.boofcv.abst.shapes.polyline.PointsToPolyline;
import com.scanflow.datacapture.barinternal.boofcv.alg.InputSanityCheck;
import com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.ContourPacked;
import com.scanflow.datacapture.barinternal.boofcv.misc.MovingAverage;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayU8;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageGray;
import com.scanflow.datacapture.barinternal.georegression.geometry.UtilPolygons2D_I32;
import com.scanflow.datacapture.barinternal.georegression.metric.Area2D_F64;
import com.scanflow.datacapture.barinternal.georegression.struct.point.Point2D_F32;
import com.scanflow.datacapture.barinternal.georegression.struct.point.Point2D_F64;
import com.scanflow.datacapture.barinternal.georegression.struct.point.Point2D_I32;
import com.scanflow.datacapture.barinternal.georegression.struct.shapes.Polygon2D_F64;
import com.scanflow.datacapture.barinternal.org.ddogleg.struct.DogArray;
import com.scanflow.datacapture.barinternal.org.ddogleg.struct.DogArray_B;
import com.scanflow.datacapture.barinternal.org.ddogleg.struct.DogArray_I32;
import com.scanflow.datacapture.barinternal.org.ddogleg.struct.Factory;
import java.io.PrintStream;
import java.util.ArrayList;
import java.util.List;

/* JADX INFO: loaded from: classes.dex */
public class DetectPolygonFromContour {
    private boolean canTouchBorder;
    private ContourEdgeIntensity contourEdgeIntensity;
    double contourEdgeThreshold;
    private BinaryContourFinder contourFinder;
    private BinaryContourInterface.Padded contourPadded;
    private PointsToPolyline contourToPolyline;
    int imageHeight;
    int imageWidth;
    private Class inputType;
    private double minimumArea;
    private int minimumContourPixels;
    private boolean outputClockwiseUpY;
    private Polygon2D_F64 polygonWork;
    private final DogArray_I32 splits = new DogArray_I32();
    DogArray foundInfo = new DogArray(new Factory() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.shapes.polygon.DetectPolygonFromContour$$ExternalSyntheticLambda0
        @Override // com.scanflow.datacapture.barinternal.org.ddogleg.struct.Factory
        public final Object newInstance() {
            return new DetectPolygonFromContour.Info();
        }
    });
    private final Polygon2D_F64 polygonDistorted = new Polygon2D_F64();
    protected Point2D_F32 distortedPoint = new Point2D_F32();
    private final DogArray undistorted = new DogArray(new Factory() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.shapes.polygon.DetectPolygonFromContour$$ExternalSyntheticLambda1
        @Override // com.scanflow.datacapture.barinternal.org.ddogleg.struct.Factory
        public final Object newInstance() {
            return new Point2D_I32();
        }
    });
    private final DogArray_B borderCorners = new DogArray_B();
    private final DogArray contourTmp = new DogArray(new Factory() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.shapes.polygon.DetectPolygonFromContour$$ExternalSyntheticLambda1
        @Override // com.scanflow.datacapture.barinternal.org.ddogleg.struct.Factory
        public final Object newInstance() {
            return new Point2D_I32();
        }
    });
    List polygonPixel = new ArrayList();
    MovingAverage milliContour = new MovingAverage(0.8d);
    MovingAverage milliShapes = new MovingAverage(0.8d);
    PrintStream verbose = null;

    public BinaryContourFinder getContourFinder() {
        return this.contourFinder;
    }

    public DogArray getFoundInfo() {
        return this.foundInfo;
    }

    public boolean isOutputClockwiseUpY() {
        return this.outputClockwiseUpY;
    }

    public void setOutputClockwiseUpY(boolean z) {
        this.outputClockwiseUpY = z;
    }

    public Class getInputType() {
        return this.inputType;
    }

    public DetectPolygonFromContour(PointsToPolyline pointsToPolyline, boolean z, boolean z2, double d, double d2, BinaryContourFinder binaryContourFinder, Class cls) {
        this.polygonWork = new Polygon2D_F64();
        this.contourToPolyline = pointsToPolyline;
        this.outputClockwiseUpY = z;
        this.canTouchBorder = z2;
        this.contourEdgeThreshold = d;
        this.contourFinder = binaryContourFinder;
        this.inputType = cls;
        if (binaryContourFinder instanceof BinaryContourInterface.Padded) {
            this.contourPadded = (BinaryContourInterface.Padded) binaryContourFinder;
        }
        if (!pointsToPolyline.isLoop()) {
            throw new IllegalArgumentException("ContourToPolygon must be configured for loops");
        }
        if (d > 0.0d) {
            this.contourEdgeIntensity = new ContourEdgeIntensity(30, 1, d2, cls);
        }
        this.polygonWork = new Polygon2D_F64(1);
    }

    public void process(ImageGray imageGray, GrayU8 grayU8) {
        DogArray dogArray;
        PrintStream printStream = this.verbose;
        if (printStream != null) {
            printStream.println("ENTER  DetectPolygonFromContour.process()");
        }
        BinaryContourInterface.Padded padded = this.contourPadded;
        if (padded != null && !padded.isCreatePaddedCopy()) {
            if (imageGray.width + 2 != grayU8.width || imageGray.height + 2 != grayU8.height) {
                throw new IllegalArgumentException("Including padding, expected a binary image with shape " + (imageGray.width + 2) + "x" + (imageGray.height + 2));
            }
        } else {
            InputSanityCheck.checkSameShape(imageGray, grayU8);
        }
        int i = this.imageWidth;
        int i2 = imageGray.width;
        if (i != i2 || this.imageHeight != imageGray.height) {
            configure(i2, imageGray.height);
        }
        int i3 = 0;
        while (true) {
            dogArray = this.foundInfo;
            if (i3 >= dogArray.size) {
                break;
            }
            ((Info) dogArray.get(i3)).reset();
            i3++;
        }
        dogArray.reset();
        ContourEdgeIntensity contourEdgeIntensity = this.contourEdgeIntensity;
        if (contourEdgeIntensity != null) {
            contourEdgeIntensity.setImage(imageGray);
        }
        long jNanoTime = System.nanoTime();
        this.contourFinder.process(grayU8);
        long jNanoTime2 = System.nanoTime();
        findCandidateShapes();
        double d = (jNanoTime2 - jNanoTime) * 1.0E-6d;
        double dNanoTime = (System.nanoTime() - jNanoTime2) * 1.0E-6d;
        this.milliContour.update(d);
        this.milliShapes.update(dNanoTime);
        PrintStream printStream2 = this.verbose;
        if (printStream2 != null) {
            printStream2.println("EXIT  DetectPolygonFromContour.process()");
        }
    }

    private void configure(int i, int i2) {
        this.imageWidth = i;
        this.imageHeight = i2;
        int iComputeNegMaxI = this.contourFinder.getMinContour(null).computeNegMaxI(Math.sqrt(i * i2));
        this.minimumContourPixels = iComputeNegMaxI;
        int iMax = Math.max(4, iComputeNegMaxI);
        this.minimumContourPixels = iMax;
        this.minimumArea = Math.pow(((double) iMax) / 4.0d, 2.0d);
    }

    /* JADX WARN: Code duplicated, block: B:40:0x00ea A[PHI: r6 r8
      0x00ea: PHI (r6v6 float) = (r6v5 float), (r6v7 float) binds: [B:32:0x00d2, B:36:0x00dd] A[DONT_GENERATE, DONT_INLINE]
      0x00ea: PHI (r8v2 float) = (r8v1 float), (r8v10 float) binds: [B:32:0x00d2, B:36:0x00dd] A[DONT_GENERATE, DONT_INLINE]] */
    /* JADX WARN: Code duplicated, block: B:42:0x00ee  */
    /* JADX WARN: Code duplicated, block: B:46:0x011a A[LOOP:2: B:44:0x0112->B:46:0x011a, LOOP_END] */
    /* JADX WARN: Code duplicated, block: B:49:0x015e  */
    /* JADX WARN: Code duplicated, block: B:50:0x0166  */
    /* JADX WARN: Code duplicated, block: B:53:0x0177  */
    /* JADX WARN: Code duplicated, block: B:55:0x017b  */
    /* JADX WARN: Code duplicated, block: B:56:0x0181  */
    /* JADX WARN: Code duplicated, block: B:69:0x01b4 A[SYNTHETIC] */
    private void findCandidateShapes() {
        float edgeInsideAverage;
        float edgeOutsideAverage;
        int i;
        float f;
        PrintStream printStream;
        List contours = this.contourFinder.getContours();
        for (int i2 = 0; i2 < contours.size(); i2++) {
            ContourPacked contourPacked = (ContourPacked) contours.get(i2);
            this.contourTmp.reset();
            this.contourFinder.loadContour(contourPacked.externalIndex, this.contourTmp);
            DogArray dogArray = this.contourTmp;
            if (dogArray.size >= this.minimumContourPixels) {
                boolean z = touchesBorder(dogArray.toList());
                if (!this.canTouchBorder && z) {
                    PrintStream printStream2 = this.verbose;
                    if (printStream2 != null) {
                        printStream2.println("rejected polygon, touched border");
                    }
                } else {
                    ContourEdgeIntensity contourEdgeIntensity = this.contourEdgeIntensity;
                    if (contourEdgeIntensity != null) {
                        contourEdgeIntensity.process(this.contourTmp.toList(), true);
                        edgeInsideAverage = this.contourEdgeIntensity.getEdgeInsideAverage();
                        edgeOutsideAverage = this.contourEdgeIntensity.getEdgeOutsideAverage();
                        if (Math.abs(edgeOutsideAverage - edgeInsideAverage) < this.contourEdgeThreshold) {
                            PrintStream printStream3 = this.verbose;
                            if (printStream3 != null) {
                                printStream3.println("rejected polygon. contour edge intensity");
                            }
                        }
                    } else {
                        edgeInsideAverage = -1.0f;
                        edgeOutsideAverage = -1.0f;
                    }
                    List list = this.contourTmp.toList();
                    if (!this.contourToPolyline.process(list, this.splits)) {
                        PrintStream printStream4 = this.verbose;
                        if (printStream4 != null) {
                            printStream4.println("rejected polygon initial fit failed. contour size = " + this.contourTmp.size());
                        }
                    } else {
                        this.polygonPixel.clear();
                        int i3 = 0;
                        while (true) {
                            DogArray_I32 dogArray_I32 = this.splits;
                            if (i3 >= dogArray_I32.size) {
                                break;
                            }
                            this.polygonPixel.add((Point2D_I32) list.get(dogArray_I32.get(i3)));
                            i3++;
                        }
                        boolean zIsCCW = UtilPolygons2D_I32.isCCW(this.polygonPixel);
                        if (this.contourEdgeIntensity == null) {
                            if (this.outputClockwiseUpY == zIsCCW) {
                                DogArray_I32 dogArray_I33 = this.splits;
                                flip(dogArray_I33.data, dogArray_I33.size);
                            }
                            this.polygonWork.vertexes.resize(this.splits.size());
                            this.polygonDistorted.vertexes.resize(this.splits.size());
                            i = 0;
                            while (i < this.splits.size()) {
                                Point2D_I32 point2D_I32 = (Point2D_I32) list.get(this.splits.get(i));
                                Point2D_I32 point2D_I33 = (Point2D_I32) this.contourTmp.get(this.splits.get(i));
                                this.polygonWork.get(i).setTo(point2D_I32.x, point2D_I32.y);
                                this.polygonDistorted.get(i).setTo(point2D_I33.x, point2D_I33.y);
                                i++;
                                edgeOutsideAverage = edgeOutsideAverage;
                            }
                            f = edgeOutsideAverage;
                            if (z) {
                                determineCornersOnBorder(this.polygonDistorted, this.borderCorners);
                            } else {
                                this.borderCorners.resize(0);
                            }
                            if (Area2D_F64.polygonSimple(this.polygonWork) < this.minimumArea) {
                                printStream = this.verbose;
                                if (printStream != null) {
                                    printStream.println("Rejected area");
                                }
                            } else {
                                Info info = (Info) this.foundInfo.grow();
                                info.splits.setTo(this.splits);
                                info.contourTouchesBorder = z;
                                info.external = true;
                                info.edgeInside = edgeInsideAverage;
                                info.edgeOutside = f;
                                info.contour = contourPacked;
                                info.polygon.setTo(this.polygonWork);
                                info.polygonDistorted.setTo(this.polygonDistorted);
                                info.borderCorners.setTo(this.borderCorners);
                            }
                        } else {
                            if (!zIsCCW) {
                                float f2 = edgeOutsideAverage;
                                edgeOutsideAverage = edgeInsideAverage;
                                edgeInsideAverage = f2;
                            }
                            if (edgeInsideAverage > edgeOutsideAverage) {
                                PrintStream printStream5 = this.verbose;
                                if (printStream5 != null) {
                                    printStream5.println("White blob. Rejected");
                                }
                            } else {
                                if (this.outputClockwiseUpY == zIsCCW) {
                                    DogArray_I32 dogArray_I34 = this.splits;
                                    flip(dogArray_I34.data, dogArray_I34.size);
                                }
                                this.polygonWork.vertexes.resize(this.splits.size());
                                this.polygonDistorted.vertexes.resize(this.splits.size());
                                i = 0;
                                while (i < this.splits.size()) {
                                    Point2D_I32 point2D_I34 = (Point2D_I32) list.get(this.splits.get(i));
                                    Point2D_I32 point2D_I35 = (Point2D_I32) this.contourTmp.get(this.splits.get(i));
                                    this.polygonWork.get(i).setTo(point2D_I34.x, point2D_I34.y);
                                    this.polygonDistorted.get(i).setTo(point2D_I35.x, point2D_I35.y);
                                    i++;
                                    edgeOutsideAverage = edgeOutsideAverage;
                                }
                                f = edgeOutsideAverage;
                                if (z) {
                                    determineCornersOnBorder(this.polygonDistorted, this.borderCorners);
                                } else {
                                    this.borderCorners.resize(0);
                                }
                                if (Area2D_F64.polygonSimple(this.polygonWork) < this.minimumArea) {
                                    printStream = this.verbose;
                                    if (printStream != null) {
                                        printStream.println("Rejected area");
                                    }
                                } else {
                                    Info info2 = (Info) this.foundInfo.grow();
                                    info2.splits.setTo(this.splits);
                                    info2.contourTouchesBorder = z;
                                    info2.external = true;
                                    info2.edgeInside = edgeInsideAverage;
                                    info2.edgeOutside = f;
                                    info2.contour = contourPacked;
                                    info2.polygon.setTo(this.polygonWork);
                                    info2.polygonDistorted.setTo(this.polygonDistorted);
                                    info2.borderCorners.setTo(this.borderCorners);
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    public static void flip(int[] iArr, int i) {
        int i2 = i / 2;
        for (int i3 = 1; i3 <= i2; i3++) {
            int i4 = i - i3;
            int i5 = iArr[i3];
            iArr[i3] = iArr[i4];
            iArr[i4] = i5;
        }
    }

    /* JADX WARN: Code duplicated, block: B:15:0x0032  */
    void determineCornersOnBorder(Polygon2D_F64 polygon2D_F64, DogArray_B dogArray_B) {
        boolean z;
        dogArray_B.reset();
        for (int i = 0; i < polygon2D_F64.size(); i++) {
            Point2D_F64 point2D_F64 = polygon2D_F64.get(i);
            double d = point2D_F64.x;
            if (d > 1.0d) {
                double d2 = point2D_F64.y;
                if (d2 <= 1.0d || d >= this.imageWidth - 2 || d2 >= this.imageHeight - 2) {
                    z = true;
                } else {
                    z = false;
                }
            } else {
                z = true;
            }
            dogArray_B.add(z);
        }
    }

    public List getContour(Info info) {
        this.contourTmp.reset();
        this.contourFinder.loadContour(info.contour.externalIndex, this.contourTmp);
        return this.contourTmp.toList();
    }

    protected final boolean touchesBorder(List list) {
        int i;
        int i2 = this.imageWidth - 1;
        int i3 = this.imageHeight - 1;
        for (int i4 = 0; i4 < list.size(); i4++) {
            Point2D_I32 point2D_I32 = (Point2D_I32) list.get(i4);
            int i5 = point2D_I32.x;
            if (i5 == 0 || (i = point2D_I32.y) == 0 || i5 == i2 || i == i3) {
                return true;
            }
        }
        return false;
    }

    public void setConvex(boolean z) {
        this.contourToPolyline.setConvex(z);
    }

    public void setNumberOfSides(int i, int i2) {
        if (i < 3) {
            throw new IllegalArgumentException("The min must be >= 3");
        }
        if (i2 < i) {
            throw new IllegalArgumentException("The max must be >= the min");
        }
        this.contourToPolyline.setMinimumSides(i);
        this.contourToPolyline.setMaximumSides(i2);
    }

    public int getMinimumSides() {
        return this.contourToPolyline.getMinimumSides();
    }

    public double getMilliContour() {
        return this.milliContour.getAverage();
    }

    public double getMilliShapes() {
        return this.milliShapes.getAverage();
    }

    public static class Info {
        public ContourPacked contour;
        public boolean contourTouchesBorder;
        public double edgeInside;
        public double edgeOutside;
        public boolean external;
        public DogArray_B borderCorners = new DogArray_B();
        public Polygon2D_F64 polygon = new Polygon2D_F64();
        public Polygon2D_F64 polygonDistorted = new Polygon2D_F64();
        public DogArray_I32 splits = new DogArray_I32();

        public void reset() {
            this.external = false;
            this.edgeOutside = -1.0d;
            this.edgeInside = -1.0d;
            this.contourTouchesBorder = true;
            this.borderCorners.reset();
            this.splits.reset();
            this.polygon.vertexes.reset();
            this.polygonDistorted.vertexes.reset();
            this.contour = null;
        }
    }
}
