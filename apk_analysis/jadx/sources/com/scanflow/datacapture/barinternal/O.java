package com.scanflow.datacapture.barinternal;

import com.google.mlkit.vision.text.Text;
import java.util.Comparator;

/* JADX INFO: loaded from: classes3.dex */
public final class O implements Comparator {
    @Override // java.util.Comparator
    public final int compare(Object obj, Object obj2) {
        return Float.compare(((Text.TextBlock) obj).getBoundingBox().left, ((Text.TextBlock) obj2).getBoundingBox().left);
    }
}
