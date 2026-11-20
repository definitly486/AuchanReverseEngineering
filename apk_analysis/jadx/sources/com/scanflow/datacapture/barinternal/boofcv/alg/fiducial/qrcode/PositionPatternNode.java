package com.scanflow.datacapture.barinternal.boofcv.alg.fiducial.qrcode;

import com.scanflow.datacapture.barinternal.boofcv.alg.fiducial.calib.squares.SquareNode;

/* JADX INFO: loaded from: classes.dex */
public class PositionPatternNode extends SquareNode {
    public double grayThreshold;

    @Override // com.scanflow.datacapture.barinternal.boofcv.alg.fiducial.calib.squares.SquareNode
    public void reset() {
        super.reset();
        this.grayThreshold = -1.0d;
    }
}
