package io.appmetrica.analytics.impl;

import com.scanflow.datacapture.barinternal.kotlin.collections.CollectionsKt;
import com.scanflow.datacapture.barinternal.kotlin.text.MatchResult;
import com.scanflow.datacapture.barinternal.kotlin.text.Regex;
import com.scanflow.datacapture.barinternal.kotlin.text.StringsKt;
import java.util.Collection;
import java.util.Iterator;
import java.util.List;
import java.util.Locale;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: loaded from: classes3.dex */
public final class O8 implements InterfaceC0712x2 {
    public final int a = 5;
    public final int b = 100;
    public final int c = 255;
    public final int d = 2;
    public final int e = 63;
    public final int f = 1;
    public final int g = 2;
    public final int h = 1;
    public final int i = 64;
    public final Regex j = new Regex("^[a-zA-Z0-9'!#$%&*+-/=?^_`{|}~]+$");
    public final Regex k = new Regex("(?:^|\\.)(?:(ya\\.ru)|(?:yandex)\\.(\\w+|com?\\.\\w+))$");
    public final List l = CollectionsKt.listOf((Object[]) new String[]{"ru", "by", "kz", "az", "kg", "lv", "md", "tj", "tm", "uz", "ee", "fr", "lt", "com", "co.il", "com.ge", "com.am", "com.tr", "com.ru"});
    public final String m = "yandex.ru";
    public final String n = "gmail.com";
    public final String o = "googlemail.com";

    /* JADX WARN: Code duplicated, block: B:103:0x01d8  */
    /* JADX WARN: Code duplicated, block: B:108:0x01e3 A[LOOP:0: B:75:0x0133->B:108:0x01e3, LOOP_END] */
    /* JADX WARN: Code duplicated, block: B:111:0x0143 A[SYNTHETIC] */
    /* JADX WARN: Code duplicated, block: B:113:0x01b8 A[SYNTHETIC] */
    /* JADX WARN: Code duplicated, block: B:115:0x01e7 A[SYNTHETIC] */
    /* JADX WARN: Code duplicated, block: B:116:? A[LOOP:2: B:65:0x010a->B:116:?, LOOP_END, SYNTHETIC] */
    /* JADX WARN: Code duplicated, block: B:56:0x00dd  */
    /* JADX WARN: Code duplicated, block: B:59:0x00f7  */
    /* JADX WARN: Code duplicated, block: B:64:0x0106  */
    /* JADX WARN: Code duplicated, block: B:67:0x0110  */
    /* JADX WARN: Code duplicated, block: B:72:0x012c  */
    /* JADX WARN: Code duplicated, block: B:77:0x0139  */
    /* JADX WARN: Code duplicated, block: B:81:0x0158  */
    /* JADX WARN: Code duplicated, block: B:83:0x016e  */
    /* JADX WARN: Code duplicated, block: B:86:0x0177  */
    /* JADX WARN: Code duplicated, block: B:91:0x0187  */
    /* JADX WARN: Code duplicated, block: B:92:0x0193  */
    /* JADX WARN: Code duplicated, block: B:94:0x019b  */
    /* JADX WARN: Code duplicated, block: B:97:0x01ad  */
    /* JADX WARN: Code duplicated, block: B:99:0x01b5 A[LOOP:1: B:96:0x01ab->B:99:0x01b5, LOOP_END] */
    @Override // io.appmetrica.analytics.impl.InterfaceC0712x2
    public final String a(String str) {
        Character chLastOrNull;
        List listSplit$default;
        List listDropLast;
        Iterator it;
        String str2;
        int i;
        String strReplace$default;
        MatchResult matchResultFind$default;
        int length;
        int i2;
        String str3;
        String str4;
        String lowerCase = new Regex("^\\++").replace(StringsKt.trim(str).toString(), "").toLowerCase(Locale.ROOT);
        int iLastIndexOf$default = StringsKt.lastIndexOf$default((CharSequence) lowerCase, '@', 0, false, 6, (Object) null);
        if (iLastIndexOf$default == -1) {
            return null;
        }
        String strSubstring = lowerCase.substring(0, iLastIndexOf$default);
        String strSubstring2 = lowerCase.substring(iLastIndexOf$default + 1);
        int length2 = strSubstring.length();
        if (length2 >= this.h && length2 <= this.i) {
            List<String> listSplit$default2 = StringsKt.split$default((CharSequence) strSubstring, new char[]{'.'}, false, 0, 6, (Object) null);
            if (!(listSplit$default2 instanceof Collection) || !listSplit$default2.isEmpty()) {
                for (String str5 : listSplit$default2) {
                    int length3 = str5.length();
                    if (length3 >= this.h) {
                        Character chFirstOrNull = StringsKt.firstOrNull(str5);
                        if (chFirstOrNull != null && chFirstOrNull.charValue() == '\"' && (chLastOrNull = StringsKt.lastOrNull(str5)) != null && chLastOrNull.charValue() == '\"' && length3 > 2) {
                            int i3 = 1;
                            while (true) {
                                int i4 = i3 + 2;
                                if (i4 >= str5.length()) {
                                    break;
                                }
                                char cCharAt = str5.charAt(i3);
                                if (cCharAt >= ' ' && cCharAt != '\"' && cCharAt <= '~') {
                                    if (cCharAt == '\\') {
                                        if (i4 != str5.length()) {
                                            i3++;
                                            if (str5.charAt(i3) < ' ') {
                                            }
                                        }
                                    }
                                    i3++;
                                }
                            }
                        } else if (!this.j.matches(str5)) {
                        }
                    }
                }
                if (strSubstring2.length() <= this.c) {
                    listSplit$default = StringsKt.split$default((CharSequence) strSubstring2, new String[]{"."}, false, 0, 6, (Object) null);
                    if (listSplit$default.size() >= this.d) {
                        listDropLast = CollectionsKt.dropLast(listSplit$default, 1);
                        if ((listDropLast instanceof Collection) || !listDropLast.isEmpty()) {
                            it = listDropLast.iterator();
                            while (it.hasNext()) {
                                if (!b((String) it.next())) {
                                }
                            }
                            str2 = (String) CollectionsKt.last(listSplit$default);
                            if (str2.length() >= this.g && b(str2)) {
                                for (i = 0; i < str2.length(); i++) {
                                    if (!Character.isDigit(str2.charAt(i))) {
                                        strReplace$default = StringsKt.replace$default(strSubstring2, this.o, this.n, false, 4, (Object) null);
                                        matchResultFind$default = Regex.find$default(this.k, strReplace$default, 0, 2, null);
                                        if (matchResultFind$default != null) {
                                            List groupValues = matchResultFind$default.getGroupValues();
                                            String str6 = (String) groupValues.get(1);
                                            str4 = (String) groupValues.get(2);
                                            if (str4.length() > 0 ? str6.length() > 0 : this.l.contains(str4)) {
                                            }
                                        }
                                        if (Intrinsics.areEqual(strReplace$default, this.m)) {
                                            strSubstring = StringsKt.replace$default(strSubstring, ".", "-", false, 4, (Object) null);
                                        } else if (Intrinsics.areEqual(strReplace$default, this.n)) {
                                            strSubstring = StringsKt.replace$default(strSubstring, ".", "", false, 4, (Object) null);
                                        }
                                        length = strSubstring.length();
                                        for (i2 = 0; i2 < length; i2++) {
                                            if (strSubstring.charAt(i2) != '+') {
                                                strSubstring = strSubstring.substring(0, i2);
                                                break;
                                            }
                                        }
                                        str3 = strSubstring + '@' + strReplace$default;
                                        if (str3.length() >= this.a || str3.length() > this.b) {
                                            return null;
                                        }
                                        return str3;
                                    }
                                }
                            }
                        } else {
                            str2 = (String) CollectionsKt.last(listSplit$default);
                            if (str2.length() >= this.g) {
                                while (i < str2.length()) {
                                    if (!Character.isDigit(str2.charAt(i))) {
                                        strReplace$default = StringsKt.replace$default(strSubstring2, this.o, this.n, false, 4, (Object) null);
                                        matchResultFind$default = Regex.find$default(this.k, strReplace$default, 0, 2, null);
                                        if (matchResultFind$default != null) {
                                            List groupValues2 = matchResultFind$default.getGroupValues();
                                            String str7 = (String) groupValues2.get(1);
                                            str4 = (String) groupValues2.get(2);
                                            strReplace$default = str4.length() > 0 ? this.m : this.m;
                                        }
                                        if (Intrinsics.areEqual(strReplace$default, this.m)) {
                                            strSubstring = StringsKt.replace$default(strSubstring, ".", "-", false, 4, (Object) null);
                                        } else if (Intrinsics.areEqual(strReplace$default, this.n)) {
                                            strSubstring = StringsKt.replace$default(strSubstring, ".", "", false, 4, (Object) null);
                                        }
                                        length = strSubstring.length();
                                        while (i2 < length) {
                                            if (strSubstring.charAt(i2) != '+') {
                                                strSubstring = strSubstring.substring(0, i2);
                                                break;
                                            }
                                        }
                                        str3 = strSubstring + '@' + strReplace$default;
                                        if (str3.length() >= this.a) {
                                        }
                                        return null;
                                    }
                                }
                            }
                        }
                    }
                }
            } else if (strSubstring2.length() <= this.c) {
                listSplit$default = StringsKt.split$default((CharSequence) strSubstring2, new String[]{"."}, false, 0, 6, (Object) null);
                if (listSplit$default.size() >= this.d) {
                    listDropLast = CollectionsKt.dropLast(listSplit$default, 1);
                    if (listDropLast instanceof Collection) {
                        it = listDropLast.iterator();
                        while (it.hasNext()) {
                            if (!b((String) it.next())) {
                            }
                        }
                        str2 = (String) CollectionsKt.last(listSplit$default);
                        if (str2.length() >= this.g) {
                            while (i < str2.length()) {
                                if (!Character.isDigit(str2.charAt(i))) {
                                    strReplace$default = StringsKt.replace$default(strSubstring2, this.o, this.n, false, 4, (Object) null);
                                    matchResultFind$default = Regex.find$default(this.k, strReplace$default, 0, 2, null);
                                    if (matchResultFind$default != null) {
                                        List groupValues3 = matchResultFind$default.getGroupValues();
                                        String str8 = (String) groupValues3.get(1);
                                        str4 = (String) groupValues3.get(2);
                                        if (str4.length() > 0) {
                                        }
                                    }
                                    if (Intrinsics.areEqual(strReplace$default, this.m)) {
                                        strSubstring = StringsKt.replace$default(strSubstring, ".", "-", false, 4, (Object) null);
                                    } else if (Intrinsics.areEqual(strReplace$default, this.n)) {
                                        strSubstring = StringsKt.replace$default(strSubstring, ".", "", false, 4, (Object) null);
                                    }
                                    length = strSubstring.length();
                                    while (i2 < length) {
                                        if (strSubstring.charAt(i2) != '+') {
                                            strSubstring = strSubstring.substring(0, i2);
                                            break;
                                        }
                                    }
                                    str3 = strSubstring + '@' + strReplace$default;
                                    if (str3.length() >= this.a) {
                                    }
                                    return null;
                                }
                            }
                        }
                    } else {
                        it = listDropLast.iterator();
                        while (it.hasNext()) {
                            if (!b((String) it.next())) {
                            }
                        }
                        str2 = (String) CollectionsKt.last(listSplit$default);
                        if (str2.length() >= this.g) {
                            while (i < str2.length()) {
                                if (!Character.isDigit(str2.charAt(i))) {
                                    strReplace$default = StringsKt.replace$default(strSubstring2, this.o, this.n, false, 4, (Object) null);
                                    matchResultFind$default = Regex.find$default(this.k, strReplace$default, 0, 2, null);
                                    if (matchResultFind$default != null) {
                                        List groupValues4 = matchResultFind$default.getGroupValues();
                                        String str9 = (String) groupValues4.get(1);
                                        str4 = (String) groupValues4.get(2);
                                        if (str4.length() > 0) {
                                        }
                                    }
                                    if (Intrinsics.areEqual(strReplace$default, this.m)) {
                                        strSubstring = StringsKt.replace$default(strSubstring, ".", "-", false, 4, (Object) null);
                                    } else if (Intrinsics.areEqual(strReplace$default, this.n)) {
                                        strSubstring = StringsKt.replace$default(strSubstring, ".", "", false, 4, (Object) null);
                                    }
                                    length = strSubstring.length();
                                    while (i2 < length) {
                                        if (strSubstring.charAt(i2) != '+') {
                                            strSubstring = strSubstring.substring(0, i2);
                                            break;
                                        }
                                    }
                                    str3 = strSubstring + '@' + strReplace$default;
                                    if (str3.length() >= this.a) {
                                    }
                                    return null;
                                }
                            }
                        }
                    }
                }
            }
        }
        return null;
    }

    public final boolean b(String str) {
        if (str.length() > this.e || str.length() < this.f || !Character.isLetterOrDigit(StringsKt.first(str)) || !Character.isLetterOrDigit(StringsKt.last(str))) {
            return false;
        }
        for (int i = 0; i < str.length(); i++) {
            char cCharAt = str.charAt(i);
            if (!Character.isLetterOrDigit(cCharAt) && cCharAt != '-') {
                return false;
            }
        }
        return true;
    }
}
