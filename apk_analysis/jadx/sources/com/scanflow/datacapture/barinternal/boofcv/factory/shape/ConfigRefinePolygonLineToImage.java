package com.scanflow.datacapture.barinternal.boofcv.factory.shape;

import java.io.Serializable;

/* JADX INFO: loaded from: classes.dex */
public class ConfigRefinePolygonLineToImage implements Serializable {
    public double cornerOffset = 1.0d;
    public int lineSamples = 30;
    public int sampleRadius = 1;
    public int maxIterations = 10;
    public double convergeTolPixels = 0.2d;
    public double maxCornerChangePixel = 2.0d;

    public String toString() {
        return getClass().getSimpleName() + "{cornerOffset=" + this.cornerOffset + ", lineSamples=" + this.lineSamples + ", sampleRadius=" + this.sampleRadius + ", maxIterations=" + this.maxIterations + ", convergeTolPixels=" + this.convergeTolPixels + ", maxCornerChangePixel=" + this.maxCornerChangePixel + "}";
    }
}
