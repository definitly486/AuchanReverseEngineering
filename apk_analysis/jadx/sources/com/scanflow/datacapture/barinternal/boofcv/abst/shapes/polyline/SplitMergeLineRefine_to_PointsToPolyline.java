package com.scanflow.datacapture.barinternal.boofcv.abst.shapes.polyline;

import com.scanflow.datacapture.barinternal.boofcv.alg.shapes.polyline.MinimizeEnergyPrune;
import com.scanflow.datacapture.barinternal.boofcv.alg.shapes.polyline.RefinePolyLineCorner;
import com.scanflow.datacapture.barinternal.boofcv.alg.shapes.polyline.splitmerge.SplitMergeLineFit;
import com.scanflow.datacapture.barinternal.boofcv.alg.shapes.polyline.splitmerge.SplitMergeLineFitLoop;
import com.scanflow.datacapture.barinternal.boofcv.alg.shapes.polyline.splitmerge.SplitMergeLineFitSegment;
import com.scanflow.datacapture.barinternal.boofcv.factory.shape.ConfigSplitMergeLineFit;
import com.scanflow.datacapture.barinternal.boofcv.struct.ConfigLength;
import com.scanflow.datacapture.barinternal.georegression.geometry.UtilPolygons2D_F64;
import com.scanflow.datacapture.barinternal.georegression.struct.point.Point2D_I32;
import com.scanflow.datacapture.barinternal.georegression.struct.shapes.Polygon2D_F64;
import com.scanflow.datacapture.barinternal.org.ddogleg.struct.DogArray_I32;
import java.util.List;

/* JADX INFO: loaded from: classes.dex */
public class SplitMergeLineRefine_to_PointsToPolyline implements PointsToPolyline {
    boolean convex;
    int maxVertexes;
    int minVertexes;
    private MinimizeEnergyPrune pruner;
    RefinePolyLineCorner refine;
    SplitMergeLineFit splitMerge;
    private final DogArray_I32 pruned = new DogArray_I32();
    Polygon2D_F64 tmp = new Polygon2D_F64();

    public SplitMergeLineRefine_to_PointsToPolyline(ConfigSplitMergeLineFit configSplitMergeLineFit) {
        this.maxVertexes = Integer.MAX_VALUE;
        this.minVertexes = 3;
        this.convex = true;
        ConfigLength configLengthCopy = configSplitMergeLineFit.minimumSide.copy();
        if (configSplitMergeLineFit.loop) {
            this.splitMerge = new SplitMergeLineFitLoop(configSplitMergeLineFit.splitFraction, configLengthCopy, configSplitMergeLineFit.iterations);
        } else {
            this.splitMerge = new SplitMergeLineFitSegment(configSplitMergeLineFit.splitFraction, configLengthCopy, configSplitMergeLineFit.iterations);
        }
        int i = configSplitMergeLineFit.refine;
        if (i > 0) {
            this.refine = new RefinePolyLineCorner(configSplitMergeLineFit.loop, i);
        }
        double d = configSplitMergeLineFit.pruneSplitPenalty;
        if (d > 0.0d) {
            this.pruner = new MinimizeEnergyPrune(d);
        }
        this.convex = configSplitMergeLineFit.convex;
        this.minVertexes = configSplitMergeLineFit.minimumSides;
        this.maxVertexes = configSplitMergeLineFit.maximumSides;
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.abst.shapes.polyline.PointsToPolyline
    public boolean process(List list, DogArray_I32 dogArray_I32) {
        if (!this.splitMerge.process(list, dogArray_I32)) {
            return false;
        }
        RefinePolyLineCorner refinePolyLineCorner = this.refine;
        if (refinePolyLineCorner != null && !refinePolyLineCorner.fit(list, dogArray_I32)) {
            return false;
        }
        MinimizeEnergyPrune minimizeEnergyPrune = this.pruner;
        if (minimizeEnergyPrune != null && minimizeEnergyPrune.prune(list, dogArray_I32, this.pruned)) {
            dogArray_I32.setTo(this.pruned);
        }
        int i = dogArray_I32.size;
        if (i > this.maxVertexes || i < this.minVertexes) {
            return false;
        }
        this.tmp.vertexes.resize(i);
        for (int i2 = 0; i2 < dogArray_I32.size; i2++) {
            Point2D_I32 point2D_I32 = (Point2D_I32) list.get(dogArray_I32.get(i2));
            this.tmp.set(i2, point2D_I32.x, point2D_I32.y);
        }
        return !this.convex || UtilPolygons2D_F64.isConvex(this.tmp);
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.abst.shapes.polyline.PointsToPolyline
    public void setMinimumSides(int i) {
        this.minVertexes = i;
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.abst.shapes.polyline.PointsToPolyline
    public int getMinimumSides() {
        return this.minVertexes;
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.abst.shapes.polyline.PointsToPolyline
    public void setMaximumSides(int i) {
        this.maxVertexes = i;
        this.splitMerge.setAbortSplits(i * 2);
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.abst.shapes.polyline.PointsToPolyline
    public boolean isLoop() {
        return this.splitMerge instanceof SplitMergeLineFitLoop;
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.abst.shapes.polyline.PointsToPolyline
    public void setConvex(boolean z) {
        this.convex = z;
    }
}
