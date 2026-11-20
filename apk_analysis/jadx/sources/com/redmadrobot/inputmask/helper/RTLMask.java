package com.redmadrobot.inputmask.helper;

import com.redmadrobot.inputmask.model.CaretString;
import com.redmadrobot.inputmask.model.Notation;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import kotlin.jvm.internal.DefaultConstructorMarker;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: RTLMask.kt */
/* JADX INFO: loaded from: classes3.dex */
public final class RTLMask extends Mask {
    public static final Factory Factory = new Factory(null);
    private static final Map<String, RTLMask> cache = new HashMap();

    /* JADX INFO: compiled from: RTLMask.kt */
    public static final class Factory {
        private Factory() {
        }

        public /* synthetic */ Factory(DefaultConstructorMarker defaultConstructorMarker) {
            this();
        }

        public final RTLMask getOrCreate(String format, List<Notation> customNotations) {
            Intrinsics.checkParameterIsNotNull(format, "format");
            Intrinsics.checkParameterIsNotNull(customNotations, "customNotations");
            RTLMask rTLMask = (RTLMask) RTLMask.cache.get(RTLMaskKt.reversedFormat(format));
            if (rTLMask != null) {
                return rTLMask;
            }
            RTLMask rTLMask2 = new RTLMask(format, customNotations);
            RTLMask.cache.put(RTLMaskKt.reversedFormat(format), rTLMask2);
            return rTLMask2;
        }
    }

    /* JADX WARN: 'super' call moved to the top of the method (can break code semantics) */
    public RTLMask(String format, List<Notation> customNotations) {
        super(RTLMaskKt.reversedFormat(format), customNotations);
        Intrinsics.checkParameterIsNotNull(format, "format");
        Intrinsics.checkParameterIsNotNull(customNotations, "customNotations");
    }

    @Override // com.redmadrobot.inputmask.helper.Mask
    public Mask.Result apply(CaretString text) {
        Intrinsics.checkParameterIsNotNull(text, "text");
        return super.apply(text.reversed()).reversed();
    }

    @Override // com.redmadrobot.inputmask.helper.Mask
    public CaretStringIterator makeIterator(CaretString text) {
        Intrinsics.checkParameterIsNotNull(text, "text");
        return new RTLCaretStringIterator(text);
    }
}
