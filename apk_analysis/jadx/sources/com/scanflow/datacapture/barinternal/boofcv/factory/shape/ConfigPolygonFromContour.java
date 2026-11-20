package com.scanflow.datacapture.barinternal.boofcv.factory.shape;

import com.scanflow.datacapture.barinternal.boofcv.abst.shapes.polyline.BaseConfigPolyline;
import com.scanflow.datacapture.barinternal.boofcv.abst.shapes.polyline.ConfigPolylineSplitMerge;
import com.scanflow.datacapture.barinternal.boofcv.struct.ConfigLength;
import com.scanflow.datacapture.barinternal.boofcv.struct.ConnectRule;
import java.io.Serializable;

/* JADX INFO: loaded from: classes.dex */
public class ConfigPolygonFromContour implements Serializable {
    public boolean canTouchBorder = false;
    public ConnectRule contourRule = ConnectRule.FOUR;
    public BaseConfigPolyline contourToPoly = new ConfigPolylineSplitMerge();
    public double minimumEdgeIntensity = 6.0d;
    public double tangentEdgeIntensity = 2.5d;
    public ConfigLength minimumContour = ConfigLength.relative(0.044d, 4.0d);
    public ConfigLength maximumContour = ConfigLength.fixed(-1.0d);
    public boolean clockwise = true;

    public ConfigPolygonFromContour(int i, int i2) {
        BaseConfigPolyline baseConfigPolyline = this.contourToPoly;
        baseConfigPolyline.minimumSides = i;
        baseConfigPolyline.maximumSides = i2;
    }

    public void checkValidity() {
        this.minimumContour.checkValidity();
        this.maximumContour.checkValidity();
    }

    public String toString() {
        return "ConfigPolygonFromContour{ contourToPoly=" + this.contourToPoly + ", minimumEdgeIntensity=" + this.minimumEdgeIntensity + ", tangentEdgeIntensity=" + this.tangentEdgeIntensity + ", minimumContour=" + this.minimumContour + ", maximumContour=" + this.maximumContour + ", clockwise=" + this.clockwise + "}";
    }
}
