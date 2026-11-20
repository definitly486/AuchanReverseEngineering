package com.google.android.datatransport;

import com.google.auto.value.AutoValue;

/* JADX INFO: loaded from: classes.dex */
@AutoValue
public abstract class ProductData {
    public abstract Integer getProductId();

    public static ProductData withProductId(Integer num) {
        return new AutoValue_ProductData(num);
    }
}
