package com.scanflow.datacapture.barinternal.boofcv.core.image.border;

import com.scanflow.datacapture.barinternal.boofcv.struct.border.BorderIndex1D;

/* JADX INFO: loaded from: classes.dex */
public class BorderIndex1D_Extend extends BorderIndex1D {
    @Override // com.scanflow.datacapture.barinternal.boofcv.struct.border.BorderIndex1D
    public int getIndex(int i) {
        if (i < 0) {
            return 0;
        }
        int i2 = this.length;
        return i >= i2 ? i2 - 1 : i;
    }
}
