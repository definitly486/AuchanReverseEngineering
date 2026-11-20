package com.scanflow.datacapture.barinternal.boofcv.factory.shape;

import com.scanflow.datacapture.barinternal.boofcv.abst.shapes.polyline.BaseConfigPolyline;
import com.scanflow.datacapture.barinternal.boofcv.abst.shapes.polyline.ConfigPolylineSplitMerge;
import com.scanflow.datacapture.barinternal.boofcv.abst.shapes.polyline.NewSplitMerge_to_PointsToPolyline;
import com.scanflow.datacapture.barinternal.boofcv.abst.shapes.polyline.PointsToPolyline;
import com.scanflow.datacapture.barinternal.boofcv.abst.shapes.polyline.SplitMergeLineRefine_to_PointsToPolyline;

/* JADX INFO: loaded from: classes.dex */
public abstract class FactoryPointsToPolyline {
    public static PointsToPolyline create(BaseConfigPolyline baseConfigPolyline) {
        if (baseConfigPolyline instanceof ConfigSplitMergeLineFit) {
            return splitMerge((ConfigSplitMergeLineFit) baseConfigPolyline);
        }
        if (baseConfigPolyline instanceof ConfigPolylineSplitMerge) {
            return splitMerge((ConfigPolylineSplitMerge) baseConfigPolyline);
        }
        throw new RuntimeException("Unknown");
    }

    public static PointsToPolyline splitMerge(ConfigSplitMergeLineFit configSplitMergeLineFit) {
        if (configSplitMergeLineFit == null) {
            configSplitMergeLineFit = new ConfigSplitMergeLineFit();
        }
        configSplitMergeLineFit.checkValidity();
        return new SplitMergeLineRefine_to_PointsToPolyline(configSplitMergeLineFit);
    }

    public static PointsToPolyline splitMerge(ConfigPolylineSplitMerge configPolylineSplitMerge) {
        if (configPolylineSplitMerge == null) {
            configPolylineSplitMerge = new ConfigPolylineSplitMerge();
        }
        configPolylineSplitMerge.checkValidity();
        return new NewSplitMerge_to_PointsToPolyline(configPolylineSplitMerge);
    }
}
