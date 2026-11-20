package com.scanflow.datacapture.barinternal.org.ejml;

import java.text.DecimalFormat;

/* JADX INFO: loaded from: classes3.dex */
public class FancyPrint {
    DecimalFormat format = new DecimalFormat("#");
    int length = 11;
    int significant = 4;

    public String s(double d) {
        return UtilEjml.fancyString(d, this.format, this.length, this.significant);
    }
}
