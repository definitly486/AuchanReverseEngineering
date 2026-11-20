package com.scanflow.datacapture.barinternal.boofcv.abst.shapes.polyline;

import com.scanflow.datacapture.barinternal.boofcv.alg.shapes.polyline.RefinePolyLineCorner;
import com.scanflow.datacapture.barinternal.boofcv.alg.shapes.polyline.splitmerge.PolylineSplitMerge;
import com.scanflow.datacapture.barinternal.org.ddogleg.struct.DogArray_I32;
import java.util.List;

/* JADX INFO: loaded from: classes.dex */
public class NewSplitMerge_to_PointsToPolyline implements PointsToPolyline {
    PolylineSplitMerge alg;
    RefinePolyLineCorner refine;

    public NewSplitMerge_to_PointsToPolyline(ConfigPolylineSplitMerge configPolylineSplitMerge) {
        PolylineSplitMerge polylineSplitMerge = new PolylineSplitMerge();
        this.alg = polylineSplitMerge;
        polylineSplitMerge.setMinimumSideLength(configPolylineSplitMerge.minimumSideLength);
        this.alg.setMaxNumberOfSideSamples(configPolylineSplitMerge.maxNumberOfSideSamples);
        this.alg.setMaxSides(configPolylineSplitMerge.maximumSides);
        this.alg.setMinSides(configPolylineSplitMerge.minimumSides);
        this.alg.setExtraConsider(configPolylineSplitMerge.extraConsider);
        this.alg.setConvex(configPolylineSplitMerge.convex);
        this.alg.setThresholdSideSplitScore(configPolylineSplitMerge.thresholdSideSplitScore);
        this.alg.setCornerScorePenalty(configPolylineSplitMerge.cornerScorePenalty);
        this.alg.setConvexTest(configPolylineSplitMerge.convexTest);
        this.alg.setMaxSideError(configPolylineSplitMerge.maxSideError);
        this.alg.setLoops(configPolylineSplitMerge.loops);
        int i = configPolylineSplitMerge.refineIterations;
        if (i > 0) {
            this.refine = new RefinePolyLineCorner(configPolylineSplitMerge.loops, i);
        }
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.abst.shapes.polyline.PointsToPolyline
    public boolean process(List list, DogArray_I32 dogArray_I32) {
        PolylineSplitMerge.CandidatePolyline bestPolyline;
        if (!this.alg.process(list) || (bestPolyline = this.alg.getBestPolyline()) == null) {
            return false;
        }
        dogArray_I32.setTo(bestPolyline.splits);
        RefinePolyLineCorner refinePolyLineCorner = this.refine;
        return refinePolyLineCorner == null || refinePolyLineCorner.fit(list, dogArray_I32);
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.abst.shapes.polyline.PointsToPolyline
    public void setMinimumSides(int i) {
        this.alg.setMinSides(i);
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.abst.shapes.polyline.PointsToPolyline
    public int getMinimumSides() {
        return this.alg.getMinSides();
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.abst.shapes.polyline.PointsToPolyline
    public void setMaximumSides(int i) {
        this.alg.setMaxSides(i);
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.abst.shapes.polyline.PointsToPolyline
    public boolean isLoop() {
        return this.alg.isLoops();
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.abst.shapes.polyline.PointsToPolyline
    public void setConvex(boolean z) {
        this.alg.setConvex(z);
    }
}
