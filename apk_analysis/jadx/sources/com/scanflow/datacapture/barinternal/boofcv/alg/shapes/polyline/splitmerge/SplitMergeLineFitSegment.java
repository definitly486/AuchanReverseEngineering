package com.scanflow.datacapture.barinternal.boofcv.alg.shapes.polyline.splitmerge;

import com.scanflow.datacapture.barinternal.boofcv.struct.ConfigLength;
import com.scanflow.datacapture.barinternal.georegression.metric.Distance2D_F64;
import com.scanflow.datacapture.barinternal.georegression.struct.point.Point2D_I32;
import com.scanflow.datacapture.barinternal.org.ddogleg.struct.DogArray_I32;
import java.util.List;
import java.util.Objects;

/* JADX INFO: loaded from: classes.dex */
public class SplitMergeLineFitSegment extends SplitMergeLineFit {
    public SplitMergeLineFitSegment(double d, ConfigLength configLength, int i) {
        super(d, configLength, i);
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.alg.shapes.polyline.splitmerge.SplitMergeLineFit
    public boolean _process(List list) {
        if (list.size() <= 2) {
            return false;
        }
        this.splits.add(0);
        splitPixels(0, list.size() - 1);
        this.splits.add(list.size() - 1);
        for (int i = 0; i < this.maxIterations && ((mergeSegments() || splitSegments()) && this.splits.size() > 2 && this.splits.size() < this.abortSplits); i++) {
        }
        return true;
    }

    protected void splitPixels(int i, int i2) {
        int iSelectSplitBetween;
        if (i + 1 < i2 && (iSelectSplitBetween = selectSplitBetween(i, i2)) >= 0) {
            splitPixels(i, iSelectSplitBetween);
            this.splits.add(iSelectSplitBetween);
            splitPixels(iSelectSplitBetween, i2);
        }
    }

    protected boolean splitSegments() {
        this.work.reset();
        int i = 0;
        boolean z = false;
        while (true) {
            DogArray_I32 dogArray_I32 = this.splits;
            int i2 = dogArray_I32.size;
            if (i < i2 - 1) {
                int[] iArr = dogArray_I32.data;
                int i3 = iArr[i];
                i++;
                int iSelectSplitBetween = selectSplitBetween(i3, iArr[i]);
                if (iSelectSplitBetween >= 0) {
                    this.work.add(i3);
                    this.work.add(iSelectSplitBetween);
                    z = true;
                } else {
                    this.work.add(i3);
                }
            } else {
                this.work.add(dogArray_I32.data[i2 - 1]);
                DogArray_I32 dogArray_I33 = this.work;
                this.work = this.splits;
                this.splits = dogArray_I33;
                return z;
            }
        }
    }

    protected int selectSplitBetween(int i, int i2) {
        Objects.requireNonNull(this.contour);
        Point2D_I32 point2D_I32 = (Point2D_I32) this.contour.get(i);
        Point2D_I32 point2D_I33 = (Point2D_I32) this.contour.get(i2);
        this.line.p.setTo(point2D_I32.x, point2D_I32.y);
        this.line.slope.setTo(point2D_I33.x - point2D_I32.x, point2D_I33.y - point2D_I32.y);
        double dSplitThresholdSq = splitThresholdSq((Point2D_I32) this.contour.get(i), (Point2D_I32) this.contour.get(i2));
        int iMax = Math.max(1, this.minimumSideLengthPixel);
        int i3 = (i2 - i) - iMax;
        int i4 = -1;
        while (iMax <= i3) {
            int i5 = i + iMax;
            Point2D_I32 point2D_I34 = (Point2D_I32) this.contour.get(i5);
            this.point2D.setTo(point2D_I34.x, point2D_I34.y);
            double dDistanceSq = Distance2D_F64.distanceSq(this.line, this.point2D);
            if (dDistanceSq >= dSplitThresholdSq) {
                i4 = i5;
                dSplitThresholdSq = dDistanceSq;
            }
            iMax++;
        }
        return i4;
    }

    protected boolean mergeSegments() {
        int i = 0;
        if (this.splits.size <= 2) {
            return false;
        }
        this.work.reset();
        this.work.add(this.splits.data[0]);
        boolean z = false;
        while (true) {
            DogArray_I32 dogArray_I32 = this.splits;
            int i2 = dogArray_I32.size;
            if (i < i2 - 2) {
                int[] iArr = dogArray_I32.data;
                if (selectSplitBetween(iArr[i], iArr[i + 2]) < 0) {
                    z = true;
                } else {
                    this.work.add(this.splits.data[i + 1]);
                }
                i++;
            } else {
                this.work.add(dogArray_I32.data[i2 - 1]);
                DogArray_I32 dogArray_I33 = this.work;
                this.work = this.splits;
                this.splits = dogArray_I33;
                return z;
            }
        }
    }
}
