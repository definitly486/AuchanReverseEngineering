package com.scanflow.datacapture.barinternal.boofcv.alg.shapes.polyline.splitmerge;

import com.scanflow.datacapture.barinternal.boofcv.struct.ConfigLength;
import com.scanflow.datacapture.barinternal.georegression.struct.line.LineParametric2D_F64;
import com.scanflow.datacapture.barinternal.georegression.struct.point.Point2D_F64;
import com.scanflow.datacapture.barinternal.georegression.struct.point.Point2D_I32;
import com.scanflow.datacapture.barinternal.org.ddogleg.struct.DogArray_B;
import com.scanflow.datacapture.barinternal.org.ddogleg.struct.DogArray_I32;
import java.util.List;

/* JADX INFO: loaded from: classes.dex */
public abstract class SplitMergeLineFit {
    protected List contour;
    protected int maxIterations;
    protected ConfigLength minimumSideLength;
    protected int minimumSideLengthPixel;
    protected double toleranceFractionSq;
    protected LineParametric2D_F64 line = new LineParametric2D_F64();
    protected Point2D_F64 point2D = new Point2D_F64();
    protected DogArray_I32 splits = new DogArray_I32();
    DogArray_I32 work = new DogArray_I32();
    protected DogArray_B changed = new DogArray_B();
    protected int abortSplits = Integer.MAX_VALUE;

    protected abstract boolean _process(List list);

    protected SplitMergeLineFit(double d, ConfigLength configLength, int i) {
        setSplitFraction(d);
        this.minimumSideLength = configLength;
        setMaxIterations(i);
    }

    public boolean process(List list, DogArray_I32 dogArray_I32) {
        this.contour = list;
        this.minimumSideLengthPixel = this.minimumSideLength.computeI(list.size());
        this.splits.reset();
        boolean z_process = _process(list);
        this.contour = null;
        dogArray_I32.setTo(this.splits);
        return z_process;
    }

    protected double splitThresholdSq(Point2D_I32 point2D_I32, Point2D_I32 point2D_I33) {
        return Math.max(2.0d, ((double) point2D_I32.distance2(point2D_I33)) * this.toleranceFractionSq);
    }

    public void setMaxIterations(int i) {
        this.maxIterations = i;
    }

    public void setSplitFraction(double d) {
        this.toleranceFractionSq = d * d;
    }

    public void setAbortSplits(int i) {
        this.abortSplits = i;
    }
}
