package io.appmetrica.analytics.impl;

import com.scanflow.datacapture.barinternal.kotlin.text.Regex;
import com.scanflow.datacapture.barinternal.kotlin.text.StringsKt;
import java.io.IOException;

/* JADX INFO: loaded from: classes3.dex */
public final class We implements InterfaceC0712x2 {
    public final int a = 10;
    public final int b = 13;
    public final Regex c = new Regex("^[0-9()\\-+\\s]+$");

    @Override // io.appmetrica.analytics.impl.InterfaceC0712x2
    public final String a(String str) throws IOException {
        StringBuilder sb = new StringBuilder();
        int length = str.length();
        for (int i = 0; i < length; i++) {
            char cCharAt = str.charAt(i);
            if (Character.isDigit(cCharAt)) {
                sb.append(cCharAt);
            }
        }
        String string = sb.toString();
        int length2 = string.length();
        Character chFirstOrNull = StringsKt.firstOrNull(str);
        Character chFirstOrNull2 = StringsKt.firstOrNull(string);
        if (length2 < this.a || length2 > this.b || ((chFirstOrNull2 != null && chFirstOrNull2.charValue() == '0') || !this.c.matches(str))) {
            return null;
        }
        if (length2 == 10 && (chFirstOrNull == null || chFirstOrNull.charValue() != '+')) {
            return "7".concat(string);
        }
        if (length2 == 11) {
            if (chFirstOrNull != null && chFirstOrNull.charValue() == '+' && chFirstOrNull2 != null && chFirstOrNull2.charValue() == '8') {
                return null;
            }
            if (chFirstOrNull2 != null && chFirstOrNull2.charValue() == '8') {
                return "7" + string.substring(1);
            }
        }
        if (length2 < 12 || chFirstOrNull == null || chFirstOrNull.charValue() != '+' || chFirstOrNull2 == null || chFirstOrNull2.charValue() != '7') {
            return string;
        }
        return null;
    }
}
