package com.scanflow.datacapture.barinternal.boofcv.factory.filter.binary;

import com.scanflow.datacapture.barinternal.boofcv.abst.filter.binary.BinaryContourFinderLinearExternal;

/* JADX INFO: loaded from: classes.dex */
public abstract class FactoryBinaryContourFinder {
    public static BinaryContourFinderLinearExternal linearExternal() {
        return new BinaryContourFinderLinearExternal();
    }
}
