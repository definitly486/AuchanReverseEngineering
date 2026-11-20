package com.scanflow.datacapture.barinternal.boofcv.alg.shapes.polyline.splitmerge;

import com.scanflow.datacapture.barinternal.boofcv.struct.ConfigLength;
import com.scanflow.datacapture.barinternal.georegression.geometry.UtilPoint2D_I32;
import com.scanflow.datacapture.barinternal.georegression.metric.Distance2D_F64;
import com.scanflow.datacapture.barinternal.georegression.struct.point.Point2D_I32;
import com.scanflow.datacapture.barinternal.org.ddogleg.struct.DogArray_I32;
import java.util.List;
import java.util.Objects;

/* JADX INFO: loaded from: classes.dex */
public class SplitMergeLineFitLoop extends SplitMergeLineFit {
    protected int N;

    public SplitMergeLineFitLoop(double d, ConfigLength configLength, int i) {
        super(d, configLength, i);
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.alg.shapes.polyline.splitmerge.SplitMergeLineFit
    public boolean _process(List list) {
        int size = list.size();
        this.N = size;
        if (size <= 1) {
            return false;
        }
        int iSelectFarthest = selectFarthest(list);
        int i = this.N;
        int i2 = ((i / 2) + iSelectFarthest) % i;
        this.splits.add(iSelectFarthest);
        splitPixels(iSelectFarthest, this.N / 2);
        this.splits.add(i2);
        int i3 = this.N;
        splitPixels(i2, i3 - (i3 / 2));
        if (this.splits.size <= 2) {
            return false;
        }
        for (int i4 = 0; i4 < this.maxIterations; i4++) {
            boolean zMergeSegments = mergeSegments();
            if (this.splits.size() <= 0) {
                return false;
            }
            if (!zMergeSegments && !splitSegments()) {
                break;
            }
            if (this.splits.size() <= 2 || this.splits.size() >= this.abortSplits) {
                return false;
            }
        }
        return true;
    }

    protected void splitPixels(int i, int i2) {
        if (i2 < this.minimumSideLengthPixel) {
            return;
        }
        int i3 = (i + i2) % this.N;
        int iSelectSplitOffset = selectSplitOffset(i, i2);
        if (iSelectSplitOffset >= 0) {
            splitPixels(i, iSelectSplitOffset);
            int i4 = (i + iSelectSplitOffset) % this.N;
            this.splits.add(i4);
            splitPixels(i4, circularDistance(i4, i3));
        }
    }

    protected int selectFarthest(List list) {
        int size = list.size();
        int i = size / 2;
        int i2 = -1;
        int i3 = 0;
        for (int i4 = 0; i4 < i; i4++) {
            Point2D_I32 point2D_I32 = (Point2D_I32) list.get(i4);
            Point2D_I32 point2D_I33 = (Point2D_I32) list.get((i4 + i) % size);
            int iDistanceSq = UtilPoint2D_I32.distanceSq(point2D_I32.x, point2D_I32.y, point2D_I33.x, point2D_I33.y);
            if (i3 < iDistanceSq) {
                i2 = i4;
                i3 = iDistanceSq;
            }
        }
        return i2;
    }

    protected boolean mergeSegments() {
        int i = 0;
        if (this.splits.size() <= 3) {
            return false;
        }
        this.work.reset();
        boolean z = false;
        while (true) {
            DogArray_I32 dogArray_I32 = this.splits;
            int i2 = dogArray_I32.size;
            if (i < i2) {
                int[] iArr = dogArray_I32.data;
                int i3 = iArr[i];
                if (selectSplitOffset(i3, circularDistance(i3, iArr[(i + 2) % i2])) < 0) {
                    z = true;
                } else {
                    DogArray_I32 dogArray_I33 = this.work;
                    DogArray_I32 dogArray_I34 = this.splits;
                    dogArray_I33.add(dogArray_I34.data[(i + 1) % dogArray_I34.size]);
                }
                i++;
            } else {
                DogArray_I32 dogArray_I35 = this.work;
                this.work = dogArray_I32;
                this.splits = dogArray_I35;
                return z;
            }
        }
    }

    protected boolean splitSegments() {
        this.work.reset();
        int i = 0;
        boolean zCheckSplit = false;
        while (true) {
            int i2 = this.splits.size;
            if (i < i2 - 1) {
                int i3 = i + 1;
                zCheckSplit |= checkSplit(zCheckSplit, i, i3);
                i = i3;
            } else {
                boolean zCheckSplit2 = checkSplit(zCheckSplit, i2 - 1, 0) | zCheckSplit;
                DogArray_I32 dogArray_I32 = this.work;
                this.work = this.splits;
                this.splits = dogArray_I32;
                return zCheckSplit2;
            }
        }
    }

    private boolean checkSplit(boolean z, int i, int i2) {
        int[] iArr = this.splits.data;
        int i3 = iArr[i];
        int iSelectSplitOffset = selectSplitOffset(i3, circularDistance(i3, iArr[i2]));
        if (iSelectSplitOffset >= 0) {
            this.work.add(i3);
            this.work.add((i3 + iSelectSplitOffset) % this.N);
            return true;
        }
        this.work.add(i3);
        return z;
    }

    protected int selectSplitOffset(int i, int i2) {
        Objects.requireNonNull(this.contour);
        int i3 = (i + i2) % this.N;
        Point2D_I32 point2D_I32 = (Point2D_I32) this.contour.get(i);
        Point2D_I32 point2D_I33 = (Point2D_I32) this.contour.get(i3);
        this.line.p.setTo(point2D_I32.x, point2D_I32.y);
        this.line.slope.setTo(point2D_I33.x - point2D_I32.x, point2D_I33.y - point2D_I32.y);
        double dSplitThresholdSq = splitThresholdSq((Point2D_I32) this.contour.get(i), (Point2D_I32) this.contour.get(i3));
        int iMax = Math.max(1, this.minimumSideLengthPixel);
        int i4 = i2 - iMax;
        int i5 = -1;
        while (iMax <= i4) {
            Point2D_I32 point2D_I34 = (Point2D_I32) this.contour.get((i + iMax) % this.N);
            this.point2D.setTo(point2D_I34.x, point2D_I34.y);
            double dDistanceSq = Distance2D_F64.distanceSq(this.line, this.point2D);
            if (dDistanceSq >= dSplitThresholdSq) {
                i5 = iMax;
                dSplitThresholdSq = dDistanceSq;
            }
            iMax++;
        }
        return i5;
    }

    protected int circularDistance(int i, int i2) {
        return i2 >= i ? i2 - i : (this.N - i) + i2;
    }
}
