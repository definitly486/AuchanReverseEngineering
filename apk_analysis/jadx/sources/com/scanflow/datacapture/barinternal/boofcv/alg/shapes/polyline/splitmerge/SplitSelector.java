package com.scanflow.datacapture.barinternal.boofcv.alg.shapes.polyline.splitmerge;

import java.util.List;

/* JADX INFO: loaded from: classes.dex */
public interface SplitSelector {
    int compareScore(double d, double d2);

    void selectSplitPoint(List list, int i, int i2, PolylineSplitMerge.SplitResults splitResults);
}
