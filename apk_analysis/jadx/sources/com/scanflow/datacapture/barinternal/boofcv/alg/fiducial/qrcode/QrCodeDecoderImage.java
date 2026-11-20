package com.scanflow.datacapture.barinternal.boofcv.alg.fiducial.qrcode;

import com.scanflow.datacapture.barinternal.boofcv.alg.fiducial.calib.squares.SquareEdge;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageGray;
import com.scanflow.datacapture.barinternal.georegression.geometry.UtilPolygons2D_F64;
import com.scanflow.datacapture.barinternal.georegression.metric.Intersection2D_F64;
import com.scanflow.datacapture.barinternal.georegression.struct.point.Point2D_F64;
import com.scanflow.datacapture.barinternal.georegression.struct.point.Point2D_I32;
import com.scanflow.datacapture.barinternal.georegression.struct.shapes.Polygon2D_F64;
import com.scanflow.datacapture.barinternal.org.ddogleg.struct.DProcess;
import com.scanflow.datacapture.barinternal.org.ddogleg.struct.DogArray;
import com.scanflow.datacapture.barinternal.org.ddogleg.struct.DogArray_F32;
import com.scanflow.datacapture.barinternal.org.ddogleg.struct.Factory;
import java.util.ArrayList;
import java.util.List;

/* JADX INFO: loaded from: classes.dex */
public class QrCodeDecoderImage {
    QrCodeAlignmentPatternLocator alignmentLocator;
    QrCodeDecoderBits decoder;
    QrCodeBinaryGridReader gridReader;
    public boolean considerTransposed = true;
    DogArray storageQR = new DogArray(new Factory() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.fiducial.qrcode.QrCodeDecoderImage$$ExternalSyntheticLambda0
        @Override // com.scanflow.datacapture.barinternal.org.ddogleg.struct.Factory
        public final Object newInstance() {
            return new QrCode();
        }
    }, new DProcess() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.fiducial.qrcode.QrCodeDecoderImage$$ExternalSyntheticLambda1
        @Override // com.scanflow.datacapture.barinternal.org.ddogleg.struct.DProcess
        public final void process(Object obj) {
            ((QrCode) obj).reset();
        }
    });
    List successes = new ArrayList();
    List failures = new ArrayList();
    PackedBits8 bits = new PackedBits8();
    Point2D_F64 grid = new Point2D_F64();
    Polygon2D_F64 tempTranspose = new Polygon2D_F64();
    DogArray_F32 intensityBits = new DogArray_F32();

    public QrCodeDecoderBits getDecoder() {
        return this.decoder;
    }

    public List getSuccesses() {
        return this.successes;
    }

    public QrCodeDecoderImage(String str, String str2, Class cls) {
        this.decoder = new QrCodeDecoderBits(str, str2);
        this.gridReader = new QrCodeBinaryGridReader(cls);
        this.alignmentLocator = new QrCodeAlignmentPatternLocator(cls);
    }

    public void process(List list, ImageGray imageGray) {
        boolean zDecode;
        this.gridReader.setImage(imageGray);
        this.storageQR.reset();
        this.successes.clear();
        this.failures.clear();
        for (int i = 0; i < list.size(); i++) {
            PositionPatternNode positionPatternNode = (PositionPatternNode) list.get(i);
            int i2 = 3;
            for (int i3 = 0; i3 < 4; i3++) {
                SquareEdge[] squareEdgeArr = positionPatternNode.edges;
                if (squareEdgeArr[i2] != null && squareEdgeArr[i3] != null) {
                    QrCode qrCode = (QrCode) this.storageQR.grow();
                    setPositionPatterns(positionPatternNode, i2, i3, qrCode);
                    computeBoundingBox(qrCode);
                    if (decode(imageGray, qrCode)) {
                        if (qrCode.failureCause == QrCode.Failure.NONE) {
                            this.successes.add(qrCode);
                        } else {
                            this.failures.add(qrCode);
                        }
                    } else {
                        if (this.considerTransposed) {
                            transposePositionPatterns(qrCode);
                            zDecode = decode(imageGray, qrCode);
                        } else {
                            zDecode = false;
                        }
                        if (zDecode) {
                            qrCode.bitsTransposed = true;
                            if (qrCode.failureCause == QrCode.Failure.NONE) {
                                this.successes.add(qrCode);
                            } else {
                                this.failures.add(qrCode);
                            }
                        } else {
                            this.failures.add(qrCode);
                        }
                    }
                }
                i2 = i3;
            }
        }
    }

    void transposePositionPatterns(QrCode qrCode) {
        this.tempTranspose.setTo(qrCode.ppDown);
        qrCode.ppDown.setTo(qrCode.ppRight);
        qrCode.ppRight.setTo(this.tempTranspose);
        transposeCorners(qrCode.ppCorner);
        transposeCorners(qrCode.ppRight);
        transposeCorners(qrCode.ppDown);
    }

    public static void transposeCorners(Polygon2D_F64 polygon2D_F64) {
        double d = polygon2D_F64.get(1).x;
        double d2 = polygon2D_F64.get(1).y;
        polygon2D_F64.get(1).setTo(polygon2D_F64.get(3));
        polygon2D_F64.get(3).setTo(d, d2);
    }

    static void setPositionPatterns(PositionPatternNode positionPatternNode, int i, int i2, QrCode qrCode) {
        PositionPatternNode positionPatternNode2 = (PositionPatternNode) positionPatternNode.edges[i].destination(positionPatternNode);
        PositionPatternNode positionPatternNode3 = (PositionPatternNode) positionPatternNode.edges[i2].destination(positionPatternNode);
        qrCode.ppRight.setTo(positionPatternNode2.square);
        qrCode.ppCorner.setTo(positionPatternNode.square);
        qrCode.ppDown.setTo(positionPatternNode3.square);
        qrCode.threshRight = positionPatternNode2.grayThreshold;
        qrCode.threshCorner = positionPatternNode.grayThreshold;
        qrCode.threshDown = positionPatternNode3.grayThreshold;
        int iFindEdgeIndex = positionPatternNode2.findEdgeIndex(positionPatternNode);
        int iFindEdgeIndex2 = positionPatternNode3.findEdgeIndex(positionPatternNode);
        rotateUntilAt(qrCode.ppRight, iFindEdgeIndex, 3);
        rotateUntilAt(qrCode.ppCorner, i, 1);
        rotateUntilAt(qrCode.ppDown, iFindEdgeIndex2, 0);
    }

    static void rotateUntilAt(Polygon2D_F64 polygon2D_F64, int i, int i2) {
        while (i != i2) {
            UtilPolygons2D_F64.shiftDown(polygon2D_F64);
            i = (i + 1) % 4;
        }
    }

    static void computeBoundingBox(QrCode qrCode) {
        qrCode.bounds.get(0).setTo(qrCode.ppCorner.get(0));
        qrCode.bounds.get(1).setTo(qrCode.ppRight.get(1));
        Intersection2D_F64.intersection(qrCode.ppRight.get(1), qrCode.ppRight.get(2), qrCode.ppDown.get(3), qrCode.ppDown.get(2), qrCode.bounds.get(2));
        qrCode.bounds.get(3).setTo(qrCode.ppDown.get(3));
    }

    private boolean decode(ImageGray imageGray, QrCode qrCode) {
        boolean z = false;
        if (!extractFormatInfo(qrCode)) {
            qrCode.failureCause = QrCode.Failure.FORMAT;
            return false;
        }
        if (!extractVersionInfo(qrCode)) {
            qrCode.failureCause = QrCode.Failure.VERSION;
            return false;
        }
        if (!this.alignmentLocator.process(imageGray, qrCode)) {
            qrCode.failureCause = QrCode.Failure.ALIGNMENT;
            return false;
        }
        this.gridReader.setMarker(qrCode);
        this.gridReader.getTransformGrid().addAllFeatures(qrCode);
        for (int i = 0; i < 6 && (i <= 0 || this.gridReader.getTransformGrid().removeFeatureWithLargestError()); i++) {
            this.gridReader.getTransformGrid().computeTransform();
            qrCode.failureCause = QrCode.Failure.NONE;
            if (!readRawData(qrCode)) {
                qrCode.failureCause = QrCode.Failure.READING_BITS;
            } else {
                if (this.decoder.applyErrorCorrection(qrCode)) {
                    z = true;
                    break;
                }
                qrCode.failureCause = QrCode.Failure.ERROR_CORRECTION;
            }
        }
        if (z) {
            qrCode.failureCause = QrCode.Failure.NONE;
            this.decoder.decodeMessage(qrCode);
        }
        qrCode.Hinv.setTo(this.gridReader.getTransformGrid().Hinv);
        return z;
    }

    private boolean extractFormatInfo(QrCode qrCode) {
        for (int i = 0; i < 2; i++) {
            if (i == 0) {
                readFormatRegion0(qrCode);
            } else {
                readFormatRegion1(qrCode);
            }
            int i2 = this.bits.read(0, 15, false) ^ 21522;
            int iCorrectFormatBits = QrCodePolynomialMath.checkFormatBits(i2) ? i2 >> 10 : QrCodePolynomialMath.correctFormatBits(i2);
            if (iCorrectFormatBits >= 0) {
                QrCodePolynomialMath.decodeFormatMessage(iCorrectFormatBits, qrCode);
                return true;
            }
        }
        return false;
    }

    final boolean readFormatRegion0(QrCode qrCode) {
        this.gridReader.setSquare(qrCode.ppCorner, (float) qrCode.threshCorner);
        this.bits.resize(15);
        this.bits.zero();
        for (int i = 0; i < 6; i++) {
            read(i, i, 8);
        }
        read(6, 7, 8);
        read(7, 8, 8);
        read(8, 8, 7);
        for (int i2 = 0; i2 < 6; i2++) {
            read(i2 + 9, 8, 5 - i2);
        }
        return true;
    }

    final boolean readFormatRegion1(QrCode qrCode) {
        this.gridReader.setSquare(qrCode.ppRight, (float) qrCode.threshRight);
        this.bits.resize(15);
        this.bits.zero();
        for (int i = 0; i < 8; i++) {
            read(i, 8, 6 - i);
        }
        this.gridReader.setSquare(qrCode.ppDown, (float) qrCode.threshDown);
        for (int i2 = 0; i2 < 7; i2++) {
            read(i2 + 8, i2, 8);
        }
        return true;
    }

    private boolean readRawData(QrCode qrCode) {
        int i = QrCode.VERSION_INFO[qrCode.version].codewords;
        qrCode.rawbits = new byte[i];
        this.bits.resize(i * 8);
        List list = QrCode.LOCATION_BITS[qrCode.version];
        qrCode.threshDownRight = readBitIntensityAndThresholdDownRight(qrCode, list);
        bitIntensityToBitValue(qrCode, list);
        byte[] bArr = this.bits.data;
        byte[] bArr2 = qrCode.rawbits;
        System.arraycopy(bArr, 0, bArr2, 0, bArr2.length);
        return true;
    }

    private float readBitIntensityAndThresholdDownRight(QrCode qrCode, List list) {
        int numberOfModules = qrCode.getNumberOfModules();
        this.intensityBits.reserve(list.size() * 5);
        this.intensityBits.reset();
        int iMax = Math.max(8, numberOfModules - 10);
        float f = 0.0f;
        int i = 0;
        for (int i2 = 0; i2 < this.bits.size; i2++) {
            Point2D_I32 point2D_I32 = (Point2D_I32) list.get(i2);
            this.gridReader.readBitIntensity(point2D_I32.y, point2D_I32.x, this.intensityBits);
            if (point2D_I32.x >= iMax || point2D_I32.y >= iMax) {
                i += 5;
                int i3 = this.intensityBits.size - 5;
                while (true) {
                    DogArray_F32 dogArray_F32 = this.intensityBits;
                    if (i3 < dogArray_F32.size) {
                        f += dogArray_F32.data[i3];
                        i3++;
                    }
                }
            }
        }
        return f / i;
    }

    private void bitIntensityToBitValue(QrCode qrCode, List list) {
        float f = 1.0f;
        float numberOfModules = qrCode.getNumberOfModules() - 1.0f;
        float f2 = (float) qrCode.threshCorner;
        float f3 = (float) qrCode.threshRight;
        float f4 = (float) qrCode.threshDown;
        float f5 = (float) qrCode.threshDownRight;
        int i = 0;
        while (i < this.intensityBits.size) {
            int i2 = i / 5;
            Point2D_I32 point2D_I32 = (Point2D_I32) list.get(i2);
            int i3 = point2D_I32.x;
            float f6 = i3 / numberOfModules;
            int i4 = point2D_I32.y;
            float f7 = i4 / numberOfModules;
            float f8 = f - f6;
            float f9 = f - f7;
            float f10 = (f8 * f9 * f2) + 0.0f + (f9 * f6 * f3) + (f6 * f7 * f5) + (f8 * f7 * f4);
            float[] fArr = this.intensityBits.data;
            int i5 = i + 3;
            int i6 = (fArr[i] < f10 ? 1 : 0) + (fArr[i + 1] < f10 ? 1 : 0) + (fArr[i + 2] < f10 ? 1 : 0);
            int i7 = i + 4;
            i += 5;
            this.bits.set(i2, qrCode.mask.apply(i4, i3, (i6 + ((fArr[i5] > f10 ? 1 : (fArr[i5] == f10 ? 0 : -1)) < 0 ? 1 : 0)) + ((fArr[i7] > f10 ? 1 : (fArr[i7] == f10 ? 0 : -1)) < 0 ? 1 : 0) >= 3 ? 1 : 0));
            f = 1.0f;
        }
    }

    private void read(int i, int i2, int i3) {
        int bit = this.gridReader.readBit(i2, i3);
        if (bit == -1) {
            bit = 0;
        }
        this.bits.set(i, bit);
    }

    /* JADX WARN: Code duplicated, block: B:15:0x0028  */
    boolean extractVersionInfo(QrCode qrCode) {
        int iEstimateVersionBySize = estimateVersionBySize(qrCode);
        if (iEstimateVersionBySize >= 7) {
            readVersionRegion0(qrCode);
            iEstimateVersionBySize = decodeVersion();
            readVersionRegion1(qrCode);
            int iDecodeVersion = decodeVersion();
            if (iEstimateVersionBySize < 1 && iDecodeVersion < 1) {
                iEstimateVersionBySize = -1;
            } else if (iEstimateVersionBySize < 1) {
                iEstimateVersionBySize = iDecodeVersion;
            } else if (iDecodeVersion >= 1 && iEstimateVersionBySize != iDecodeVersion) {
                iEstimateVersionBySize = -1;
            }
        } else if (iEstimateVersionBySize <= 0) {
            iEstimateVersionBySize = -1;
        }
        qrCode.version = iEstimateVersionBySize;
        return iEstimateVersionBySize >= 1 && iEstimateVersionBySize <= 40;
    }

    int decodeVersion() {
        int i = this.bits.read(0, 18, false);
        int iCorrectVersionBits = QrCodePolynomialMath.checkVersionBits(i) ? i >> 12 : QrCodePolynomialMath.correctVersionBits(i);
        if (iCorrectVersionBits > 40 || iCorrectVersionBits < 7) {
            return -1;
        }
        return iCorrectVersionBits;
    }

    int estimateVersionBySize(QrCode qrCode) {
        this.gridReader.setMarkerUnknownVersion(qrCode, 0.0f);
        this.gridReader.imageToGrid(qrCode.ppRight.get(0), this.grid);
        Point2D_F64 point2D_F64 = this.grid;
        if (Math.abs(point2D_F64.y / point2D_F64.x) >= 0.3d) {
            return -1;
        }
        double d = ((this.grid.x + 7.0d) - 17.0d) / 4.0d;
        this.gridReader.imageToGrid(qrCode.ppDown.get(0), this.grid);
        Point2D_F64 point2D_F65 = this.grid;
        if (Math.abs(point2D_F65.x / point2D_F65.y) >= 0.3d) {
            return -1;
        }
        double d2 = ((this.grid.y + 7.0d) - 17.0d) / 4.0d;
        int i = (int) (((d + d2) / 2.0d) + 0.5d);
        double dAbs = Math.abs(d - d2);
        if (dAbs > 2.0d && (i < 7 || dAbs / ((double) i) > 0.4d)) {
            return -1;
        }
        return i;
    }

    private boolean readVersionRegion0(QrCode qrCode) {
        this.gridReader.setSquare(qrCode.ppRight, (float) qrCode.threshRight);
        this.bits.resize(18);
        this.bits.zero();
        for (int i = 0; i < 18; i++) {
            read(i, i / 3, (i % 3) - 4);
        }
        return true;
    }

    private boolean readVersionRegion1(QrCode qrCode) {
        this.gridReader.setSquare(qrCode.ppDown, (float) qrCode.threshDown);
        this.bits.resize(18);
        this.bits.zero();
        for (int i = 0; i < 18; i++) {
            read(i, (i % 3) - 4, i / 3);
        }
        return true;
    }
}
