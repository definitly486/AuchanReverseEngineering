package com.redmadrobot.inputmask.helper;

import com.redmadrobot.inputmask.model.CaretString;
import com.scanflow.datacapture.barinternal.kotlin.NoWhenBranchMatchedException;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: AffinityCalculationStrategy.kt */
/* JADX INFO: loaded from: classes3.dex */
public enum AffinityCalculationStrategy {
    WHOLE_STRING,
    PREFIX,
    CAPACITY,
    EXTRACTED_VALUE_CAPACITY;

    public final /* synthetic */ class WhenMappings {
        public static final /* synthetic */ int[] $EnumSwitchMapping$0;

        static {
            int[] iArr = new int[AffinityCalculationStrategy.values().length];
            $EnumSwitchMapping$0 = iArr;
            iArr[AffinityCalculationStrategy.WHOLE_STRING.ordinal()] = 1;
            iArr[AffinityCalculationStrategy.PREFIX.ordinal()] = 2;
            iArr[AffinityCalculationStrategy.CAPACITY.ordinal()] = 3;
            iArr[AffinityCalculationStrategy.EXTRACTED_VALUE_CAPACITY.ordinal()] = 4;
        }
    }

    public final int calculateAffinityOfMask(Mask mask, CaretString text) {
        int length;
        int i;
        Intrinsics.checkParameterIsNotNull(mask, "mask");
        Intrinsics.checkParameterIsNotNull(text, "text");
        int i2 = WhenMappings.$EnumSwitchMapping$0[ordinal()];
        if (i2 == 1) {
            return mask.apply(text).getAffinity();
        }
        if (i2 == 2) {
            return prefixIntersection(mask.apply(text).getFormattedText().getString(), text.getString()).length();
        }
        if (i2 != 3) {
            if (i2 == 4) {
                length = mask.apply(text).getExtractedValue().length();
                if (length > mask.totalValueLength()) {
                    return Integer.MIN_VALUE;
                }
                i = mask.totalValueLength();
            } else {
                throw new NoWhenBranchMatchedException();
            }
        } else {
            if (text.getString().length() > mask.totalTextLength()) {
                return Integer.MIN_VALUE;
            }
            length = text.getString().length();
            i = mask.totalTextLength();
        }
        return length - i;
    }

    private final String prefixIntersection(String str, String str2) {
        if (str.length() == 0 || str2.length() == 0) {
            return "";
        }
        int i = 0;
        while (i < str.length() && i < str2.length()) {
            if (str.charAt(i) != str2.charAt(i)) {
                String strSubstring = str.substring(0, i);
                Intrinsics.checkExpressionValueIsNotNull(strSubstring, "(this as java.lang.Strin…ing(startIndex, endIndex)");
                return strSubstring;
            }
            i++;
        }
        String strSubstring2 = str.substring(0, i);
        Intrinsics.checkExpressionValueIsNotNull(strSubstring2, "(this as java.lang.Strin…ing(startIndex, endIndex)");
        return strSubstring2;
    }
}
