package com.scanflow.datacapture.barinternal.boofcv.factory.shape;

import com.scanflow.datacapture.barinternal.boofcv.abst.filter.binary.BinaryContourFinderLinearExternal;
import com.scanflow.datacapture.barinternal.boofcv.abst.shapes.polyline.PointsToPolyline;
import com.scanflow.datacapture.barinternal.boofcv.alg.shapes.polygon.DetectPolygonBinaryGrayRefine;
import com.scanflow.datacapture.barinternal.boofcv.alg.shapes.polygon.DetectPolygonFromContour;
import com.scanflow.datacapture.barinternal.boofcv.alg.shapes.polygon.RefinePolygonToContour;
import com.scanflow.datacapture.barinternal.boofcv.alg.shapes.polygon.RefinePolygonToGray;
import com.scanflow.datacapture.barinternal.boofcv.alg.shapes.polygon.RefinePolygonToGrayLine;
import com.scanflow.datacapture.barinternal.boofcv.factory.filter.binary.FactoryBinaryContourFinder;

/* JADX INFO: loaded from: classes.dex */
public abstract class FactoryShapeDetector {
    public static DetectPolygonBinaryGrayRefine polygon(ConfigPolygonDetector configPolygonDetector, Class cls) {
        if (configPolygonDetector == null) {
            configPolygonDetector = new ConfigPolygonDetector();
        }
        configPolygonDetector.checkValidity();
        RefinePolygonToContour refinePolygonToContour = configPolygonDetector.refineContour ? new RefinePolygonToContour() : null;
        ConfigRefinePolygonLineToImage configRefinePolygonLineToImage = configPolygonDetector.refineGray;
        return new DetectPolygonBinaryGrayRefine(polygonContour(configPolygonDetector.detector, cls), refinePolygonToContour, configRefinePolygonLineToImage != null ? refinePolygon(configRefinePolygonLineToImage, cls) : null, configPolygonDetector.minimumRefineEdgeIntensity, configPolygonDetector.adjustForThresholdBias);
    }

    public static DetectPolygonFromContour polygonContour(ConfigPolygonFromContour configPolygonFromContour, Class cls) {
        configPolygonFromContour.checkValidity();
        PointsToPolyline pointsToPolylineCreate = FactoryPointsToPolyline.create(configPolygonFromContour.contourToPoly);
        BinaryContourFinderLinearExternal binaryContourFinderLinearExternalLinearExternal = FactoryBinaryContourFinder.linearExternal();
        binaryContourFinderLinearExternalLinearExternal.setConnectRule(configPolygonFromContour.contourRule);
        binaryContourFinderLinearExternalLinearExternal.setMinContour(configPolygonFromContour.minimumContour);
        binaryContourFinderLinearExternalLinearExternal.setMaxContour(configPolygonFromContour.maximumContour);
        return new DetectPolygonFromContour(pointsToPolylineCreate, configPolygonFromContour.clockwise, configPolygonFromContour.canTouchBorder, configPolygonFromContour.minimumEdgeIntensity, configPolygonFromContour.tangentEdgeIntensity, binaryContourFinderLinearExternalLinearExternal, cls);
    }

    public static RefinePolygonToGray refinePolygon(ConfigRefinePolygonLineToImage configRefinePolygonLineToImage, Class cls) {
        return new RefinePolygonToGrayLine(configRefinePolygonLineToImage.cornerOffset, configRefinePolygonLineToImage.lineSamples, configRefinePolygonLineToImage.sampleRadius, configRefinePolygonLineToImage.maxIterations, configRefinePolygonLineToImage.convergeTolPixels, configRefinePolygonLineToImage.maxCornerChangePixel, cls);
    }
}
