package com.scanflow.datacapture.barinternal.org.ddogleg.nn.alg;

/* JADX INFO: loaded from: classes3.dex */
public class AxisSplitRuleMax implements AxisSplitRule {
    int N;

    @Override // com.scanflow.datacapture.barinternal.org.ddogleg.nn.alg.AxisSplitRule
    public void setDimension(int i) {
        this.N = i;
    }

    @Override // com.scanflow.datacapture.barinternal.org.ddogleg.nn.alg.AxisSplitRule
    public int select(double[] dArr) {
        int i = -1;
        double d = -1.0d;
        for (int i2 = 0; i2 < this.N; i2++) {
            double d2 = dArr[i2];
            if (d2 > d) {
                i = i2;
                d = d2;
            }
        }
        return i;
    }
}
