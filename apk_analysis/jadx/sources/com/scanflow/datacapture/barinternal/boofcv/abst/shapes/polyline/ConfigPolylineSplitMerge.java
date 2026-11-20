package com.scanflow.datacapture.barinternal.boofcv.abst.shapes.polyline;

import com.scanflow.datacapture.barinternal.boofcv.struct.ConfigLength;

/* JADX INFO: loaded from: classes.dex */
public class ConfigPolylineSplitMerge extends BaseConfigPolyline {
    public int minimumSideLength = 2;
    public ConfigLength extraConsider = ConfigLength.relative(1.0d, 0.0d);
    public double cornerScorePenalty = 0.025d;
    public double thresholdSideSplitScore = 0.2d;
    public int maxNumberOfSideSamples = 50;
    public double convexTest = 2.5d;
    public ConfigLength maxSideError = ConfigLength.relative(0.05d, 3.0d);
    public int refineIterations = 10;

    public void checkValidity() {
        this.extraConsider.checkValidity();
    }

    public String toString() {
        return "ConfigPolylineSplitMerge{minimumSideLength=" + this.minimumSideLength + ", extraConsider=" + this.extraConsider + ", cornerScorePenalty=" + this.cornerScorePenalty + ", thresholdSideSplitScore=" + this.thresholdSideSplitScore + ", maxNumberOfSideSamples=" + this.maxNumberOfSideSamples + ", convexTest=" + this.convexTest + ", maxSideError=" + this.maxSideError + ", refineIterations=" + this.refineIterations + ", loops=" + this.loops + ", minimumSides=" + this.minimumSides + ", maximumSides=" + this.maximumSides + ", convex=" + this.convex + "}";
    }
}
