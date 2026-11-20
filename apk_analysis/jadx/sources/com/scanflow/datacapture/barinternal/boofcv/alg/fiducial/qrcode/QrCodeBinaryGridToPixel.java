package com.scanflow.datacapture.barinternal.boofcv.alg.fiducial.qrcode;

import com.scanflow.datacapture.barinternal.boofcv.alg.geo.h.HomographyDirectLinearTransform;
import com.scanflow.datacapture.barinternal.boofcv.alg.geo.robust.GenerateHomographyLinear;
import com.scanflow.datacapture.barinternal.boofcv.struct.geo.AssociatedPair;
import com.scanflow.datacapture.barinternal.boofcv.struct.geo.AssociatedPair3D;
import com.scanflow.datacapture.barinternal.georegression.struct.ConvertFloatType;
import com.scanflow.datacapture.barinternal.georegression.struct.homography.Homography2D_F32;
import com.scanflow.datacapture.barinternal.georegression.struct.homography.Homography2D_F64;
import com.scanflow.datacapture.barinternal.georegression.struct.point.Point2D_F32;
import com.scanflow.datacapture.barinternal.georegression.struct.point.Point2D_F64;
import com.scanflow.datacapture.barinternal.georegression.struct.point.Point3D_F64;
import com.scanflow.datacapture.barinternal.georegression.struct.shapes.Polygon2D_F64;
import com.scanflow.datacapture.barinternal.georegression.transform.homography.HomographyPointOps_F32;
import com.scanflow.datacapture.barinternal.georegression.transform.homography.HomographyPointOps_F64;
import com.scanflow.datacapture.barinternal.org.ddogleg.fitting.modelset.ModelGenerator;
import com.scanflow.datacapture.barinternal.org.ddogleg.struct.DogArray;
import com.scanflow.datacapture.barinternal.org.ddogleg.struct.Factory;
import com.scanflow.datacapture.barinternal.org.ejml.data.DMatrixRMaj;
import java.util.ArrayList;
import java.util.List;

/* JADX INFO: loaded from: classes.dex */
public class QrCodeBinaryGridToPixel {
    boolean adjustWithFeatures;
    final ModelGenerator generator = new GenerateHomographyLinear(true);
    final HomographyDirectLinearTransform dlt = new HomographyDirectLinearTransform(true);
    final DogArray storagePairs2D = new DogArray(new Factory() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.fiducial.qrcode.QrCodeBinaryGridToPixel$$ExternalSyntheticLambda0
        @Override // com.scanflow.datacapture.barinternal.org.ddogleg.struct.Factory
        public final Object newInstance() {
            return new AssociatedPair();
        }
    });
    final DogArray storagePairs3D = new DogArray(new Factory() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.fiducial.qrcode.QrCodeBinaryGridToPixel$$ExternalSyntheticLambda1
        @Override // com.scanflow.datacapture.barinternal.org.ddogleg.struct.Factory
        public final Object newInstance() {
            return new AssociatedPair3D();
        }
    });
    final List pairs2D = new ArrayList();
    final DogArray adjustments = new DogArray(new QrCodeBinaryGridToPixel$$ExternalSyntheticLambda2());
    final Homography2D_F64 H = new Homography2D_F64();
    public final Homography2D_F64 Hinv = new Homography2D_F64();
    final Homography2D_F32 Hinv32 = new Homography2D_F32();
    final Homography2D_F32 H32 = new Homography2D_F32();
    final Point2D_F64 tmp64 = new Point2D_F64();

    public void setTransformFromSquare(Polygon2D_F64 polygon2D_F64) {
        this.adjustWithFeatures = false;
        this.storagePairs2D.reset();
        this.pairs2D.clear();
        set(0.0f, 0.0f, polygon2D_F64, 0);
        set(0.0f, 7.0f, polygon2D_F64, 1);
        set(7.0f, 7.0f, polygon2D_F64, 2);
        set(7.0f, 0.0f, polygon2D_F64, 3);
        computeTransform();
    }

    public void setTransformFromLinesSquare(QrCode qrCode) {
        this.storagePairs2D.reset();
        this.storagePairs3D.reset();
        set(0.0f, 7.0f, qrCode.ppCorner, 1);
        set(7.0f, 7.0f, qrCode.ppCorner, 2);
        set(7.0f, 0.0f, qrCode.ppCorner, 3);
        setLine(0.0f, 7.0f, 0.0f, 14.0f, qrCode.ppCorner, 1, qrCode.ppRight, 0);
        setLine(7.0f, 7.0f, 7.0f, 14.0f, qrCode.ppCorner, 2, qrCode.ppRight, 3);
        setLine(7.0f, 7.0f, 14.0f, 7.0f, qrCode.ppCorner, 2, qrCode.ppDown, 1);
        setLine(7.0f, 0.0f, 14.0f, 0.0f, qrCode.ppCorner, 3, qrCode.ppDown, 0);
        DMatrixRMaj dMatrixRMaj = new DMatrixRMaj(3, 3);
        this.dlt.process(this.storagePairs2D.toList(), this.storagePairs3D.toList(), null, dMatrixRMaj);
        this.H.setTo(dMatrixRMaj);
        this.H.invert(this.Hinv);
        ConvertFloatType.convert(this.Hinv, this.Hinv32);
        ConvertFloatType.convert(this.H, this.H32);
    }

    public void addAllFeatures(QrCode qrCode) {
        int i = 0;
        this.adjustWithFeatures = false;
        this.storagePairs2D.reset();
        this.pairs2D.clear();
        int numberOfModules = qrCode.getNumberOfModules();
        set(0.0f, 0.0f, qrCode.ppCorner, 0);
        set(0.0f, 7.0f, qrCode.ppCorner, 1);
        set(7.0f, 7.0f, qrCode.ppCorner, 2);
        set(7.0f, 0.0f, qrCode.ppCorner, 3);
        float f = numberOfModules - 7;
        set(0.0f, f, qrCode.ppRight, 0);
        float f2 = numberOfModules;
        set(0.0f, f2, qrCode.ppRight, 1);
        set(7.0f, f2, qrCode.ppRight, 2);
        set(7.0f, f, qrCode.ppRight, 3);
        set(f, 0.0f, qrCode.ppDown, 0);
        set(f, 7.0f, qrCode.ppDown, 1);
        set(f2, 7.0f, qrCode.ppDown, 2);
        set(f2, 0.0f, qrCode.ppDown, 3);
        while (true) {
            DogArray dogArray = qrCode.alignment;
            if (i >= dogArray.size) {
                return;
            }
            QrCode.Alignment alignment = (QrCode.Alignment) dogArray.get(i);
            AssociatedPair associatedPair = (AssociatedPair) this.storagePairs2D.grow();
            Point2D_F64 point2D_F64 = alignment.pixel;
            associatedPair.setTo(point2D_F64.x, point2D_F64.y, alignment.moduleX + 0.5f, alignment.moduleY + 0.5f);
            this.pairs2D.add(associatedPair);
            i++;
        }
    }

    public void removeOutsideCornerFeatures() {
        if (this.pairs2D.size() != this.storagePairs2D.size) {
            throw new RuntimeException("This can only be called when all the features have been added");
        }
        this.pairs2D.remove(11);
        this.pairs2D.remove(5);
        this.pairs2D.remove(0);
    }

    public boolean removeFeatureWithLargestError() {
        double d = 0.0d;
        int i = -1;
        for (int i2 = 0; i2 < this.pairs2D.size(); i2++) {
            AssociatedPair associatedPair = (AssociatedPair) this.pairs2D.get(i2);
            Homography2D_F64 homography2D_F64 = this.Hinv;
            Point2D_F64 point2D_F64 = associatedPair.p2;
            HomographyPointOps_F64.transform(homography2D_F64, point2D_F64.x, point2D_F64.y, this.tmp64);
            Point2D_F64 point2D_F65 = this.tmp64;
            double d2 = point2D_F65.x;
            Point2D_F64 point2D_F66 = associatedPair.p1;
            double d3 = d2 - point2D_F66.x;
            double d4 = point2D_F65.y - point2D_F66.y;
            double d5 = (d3 * d3) + (d4 * d4);
            if (d5 > d) {
                i = i2;
                d = d5;
            }
        }
        if (i == -1 || d <= 4.0d) {
            return false;
        }
        this.pairs2D.remove(i);
        return true;
    }

    public void computeTransform() {
        this.generator.generate(this.pairs2D, this.H);
        this.H.invert(this.Hinv);
        ConvertFloatType.convert(this.Hinv, this.Hinv32);
        ConvertFloatType.convert(this.H, this.H32);
        this.adjustments.reset();
        if (this.adjustWithFeatures) {
            for (int i = 0; i < this.pairs2D.size(); i++) {
                AssociatedPair associatedPair = (AssociatedPair) this.pairs2D.get(i);
                Point2D_F64 point2D_F64 = (Point2D_F64) this.adjustments.grow();
                Homography2D_F64 homography2D_F64 = this.Hinv;
                Point2D_F64 point2D_F65 = associatedPair.p2;
                HomographyPointOps_F64.transform(homography2D_F64, point2D_F65.x, point2D_F65.y, this.tmp64);
                Point2D_F64 point2D_F66 = associatedPair.p1;
                double d = point2D_F66.x;
                Point2D_F64 point2D_F67 = this.tmp64;
                point2D_F64.x = d - point2D_F67.x;
                point2D_F64.y = point2D_F66.y - point2D_F67.y;
            }
        }
    }

    private void set(float f, float f2, Polygon2D_F64 polygon2D_F64, int i) {
        AssociatedPair associatedPair = (AssociatedPair) this.storagePairs2D.grow();
        Point2D_F64 point2D_F64 = polygon2D_F64.get(i);
        associatedPair.setTo(point2D_F64.x, point2D_F64.y, f2, f);
        this.pairs2D.add(associatedPair);
    }

    private void setLine(float f, float f2, float f3, float f4, Polygon2D_F64 polygon2D_F64, int i, Polygon2D_F64 polygon2D_F65, int i2) {
        AssociatedPair3D associatedPair3D = (AssociatedPair3D) this.storagePairs3D.grow();
        Point2D_F64 point2D_F64 = polygon2D_F64.get(i);
        Point2D_F64 point2D_F65 = polygon2D_F65.get(i2);
        associatedPair3D.setTo(point2D_F65.x - point2D_F64.x, point2D_F65.y - point2D_F64.y, 0.0d, f4 - f2, f3 - f, 0.0d);
        Point3D_F64 point3D_F64 = associatedPair3D.p1;
        point3D_F64.divideIP(point3D_F64.norm());
        Point3D_F64 point3D_F65 = associatedPair3D.p2;
        point3D_F65.divideIP(point3D_F65.norm());
    }

    public final void imageToGrid(double d, double d2, Point2D_F64 point2D_F64) {
        HomographyPointOps_F64.transform(this.H, d, d2, point2D_F64);
    }

    public final void gridToImage(float f, float f2, Point2D_F32 point2D_F32) {
        HomographyPointOps_F32.transform(this.Hinv32, f2, f, point2D_F32);
        if (this.adjustWithFeatures) {
            int i = -1;
            double d = Double.MAX_VALUE;
            for (int i2 = 0; i2 < this.pairs2D.size(); i2++) {
                double dDistance2 = ((AssociatedPair) this.pairs2D.get(i2)).p2.distance2(f2, f);
                if (dDistance2 < d) {
                    i = i2;
                    d = dDistance2;
                }
            }
            Point2D_F64 point2D_F64 = (Point2D_F64) this.adjustments.get(i);
            point2D_F32.x += (float) point2D_F64.x;
            point2D_F32.y += (float) point2D_F64.y;
        }
    }
}
