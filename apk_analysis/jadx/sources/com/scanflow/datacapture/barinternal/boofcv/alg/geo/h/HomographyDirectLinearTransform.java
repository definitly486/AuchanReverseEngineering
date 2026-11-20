package com.scanflow.datacapture.barinternal.boofcv.alg.geo.h;

import com.scanflow.datacapture.barinternal.a.a$$ExternalSyntheticThrowCCEIfNotNull0;
import com.scanflow.datacapture.barinternal.boofcv.alg.geo.NormalizationPoint2D;
import com.scanflow.datacapture.barinternal.boofcv.struct.geo.AssociatedPair;
import com.scanflow.datacapture.barinternal.boofcv.struct.geo.AssociatedPair3D;
import com.scanflow.datacapture.barinternal.boofcv.struct.geo.AssociatedPairConic;
import com.scanflow.datacapture.barinternal.georegression.struct.point.Point2D_F64;
import com.scanflow.datacapture.barinternal.georegression.struct.point.Point3D_F64;
import com.scanflow.datacapture.barinternal.org.ejml.data.DMatrix3x3;
import com.scanflow.datacapture.barinternal.org.ejml.data.DMatrixRMaj;
import com.scanflow.datacapture.barinternal.org.ejml.dense.row.linsol.svd.SolveNullSpaceSvd_DDRM;
import com.scanflow.datacapture.barinternal.org.ejml.interfaces.SolveNullSpace;
import com.scanflow.datacapture.barinternal.org.ejml.simple.SimpleMatrix;
import java.util.List;

/* JADX INFO: loaded from: classes.dex */
public class HomographyDirectLinearTransform {
    boolean normalize;
    private boolean shouldNormalize;
    protected DMatrixRMaj A = new DMatrixRMaj(1, 9);
    protected SolveNullSpace solverNullspace = new SolveNullSpaceSvd_DDRM();
    protected NormalizationPoint2D N1 = new NormalizationPoint2D();
    protected NormalizationPoint2D N2 = new NormalizationPoint2D();
    private AdjustHomographyMatrix adjust = new AdjustHomographyMatrix();
    private boolean exhaustiveConics = false;
    private final DMatrix3x3 C1 = new DMatrix3x3();
    private final DMatrix3x3 V1 = new DMatrix3x3();
    private final DMatrix3x3 C1_inv = new DMatrix3x3();
    private final DMatrix3x3 V1_inv = new DMatrix3x3();
    private final DMatrix3x3 C2 = new DMatrix3x3();
    private final DMatrix3x3 V2 = new DMatrix3x3();
    private final DMatrix3x3 C2_inv = new DMatrix3x3();
    private final DMatrix3x3 V2_inv = new DMatrix3x3();
    private final DMatrix3x3 L = new DMatrix3x3();
    private final DMatrix3x3 R = new DMatrix3x3();

    public HomographyDirectLinearTransform(boolean z) {
        this.normalize = z;
    }

    public boolean process(List list, DMatrixRMaj dMatrixRMaj) {
        return process(list, null, null, dMatrixRMaj);
    }

    public boolean process(List list, List list2, List list3, DMatrixRMaj dMatrixRMaj) {
        int iComputeTotalRows = computeTotalRows(list != null ? list.size() : 0, list2 != null ? list2.size() : 0, list3 != null ? list3.size() : 0);
        this.shouldNormalize = false;
        this.A.reshape(iComputeTotalRows, 9);
        this.A.zero();
        int iAddPoints2D = list != null ? addPoints2D(list, this.A, 0) : 0;
        if (list2 != null) {
            iAddPoints2D = addPoints3D(list2, this.A, iAddPoints2D);
        }
        if (list3 != null) {
            addConics(list3, this.A, iAddPoints2D);
        }
        if (computeH(this.A, dMatrixRMaj)) {
            return false;
        }
        if (this.shouldNormalize) {
            undoNormalizationH(dMatrixRMaj, this.N1, this.N2);
        }
        if (list == null) {
            return true;
        }
        this.adjust.adjust(dMatrixRMaj, (AssociatedPair) list.get(0));
        return true;
    }

    protected boolean computeH(DMatrixRMaj dMatrixRMaj, DMatrixRMaj dMatrixRMaj2) {
        if (!this.solverNullspace.process(dMatrixRMaj.copy(), 1, dMatrixRMaj2)) {
            return true;
        }
        dMatrixRMaj2.numRows = 3;
        dMatrixRMaj2.numCols = 3;
        return false;
    }

    public static void undoNormalizationH(DMatrixRMaj dMatrixRMaj, NormalizationPoint2D normalizationPoint2D, NormalizationPoint2D normalizationPoint2D2) {
        SimpleMatrix simpleMatrixWrap = SimpleMatrix.wrap(dMatrixRMaj);
        dMatrixRMaj.setTo(((SimpleMatrix) ((SimpleMatrix) SimpleMatrix.wrap(normalizationPoint2D2.matrixInv(null)).mult(simpleMatrixWrap)).mult(SimpleMatrix.wrap(normalizationPoint2D.matrix(null)))).getDDRM());
    }

    private void adjustPoint(AssociatedPair associatedPair, Point2D_F64 point2D_F64, Point2D_F64 point2D_F65) {
        if (this.shouldNormalize) {
            this.N1.apply(associatedPair.p1, point2D_F64);
            this.N2.apply(associatedPair.p2, point2D_F65);
        } else {
            point2D_F64.setTo(associatedPair.p1);
            point2D_F65.setTo(associatedPair.p2);
        }
    }

    int computeTotalRows(int i, int i2, int i3) {
        return (i * 2) + (i2 * 2) + (i3 * 9);
    }

    private void adjustPoint(AssociatedPair3D associatedPair3D, Point3D_F64 point3D_F64, Point3D_F64 point3D_F65) {
        if (this.shouldNormalize) {
            this.N1.apply(associatedPair3D.p1, point3D_F64);
            this.N2.apply(associatedPair3D.p2, point3D_F65);
        } else {
            point3D_F64.setTo(associatedPair3D.p1);
            point3D_F65.setTo(associatedPair3D.p2);
        }
    }

    protected int addPoints2D(List list, DMatrixRMaj dMatrixRMaj, int i) {
        Point2D_F64 point2D_F64 = new Point2D_F64();
        Point2D_F64 point2D_F65 = new Point2D_F64();
        int i2 = 0;
        int i3 = i;
        int i4 = 0;
        while (i4 < list.size()) {
            adjustPoint((AssociatedPair) list.get(i4), point2D_F64, point2D_F65);
            dMatrixRMaj.set(i3, 3, -point2D_F64.x);
            dMatrixRMaj.set(i3, 4, -point2D_F64.y);
            dMatrixRMaj.set(i3, 5, -1.0d);
            dMatrixRMaj.set(i3, 6, point2D_F65.y * point2D_F64.x);
            dMatrixRMaj.set(i3, 7, point2D_F65.y * point2D_F64.y);
            dMatrixRMaj.set(i3, 8, point2D_F65.y);
            int i5 = i3 + 1;
            dMatrixRMaj.set(i5, i2, point2D_F64.x);
            dMatrixRMaj.set(i5, 1, point2D_F64.y);
            dMatrixRMaj.set(i5, 2, 1.0d);
            dMatrixRMaj.set(i5, 6, (-point2D_F65.x) * point2D_F64.x);
            dMatrixRMaj.set(i5, 7, (-point2D_F65.x) * point2D_F64.y);
            dMatrixRMaj.set(i5, 8, -point2D_F65.x);
            i3 += 2;
            i4++;
            i2 = 0;
        }
        return i3;
    }

    protected int addPoints3D(List list, DMatrixRMaj dMatrixRMaj, int i) {
        Point3D_F64 point3D_F64 = new Point3D_F64();
        Point3D_F64 point3D_F65 = new Point3D_F64();
        int i2 = i;
        for (int i3 = 0; i3 < list.size(); i3++) {
            adjustPoint((AssociatedPair3D) list.get(i3), point3D_F64, point3D_F65);
            dMatrixRMaj.set(i2, 3, (-point3D_F65.z) * point3D_F64.x);
            dMatrixRMaj.set(i2, 4, (-point3D_F65.z) * point3D_F64.y);
            dMatrixRMaj.set(i2, 5, (-point3D_F65.z) * point3D_F64.z);
            dMatrixRMaj.set(i2, 6, point3D_F65.y * point3D_F64.x);
            dMatrixRMaj.set(i2, 7, point3D_F65.y * point3D_F64.y);
            dMatrixRMaj.set(i2, 8, point3D_F65.y * point3D_F64.z);
            int i4 = i2 + 1;
            dMatrixRMaj.set(i4, 0, point3D_F65.z * point3D_F64.x);
            dMatrixRMaj.set(i4, 1, point3D_F65.z * point3D_F64.y);
            dMatrixRMaj.set(i4, 2, point3D_F65.z * point3D_F64.z);
            dMatrixRMaj.set(i4, 6, (-point3D_F65.x) * point3D_F64.x);
            dMatrixRMaj.set(i4, 7, (-point3D_F65.x) * point3D_F64.y);
            dMatrixRMaj.set(i4, 8, (-point3D_F65.x) * point3D_F64.z);
            i2 += 2;
        }
        return i2;
    }

    protected int addConics(List list, DMatrixRMaj dMatrixRMaj, int i) {
        int i2 = 0;
        if (this.exhaustiveConics) {
            while (i2 < list.size()) {
                int i3 = i2 + 1;
                for (int i4 = i3; i4 < list.size(); i4++) {
                    a$$ExternalSyntheticThrowCCEIfNotNull0.m(list.get(i2));
                    a$$ExternalSyntheticThrowCCEIfNotNull0.m(list.get(i4));
                    i = addConicPairConstraints(null, null, dMatrixRMaj, i);
                }
                i2 = i3;
            }
            return i;
        }
        for (int i5 = 1; i5 < list.size(); i5++) {
            a$$ExternalSyntheticThrowCCEIfNotNull0.m(list.get(i5 - 1));
            a$$ExternalSyntheticThrowCCEIfNotNull0.m(list.get(i5));
            i = addConicPairConstraints(null, null, dMatrixRMaj, i);
        }
        int size = list.size();
        a$$ExternalSyntheticThrowCCEIfNotNull0.m(list.get(0));
        a$$ExternalSyntheticThrowCCEIfNotNull0.m(list.get(size - 1));
        return addConicPairConstraints(null, null, dMatrixRMaj, i);
    }

    protected int addConicPairConstraints(AssociatedPairConic associatedPairConic, AssociatedPairConic associatedPairConic2, DMatrixRMaj dMatrixRMaj, int i) {
        throw null;
    }
}
