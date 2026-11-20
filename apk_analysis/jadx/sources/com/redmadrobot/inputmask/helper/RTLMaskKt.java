package com.redmadrobot.inputmask.helper;

import com.scanflow.datacapture.barinternal.kotlin.TypeCastException;
import com.scanflow.datacapture.barinternal.kotlin.collections.CollectionsKt;
import com.scanflow.datacapture.barinternal.kotlin.text.StringsKt;
import java.util.ArrayList;

/* JADX INFO: compiled from: RTLMask.kt */
/* JADX INFO: loaded from: classes3.dex */
public final class RTLMaskKt {
    /* JADX INFO: Access modifiers changed from: private */
    /* JADX WARN: Code duplicated, block: B:13:0x0055 A[PHI: r4
      0x0055: PHI (r4v3 char) = (r4v2 char), (r4v4 char) binds: [B:8:0x004a, B:11:0x0052] A[DONT_GENERATE, DONT_INLINE]] */
    /* JADX WARN: Code duplicated, block: B:14:0x0057 A[PHI: r3
      0x0057: PHI (r3v3 char) = (r3v2 char), (r3v4 char) binds: [B:7:0x0048, B:10:0x0050] A[DONT_GENERATE, DONT_INLINE]] */
    public static final String reversedFormat(String str) {
        if (str == null) {
            throw new TypeCastException("null cannot be cast to non-null type kotlin.CharSequence");
        }
        String strReplace$default = StringsKt.replace$default(StringsKt.replace$default(StringsKt.replace$default(StringsKt.replace$default(StringsKt.reversed(str).toString(), "[\\", "\\]", false, 4, (Object) null), "]\\", "\\[", false, 4, (Object) null), "{\\", "\\}", false, 4, (Object) null), "}\\", "\\{", false, 4, (Object) null);
        ArrayList arrayList = new ArrayList(strReplace$default.length());
        for (int i = 0; i < strReplace$default.length(); i++) {
            char cCharAt = strReplace$default.charAt(i);
            char c = ']';
            char c2 = '[';
            if (cCharAt == '[') {
                cCharAt = c;
            } else if (cCharAt != ']') {
                c = '}';
                c2 = '{';
                if (cCharAt == '{') {
                    cCharAt = c;
                } else if (cCharAt == '}') {
                    cCharAt = c2;
                }
            } else {
                cCharAt = c2;
            }
            arrayList.add(Character.valueOf(cCharAt));
        }
        return CollectionsKt.joinToString$default(arrayList, "", null, null, 0, null, null, 62, null);
    }
}
