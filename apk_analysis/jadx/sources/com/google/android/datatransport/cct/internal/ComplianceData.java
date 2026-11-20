package com.google.android.datatransport.cct.internal;

import android.util.SparseArray;
import com.google.auto.value.AutoValue;

/* JADX INFO: loaded from: classes.dex */
@AutoValue
public abstract class ComplianceData {

    @AutoValue.Builder
    public static abstract class Builder {
        public abstract ComplianceData build();

        public abstract Builder setPrivacyContext(ExternalPrivacyContext externalPrivacyContext);

        public abstract Builder setProductIdOrigin(ProductIdOrigin productIdOrigin);
    }

    public abstract ExternalPrivacyContext getPrivacyContext();

    public abstract ProductIdOrigin getProductIdOrigin();

    /* JADX WARN: Enum visitor error
    jadx.core.utils.exceptions.JadxRuntimeException: Can't remove SSA var: r0v0 com.google.android.datatransport.cct.internal.ComplianceData$ProductIdOrigin, still in use, count: 1, list:
      (r0v0 com.google.android.datatransport.cct.internal.ComplianceData$ProductIdOrigin) from 0x0022: INVOKE 
      (r3v2 android.util.SparseArray<com.google.android.datatransport.cct.internal.ComplianceData$ProductIdOrigin>)
      (0 int)
      (r0v0 com.google.android.datatransport.cct.internal.ComplianceData$ProductIdOrigin)
     VIRTUAL call: android.util.SparseArray.put(int, java.lang.Object):void A[MD:(int, E):void (c)] (LINE:33)
    	at jadx.core.utils.InsnRemover.removeSsaVar(InsnRemover.java:164)
    	at jadx.core.utils.InsnRemover.unbindResult(InsnRemover.java:129)
    	at jadx.core.utils.InsnRemover.lambda$unbindInsns$1(InsnRemover.java:101)
    	at java.base/java.util.ArrayList.forEach(ArrayList.java:1511)
    	at jadx.core.utils.InsnRemover.unbindInsns(InsnRemover.java:100)
    	at jadx.core.utils.InsnRemover.removeAllAndUnbind(InsnRemover.java:257)
    	at jadx.core.dex.visitors.EnumVisitor.convertToEnum(EnumVisitor.java:187)
    	at jadx.core.dex.visitors.EnumVisitor.visit(EnumVisitor.java:102)
     */
    /* JADX WARN: Failed to restore enum class, 'enum' modifier and super class removed */
    public static final class ProductIdOrigin {
        NOT_SET(0),
        EVENT_OVERRIDE(5);

        private static final SparseArray<ProductIdOrigin> valueMap;
        private final int value;

        public static ProductIdOrigin valueOf(String str) {
            return (ProductIdOrigin) Enum.valueOf(ProductIdOrigin.class, str);
        }

        public static ProductIdOrigin[] values() {
            return (ProductIdOrigin[]) $VALUES.clone();
        }

        static {
            SparseArray<ProductIdOrigin> sparseArray = new SparseArray<>();
            valueMap = sparseArray;
            sparseArray.put(0, new ProductIdOrigin(0));
            sparseArray.put(5, new ProductIdOrigin(5));
        }

        private ProductIdOrigin(int i) {
            super(str, i);
            this.value = i;
        }

        public int getValue() {
            return this.value;
        }

        public static ProductIdOrigin forNumber(int i) {
            return valueMap.get(i);
        }
    }

    public static Builder builder() {
        return new AutoValue_ComplianceData.Builder();
    }
}
