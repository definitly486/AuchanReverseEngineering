package com.scanflow.datacapture.barinternal.boofcv.factory.fiducial;

import com.scanflow.datacapture.barinternal.boofcv.abst.shapes.polyline.BaseConfigPolyline;
import com.scanflow.datacapture.barinternal.boofcv.abst.shapes.polyline.ConfigPolylineSplitMerge;
import com.scanflow.datacapture.barinternal.boofcv.factory.filter.binary.ConfigThreshold;
import com.scanflow.datacapture.barinternal.boofcv.factory.filter.binary.ConfigThresholdLocalOtsu;
import com.scanflow.datacapture.barinternal.boofcv.factory.filter.binary.ThresholdType;
import com.scanflow.datacapture.barinternal.boofcv.factory.shape.ConfigPolygonDetector;
import com.scanflow.datacapture.barinternal.boofcv.factory.shape.ConfigPolygonFromContour;
import com.scanflow.datacapture.barinternal.boofcv.struct.ConfigLength;
import com.scanflow.datacapture.barinternal.boofcv.struct.ConnectRule;
import java.io.Serializable;

/* JADX INFO: loaded from: classes.dex */
public class ConfigQrCode implements Serializable {
    public ConfigThreshold threshold;
    public ConfigPolygonDetector polygon = new ConfigPolygonDetector();
    public int versionMinimum = 1;
    public int versionMaximum = 40;
    public String forceEncoding = null;
    public String defaultEncoding = "ISO8859_1";
    public boolean considerTransposed = true;
    public boolean ignorePaddingBytes = true;

    public ConfigQrCode() {
        ConfigThresholdLocalOtsu configThresholdLocalOtsu = (ConfigThresholdLocalOtsu) ConfigThreshold.local(ThresholdType.BLOCK_OTSU, 40);
        configThresholdLocalOtsu.useOtsu2 = true;
        configThresholdLocalOtsu.scale = 1.0d;
        configThresholdLocalOtsu.thresholdFromLocalBlocks = true;
        configThresholdLocalOtsu.tuning = 4.0d;
        this.threshold = configThresholdLocalOtsu;
        ConfigPolygonFromContour configPolygonFromContour = this.polygon.detector;
        configPolygonFromContour.contourRule = ConnectRule.EIGHT;
        configPolygonFromContour.clockwise = false;
        ((ConfigPolylineSplitMerge) configPolygonFromContour.contourToPoly).maxSideError = ConfigLength.relative(0.12d, 3.0d);
        ConfigPolygonFromContour configPolygonFromContour2 = this.polygon.detector;
        BaseConfigPolyline baseConfigPolyline = configPolygonFromContour2.contourToPoly;
        ((ConfigPolylineSplitMerge) baseConfigPolyline).cornerScorePenalty = 0.4d;
        ((ConfigPolylineSplitMerge) baseConfigPolyline).minimumSideLength = 2;
        configPolygonFromContour2.minimumContour = ConfigLength.fixed(40.0d);
        ConfigPolygonDetector configPolygonDetector = this.polygon;
        ConfigPolygonFromContour configPolygonFromContour3 = configPolygonDetector.detector;
        configPolygonFromContour3.minimumEdgeIntensity = 3.0d;
        configPolygonDetector.minimumRefineEdgeIntensity = 6.0d;
        configPolygonFromContour3.tangentEdgeIntensity = 1.5d;
    }

    public void checkValidity() {
        this.threshold.checkValidity();
        this.polygon.checkValidity();
    }
}
