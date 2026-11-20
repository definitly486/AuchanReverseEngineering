package com.scanflow.datacapture.barinternal.boofcv.factory.shape;

import com.scanflow.datacapture.barinternal.boofcv.abst.shapes.polyline.BaseConfigPolyline;
import com.scanflow.datacapture.barinternal.boofcv.struct.ConfigLength;

/* JADX INFO: loaded from: classes.dex */
public class ConfigSplitMergeLineFit extends BaseConfigPolyline {
    public double splitFraction = 0.05d;
    public int iterations = 10;
    public int refine = 20;
    public double pruneSplitPenalty = 2.0d;
    public ConfigLength minimumSide = ConfigLength.relative(0.025d, 10.0d);
    public boolean loop = true;

    public void checkValidity() {
        this.minimumSide.checkValidity();
    }

    public String toString() {
        return "ConfigSplitMergeLineFit{splitFraction=" + this.splitFraction + ", iterations=" + this.iterations + ", minimumSide=" + this.minimumSide + ", loop=" + this.loop + "}";
    }
}
