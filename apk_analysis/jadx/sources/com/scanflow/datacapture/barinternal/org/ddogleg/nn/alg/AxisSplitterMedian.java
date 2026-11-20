package com.scanflow.datacapture.barinternal.org.ddogleg.nn.alg;

import com.scanflow.datacapture.barinternal.org.ddogleg.sorting.QuickSelect;
import com.scanflow.datacapture.barinternal.org.ddogleg.struct.DogArray_I32;
import java.util.List;
import java.util.Objects;

/* JADX INFO: loaded from: classes3.dex */
public class AxisSplitterMedian implements AxisSplitter {
    private final int N;
    KdTreeDistance distance;
    private int[] indexes;
    private final double[] mean;
    int splitAxis;
    int splitIndex;
    Object splitPoint;
    AxisSplitRule splitRule;
    private double[] tmp;
    private final double[] var;

    public AxisSplitterMedian(KdTreeDistance kdTreeDistance, AxisSplitRule axisSplitRule) {
        this.tmp = new double[1];
        this.indexes = new int[1];
        this.distance = kdTreeDistance;
        this.splitRule = axisSplitRule;
        int length = kdTreeDistance.length();
        this.N = length;
        this.mean = new double[length];
        this.var = new double[length];
        axisSplitRule.setDimension(length);
    }

    public AxisSplitterMedian(KdTreeDistance kdTreeDistance) {
        this(kdTreeDistance, new AxisSplitRuleMax());
    }

    @Override // com.scanflow.datacapture.barinternal.org.ddogleg.nn.alg.AxisSplitter
    public void splitData(List list, DogArray_I32 dogArray_I32, List list2, DogArray_I32 dogArray_I33, List list3, DogArray_I32 dogArray_I34) {
        computeAxisVariance(list);
        int i = 0;
        for (int i2 = 0; i2 < this.N; i2++) {
            if (Double.isNaN(this.var[i2])) {
                throw new RuntimeException("Variance is NaN.  Bad input is the cause. mean[i]=" + this.mean[i2] + " i=" + i2 + " points.size=" + list.size());
            }
        }
        this.splitAxis = this.splitRule.select(this.var);
        int size = list.size() / 2;
        quickSelect(list, this.splitAxis, size);
        this.splitPoint = list.get(this.indexes[size]);
        if (dogArray_I32 != null) {
            Objects.requireNonNull(dogArray_I33);
            Objects.requireNonNull(dogArray_I34);
            dogArray_I33.reset();
            dogArray_I34.reset();
            while (i < size) {
                int i3 = this.indexes[i];
                list2.add(list.get(i3));
                dogArray_I33.add(dogArray_I32.get(i3));
                i++;
            }
            for (int i4 = size + 1; i4 < list.size(); i4++) {
                int i5 = this.indexes[i4];
                list3.add(list.get(i5));
                dogArray_I34.add(dogArray_I32.get(i5));
            }
            this.splitIndex = dogArray_I32.get(this.indexes[size]);
            return;
        }
        while (i < size) {
            list2.add(list.get(this.indexes[i]));
            i++;
        }
        while (true) {
            size++;
            if (size >= list.size()) {
                return;
            } else {
                list3.add(list.get(this.indexes[size]));
            }
        }
    }

    @Override // com.scanflow.datacapture.barinternal.org.ddogleg.nn.alg.AxisSplitter
    public Object getSplitPoint() {
        return this.splitPoint;
    }

    @Override // com.scanflow.datacapture.barinternal.org.ddogleg.nn.alg.AxisSplitter
    public int getSplitIndex() {
        return this.splitIndex;
    }

    @Override // com.scanflow.datacapture.barinternal.org.ddogleg.nn.alg.AxisSplitter
    public int getSplitAxis() {
        return this.splitAxis;
    }

    @Override // com.scanflow.datacapture.barinternal.org.ddogleg.nn.alg.AxisSplitter
    public int getPointLength() {
        return this.N;
    }

    private void computeAxisVariance(List list) {
        int size = list.size();
        for (int i = 0; i < this.N; i++) {
            this.mean[i] = 0.0d;
            this.var[i] = 0.0d;
        }
        for (int i2 = 0; i2 < size; i2++) {
            Object obj = list.get(i2);
            for (int i3 = 0; i3 < this.N; i3++) {
                double[] dArr = this.mean;
                dArr[i3] = dArr[i3] + this.distance.valueAt(obj, i3);
            }
        }
        for (int i4 = 0; i4 < this.N; i4++) {
            double[] dArr2 = this.mean;
            dArr2[i4] = dArr2[i4] / ((double) size);
        }
        for (int i5 = 0; i5 < size; i5++) {
            Object obj2 = list.get(i5);
            for (int i6 = 0; i6 < this.N; i6++) {
                double dValueAt = this.mean[i6] - this.distance.valueAt(obj2, i6);
                double[] dArr3 = this.var;
                dArr3[i6] = dArr3[i6] + (dValueAt * dValueAt);
            }
        }
    }

    private void quickSelect(List list, int i, int i2) {
        int size = list.size();
        if (this.tmp.length < size) {
            this.tmp = new double[size];
            this.indexes = new int[size];
        }
        for (int i3 = 0; i3 < size; i3++) {
            this.tmp[i3] = this.distance.valueAt(list.get(i3), i);
        }
        QuickSelect.selectIndex(this.tmp, i2, size, this.indexes);
    }
}
