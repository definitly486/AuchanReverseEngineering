package com.scanflow.datacapture.barinternal.boofcv.alg.descriptor;

import android.R;

/* JADX INFO: loaded from: classes.dex */
public abstract class DescriptorDistance {
    public static int hamming(int i) {
        int i2 = i - ((i >> 1) & 1431655765);
        int i3 = (i2 & 858993459) + ((i2 >> 2) & 858993459);
        return ((252645135 & (i3 + (i3 >> 4))) * R.attr.cacheColorHint) >> 24;
    }
}
