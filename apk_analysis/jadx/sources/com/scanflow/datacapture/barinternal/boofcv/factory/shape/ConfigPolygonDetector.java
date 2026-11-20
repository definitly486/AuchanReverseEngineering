package com.scanflow.datacapture.barinternal.boofcv.factory.shape;

import java.io.Serializable;

/* JADX INFO: loaded from: classes.dex */
public class ConfigPolygonDetector implements Serializable {
    public ConfigPolygonFromContour detector = new ConfigPolygonFromContour(3, 10000);
    public double minimumRefineEdgeIntensity = 6.0d;
    public boolean refineContour = false;
    public boolean adjustForThresholdBias = true;
    public ConfigRefinePolygonLineToImage refineGray = new ConfigRefinePolygonLineToImage();

    public void checkValidity() {
    }

    public String toString() {
        return "ConfigPolygonDetector{detector=" + this.detector + ", minimumEdgeIntensity=" + this.minimumRefineEdgeIntensity + ", refineContour=" + this.refineContour + ", refineGray=" + this.refineGray + "}";
    }
}
